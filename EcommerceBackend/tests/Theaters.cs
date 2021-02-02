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
            var htmlReporter = new ExtentHtmlReporter(@"C:\AutomationTools\EcommerceBackendReports\Reports\Theaters\");
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
                    test.Log(Status.Info, "Teste OK");
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
            ExtentTest test = null;
            test = extent.CreateTest("ValidaDetalhesCinema").Info("Início do teste.");
            int theaterId = 785; 

            try
            {
                //Criando e enviando requisição
                test.Log(Status.Info, "Criando requisição responsável por realizar login.");
                var client = new RestClient(ConfigurationManager.AppSettings["dnsSensedia"]);
                var request = new RestRequest("bus/v1/theaters/"+theaterId, Method.GET);
                request.RequestFormat = DataFormat.Json;
                utils.Utils.setCisToken(request);
                test.Log(Status.Info, "Setando headers necessários para realizar a requisição.");

                var response = client.Execute<List<ModelDetalhesCinema>>(request);

                //Início das validações
                test.Log(Status.Info, "Validando se o Status Code de retorno da requisição é 200.");
                Assert.That((int)response.StatusCode, Is.EqualTo(200), "Status Code divergente.");
                
                test.Log(Status.Info, "Contrato validado em sua totalidade.");

                if (response.IsSuccessful)
                {
                    test.Log(Status.Info, "Validando dados de theater "+theaterId);

                    Assert.That(response.Data[0].Id, Is.EqualTo("3c3e464e-1d15-4f77-935d-951b81ad8892"), "Id divergente.");
                    Assert.That(response.Data[0].TheaterCode, Is.EqualTo("785"), "TheaterCode divergente.");
                    Assert.That(response.Data[0].TheaterCodePrime, Is.EqualTo("9"), "TheaterCode divergente.");
                    Assert.That(response.Data[0].Name, Is.EqualTo("Salvador Shopping"), "Name divergente.");
                    Assert.That(response.Data[0].Latitude, Is.EqualTo(-12.97681), "Latitude divergente.");
                    Assert.That(response.Data[0].Longitude, Is.EqualTo(-38.445869), "Longitude divergente.");
                    Assert.That(response.Data[0].Address1, Is.EqualTo("Avenida Tancredo Neves, 2915, Loja 3005"), "Address1 divergente.");
                    Assert.That(response.Data[0].CityId, Is.EqualTo(988), "CityId divergente.");
                    Assert.That(response.Data[0].StateId, Is.EqualTo("5"), "StateId divergente.");
                    Assert.That(response.Data[0].Phone1, Is.EqualTo("(71) 3023-3916"), "Phone1 divergente.");
                    Assert.That(response.Data[0].Status, Is.EqualTo(10), "Status divergente.");
                    Assert.That(response.Data[0].InvoiceEnabled, Is.EqualTo("False"), "InvoiceEnabled divergente.");
                    Assert.That(response.Data[0].SnackbarEnabled, Is.EqualTo("True"), "SnackbarEnabled divergente.");
                    Assert.That(response.Data[0].IngressoSiteCode, Is.EqualTo("449"), "IngressoSiteCode divergente.");
                    Assert.That(response.Data[0].CNPJ, Is.EqualTo("00779721004139"), "CNPJ divergente.");
                    Assert.That(response.Data[0].ZipCode, Is.EqualTo("41820021"), "ZipCode divergente.");

                    Assert.That(response.Data[0].City[0].CityId, Is.EqualTo(988), "CityId divergente.");
                    Assert.That(response.Data[0].City[0].Name, Is.EqualTo("SALVADOR"), "Name divergente.");
                    Assert.That(response.Data[0].City[0].StateId, Is.EqualTo("5"), "StateId divergente.");
                    Assert.That(response.Data[0].City[0].IbgeCode, Is.EqualTo("2927408"), "IbgeCode divergente.");

                    Assert.That(response.Data[0].State[0].StateId, Is.EqualTo("5"), "StateId divergente.");
                    Assert.That(response.Data[0].State[0].Code, Is.EqualTo("BA"), "Code divergente.");
                    Assert.That(response.Data[0].State[0].Name, Is.EqualTo("Bahia"), "Name divergente.");
                    Assert.That(response.Data[0].State[0].CountryId, Is.EqualTo("1"), "CountryId divergente.");

                }

            }
            catch (Exception e)
            {
                test.Log(Status.Fail, e.ToString());
                throw new Exception("Falha ao validar dados de detalhes de theaters: " + e.Message);
            }

        }


        

        [Test]
        public void ValidaShowtimeTheater()
        {
            ExtentTest test = null;
            test = extent.CreateTest("ValidaShowtimeTheater").Info("Início do teste.");


            try
            {

                //Criando e enviando requisição
                test.Log(Status.Info, "Criando requisição responsável por realizar login.");
                var client = new RestClient(ConfigurationManager.AppSettings["dnsSensedia"]);
                var request = new RestRequest("showtime/theater/785", Method.GET);
                request.RequestFormat = DataFormat.Json;
                utils.Utils.setCisToken(request);
                test.Log(Status.Info, "Setando headers necessários para realizar a requisição.");

                var response = client.Execute<List<ModelTheater>>(request);

                string responseContent = response.Content.ToString();
                //Declarando as propriedades que deverão obrigatoriamente estar na resposta da requisição
                string[] properties = new string[] { "\"id\":", "\"ShowTimeId\":", "\"cm\":", "\"tht\":",
                "\"mov\":", "\"aud\":", "\"xd\":", "\"prime\":", "\"dbox\":", "\"d3d\":", "\"psl\":",
                "\"mov\":", "\"aud\":", "\"xd\":", "\"prime\":", "\"dbox\":", "\"d3d\":", "\"pre\":", "\"psl\":",
                "\"deb\":", "\"time\":", "\"loc\":", "\"MoviePrintCode\":", "\"IsSessionExpired\":", "\"TheaterAllow\":" ,
                "\"Utc\":", "\"level\":", "\"Suggestions\":", "\"SnackCategoryId\":" ,"\"SnackCategoryIconUrl\":"};


                //Início das validações
                test.Log(Status.Info, "Validando se o Status Code de retorno da requisição é 200.");
                Assert.That((int)response.StatusCode, Is.EqualTo(200), "Status Code divergente.");
                test.Log(Status.Info, "Validando se o contrato esta ok.");
                Utils.validaContrato(properties, responseContent, test);
                test.Log(Status.Info, "Todos os campos do contrato estão ok.");

            }
            catch (Exception e)
            {
                test.Log(Status.Fail, e.ToString());
                throw new Exception("Falha ao validar dados de detalhes de salas full de theaters: " + e.Message);
            }

        }

        [Test]
        public void ValidaConsultaSalaEspecifica()
        {
            ExtentTest test = null;
            test = extent.CreateTest("ValidaConsultaSalaEspecifica").Info("Início do teste.");

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
                    test.Log(Status.Info, "Validando a posição 0 da lista de cinemas.");

                    if (response.Data[0].TheaterCode == null || response.Data[0].TheaterCode == "")
                    {
                        test.Log(Status.Fail, "Cinema Inexistente!");
                    }
                    test.Log(Status.Info, "Validando a sala específica na posição [0].");
                    Assert.That(response.Data[0].Auditoriums[0].TheaterCode, Is.EqualTo("716"), "TheaterCode divergente.");
                    Assert.That(response.Data[0].Auditoriums[0].Description, Is.EqualTo(""), "Description divergente.");
                    Assert.That(response.Data[0].Auditoriums[0].AuditoriumCode, Is.EqualTo("4"), "AuditoriumCode divergente.");
                    Assert.That(response.Data[0].Auditoriums[0].TotalSeats, Is.EqualTo("133"), "TotalSeats divergente.");
                    Assert.That(response.Data[0].Auditoriums[0].Xd, Is.EqualTo(false), "XD divergente.");
                    Assert.That(response.Data[0].Auditoriums[0].Prime, Is.EqualTo(false), "Prime divergente.");
                    Assert.That(response.Data[0].Auditoriums[0].Dbox, Is.EqualTo(false), "DBOX divergente.");
                    Assert.That(response.Data[0].Auditoriums[0].DboxDescription, Is.EqualTo(""), "DboxDescription divergente.");
                    Assert.That(response.Data[0].Auditoriums[0].Status, Is.EqualTo("10"), "Status divergente.");

                    test.Log(Status.Info, "Sala específica validada com sucesso.");

                }
            }
            catch (Exception e)
            {
                test.Log(Status.Fail, e.ToString());
                throw new Exception("Falha ao validar sala específica!" + e.Message);
            }

        }


        [Test]
        public void ValidaConsultaSalasDoCinema()
        {
            ExtentTest test = null;
            test = extent.CreateTest("ValidaConsultaSalasDoCinema").Info("Início do teste.");

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

                test.Log(Status.Info, "Validando se o Status Code de retorno da requisição é 200.");
                if (response.IsSuccessful)
                {
                    test.Log(Status.Info, "Validando a posição de 0 a 3 da lista de cinemas - salas.");

                    //if (response.Data[0].Auditoriums[0].TheaterCode != null && response.Data[0].Auditoriums[0].TheaterCode != "")
                    //{
                    //    test.Log(Status.Info, "Validando a sala específica na posição [0].");
                    //    Assert.That(response.Data[0].Auditoriums[0].TheaterCode, Is.EqualTo("716"), "TheaterCode divergente.");
                    //    Assert.That(response.Data[0].Auditoriums[0].Description, Is.EqualTo(""), "Description divergente.");
                    //    Assert.That(response.Data[0].Auditoriums[0].AuditoriumCode, Is.EqualTo("4"), "AuditoriumCode divergente.");
                    //    Assert.That(response.Data[0].Auditoriums[0].TotalSeats, Is.EqualTo("133"), "TotalSeats divergente.");
                    //    Assert.That(response.Data[0].Auditoriums[0].XD, Is.EqualTo("False"), "XD divergente.");
                    //    Assert.That(response.Data[0].Auditoriums[0].Prime, Is.EqualTo("False"), "Prime divergente.");
                    //    Assert.That(response.Data[0].Auditoriums[0].DBOX, Is.EqualTo("False"), "DBOX divergente.");
                    //    Assert.That(response.Data[0].Auditoriums[0].DboxDescription, Is.EqualTo(""), "DboxDescription divergente.");
                    //    Assert.That(response.Data[0].Auditoriums[0].Status, Is.EqualTo("10"), "Status divergente.");
                    //}
                    //else if (response.Data[0].Auditoriums[1].TheaterCode != null && response.Data[0].Auditoriums[1].TheaterCode != "")
                    //{
                    //    test.Log(Status.Info, "Validando a sala específica na posição [1].");
                    //    Assert.That(response.Data[0].Auditoriums[1].TheaterCode, Is.EqualTo("2115"), "TheaterCode divergente.");
                    //    Assert.That(response.Data[0].Auditoriums[1].Description, Is.EqualTo(""), "Description divergente.");
                    //    Assert.That(response.Data[0].Auditoriums[1].AuditoriumCode, Is.EqualTo("5"), "AuditoriumCode divergente.");
                    //    Assert.That(response.Data[0].Auditoriums[1].TotalSeats, Is.EqualTo("214"), "TotalSeats divergente.");
                    //    Assert.That(response.Data[0].Auditoriums[1].XD, Is.EqualTo("False"), "XD divergente.");
                    //    Assert.That(response.Data[0].Auditoriums[1].Prime, Is.EqualTo("False"), "Prime divergente.");
                    //    Assert.That(response.Data[0].Auditoriums[1].DBOX, Is.EqualTo("False"), "DBOX divergente.");
                    //    Assert.That(response.Data[0].Auditoriums[1].DboxDescription, Is.EqualTo(""), "DboxDescription divergente.");
                    //    Assert.That(response.Data[0].Auditoriums[1].Status, Is.EqualTo("10"), "Status divergente.");
                    //}
                    //else if (response.Data[0].Auditoriums[2].TheaterCode != null && response.Data[0].Auditoriums[2].TheaterCode != "")
                    //{
                    //    test.Log(Status.Info, "Validando a sala específica na posição [2].");
                    //    Assert.That(response.Data[0].Auditoriums[2].TheaterCode, Is.EqualTo("2115"), "TheaterCode divergente.");
                    //    Assert.That(response.Data[0].Auditoriums[2].Description, Is.EqualTo(""), "Description divergente.");
                    //    Assert.That(response.Data[0].Auditoriums[2].AuditoriumCode, Is.EqualTo("1"), "AuditoriumCode divergente.");
                    //    Assert.That(response.Data[0].Auditoriums[2].TotalSeats, Is.EqualTo("409"), "TotalSeats divergente.");
                    //    Assert.That(response.Data[0].Auditoriums[2].XD, Is.EqualTo("True"), "XD divergente.");
                    //    Assert.That(response.Data[0].Auditoriums[2].Prime, Is.EqualTo("False"), "Prime divergente.");
                    //    Assert.That(response.Data[0].Auditoriums[2].DBOX, Is.EqualTo("False"), "DBOX divergente.");
                    //    Assert.That(response.Data[0].Auditoriums[2].DboxDescription, Is.EqualTo(""), "DboxDescription divergente.");
                    //    Assert.That(response.Data[0].Auditoriums[2].Status, Is.EqualTo("10"), "Status divergente.");
                    //}
                    //else if (response.Data[0].Auditoriums[3].TheaterCode != null && response.Data[0].Auditoriums[3].TheaterCode != "")
                    //{
                    //    test.Log(Status.Info, "Validando a sala específica na posição [3].");
                    //    Assert.That(response.Data[0].Auditoriums[3].TheaterCode, Is.EqualTo("2115"), "TheaterCode divergente.");
                    //    Assert.That(response.Data[0].Auditoriums[3].Description, Is.EqualTo(""), "Description divergente.");
                    //    Assert.That(response.Data[0].Auditoriums[2].AuditoriumCode, Is.EqualTo("1"), "AuditoriumCode divergente.");
                    //    Assert.That(response.Data[0].Auditoriums[3].TotalSeats, Is.EqualTo("201"), "TotalSeats divergente.");
                    //    Assert.That(response.Data[0].Auditoriums[3].XD, Is.EqualTo("False"), "XD divergente.");
                    //    Assert.That(response.Data[0].Auditoriums[3].Prime, Is.EqualTo("False"), "Prime divergente.");
                    //    Assert.That(response.Data[0].Auditoriums[3].DBOX, Is.EqualTo("False"), "DBOX divergente.");
                    //    Assert.That(response.Data[0].Auditoriums[3].DboxDescription, Is.EqualTo(""), "DboxDescription divergente.");
                    //    Assert.That(response.Data[0].Auditoriums[3].Status, Is.EqualTo("10"), "Status divergente.");
                    

                }

            }
            catch (Exception e)
            {
                test.Log(Status.Fail, e.ToString());
                throw new Exception("Falha ao validar dados de salas de indices 0 a 3: " + e.Message);
            }

        }
    }

}



