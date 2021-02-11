using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework;
using RestSharp;
using RestSharp.Serialization.Json;
using System.Threading;
using EcommerceBackend.models.Users;
using Newtonsoft.Json;
using System.IO;
using EcommerceBackend.models.Discount;
using EcommerceBackend.models.Bookings.ShowTimes;
using Newtonsoft.Json.Linq;

namespace EcommerceBackend.utils
{
    public static class Utils
    {
        public static bool IsNullOrEmptyJToken(this JToken token)
        {
            return (token == null) ||
                   (token.Type == JTokenType.Array && !token.HasValues) ||
                   (token.Type == JTokenType.Object && !token.HasValues) ||
                   (token.Type == JTokenType.String && token.ToString() == String.Empty) ||
                   (token.Type == JTokenType.Null);
        }

        public static string VerificaSessaoValida(int theaterId)
        {
            if (theaterId < 0)
            {
                throw new ArgumentOutOfRangeException("Codigo do cinema invalido");
            }

            var client = new RestClient(ConfigurationManager.AppSettings["dnsSensedia"]);
            var request = new RestRequest("bus/v1/bookings/showtimes/theaters/" + theaterId, Method.GET);
            request.RequestFormat = DataFormat.Json;
            Utils.setCisToken(request);
            var response = client.Get<List<ModelTheatersShowTimes>>(request);

            string show_time_id = "";
            int dt = response.Data[0].Theaters[0].Dates.Count;
            
            for (int j = 0; j < dt; j++)
            {
                for (int i = 0; i < j; i++)
                {
                    var session_id = response.Data[0].Theaters[0].Dates[j].ShowTimes[i];
                    if (!session_id.IsSessionExpired)
                    {
                        show_time_id = session_id.ShowTimeId;
                        
                        break;
                    }

                }

            }
            return show_time_id;

        }




         
        public static int VerificaCinemaFlagsAllTrue(int theaterId)
        {
            /*
             *  public enum RuleType : int
                {
                    QRCode = 1,
                    Coupon = 2
                }
 
                public enum ProductType : int
                {
                    Ticket = 1,
                    Snack = 2
                }
            */


            if (!(theaterId > 0 ))
            {
                throw new ArgumentException("theaterId nao é valido");
            }

            //Atualizar para receber massa do txt
            string cinema_qr_code = "b6a41a1c-c89d-4428-a320-2a2eeb1b2145";

            var client = new RestClient(ConfigurationManager.AppSettings["dnsSensedia"]);
            var request = new RestRequest("/discount/validate/" + cinema_qr_code, Method.GET);
            request.RequestFormat = DataFormat.Json;
            utils.Utils.setCisToken(request);
            
            try
            {
                var response = client.Execute<ModelDiscountValidate>(request);

                Assert.That((int)response.StatusCode, Is.EqualTo(200),
                    "Status Code diferente do esperado ao realizar requisição responsável validar desconto lobby");
                Assert.That(response.Data.IsCodeValid, Is.EqualTo(true),
                    "QR Code invalido!");
                Assert.That(response.Data.TheaterId, Is.EqualTo(theaterId),
                    "QR CODE informado na request nao é o codigo correto que vem do response: " + theaterId);
                Assert.IsTrue(response.Data.RuleType > 0, response.Data.Message);
                //Caso ruleType seja 0 ou menor, retorna a propria mensagem de erro do response

                if (response.Data.RuleType > 0)
                {
                    Assert.IsTrue(response.Data.enabledTypes[0] == 1, "Nao habilitado para ingresso");
                    Assert.IsTrue(response.Data.enabledTypes[1] == 2, "Nao habilitado para snack");
                }
                DateTime localDate = DateTime.Now;
                Assert.IsTrue(response.Data.ValidUntil > localDate, "Codigo expirado");


            }
            catch (Exception e)
                {
                    throw new Exception("Cinema invalido, atualizar a massa!" + e);
                }

            return theaterId;


        }

        public static double IsNullDouble(System.Object d)
        {
            return (d != null && d is double) ? (double)d : 0;
        }




        public static string RetornaStringJson(string jsonFilePath)
        {
            if (string.IsNullOrEmpty(jsonFilePath))
            {
                throw new Exception("Caminho/Path invalido");
            }
            string jsonContent = File.ReadAllText(jsonFilePath);
            return jsonContent;
        }


        public static RestRequest setCisToken(RestRequest request)
        {
            request.AddHeader("X-CISIdentity", ConfigurationManager.AppSettings["CISToken"]);
            return request;
        }


        public static RestRequest setCisTokenDEV(RestRequest request)
        {
            request.AddHeader("X-CISIdentity", ConfigurationManager.AppSettings["CISTokenDEV"]);
            return request;
        }

        public static string getAuthorization(string Email, string Password)
        {
            var client = new RestClient(ConfigurationManager.AppSettings["dnsSensedia"]);
            var request = new RestRequest("bus/v1/users/login/byapp", Method.POST);
            request.RequestFormat = DataFormat.Json;
            request.AddJsonBody(new ModelUsers() { Email = Email, Password = Password });
            utils.Utils.setCisToken(request);
            var response = client.Execute<ModelUsers>(request);
            Assert.That((int)response.StatusCode, Is.EqualTo(200), "Erro ao tentar coletar o token 'Authorization'.");
            string authorizationToken = response.Headers.ToList()
                             .Find(x => x.Name == "authorization")
                             .Value.ToString();
            return authorizationToken;
        }

        public static RestRequest setAuthorizationToken(RestRequest request, string authorizationToken)
        {
            request.AddHeader("Authorization", authorizationToken);
            return request;
        }

        public static string gerarEmailAleatorio(int qtdCaracteres)
        {
            var chars = "abcdefghijklmnopqrstuvxz0123456789";
            var random = new Random();
            var result = new string(
                Enumerable.Repeat(chars, qtdCaracteres)
                          .Select(s => s[random.Next(s.Length)])
                          .ToArray());
            return result + "@mailinator.com";
        }

        public static String gerarCpf()
        {
            int soma = 0, resto = 0;
            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

            Random rnd = new Random();
            string semente = rnd.Next(100000000, 999999999).ToString();

            for (int i = 0; i < 9; i++)
                soma += int.Parse(semente[i].ToString()) * multiplicador1[i];

            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            semente = semente + resto;
            soma = 0;

            for (int i = 0; i < 10; i++)
                soma += int.Parse(semente[i].ToString()) * multiplicador2[i];

            resto = soma % 11;

            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            semente = semente + resto;

            Thread.Sleep(1000);

            return semente;
        }

        public static void validaContrato(string[] properties, string responseContent, ExtentTest test)
        {
            test.Log(Status.Info, "Inicío da validação de contrato.");
            for (int i = 0; i < properties.Length; i++)
            {
                var isPropertyInResponse = responseContent.Contains(properties[i]);
                if (isPropertyInResponse != true)
                {
                    Assert.That(isPropertyInResponse, Is.EqualTo(true), "Propriedade: " + properties[i] + " não existente na resposta da requisição.");
                }
                test.Log(Status.Info, "Propriedade: " + properties[i] + " presente na resposta do serviço.");
            }
        }

    }
}
