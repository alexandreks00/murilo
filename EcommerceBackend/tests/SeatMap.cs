using System.Configuration;
using System;
using EcommerceBackend.models.Loyalty;
using NUnit.Framework;
using RestSharp;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Reporter.Configuration;
using EcommerceBackend.utils;

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
            var htmlReporter = new ExtentHtmlReporter(@"C:\EcommerceBackendReports\Reports\SeatMap\");
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
            string Idtheater = "688";
            string Idsession = "5445B76F-E8B1-4C7D-BB8F-5CAAA13ADCCE";

          
            try
            {
                //Criando e enviando requisição
                //comentario
                test.Log(Status.Info, "Criando requisição.");
                var client = new RestClient(ConfigurationManager.AppSettings["dnsSensedia"]);
                var request = new RestRequest("theater/v1/map/" + Idtheater + "/" + Idsession, Method.GET);

                request.RequestFormat = DataFormat.Json;
                test.Log(Status.Info, "Setando headers necessários para realizar a requisição.");
                Utils.setCisToken(request);
                test.Log(Status.Info, "Enviando requisição.");
                var response = client.Execute(request);

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

    }
}