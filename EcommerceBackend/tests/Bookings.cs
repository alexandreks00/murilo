using System.Configuration;
using System;
using EcommerceBackend.Models.Users;
using NUnit.Framework;
using RestSharp;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Reporter.Configuration;

namespace DemoRestSharp.tests
{
    [TestFixture]
    public class Bookings
    {
        ExtentReports extent = null;

        [OneTimeSetUp]
        public void StartReport()
        {
            extent = new ExtentReports();
            var htmlReporter = new ExtentHtmlReporter(@"C:\EcommerceBackendReports\Reports\Bookings\");
            extent.AttachReporter(htmlReporter);
        }

        [OneTimeTearDown]
        public void CloseReport()
        {
            extent.Flush();
        }

        [Test]
        public void ValidaConsultaDetalhesFilme()
        {
            ExtentTest test = null;
            test = extent.CreateTest("ValidaConsultaDetalhesFilme").Info("Início do teste.");

            try
            {
                //Criando e enviando requisição
                test.Log(Status.Info, "Criando requisição.");
                var client = new RestClient(ConfigurationManager.AppSettings["dnsSensedia"]);
                var request = new RestRequest("", Method.POST);
                request.RequestFormat = DataFormat.Json;
                request.AddJsonBody(new
                {
                    Email = "automaticusers@mailinator.com",
                    Password = "112233"
                }
                );
                test.Log(Status.Info, "Setando headers necessários para realizar a requisição.");
                EcommerceBackend.utils.Utils.setCisToken(request);
                test.Log(Status.Info, "Enviando requisição.");
                var response = client.Execute<ModelUsers>(request);

                //Início das validações
                test.Log(Status.Info, "Validando se o Status Code de retorno da requisição é 200.");
                Assert.That((int)response.StatusCode, Is.EqualTo(200), "Status Code divergente.");
                test.Log(Status.Info, "Validando o retorno das propriedades.");
                Assert.That(response.Data.Id, Is.EqualTo("5e0dfe5b1a4fe4000190ac85"), "Valor da propriedade 'Id' divergente.");
                Assert.That(response.Data.UserId, Is.EqualTo(6947486), "Valor da propriedade 'UserId' divergente.");
                Assert.That(response.Data.Name, Is.EqualTo("Teste Users"), "Valor da propriedade 'Name' divergente.");
                Assert.That(response.Data.NickName, Is.EqualTo("Users"), "Valor da propriedade 'NickName' divergente.");
                Assert.That(response.Data.Gender, Is.EqualTo("F"), "Valor da propriedade 'Gender' divergente.");
                Assert.That(response.Data.Email, Is.EqualTo("automaticusers@mailinator.com"), "Valor da propriedade 'Email' divergente.");
                Assert.That(response.Data.CPF, Is.EqualTo("05163366068"), "Valor da propriedade 'CPF' divergente.");
                Assert.That(response.Data.DateOfBirth, Is.EqualTo("1996-04-12T00:00:00Z"), "Valor da propriedade 'DateOfBirth' divergente.");
                Assert.That(response.Data.Member.CityId, Is.EqualTo("12789"), "Valor da propriedade 'CityId' divergente.");
                Assert.That(response.Data.Member.City.CityId, Is.EqualTo(12789), "Valor da propriedade 'City.CityId' divergente.");
                Assert.That(response.Data.Member.City.Name, Is.EqualTo("Taguatinga"), "Valor da propriedade 'City.Name' divergente.");
                Assert.That(response.Data.Member.City.StateId, Is.EqualTo(7), "Valor da propriedade 'City.StateId' divergente.");
                Assert.That(response.Data.Member.City.State.Code, Is.EqualTo("DF"), "Valor da propriedade 'City.State.Code' divergente.");
                Assert.That(response.Data.Member.City.State.Name, Is.EqualTo("Distrito Federal"), "Valor da propriedade 'City.State.Name' divergente.");
                Assert.That(response.Data.City.State.CountryId, Is.EqualTo(0), "Valor da propriedade 'City.State.CountryId' divergente.");
                Assert.That(response.Data.Member.Phone1, Is.EqualTo("1136362525"), "Valor da propriedade 'Phone1' divergente.");
                Assert.That(response.Data.NLPActive, Is.EqualTo("True"), "Valor da propriedade 'NLPActive' divergente.");
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
