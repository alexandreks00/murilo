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

namespace EcommerceBackend.utils
{
    public static class Utils


    {
        public static int VerificaCinemaFlagsAllTrue(int theaterId)
        {
            if (!(theaterId > 0 ))
            {
                throw new ArgumentException("theaterId nao é valido");
            }

            //Atualizar para receber massa do txt
            string cinema_salvador = "b6a41a1c-c89d-4428-a320-2a2eeb1b2145";

            try
            {
                var client = new RestClient(ConfigurationManager.AppSettings["dnsSensedia"]);
                var request = new RestRequest("/discount/validate/" + cinema_salvador, Method.GET);
                request.RequestFormat = DataFormat.Json;
                utils.Utils.setCisToken(request);

                var response = client.Execute<ModelDiscountValidate>(request);
                Assert.That((int)response.StatusCode, Is.EqualTo(200),
                    "Status Code diferente do esperado ao realizar requisição responsável validar desconto lobby");
                Assert.That(response.Data.IsCodeValid, Is.EqualTo(true),
                    "QR Code invalido!");
                Assert.That(response.Data.TheaterId, Is.EqualTo(theaterId),
                    "QR CODE informado na request nao é o codigo correto que vem do response: " + theaterId);
                Assert.IsTrue(response.Data.RuleType > 0, "Propriedade ruleType invalido");
                Assert.IsTrue(response.Data.EnabledTypes[0] == 1, "Nao habilitado para ingresso");
                Assert.IsTrue(response.Data.EnabledTypes[1] == 2, "Nao habilitado para snack");

                DateTime localDate = DateTime.Now;
                Assert.IsTrue(response.Data.ValidUntil > localDate, "Codigo expirado");


            }
            catch (Exception e)
                {
                    throw new Exception("Cinema invalido, atualizar a massa!");
                }

            return theaterId;


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
