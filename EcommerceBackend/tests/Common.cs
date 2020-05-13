using System.Configuration;
using System;
//using EcommerceBackend.models.Loyalty;
using NUnit.Framework;
using RestSharp;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using EcommerceBackend.utils;
using DemoRestSharp.models.Common;
using System.Collections.Generic;

namespace EcommerceBackend
{
    [TestFixture]
    public class Common
    {
        ExtentReports extent = null;

        [OneTimeSetUp]
        public void StartReport()
        {
            extent = new ExtentReports();
            var htmlReporter = new ExtentHtmlReporter(@"C:\AutomationTools\EcommerceBackendReports\Reports\Common\");
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
            test = extent.CreateTest("ValidaConsultaCidades").Info("Início do teste.");

            string idEstado = "25";


            try
            {
                //Criando e enviando requisição
                test.Log(Status.Info, "Criando requisição responsável por consultar as cidades.");
                var client = new RestClient(ConfigurationManager.AppSettings["dnsSensedia"]);
                var request = new RestRequest("bus/v1/common/states/"+idEstado+"/cities", Method.GET);
                request.RequestFormat = DataFormat.Json;
                test.Log(Status.Info, "Setando headers necessários para realizar a requisição.");
                Utils.setCisToken(request);
                test.Log(Status.Info, "Enviando requisição.");
                var response = client.Execute<List<ModelCommon>>(request);
                
                //Início das validações
                test.Log(Status.Info, "Validando se o Status Code de retorno da requisição é 200.");
                Assert.That((int)response.StatusCode, Is.EqualTo(200), "Status Code divergente.");

                //Validando o retorno das propriedades
                test.Log(Status.Info, "Validando o retorno das propriedades.");
                Assert.That(response.Data[0].CityId, Is.EqualTo(8853), "Valor da propriedade 'CityId' divergente.");
                Assert.That(response.Data[0].Name, Is.EqualTo("ADAMANTINA"), "Valor da propriedade 'Name' divergente.");
                Assert.That(response.Data[0].StateId, Is.EqualTo(25), "Valor da propriedade 'StateId' divergente.");
                Assert.That(response.Data[0].IbgeCode, Is.EqualTo("3500105"), "Valor da propriedade 'IbgeCode' divergente.");
                Assert.That(response.Data[11].CityId, Is.EqualTo(8865), "Valor da propriedade 'CityId' divergente.");
                Assert.That(response.Data[11].Name, Is.EqualTo("ALAMBARI"), "Valor da propriedade 'Name' divergente.");
                Assert.That(response.Data[11].StateId, Is.EqualTo(25), "Valor da propriedade 'StateId' divergente.");
                Assert.That(response.Data[11].IbgeCode, Is.EqualTo("3500758"), "Valor da propriedade 'IbgeCode' divergente.");
                Assert.That(response.Data[20].CityId, Is.EqualTo(8876), "Valor da propriedade 'CityId' divergente.");
                Assert.That(response.Data[20].Name, Is.EqualTo("ÁLVARES FLORENCE"), "Valor da propriedade 'Name' divergente.");
                Assert.That(response.Data[20].StateId, Is.EqualTo(25), "Valor da propriedade 'StateId' divergente.");
                Assert.That(response.Data[20].IbgeCode, Is.EqualTo("3501202"), "Valor da propriedade 'IbgeCode' divergente.");

                test.Log(Status.Pass, "Teste ok! Todas as verificações foram realizadas com sucesso.");
            }
            catch (Exception e)
            {
                test.Log(Status.Fail, e.ToString());
                throw new Exception("Falha ao validar dados do login do usuário: " + e.Message);
            }
        }
    
        [Test]
        public void ValidaConsultaEstados()
        {
            ExtentTest test = null;
            test = extent.CreateTest("ValidaConsultaEstados").Info("Início do teste.");

            try
            {
                //Criando e enviando requisição
                test.Log(Status.Info, "Criando requisição responsável por consultar os estados.");
                var client = new RestClient(ConfigurationManager.AppSettings["dnsSensedia"]);
                var request = new RestRequest("bus/v1/common/states/", Method.GET);
                request.RequestFormat = DataFormat.Json;
                test.Log(Status.Info, "Setando headers necessários para realizar a requisição.");
                Utils.setCisToken(request);
                test.Log(Status.Info, "Enviando requisição.");
                var response = client.Execute<List<ModelCommon>>(request);

                //Início das validações
                test.Log(Status.Info, "Validando se o Status Code de retorno da requisição é 200.");
                Assert.That((int)response.StatusCode, Is.EqualTo(200), "Status Code divergente.");

                //Validando o retorno das propriedades
                test.Log(Status.Info, "Validando o retorno das propriedades.");
                Assert.That(response.Data[0].StateId, Is.EqualTo(2), "Valor da propriedade 'StateId' divergente.");
                Assert.That(response.Data[0].Code, Is.EqualTo("AC"), "Valor da propriedade 'Code' divergente.");
                Assert.That(response.Data[0].Name, Is.EqualTo("Acre"), "Valor da propriedade 'Name' divergente.");
                Assert.That(response.Data[0].CountryId, Is.EqualTo("0"), "Valor da propriedade 'CountryId' divergente.");
                Assert.That(response.Data[0].Cities, Is.EqualTo(null), "Valor da propriedade 'Cities' divergente.");
                Assert.That(response.Data[6].StateId, Is.EqualTo(7), "Valor da propriedade 'StateId' divergente.");
                Assert.That(response.Data[6].Code, Is.EqualTo("DF"), "Valor da propriedade 'Code' divergente.");
                Assert.That(response.Data[6].Name, Is.EqualTo("Distrito Federal"), "Valor da propriedade 'Name' divergente.");
                Assert.That(response.Data[6].CountryId, Is.EqualTo("0"), "Valor da propriedade 'CountryId' divergente.");
                Assert.That(response.Data[6].Cities, Is.EqualTo(null), "Valor da propriedade 'Cities' divergente.");
                Assert.That(response.Data[17].StateId, Is.EqualTo(18), "Valor da propriedade 'StateId' divergente.");
                Assert.That(response.Data[17].Code, Is.EqualTo("PI"), "Valor da propriedade 'Code' divergente.");
                Assert.That(response.Data[17].Name, Is.EqualTo("Piauí"), "Valor da propriedade 'Name' divergente.");
                Assert.That(response.Data[17].CountryId, Is.EqualTo("0"), "Valor da propriedade 'CountryId' divergente.");
                Assert.That(response.Data[17].Cities, Is.EqualTo(null), "Valor da propriedade 'Cities' divergente.");

                test.Log(Status.Pass, "Teste ok! Todas as verificações foram realizadas com sucesso.");
            }
            catch(Exception e)
            {
                test.Log(Status.Fail, e.ToString());
                throw new Exception("Falha ao validar dados do login do usuário: " + e.Message);
            }
        }
    
    
    
    }
}
