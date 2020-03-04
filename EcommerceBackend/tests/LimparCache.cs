using System.Configuration;
using System;
using NUnit.Framework;
using RestSharp;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Reporter.Configuration;
using EcommerceBackend.utils;

namespace EcommerceBackend
{
    [TestFixture]
    public class LimparCache
    {

        ExtentReports extent = null;

        [OneTimeSetUp]
        public void StartReport()
        {
            extent = new ExtentReports();
            var htmlReporter = new ExtentHtmlReporter(@"C:\EcommerceBackendReports\Reports\LimparCache\");
            extent.AttachReporter(htmlReporter);
        }

        [OneTimeTearDown]
        public void CloseReport()
        {          
            extent.Flush();
        }

        [Test]
        public void ValidaLimparCache()
        {
              ExtentTest test = null;
            test = extent.CreateTest("ValidaLimparCache").Info("Início do teste.");

            try
            {

                //Criando e enviando requisição
                test.Log(Status.Info, "Criando requisição");
                var client = new RestClient(ConfigurationManager.AppSettings["dnsSensedia"]);
                var request = new RestRequest("bus/v1/limparcaches",  Method.POST);
                utils.Utils.setCisToken(request);
                test.Log(Status.Info, "Setando headers necessários para realizar a requisição");
                var response = client.Execute<ModelLimparCache>(request);

                // Valida se Existe o campo de mensagem
                test.Log(Status.Info, "Valida a mensagem de limpeza da lixeira");
                string responseContent = response.Content.ToString();
                string[] properties = new string[] { "\"Message\":" };

                //Início das validações
                test.Log(Status.Info, "Validando se o Status Code de retorno da requisição é 200.");
                Assert.That((int)response.StatusCode, Is.EqualTo(200), "Status Code divergente.");
                Utils.validaContrato(properties, responseContent, test);
                test.Log(Status.Info, "Finalizado todas as etapas.");

            }
            catch (Exception e)
            {
                test.Log(Status.Fail, e.ToString());
                throw new Exception("Falha ao validar limpeza de cache: " + e.Message);
            }
        }

    }
}
