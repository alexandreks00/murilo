using System.Configuration;
using System;
//using EcommerceBackend.models.Loyalty;
using NUnit.Framework;
using RestSharp;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Reporter.Configuration;
using EcommerceBackend.utils;

namespace EcommerceBackend
{
    [TestFixture]
    public class Bookings
    {
        ExtentReports extent = null;

        [OneTimeSetUp]
        public void StartReport()
        {
            extent = new ExtentReports();
            var htmlReporter = new ExtentHtmlReporter(@"C:\AutomationTools\EcommerceBackendReports\Reports\Bookings\");
            extent.AttachReporter(htmlReporter);
        }

        [OneTimeTearDown]
        public void CloseReport()
        {
            extent.Flush();
        }

        [Test]
        public void ValidaContratoDetalhesFilme()
        {
            ExtentTest test = null;
            test = extent.CreateTest("ValidaConsultaDetalhesFilme").Info("Início do teste.");
            string idDeadpool = "6132";

            try
            {
                //Criando e enviando requisição
                //comentario

                test.Log(Status.Info, "Criando requisição.");
                var client = new RestClient(ConfigurationManager.AppSettings["dnsSensedia"]);
                var request = new RestRequest("bus/v1/bookings/showtimes/movies/" + idDeadpool, Method.GET);
                request.RequestFormat = DataFormat.Json;
                test.Log(Status.Info, "Setando headers necessários para realizar a requisição.");
                Utils.setCisToken(request);
                test.Log(Status.Info, "Enviando requisição.");
                var response = client.Execute(request);

                string responseContent = response.Content.ToString();
                //Declarando as propriedades que deverão obrigatoriamente estar na resposta da requisição
                string[] properties = new string[] { "\"Movies\":", "\"MovieCode\":", "\"Dates\":", "\"Date\":",
                "\"ExhibitionDate\":", "\"ShowTimes\":", "\"id\":", "\"ShowTimeId\":", "\"date\":", "\"cm\":", "\"tht\":",
                "\"mov\":", "\"aud\":", "\"xd\":", "\"prime\":", "\"dbox\":", "\"d3d\":", "\"pre\":", "\"psl\":",
                "\"deb\":", "\"time\":", "\"loc\":", "\"MoviePrintCode\":", "\"IsSessionExpired\":", "\"TheaterAllow\":" ,
                "\"Utc\":", "\"level\":", "\"Suggestions\":", "\"SnackCategoryId\":" ,"\"SnackCategoryIconUrl\":"};

                //Início das validações
                test.Log(Status.Info, "Validando se o Status Code de retorno da requisição é 200.");

                Assert.That((int)response.StatusCode, Is.EqualTo(200), "Status Code divergente.");
                Utils.validaContrato(properties, responseContent, test);

                test.Log(Status.Pass, "Teste ok, todas as verificações foram realizadas com sucesso.");
            }
            catch (Exception e)
            {
                test.Log(Status.Fail, e.ToString());
                throw new Exception("Falha ao validar contrato: " + e.Message);
            }
        }

       

        [Test]
        public void ValidaContratoDisplayArea()
        {
            ExtentTest test = null;
            test = extent.CreateTest("ValidaContratoDisplayArea").Info("Início do teste.");

            try
            {
                //Criando e enviando requisição
                test.Log(Status.Info, "Criando requisição.");
                var client = new RestClient(ConfigurationManager.AppSettings["dnsSensedia"]);
                var request = new RestRequest("showtime/displayarea/all", Method.GET);
                request.RequestFormat = DataFormat.Json;
                test.Log(Status.Info, "Setando headers necessários para realizar a requisição.");
                Utils.setCisToken(request);
                test.Log(Status.Info, "Enviando requisição.");
                var response = client.Execute(request);

                string responseContent = response.Content.ToString();
                //Declarando as propriedades que deverão obrigatoriamente estar na resposta da requisição
                string[] properties = new string[] { "\"Id\":", "\"Title\":", "\"AreaType\":", "\"AreaTypeName\":",
                "\"Movies\":", "\"Code\":", "\"Name\":", "\"LocalTitle\":", "\"Runtime\":", "\"Rating\":", "\"ReleaseDate\":",
                "\"ImageUrl\":", "\"TrailerImageUrl\":", "\"TrailerVideoUrl\":", "\"ImageLabel\":", "\"Synopsis\":", "\"Director\":",
                "\"Distributor\":", "\"Cast\":", "\"Genre\":", "\"Nationality\":"};

                //Início das validações
                test.Log(Status.Info, "Validando se o Status Code de retorno da requisição é 200.");
                Assert.That((int)response.StatusCode, Is.EqualTo(200), "Status Code divergente.");
                Utils.validaContrato(properties, responseContent, test);
                test.Log(Status.Pass, "Teste ok, todas as verificações foram realizadas com sucesso.");
            }
            catch (Exception e)
            {
                test.Log(Status.Fail, e.ToString());
                throw new Exception("Falha ao validar contrato: " + e.Message);
            }
        }

        [Test]
        public void ValidaContratoExibeProgramacao()
        {
            ExtentTest test = null;
            test = extent.CreateTest("ValidaContratoExibeProgramacao").Info("Início do teste.");

            try
            {
                //Criando e enviando requisição
                test.Log(Status.Info, "Criando requisição.");
                var client = new RestClient(ConfigurationManager.AppSettings["dnsSensedia"]);
                var request = new RestRequest("bus/v1/bookings/showtimes/theaters/785", Method.GET);
                request.RequestFormat = DataFormat.Json;
                test.Log(Status.Info, "Setando headers necessários para realizar a requisição.");
                Utils.setCisToken(request);
                test.Log(Status.Info, "Enviando requisição.");
                var response = client.Execute(request);

                string responseContent = response.Content.ToString();
                //Declarando as propriedades que deverão obrigatoriamente estar na resposta da requisição
                string[] properties = new string[] { "\"Theaters\":", "\"TheaterCode\":", "\"Utc\":", "\"Dates\":",
                "\"Date\":", "\"ExhibitionDate\":", "\"ShowTimes\":", "\"id\":", "\"ShowTimeId\":", "\"date\":", "\"cm\":",
                "\"tht\":", "\"mov\":", "\"aud\":", "\"xd\":", "\"prime\":", "\"dbox\":", "\"d3d\":", "\"pre\":", "\"psl\":",
                "\"deb\":", "\"time\":", "\"loc\":", "\"MoviePrintCode\":", "\"IsSessionExpired\":", "\"TheaterAllow\":", "\"Utc\":",
                "\"level\":", "\"Suggestions\":", "\"SnackCategoryId\":", "\"SnackCategoryIconUrl\":"};

                //Início das validações
                test.Log(Status.Info, "Validando se o Status Code de retorno da requisição é 200.");
                Assert.That((int)response.StatusCode, Is.EqualTo(200), "Status Code divergente.");
                Utils.validaContrato(properties, responseContent, test);
                test.Log(Status.Pass, "Teste ok, todas as verificações foram realizadas com sucesso.");
            }
            catch (Exception e)
            {
                test.Log(Status.Fail, e.ToString());
                throw new Exception("Falha ao validar contrato: " + e.Message);
            }
        }
    }
}