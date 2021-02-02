using System.Configuration;
using System;
using NUnit.Framework;
// using EcommerceBackend.models.Loyalty;
using RestSharp;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Reporter.Configuration;
using EcommerceBackend.utils;
using EcommerceBackend.models;
using DemoRestSharp.models.SeatMap;
using EcommerceBackend.models.Bookings.ShowTimes;
using System.Collections.Generic;

namespace EcommerceBackend
{
    [TestFixture]
    public class SeatMap
    {
        ExtentReports extent = null;

        [OneTimeSetUp]
        public void StartReport()
        {
            extent = new ExtentReports();
            var htmlReporter = new ExtentHtmlReporter(@"C:\AutomationTools\EcommerceBackendReports\Reports\SeatMap\");
            extent.AttachReporter(htmlReporter);
        }

        [OneTimeTearDown]
        public void CloseReport()
        {
            extent.Flush();
        }

        [Test]
        public void ValidaMapaSessaoDisponivel()
        {
            ExtentTest test = null;
            test = extent.CreateTest("ValidaMapaSessaoDisponivel").Info("Início do teste.");

            int theaterId = 785;
            string Idsession = "D7F77B6B-8A5B-4D12-BF41-289D7C52D221";
            

            var client = new RestClient(ConfigurationManager.AppSettings["dnsSensedia"]);
            var request = new RestRequest("bus/v1/bookings/showtimes/theaters/" + theaterId, Method.GET);
            request.RequestFormat = DataFormat.Json;
            Utils.setCisToken(request);
            var response = client.Get<List<ModelTheatersShowTimes>>(request);

            int i = 0;
            string show_time_id = "";
            while (true)
            {
                var session_id = response.Data[0].Theaters[0].Dates[0].ShowTimes[i];
                if (!session_id.IsSessionExpired)
                {
                    show_time_id = session_id.ShowTimeId;
                    break;
                }
                i++;

            }
            test.Log(Status.Info, show_time_id);

            try
            {
                //Criando e enviando requisição
                //comentario
                test.Log(Status.Info, "Criando requisição.");
                var restClient = new RestClient(ConfigurationManager.AppSettings["dnsSensedia"]);
                var restRequest = new RestRequest("theater/v1/map/" + theaterId + "/" + Idsession, Method.GET);

                request.RequestFormat = DataFormat.Json;
                test.Log(Status.Info, "Setando headers necessários para realizar a requisição.");
                Utils.setCisToken(request);
                test.Log(Status.Info, "Enviando requisição.");
                var restResponse = client.Execute(restRequest);

                string responseContent = response.Content.ToString();
                //Declarando as propriedades que deverão obrigatoriamente estar na resposta da requisição
                string[] properties = new string[] { "\"Room\":", "\"Id\":", "\"Name\":", "\"Avail\":",
                "\"SectorCode\":", "\"Positions\":", "\"Row\":", "\"Col\":", "\"Code\":", "\"Name\":", "\"Status\":",
                "\"Type\":", "\"Subtype\":", "\"Realtype\":"};

                if (responseContent != null)
                {
                    //Início das validações
                    test.Log(Status.Info, "Validando se o Status Code de retorno da requisição é 200.");
                    Assert.That((int)response.StatusCode, Is.EqualTo(200), "Status Code divergente.");
                    Utils.validaContrato(properties, responseContent, test);
                    test.Log(Status.Info, "Lista de assentos concluída - teste terminado.");
                    test.Log(Status.Pass, "Teste ok, todas as verificações foram realizadas com sucesso.");
                }

            }
            catch (Exception e)
            {
                test.Log(Status.Fail, e.ToString());
                throw new Exception("Falha ao validar contrato: " + e.Message);
            }
        }

        [Test]
        public void ValidaMapaSessaoInexistente()
        {
            ExtentTest test = null;
            test = extent.CreateTest("ValidaMapaSessaoInexistente").Info("Início do teste.");
            string Idtheater = "688";
            string Idsession = "4B5E8F7F-2A16-4FE7-82C3-D993B9ACA3F7";

            try
            {
                //Criando e enviando requisição
                //comentario
                test.Log(Status.Info, "Criando requisição.");
                var client = new RestClient(ConfigurationManager.AppSettings["dnsSensedia"]);
                var request = new RestRequest("theater/v1/map/" + Idtheater + Idsession, Method.GET);

                request.RequestFormat = DataFormat.Json;
                test.Log(Status.Info, "Setando headers necessários para realizar a requisição.");
                Utils.setCisToken(request);
                test.Log(Status.Info, "Enviando requisição.");
                var response = client.Execute<ModelSeatMap>(request);
                string responseContent = response.Content.ToString();

                //Declarando as propriedades que deverão obrigatoriamente estar na resposta da requisição
                string[] properties = new string[] { "\"Room\":", "\"Id\":", "\"Name\":", "\"Avail\":",
                "\"SectorCode\":", "\"Positions\":", "\"Row\":", "\"Col\":", "\"Code\":", "\"Name\":", "\"Status\":",
                "\"Type\":", "\"Subtype\":", "\"Realtype\":"};


                if (String.IsNullOrEmpty(responseContent))
                {
                    //Início das validações
         
                    test.Log(Status.Info, "Validando se o Status Code de retorno da requisição é 200.");
                    Assert.That((int)response.StatusCode, Is.EqualTo(404), "Status Code divergente.");
                
                    //Utils.validaContrato(properties, responseContent, test);

                    // Solução temporária até resolver a melhoria de tratar a mensagem de sessão inexistente
                   // test.Log(Status.Info, "Forçando erro de id inexistente");
                   // Assert.That((int)response.Data.id, Is.EqualTo("33"), "Status Code divergente.");
                   // test.Log(Status.Pass, "Teste ok, todas as verificações foram realizadas com sucesso.");
                }

            }
            catch (Exception e)
            {
                test.Log(Status.Fail, e.ToString());
                throw new Exception("Falha ao validar contrato: " + e.Message);
            }
        }

        [Test]
        public void ValidaMapaSessaoInvalida()
        {
            ExtentTest test = null;
            test = extent.CreateTest("ValidaMapaSessaoInvalida").Info("Início do teste.");
            string Idtheater = "785";

            try
            {
                //Criando e enviando requisição
                //comentario
                test.Log(Status.Info, "Criando requisição.");
                var client = new RestClient(ConfigurationManager.AppSettings["dnsSensedia"]);
                var request = new RestRequest("theater/v1/map/" + Idtheater + "/4B5E8F74D993B9ACA3F7", Method.GET);

                request.RequestFormat = DataFormat.Json;
                test.Log(Status.Info, "Setando headers necessários para realizar a requisição.");
                Utils.setCisToken(request);
                test.Log(Status.Info, "Enviando requisição.");
                var response = client.Execute<ModelSeatMap>(request);

                //Início das validações
                test.Log(Status.Info, "Validando se o Status Code de retorno da requisição é 400.");
                Assert.That(response.Data.status, Is.EqualTo(400), "Status Code divergente.");
                
 
                // "message": "Erro inesperado"

                test.Log(Status.Pass, "Teste ok para o retorno 500, todas as verificações foram realizadas com sucesso.");

            }
            catch (Exception e)
            {
                test.Log(Status.Fail, e.ToString());
                throw new Exception("Falha ao validar contrato: ");
            }
        }

    }
}
