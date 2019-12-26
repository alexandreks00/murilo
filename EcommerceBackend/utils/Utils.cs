using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using DemoRestSharp.Models;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using RestSharp;
using RestSharp.Serialization.Json;
using DemoRestSharp.Models.Users;

namespace DemoRestSharp.utils
{
    public static class Utils
    {
        public static RestRequest setCisToken(RestRequest request)
        {
            request.AddHeader("X-CISIdentity", ConfigurationManager.AppSettings["CISToken"]);
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
            return result+"@mailinator.com";
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
            return semente;
        }




    }
}
