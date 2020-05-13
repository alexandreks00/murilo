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
    public class Marketing
    {

        ExtentReports extent = null;

        [OneTimeSetUp]
        public void StartReport()
        {
            extent = new ExtentReports();
            var htmlReporter = new ExtentHtmlReporter(@"C:\AutomationTools\EcommerceBackendReports\Reports\Marketing\");
            extent.AttachReporter(htmlReporter);
        }

        [OneTimeTearDown]
        public void CloseReport()
        {          
            extent.Flush();
        }

        [Test]
        public void ValidaConsultaPromocoes()
        {
              ExtentTest test = null;
            test = extent.CreateTest("ValidaConsultaPromocoes").Info("Início do teste.");

            try
            {

                //Criando e enviando requisição
                test.Log(Status.Info, "Criando requisição");
                var client = new RestClient(ConfigurationManager.AppSettings["dnsSensedia"]);
                var request = new RestRequest("bus/v1/marketing/offers",  Method.GET);
                utils.Utils.setCisToken(request);
                test.Log(Status.Info, "Setando headers necessários para realizar a requisição");
                var response = client.Execute(request);

                // Valida se Existe o campo de mensagem
                test.Log(Status.Info, "Valida a mensagem de limpeza da lixeira");
                string responseContent = response.Content.ToString();

                // Sem promoções no momento no app - quando ter promoções descomentar a validação de contrato
                string[] properties = new string[] { "\"OfferId\":", "\"Code\":", "\"Title\":", "\"Text\":", "\"RedirectUrl\":", "\"ImageUrl\":", "\"StartDate\":", "\"EndDate\":"
                , "\"OfferType\":", "\"TwitterDescription\":", "\"FacebookDescription\":", "\"MobileImageUrl\":", "\"MobileText\":", "\"TabletImageUrl\":"
                , "\"Theaters\":", "\"TheaterCode\":", "\"Name\":", "\"Latitude\":", "\"Longitude\":", "\"Address1\":"
                , "\"Address2\":", "\"PriceTableHTML\":", "\"Status\":", "\"Auditoriums\":", "\"Notice\":", "\"InvoiceEnabled\":", "\"SnackbarEnabled\":"
                , "\"IngressoSiteCode\":", "\"SnackbarPOSCode\":", "\"CNPJ\":", "\"ZipCode\":", "\"EconomicGroupId\":"};

                //Início das validações
                test.Log(Status.Info, "Validando se o Status Code de retorno da requisição é 200.");
                Assert.That((int)response.StatusCode, Is.EqualTo(200), "Status Code divergente.");
                //Utils.validaContrato(properties, responseContent, test);
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
