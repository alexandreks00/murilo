using System;
using System.Collections.Generic;
using System.Configuration;
using DemoRestSharp.Models;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using RestSharp;
using RestSharp.Serialization.Json;

namespace DemoRestSharp
{
    [TestFixture]
    public class UnitTest1
    {
        [Test]
        public void GetMethod()
        {
            var client = new RestClient("https://jsonplaceholder.typicode.com/");
            var request = new RestRequest("todos/1", Method.GET);
           
            var response= client.Execute(request);

            //var deserialize = new JsonDeserializer();
            //var output = deserialize.Deserialize<Dictionary<string, string>>(response);
            //var result = output["userId"];

            JObject obj = JObject.Parse(response.Content);
            Assert.That(obj["userId"].ToString(), Is.EqualTo("1"), "User Id errado na parada");
        }

        [Test]
        public void GetUserinfoLoginByApp()
        {

            //Posts pst = new Posts();
            var client = new RestClient(ConfigurationManager.AppSettings["dnsSensedia"]);
            
            var request = new RestRequest("bus/v1/users/login/byapp", Method.POST);
            
            request.RequestFormat = DataFormat.Json;
            
            request.AddBody(new Posts() { Email = "gustavoqueiroz@mailinator.com", Password = "112233" });

            request.AddHeader("X-CISIdentity", ConfigurationManager.AppSettings["CISToken"]);
            
            var response = client.Execute<Posts>(request);

            Assert.That((int)response.StatusCode, Is.EqualTo(200), "Status Code diferente de 200");

            //Assert.That(response.Data.City.StateId, Is.EqualTo(1), "Nome da cidade diferente");

            //Assert.That(response.Data.City.Name, Is.EqualTo("SÃO BRÁS"), "Nome da cidade diferente");
            


            //Assert.That(response.Data.Email, Is.EqualTo("gustavoqueiroz@mailinator.com"), "E-mail retornado na resposta é inválido.");
        }
    }
}