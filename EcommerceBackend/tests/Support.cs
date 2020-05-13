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
    public class Support
    {

        ExtentReports extent = null;

        [OneTimeSetUp]
        public void StartReport()
        {
            extent = new ExtentReports();
            var htmlReporter = new ExtentHtmlReporter(@"C:\AutomationTools\EcommerceBackendReports\Reports\Support\");
            extent.AttachReporter(htmlReporter);
        }

        [OneTimeTearDown]
        public void CloseReport()
        {          
            extent.Flush();
        }

        [Test]
        public void ValidaConsultaFaq()
        {
              ExtentTest test = null;
            test = extent.CreateTest("ValidaConsultaFaq").Info("Início do teste.");

            try
            {

                //Criando e enviando requisição
                test.Log(Status.Info, "Criando requisição");
                var client = new RestClient(ConfigurationManager.AppSettings["dnsSensedia"]);
                var request = new RestRequest("bus/v1/support/faqcategories",  Method.GET);
                utils.Utils.setCisToken(request);
                test.Log(Status.Info, "Setando headers necessários para realizar a requisição");
                var response = client.Execute(request);

                 
                string responseContent = response.Content.ToString();

                string[] properties = new string[] { "\"FaqCategoryId\":", "\"Description\":", "\"Deleted\":", "\"Faqs\":", "\"FaqId\":", "\"IssueDescription\":", "\"Instructions\":", "\"Deleted\":"
                , "\"FaqCategoryId\":", "\"IsContactEnabled\":", "\"FaqType\":"};

                //Início das validações
                test.Log(Status.Info, "Validando se o Status Code de retorno da requisição é 200.");
                Assert.That((int)response.StatusCode, Is.EqualTo(200), "Status Code divergente.");
                test.Log(Status.Info, "Valida Contrato de ajuda - help");
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
