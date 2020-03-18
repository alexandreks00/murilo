using System.Configuration;
using System;
using NUnit.Framework;
using RestSharp;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using DemoRestSharp.models.Theaters;
using System.Collections.Generic;
using EcommerceBackend.utils;
using Newtonsoft.Json;

namespace EcommerceBackend


{
    [TestFixture]
    public class Theaters
    {
        ExtentReports extent = null;

        [OneTimeSetUp]
        public void StartReport()
        {
            extent = new ExtentReports();
            var htmlReporter = new ExtentHtmlReporter(@"C:\EcommerceBackendReports\Reports\Theater\");
            extent.AttachReporter(htmlReporter);

        }

        [OneTimeTearDown]
        public void CloseReport()
        {
            extent.Flush();
        }

        [Test]
        public void ValidaListaCinemas()
        {
            ExtentTest test = null;
            test = extent.CreateTest("ValidaListaCinemas").Info("Início do teste.");

            try
            {

                //Criando e enviando requisição
                test.Log(Status.Info, "Criando requisição responsável por realizar login.");
                var client = new RestClient(ConfigurationManager.AppSettings["dnsSensedia"]);
                var request = new RestRequest("bus/v1/theaters", Method.GET);
                request.RequestFormat = DataFormat.Json;
                utils.Utils.setCisToken(request);
                test.Log(Status.Info, "Setando headers necessários para realizar a requisição.");

                var response = client.Execute<List<ModelTheater>>(request);

                //Início das validações
                test.Log(Status.Info, "Validando se o Status Code de retorno da requisição é 200.");
                Assert.That((int)response.StatusCode, Is.EqualTo(200), "Status Code divergente.");


                if (response.IsSuccessful)
                {

                    test.Log(Status.Info, "Início da validação de cinemas.");
                    Assert.That(response.Data[0].TheaterCode, Is.EqualTo("2115"), "TheaterCode divergente.");
                    Assert.That(response.Data[0].Name, Is.EqualTo("Atrium Shopping"), "Name divergente.");
                    Assert.That(response.Data[0].Latitude, Is.EqualTo("-23.6644134"), "Latitude divergente.");
                    Assert.That(response.Data[0].Longitude, Is.EqualTo("-46.5078915"), "Longitude divergente.");
                    Assert.That(response.Data[0].Address1, Is.EqualTo("RUA GIOVANNI BATTISTA PIRELLI, 155  /  ATRIUM SHOPPING SANTO ANDRE - 2 ANDAR - LUC/SUC CINEMA"), "Address1 divergente.");
                    Assert.That(response.Data[0].StateId, Is.EqualTo("25"), "StateId divergente.");
                    Assert.That(response.Data[0].City[0].CityId, Is.EqualTo("9625"), "CityId divergente.");
                    Assert.That(response.Data[0].City[0].Name, Is.EqualTo("SANTO ANDRÉ"), "Name divergente.");
                    Assert.That(response.Data[0].City[0].StateId, Is.EqualTo("25"), "' divergente.");
                    Assert.That(response.Data[0].City[0].IbgeCode, Is.EqualTo("3547809"), "IbgeCode divergente.");
                    Assert.That(response.Data[0].State[0].StateId, Is.EqualTo("25"), "StateId divergente.");
                    Assert.That(response.Data[0].State[0].Code, Is.EqualTo("SP"), "Code divergente.");
                    Assert.That(response.Data[0].State[0].Name, Is.EqualTo("São Paulo"), "Name divergente.");
                    Assert.That(response.Data[0].State[0].CountryId, Is.EqualTo("1"), "CountryId divergente.");
                    Assert.That(response.Data[0].Phone1, Is.EqualTo("(11) 5180-3292"), "Phone1 divergente.");

                    test.Log(Status.Info, "Início da validação de auditórios.");
                    Assert.That(response.Data[0].Auditoriums[0].TheaterCode, Is.EqualTo("2115"), "TheaterCode divergente.");
                    Assert.That(response.Data[0].Auditoriums[0].Description, Is.EqualTo(""), "Description divergente.");
                    Assert.That(response.Data[0].Auditoriums[0].AuditoriumCode, Is.EqualTo("4"), "AuditoriumCode divergente.");
                    Assert.That(response.Data[0].Auditoriums[0].TotalSeats, Is.EqualTo("226"), "TotalSeats divergente.");
                    Assert.That(response.Data[0].Auditoriums[0].DboxDescription, Is.EqualTo(""), "DboxDescription divergente.");
                    Assert.That(response.Data[0].Auditoriums[0].XD, Is.EqualTo("False"), "XD divergente.");
                    Assert.That(response.Data[0].Auditoriums[0].Prime, Is.EqualTo("False"), "Prime divergente.");
                    Assert.That(response.Data[0].Auditoriums[0].DBOX, Is.EqualTo("False"), "DBOX divergente.");
                    Assert.That(response.Data[0].Auditoriums[0].Status, Is.EqualTo("10"), "Status divergente.");

                    Assert.That(response.Data[0].InvoiceEnabled, Is.EqualTo("False"), "InvoiceEnabled divergente.");
                    Assert.That(response.Data[0].SnackbarEnabled, Is.EqualTo("True"), "SnackbarEnabled divergente.");
                    Assert.That(response.Data[0].IngressoSiteCode, Is.EqualTo("1173"), "IngressoSiteCode divergente.");
                    Assert.That(response.Data[0].SnackbarPOSCode, Is.EqualTo("75"), "SnackbarPOSCode divergente.");
                    Assert.That(response.Data[0].CNPJ, Is.EqualTo("00779721006778"), "CNPJ divergente.");
                    Assert.That(response.Data[0].ZipCode, Is.EqualTo("09111340"), "ZipCode divergente.");
                    Assert.That(response.Data[0].EconomicGroupId, Is.EqualTo(1), "EconomicGroupId divergente.");

                    test.Log(Status.Info, "Validação de tabela de preços.");
                    Assert.That(response.Content.Contains("PriceTableHTML"), "Status Code divergente.");
                    test.Log(Status.Pass, "Validação de tabela de preços verificada com sucesso.");
                    test.Log(Status.Info, "Validação realizada com sucesso de todos os campos e seus valores.");

                }
        
            }
            catch (Exception e)
            {
                test.Log(Status.Fail, e.ToString());
                throw new Exception("Falha ao validar dados de theaters: " + e.Message);
            }

        }

        [Test]
        public void ValidaDetalhesCinema()
        {

        }

    }

}



