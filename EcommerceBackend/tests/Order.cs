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
using System.Net;

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

        private void ValidaStatusResponse(IRestResponse response)
        {   
            ExtentTest test = null;

            var result = (response.IsSuccessful && !String.IsNullOrEmpty(response.Content))
                        ? test.Log(Status.Info, "Status code: " + response.StatusCode + "Propriedades OK")
                        : (int)response.StatusCode == 401
                        ? test.Log(Status.Info, "Nao autorizado, erro na autenticação/token do usuario")
                        : (int)response.StatusCode == 204
                        ? test.Log(Status.Info, "OK porém a consulta não trouxe nenhum conteudo")
                        : throw new Exception("Retorno inesperado");
        }

        [Test]
        public void ValidaConsultaListaPedidos()
        {
            ExtentTest test = null;
            test = extent.CreateTest("ValidaConsultaListaPedidos").Info("Início do teste.");

            var authorizationToken = utils.Utils.getAuthorization("mobile2020cinemark@gmail.com", "123456");

            //Criando e enviando requisição
            test.Log(Status.Info, "Criando requisição responsável por realizar login.");
            var client = new RestClient(ConfigurationManager.AppSettings["dnsSensedia"]);
            var request = new RestRequest("order/v1/list", Method.GET);
            request.RequestFormat = DataFormat.Json;
            utils.Utils.setCisToken(request);
            test.Log(Status.Info, "Setando headers necessários para realizar a requisição.");
            utils.Utils.setAuthorizationToken(request, authorizationToken);

            IRestResponse response = client.Execute<List<ModelOrder>>(request);
            ValidaStatusResponse(response);
            var responseContent = JObject.Parse(response.Content);

                if (responseContent.HasValues)
                    test.Log(Status.Pass);

        
        

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
                ValidaStatusResponse(response);
                var responseContent = JObject.Parse(response.Content);
                var guid = responseContent.GetValue("id");
                
                if (!(Utils.IsNullOrEmptyJToken(guid)))
                {
                    test.Log(Status.Pass);
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
            test = extent.CreateTest("ValidaConsultaOrderId").Info("Início do teste.");

            try
            {
                ValidaRealizaPedidoSnack();
                string authorizationToken = utils.Utils.getAuthorization("8d3hfnah@mailinator.com", "112233");
                var guid = "";
                //Criando e enviando requisição
                test.Log(Status.Info, "Criando requisição responsável por realizar login.");
                var client = new RestClient(ConfigurationManager.AppSettings["dnsSensedia"]);
                var request = new RestRequest("order/v1/getorder/"+guid, Method.GET);
                request.RequestFormat = DataFormat.Json;
                utils.Utils.setCisToken(request);
                test.Log(Status.Info, "Setando headers necessários para realizar a requisição.");
                utils.Utils.setAuthorizationToken(request, authorizationToken);

                var response = client.Execute<List<ModelOrder>>(request);

                //Início das validações
                test.Log(Status.Info, "Validando se o Status Code de retorno da requisição é 200.");
                Assert.That((int)response.StatusCode, Is.EqualTo(200), "Status Code divergente.");

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
                test.Log(Status.Info, "Enviando requisição.");
                var response = client.Execute(request);
                
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

                var isGuidOk = Utils.IsNullOrEmptyJToken(guid);
                
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
