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
       
                string authorizationToken = utils.Utils.getAuthorization("listadepedidos@mailinator.com", "112233");

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


                //Início das validações
                test.Log(Status.Info, "Validando se o Status Code de retorno da requisição é 200.");
                Assert.That((int)response.StatusCode, Is.EqualTo(200), "Status Code divergente.");

                test.Log(Status.Info, "Validando o contrato por inteiro.");
                Utils.validaContrato(properties, responseContent, test);

                test.Log(Status.Info, "Início da validação de pedido.");
                Assert.That(response.Data[1].id, Is.EqualTo("d612f383-fc26-4db4-8590-a9dd015c28a3"), "Status Code divergente.");
                Assert.That(response.Data[1].externalId, Is.EqualTo(""), "Status Code divergente.");
                Assert.That(response.Data[1].status, Is.EqualTo(0), "Status Code divergente.");
                Assert.That(response.Data[1].orderDate, Is.EqualTo("2019-01-22T21:07:36.438+00:00"), "Status Code divergente.");
                Assert.That(response.Data[1].expirationDate, Is.EqualTo("2019-01-29T21:07:36.438+00:00"), "Status Code divergente.");
                Assert.That(response.Data[1].theaterId, Is.EqualTo("688"), "Status Code divergente.");
                Assert.That(response.Data[1].products[0].name, Is.EqualTo("Pipoca Salgada Balde"), "Status Code divergente.");
                Assert.That(response.Data[1].products[0].theaterName, Is.EqualTo("Market Place"), "Status Code divergente.");
                Assert.That(response.Data[1].products[0].theaterAddress, Is.EqualTo("Av. Dr. Chucri Zaidan, 920 - Vila Cordeiro teste de quebra de linha e endereço grande 12345"), "Status Code divergente.");
                Assert.That(response.Data[1].products[0].id, Is.EqualTo("535"), "Status Code divergente.");
                Assert.That(response.Data[1].products[0].unitPrice, Is.EqualTo("26"), "Status Code divergente.");
                Assert.That(response.Data[1].products[0].status, Is.EqualTo("EXPIRADO"), "Status Code divergente.");
                Assert.That(response.Data[1].products[0].integrationCode, Is.EqualTo("884923"), "Status Code divergente.");
                Assert.That(response.Data[1].products[0].integrationTracking, Is.EqualTo("949908801547"), "Status Code divergente.");
                Assert.That(response.Data[1].total, Is.EqualTo("26"), "Status Code divergente.");

                test.Log(Status.Info, "Início da validação de pedido que contém SNACK + INGRESSO");
                Assert.That(response.Data[2].id, Is.EqualTo("561ccceb-269d-4ad6-936e-a9dd015c64f1"), "Status Code divergente.");
                Assert.That(response.Data[2].externalId, Is.EqualTo(""), "Status Code divergente.");
                Assert.That(response.Data[2].status, Is.EqualTo(0), "Status Code divergente.");
                Assert.That(response.Data[2].orderDate, Is.EqualTo("2019-01-22T19:08:27.899+00:00"), "Status Code divergente.");
                Assert.That(response.Data[2].expirationDate, Is.EqualTo("2019-01-23T21:40:00.000+00:00"), "Status Code divergente.");
                Assert.That(response.Data[2].theaterId, Is.EqualTo("688"), "Status Code divergente.");
                Assert.That(response.Data[1].movieId, Is.EqualTo("0"), "Status Code divergente.");
                Assert.That(response.Data[2].tickets[0].theaterId, Is.EqualTo(688), "Status Code divergente.");
                Assert.That(response.Data[2].tickets[0].ticketCode, Is.EqualTo("Inteira"), "Status Code divergente.");
                Assert.That(response.Data[2].tickets[0].seatCode, Is.EqualTo("299006"), "Status Code divergente.");
                Assert.That(response.Data[2].tickets[0].seatName, Is.EqualTo("H 1"), "Status Code divergente.");
                Assert.That(response.Data[2].tickets[0].quantity, Is.EqualTo("1"), "Status Code divergente.");
                Assert.That(response.Data[2].tickets[0].seatType, Is.EqualTo("Normal"), "Status Code divergente.");
                Assert.That(response.Data[2].tickets[0].seatCode, Is.EqualTo("299006"), "Status Code divergente.");
                Assert.That(response.Data[2].tickets[0].theaterName, Is.EqualTo("Market Place"), "Status Code divergente.");
                Assert.That(response.Data[2].tickets[0].movieName, Is.EqualTo("Os Incríveis 2"), "Status Code divergente.");
                Assert.That(response.Data[2].tickets[0].sessionDateTime, Is.EqualTo("2019-01-22T21:40:00.000+00:00"), "Status Code divergente.");
                Assert.That(response.Data[2].tickets[0].sessionDateTimeString, Is.EqualTo("22/01/19 19:40"), "Status Code divergente.");
                Assert.That(response.Data[2].tickets[0].roomNumber, Is.EqualTo("4"), "Status Code divergente.");
                Assert.That(response.Data[2].tickets[0].status, Is.EqualTo("EXPIRADO"), "Status Code divergente.");
                Assert.That(response.Data[2].tickets[0].integrationCode, Is.EqualTo("D8C529D652"), "Status Code divergente.");
                Assert.That(response.Data[2].tickets[0].unitPrice, Is.EqualTo(21), "Status Code divergente.");
                Assert.That(response.Data[2].tickets[0].theaterAddress, Is.EqualTo("Av. Dr. Chucri Zaidan, 920 - Vila Cordeiro teste de quebra de linha e endereço grande 12345"), "Status Code divergente.");
                Assert.That(response.Data[2].tickets[0].localizationType, Is.EqualTo("Dublado"), "Status Code divergente.");
                Assert.That(response.Data[2].tickets[0].rating, Is.EqualTo("Livre"), "Status Code divergente.");

                Assert.That(response.Data[2].products[0].name, Is.EqualTo("Coca-Cola Zero Grande"), "Status Code divergente.");
                Assert.That(response.Data[2].products[0].unitPrice, Is.EqualTo("16"), "Status Code divergente.");
                Assert.That(response.Data[2].products[0].status, Is.EqualTo("EXPIRADO"), "Status Code divergente.");
                Assert.That(response.Data[2].products[0].integrationCode, Is.EqualTo("884924"), "Status Code divergente.");
                Assert.That(response.Data[2].products[0].integrationTracking, Is.EqualTo("999808801527"), "Status Code divergente.");
                Assert.That(response.Data[2].products[0].theaterName, Is.EqualTo("Market Place"), "Status Code divergente.");
                Assert.That(response.Data[2].total, Is.EqualTo("36.88"), "Status Code divergente.");

                Assert.That(response.Data[2].fee[0].price, Is.EqualTo(4), "Status Code divergente.");

                test.Log(Status.Info, "Início da validação de pedido que contém apenas INGRESSO.");
                Assert.That(response.Data[3].id, Is.EqualTo("b8cd61eb-fcf7-4a1b-8077-a9dd015bf0da"), "Status Code divergente.");
                Assert.That(response.Data[3].externalId, Is.EqualTo(""), "Status Code divergente.");
                Assert.That(response.Data[3].status, Is.EqualTo(0), "Status Code divergente.");
                Assert.That(response.Data[3].orderDate, Is.EqualTo("2019-01-22T19:06:48.833+00:00"), "Status Code divergente.");
                Assert.That(response.Data[3].expirationDate, Is.EqualTo("2019-01-23T19:40:00.000+00:00"), "Status Code divergente.");
                Assert.That(response.Data[3].theaterId, Is.EqualTo("688"), "Status Code divergente.");
                Assert.That(response.Data[3].movieId, Is.EqualTo("22505"), "Status Code divergente.");

                Assert.That(response.Data[3].tickets[0].theaterName, Is.EqualTo("Market Place"), "Status Code divergente.");
                Assert.That(response.Data[3].tickets[0].movieName, Is.EqualTo("Os Incríveis 2"), "Status Code divergente.");
                Assert.That(response.Data[3].tickets[0].sessionDateTime, Is.EqualTo("2019-01-22T21:40:00.000+00:00"), "Status Code divergente.");
                Assert.That(response.Data[3].tickets[0].sessionDateTimeString, Is.EqualTo("22/01/19 19:40"), "Status Code divergente.");
                Assert.That(response.Data[3].tickets[0].roomNumber, Is.EqualTo("4"), "Status Code divergente.");
                Assert.That(response.Data[3].tickets[0].status, Is.EqualTo("EXPIRADO"), "Status Code divergente.");
                Assert.That(response.Data[3].tickets[0].integrationCode, Is.EqualTo("8CA02C1CA8"), "Status Code divergente.");
                Assert.That(response.Data[3].tickets[0].unitPrice, Is.EqualTo(21), "Status Code divergente.");
                Assert.That(response.Data[3].tickets[0].theaterAddress, Is.EqualTo("Av. Dr. Chucri Zaidan, 920 - Vila Cordeiro teste de quebra de linha e endereço grande 12345"), "Status Code divergente.");
                Assert.That(response.Data[3].tickets[0].localizationType, Is.EqualTo("Dublado"), "Status Code divergente.");
                Assert.That(response.Data[3].tickets[0].rating, Is.EqualTo("Livre"), "Status Code divergente.");

                test.Log(Status.Info, "Validação realizada com sucesso de todos os campos e seus valores.");

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



        [Test]
        public void ValidaRealizaPedidoSnack()
        {
            ExtentTest test = null;
            test = extent.CreateTest("ValidaRealizaPedidoSnack").Info("Início do teste.");

            try
            {

                string authorizationToken = utils.Utils.getAuthorization("alexandre.ksss@gmail.com", "batata@1010");
                //Criando e enviando requisição
                test.Log(Status.Info, "Criando requisição responsável por realizar login.");
                var client = new RestClient(ConfigurationManager.AppSettings["dnsSensedia"]);
                var request = new RestRequest("order/v2/startorder", Method.POST);
                request.RequestFormat = DataFormat.Json;
                utils.Utils.setCisToken(request);
                test.Log(Status.Info, "Setando headers necessários para realizar a requisição.");
                utils.Utils.setAuthorizationToken(request, authorizationToken);

                //json original (do postman) foi alterado de aspas dupla para aspas simples 
                //site https://csvjson.com/json_beautifier
                
                string json = @"{
                                  'account': {
                                    'email': 'alexandre.ksss@gmail.com',
                                    'name': 'Alexandre Kenji Shimizu',
                                    'userId': 7365872
                                  },
                                  'appInfo': {
                                    'Fingerprint': 'atmxcmqlyqyydanpimtf94ysv91uunvy',
                                    'deviceModel': 'SM-J701MT',
                                    'devicePlatform': 'Android',
                                    'deviceUUID': '75e73711-71ae-41c8-b883-b12c4151898c',
                                    'geolocation': {
                                      'latitude': -23.577729,
                                      'longitude': -46.7969339
                                    },
                                    'version': '4.1.9'
                                  },
                                  'theaterId': 785,
                                  'fee': {
                                    'price': 10
                                  },
                                  'movieId': 0,
                                  'payment': {
                                    'number': 'mTSBDAgF/PbX+jicDGuqOEjpWAMo7rOuQ/LuLGGIesg=',
                                    'cpf': '35074705940',
                                    'cvc': '737',
                                    'expiryMonth': '02',
                                    'expiryYear': '2025',
                                    'holderName': 'Tggg Hhhhh',
                                    'saveCardInformation': true
                                  },
                                  'products': [
                                    {
                                      'fee': {
                                        'price': 5
                                      },
                                      'id': 3375,
                                      'name': 'Coca-Cola Grande',
                                      'quantity': 1,
                                      'subTotal': 26,
                                      'theaterAddress': 'Av. Dr. Chucri Zaidan, 920 - Vila Cordeiro',
                                      'theaterName': 'Market Place',
                                      'theaterPOS': 3,
                                      'unitPrice': 21,
                                      'urlImagem': 'https://cdnim.hml.cineticket.com.br/snackbar/product/product_3375_20170605164929.png'
                                    }
                                  ],
                                  'total': 27
                                }";

             
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












    }
    

}
