using System.Configuration;
using System;
using EcommerceBackend.Models.Users;
using NUnit.Framework;
using RestSharp;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using EcommerceBackend.utils;

namespace DemoRestSharp.tests
{
    [TestFixture]
    public class Common
    {
        ExtentReports extent = null;

        [OneTimeSetUp]
        public void StartReport()
        {
            extent = new ExtentReports();
            var htmlReporter = new ExtentHtmlReporter(@"C:\EcommerceBackendReports\Reports\Users\");
            extent.AttachReporter(htmlReporter);
        }

        [OneTimeTearDown]
        public void CloseReport()
        {
            extent.Flush();
        }

        [Test]
        public void ValidaConsultaCidades()
        {
            ExtentTest test = null;          
            string idEstado = "25";

            test = extent.CreateTest("ValidaConsultaCidades").Info("Início do teste.");

            try
            {
                //Criando e enviando requisição
                test.Log(Status.Info, "Criando requisição responsável por realizar login.");
                var client = new RestClient(ConfigurationManager.AppSettings["dnsSensedia"]);
                var request = new RestRequest("bus/v1/common/states/"+idEstado+"/cities", Method.GET);
                request.RequestFormat = DataFormat.Json;
                test.Log(Status.Info, "Setando headers necessários para realizar a requisição.");
                Utils.setCisToken(request);
                test.Log(Status.Info, "Enviando requisição.");
                var response = client.Execute<models.Common.ModelCommon>(request);
                
                //Início das validações
                test.Log(Status.Info, "Validando se o Status Code de retorno da requisição é 200.");
                Assert.That((int)response.StatusCode, Is.EqualTo(200), "Status Code divergente.");

                test.Log(Status.Info, "Validando o retorno das propriedades.");
                Assert.That(response.Data.CityId, Is.EqualTo("5e0dfe5b1a4fe4000190ac85"), "Valor da propriedade 'Id' divergente.");
                Assert.That(response.Data.Name, Is.EqualTo(6947486), "Valor da propriedade 'UserId' divergente.");
                Assert.That(response.Data.StateId, Is.EqualTo("Teste Users"), "Valor da propriedade 'Name' divergente.");
                Assert.That(response.Data.IbgeCode, Is.EqualTo("Users"), "Valor da propriedade 'NickName' divergente.");
                
                test.Log(Status.Pass, "Teste ok, todas as verificações foram realizadas com sucesso.");
            }
            catch (Exception e)
            {
                test.Log(Status.Fail, e.ToString());
                throw new Exception("Falha ao validar dados do login do usuário: " + e.Message);
            }
        }
    }
}
