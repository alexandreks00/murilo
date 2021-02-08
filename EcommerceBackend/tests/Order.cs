using System.Configuration;
using System;
using NUnit.Framework;
using RestSharp;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using DemoRestSharp.models.Order;
using System.Collections.Generic;
using EcommerceBackend.utils;
using Newtonsoft.Json;
using System.Reflection;
using EcommerceBackend.models.Order;
using Newtonsoft.Json.Linq;
using System.IO;

namespace EcommerceBackend


{
    [TestFixture]
    public class Order
    {

        ExtentReports extent = null;

        [OneTimeSetUp]
        public void StartReport()
        {
            extent = new ExtentReports();
            var htmlReporter = new ExtentHtmlReporter(@"C:\AutomationTools\EcommerceBackendReports\Reports\Order\");
            extent.AttachReporter(htmlReporter);

        }

        [OneTimeTearDown]
        public void CloseReport()
        {
            extent.Flush();
        }

        [Test]
        public void ValidaConsultaListaPedidos()
        {
            ExtentTest test = null;
            test = extent.CreateTest("ValidaConsultaListaPedidos").Info("Início do teste.");

            try
            {

                string authorizationToken = utils.Utils.getAuthorization("mobile2020cinemark@gmail.com", "123456");

                //Criando e enviando requisição
                test.Log(Status.Info, "Criando requisição responsável por realizar login.");
                var client = new RestClient(ConfigurationManager.AppSettings["dnsSensedia"]);
                var request = new RestRequest("order/v1/list", Method.GET);
                request.RequestFormat = DataFormat.Json;
                utils.Utils.setCisToken(request);
                test.Log(Status.Info, "Setando headers necessários para realizar a requisição.");
                utils.Utils.setAuthorizationToken(request, authorizationToken);

                var response = client.Execute<List<ModelOrder>>(request);

                string[] properties = new string[] { "\"id\":", "\"externalId\":", "\"status\":", "\"orderDate\":",
                "\"expirationDate\":", "\"theaterId\":", "\"movieId\":", "\"movieId\":", "\"account\":", "\"userId\":", "\"applicationUserId\":",
                "\"identification\":", "\"email\":", "\"name\":", "\"phone\":", "\"type\":", "\"ticketCode\":",
                "\"tickets\":", "\"products\":", "\"name\":", "\"unitPrice\":", "\"status\":", "\"integrationCode\":", "\"integrationTracking\":", "\"total\":"
                , "\"order\":", "\"localizationType\":", "\"rating\":", "\"sessionType\":"};

                string responseContent = response.Content.ToString();
                var objResponseContent = JObject.Parse(response.Content);

                var guid = objResponseContent.GetValue("id");

                //Início das validações
                test.Log(Status.Info, "Validando se o Status Code de retorno da requisição é 200.");
                Assert.That((int)response.StatusCode, Is.EqualTo(200), "Status Code divergente.");

                test.Log(Status.Info, "Validando o contrato por inteiro.");
                Utils.validaContrato(properties, responseContent, test);

               

            }
            catch (Exception e)
            {
                test.Log(Status.Fail, e.ToString());
                throw new Exception("Falha ao validar dados do login do usuário: " + e.Message);
            }

        }

        [Test]
        public void ValidaConsultaUltimoPedido()
        {
            ExtentTest test = null;
            test = extent.CreateTest("ValidaConsultaUltimoPedido").Info("Início do teste.");

            try
            {
                string authorizationToken = utils.Utils.getAuthorization("consultaultimopedido@mailinator.com", "112233");

                //Criando e enviando requisição
                test.Log(Status.Info, "Criando requisição responsável por realizar login.");
                var client = new RestClient(ConfigurationManager.AppSettings["dnsSensedia"]);
                var request = new RestRequest("order/v1/lastorder", Method.GET);
                request.RequestFormat = DataFormat.Json;
                utils.Utils.setCisToken(request);
                test.Log(Status.Info, "Setando headers necessários para realizar a requisição.");
                utils.Utils.setAuthorizationToken(request, authorizationToken);

                var response = client.Execute<List<ModelOrderLast>>(request);
              
                //Início das validações
                test.Log(Status.Info, "Validando se o Status Code de retorno da requisição é 200.");
                Assert.That((int)response.StatusCode, Is.EqualTo(200), "Status Code divergente.");

                if ((int)response.StatusCode == 200 && authorizationToken != null)
                {
                    //testes realizados de forma unitaria
                    test.Log(Status.Info, "Início de validações de propriedades e valores.");
                    Assert.That(response.Data[0].id, Is.EqualTo("26a33aed-a360-451b-8f6d-a9ff00fc1118"), "Status Code divergente.");
                    Assert.That(response.Data[0].account[0].userId, Is.EqualTo(5640490), "Status Code divergente.");
                    Assert.That(response.Data[0].account[0].email, Is.EqualTo("consultaultimopedido@mailinator.com"), "Status Code divergente.");
                    Assert.That(response.Data[0].account[0].name, Is.EqualTo("Consulta O Ultimo"), "Status Code divergente.");

                    Assert.That(response.Data[0].products[0].name, Is.EqualTo("Combo Balde c/ Manteiga"), "Status Code divergente.");
                    Assert.That(response.Data[0].products[1].name, Is.EqualTo("Pipoca Caramelo Balde"), "Status Code divergente.");
                    Assert.That(response.Data[0].products[2].name, Is.EqualTo("Pipoca Caramelo Balde"), "Status Code divergente.");
                    Assert.That(response.Data[0].products[3].name, Is.EqualTo("Coca-Cola Grande"), "Status Code divergente.");
                    Assert.That(response.Data[0].products[4].name, Is.EqualTo("Batata Lays"), "Status Code divergente.");
                    Assert.That(response.Data[0].products[5].name, Is.EqualTo("Batata Lays"), "Status Code divergente.");
                    Assert.That(response.Data[0].products[6].name, Is.EqualTo("M&Ms 270g chocolate"), "Status Code divergente.");
                    Assert.That(response.Data[0].products[7].name, Is.EqualTo("M&Ms 270g chocolate"), "Status Code divergente.");

                    test.Log(Status.Info, "Término de validações de propriedades e valores.");
                }
                else if (response.Data[0].id == "" || response.Data[0].id == null)
                {
                    test.Log(Status.Fail, "Usuário inexistente.");
                }
           
            }

            catch (Exception e)
            {
                test.Log(Status.Fail, e.ToString());
                throw new Exception("Falha ao validar dados do último pedido: " + e.Message);
            }
        }

        public void ValidaConsultaOrderId()
        {
            ExtentTest test = null;
            test = extent.CreateTest("ValidaConsultaUltimoPedido").Info("Início do teste.");

            try
            {
                ValidaRealizaPedidoSnack();
                string authorizationToken = utils.Utils.getAuthorization("8d3hfnah@mailinator.com", "112233");

                //Criando e enviando requisição
                test.Log(Status.Info, "Criando requisição responsável por realizar login.");
                var client = new RestClient(ConfigurationManager.AppSettings["dnsSensedia"]);
                var request = new RestRequest("order/v1/lastorder", Method.GET);
                request.RequestFormat = DataFormat.Json;
                utils.Utils.setCisToken(request);
                test.Log(Status.Info, "Setando headers necessários para realizar a requisição.");
                utils.Utils.setAuthorizationToken(request, authorizationToken);

                var response = client.Execute<List<ModelOrder>>(request);

                //Início das validações
                test.Log(Status.Info, "Validando se o Status Code de retorno da requisição é 200.");
                Assert.That((int)response.StatusCode, Is.EqualTo(200), "Status Code divergente.");

                if ((int)response.StatusCode == 200 && authorizationToken != null)
                {
                    //testes realizados de forma unitaria
                    test.Log(Status.Info, "Início de validações de propriedades e valores.");
                    //Assert.That(response.Data[0].id, Is.EqualTo("26a33aed-a360-451b-8f6d-a9ff00fc1118"), "Status Code divergente.");
                    //Assert.That(response.Data[0].account[0].userId, Is.EqualTo(5640490), "Status Code divergente.");
                    //Assert.That(response.Data[0].account[0].email, Is.EqualTo("consultaultimopedido@mailinator.com"), "Status Code divergente.");
                    //Assert.That(response.Data[0].account[0].name, Is.EqualTo("Consulta O Ultimo"), "Status Code divergente.");

                    //Assert.That(response.Data[0].products[0].name, Is.EqualTo("Combo Balde c/ Manteiga"), "Status Code divergente.");
                    //Assert.That(response.Data[0].products[1].name, Is.EqualTo("Pipoca Caramelo Balde"), "Status Code divergente.");
                    //Assert.That(response.Data[0].products[2].name, Is.EqualTo("Pipoca Caramelo Balde"), "Status Code divergente.");
                    //Assert.That(response.Data[0].products[3].name, Is.EqualTo("Coca-Cola Grande"), "Status Code divergente.");
                    //Assert.That(response.Data[0].products[4].name, Is.EqualTo("Batata Lays"), "Status Code divergente.");
                    //Assert.That(response.Data[0].products[5].name, Is.EqualTo("Batata Lays"), "Status Code divergente.");
                    //Assert.That(response.Data[0].products[6].name, Is.EqualTo("M&Ms 270g chocolate"), "Status Code divergente.");
                    //Assert.That(response.Data[0].products[7].name, Is.EqualTo("M&Ms 270g chocolate"), "Status Code divergente.");

                    test.Log(Status.Info, "Término de validações de propriedades e valores.");
                }
                else if (response.Data[0].id == "" || response.Data[0].id == null)
                {
                    test.Log(Status.Fail, "Usuário inexistente.");
                }

            }

            catch (Exception e)
            {
                test.Log(Status.Fail, e.ToString());
                throw new Exception("Falha ao validar get /order,v: " + e.Message);
            }
        }


        [Test]
        public void ValidaRealizaPedidoSnack()
        {
            ExtentTest test = null;
            test = extent.CreateTest("ValidaRealizaPedidoSnack").Info("Início do teste.");
            
            try
            {

                string authorizationToken = utils.Utils.getAuthorization("4uadpxcq@mailinator.com", "112233");
                //Criando e enviando requisição
                test.Log(Status.Info, "Criando requisição responsável por realizar login.");
                var client = new RestClient(ConfigurationManager.AppSettings["dnsSensedia"]);
                var request = new RestRequest("order/v2/startorder", Method.POST);
                request.RequestFormat = DataFormat.Json;
                utils.Utils.setCisToken(request);
                test.Log(Status.Info, "Setando headers necessários para realizar a requisição.");
                utils.Utils.setAuthorizationToken(request, authorizationToken);

                /*
                    enviando o payload / body atraves do arquivo.json de massa e retornando na variavel json o 
                    conteudo do arquivo já de-serializado
      
                */

                string jsonFilePath = @"C:\Users\alexa\CSharpProjects\backend\EcommerceBackendRestSharp\EcommerceBackend\utils\payloads\ValidaRealizaPedidoSnack.json";
                string json = Utils.RetornaStringJson(jsonFilePath);


                /*
                     No metodo AddParameter especificamos o content-type como "application/json"
                     Dessa forma não precisamos usar o deserializer
                 */
                request.AddParameter("application /json", json , ParameterType.RequestBody);
                var response = client.Execute(request);
                test.Log(Status.Info, "Enviando requisição.");
                Console.WriteLine(response);
                
          
                //Início das validações
                test.Log(Status.Info, "Validando se o Status Code de retorno da requisição é 200.");
                Assert.That((int)response.StatusCode, Is.EqualTo(200), "Status Code divergente.");

            }
            catch (Exception e)
            {
                test.Log(Status.Fail, e.ToString());
                throw new Exception("Falha ao validar geracao do pedido: " + e.Message);
            }
        }
        [Test]
        public void ValidaPreparoDoPedido()
        {
            ExtentTest test = null;
            test = extent.CreateTest("ValidaPreparoDoPedido").Info("Início do teste.");

            try
            {

                string authorizationToken = utils.Utils.getAuthorization("8d3hfnah@mailinator.com", "112233");
                //Criando e enviando requisição
                test.Log(Status.Info, "Criando requisição responsável por realizar login.");
                var client = new RestClient(ConfigurationManager.AppSettings["dnsSensedia"]);
                var request = new RestRequest("order/v2/startorder", Method.POST);
                request.RequestFormat = DataFormat.Json;
                utils.Utils.setCisToken(request);
                test.Log(Status.Info, "Setando headers necessários para realizar a requisição.");
                utils.Utils.setAuthorizationToken(request, authorizationToken);
                string jsonFilePath = @"C:\Users\alexa\CSharpProjects\backend\EcommerceBackendRestSharp\EcommerceBackend\utils\payloads\ValidaRealizaPedidoSnack.json";
                string json = Utils.RetornaStringJson(jsonFilePath);
                request.AddParameter("application /json", json, ParameterType.RequestBody);
                IRestResponse response = client.Execute(request);

                /* Guardando o id do response
                 * É necessario fazer o parse do response (string -> objeto)
                 */
                
                var responseContent = JObject.Parse(response.Content);
                var guid = responseContent.GetValue("id");

                utils.Utils.IsNullOrEmpty(guid);
                
                var clientPrepare = new RestClient(ConfigurationManager.AppSettings["dnsSensedia"]);
                var requestPrepare = new RestRequest("order/v1/prepare/"+guid, Method.POST);
                requestPrepare.RequestFormat = DataFormat.Json;
                utils.Utils.setCisToken(requestPrepare);
                utils.Utils.setAuthorizationToken(requestPrepare, authorizationToken);
                IRestResponse responsePrepare = client.Execute(request);

                //Início das validações
                test.Log(Status.Info, "Validando se o Status Code de retorno da requisição de preparo é 200.");
                Assert.That((int)response.StatusCode, Is.EqualTo(200), "Status Code divergente.");

            }
            

            catch (Exception e)
            {
                test.Log(Status.Fail, e.ToString());
                throw new Exception("Falha ao validar geracao do pedido: " + e.Message);
            }
        }

        [Test]
        public void ValidaRealizaPedidoMeiaElo()
        {
            ExtentTest test = null;
            test = extent.CreateTest("ValidaRealizaPedidoSnack").Info("Início do teste.");
            
            try
            {

                string authorizationToken = utils.Utils.getAuthorization("mobile2020cinemark@gmail.com", "123456");
                //Criando e enviando requisição
                test.Log(Status.Info, "Criando requisição responsável por realizar login.");
                var client = new RestClient(ConfigurationManager.AppSettings["dnsSensedia"]);
                var request = new RestRequest("order/v2/startorder", Method.POST);
                request.RequestFormat = DataFormat.Json;
                utils.Utils.setCisToken(request);
                test.Log(Status.Info, "Setando headers necessários para realizar a requisição.");
                utils.Utils.setAuthorizationToken(request, authorizationToken);

                string jsonFilePath =
                @"C:\Users\alexa\CSharpProjects\backend\EcommerceBackendRestSharp\EcommerceBackend\utils\payloads\ValidaRealizaPedidoMeiaElo.json";
                string json = Utils.RetornaStringJson(jsonFilePath);
                dynamic jsonObj = Newtonsoft.Json.JsonConvert.DeserializeObject(json);
                //jsonObj["tickets"][0];

                request.AddParameter("application /json", json, ParameterType.RequestBody);
                var response = client.Execute(request);
                test.Log(Status.Info, "Enviando requisição.");
                Console.WriteLine(response);


                //Início das validações
                test.Log(Status.Info, "Validando se o Status Code de retorno da requisição é 200.");
                Assert.That((int)response.StatusCode, Is.EqualTo(200), "Status Code divergente.");

            }
            catch (Exception e)
            {
                test.Log(Status.Fail, e.ToString());
                throw new Exception("Falha ao validar geracao do pedido: " + e.Message);
            }
        }











    }
    

}
