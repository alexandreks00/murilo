using System.Configuration;
using System;
using NUnit.Framework;
using RestSharp;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Reporter.Configuration;
using EcommerceBackend.models.SuperSaver;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using EcommerceBackend.utils;




namespace EcommerceBackend
{
    [TestFixture]
    public class SuperSaver
    {
        ExtentReports extent = null;

        [OneTimeSetUp]
        public void StartReport()
        {
            extent = new ExtentReports();
            var htmlReporter = new ExtentHtmlReporter(@"C:\EcommerceBackendReports\Reports\SuperSaver\");
            extent.AttachReporter(htmlReporter);
        }

        [OneTimeTearDown]
        public void CloseReport()
        {
            extent.Flush();
        }

        [Test]
        public void ValidaSuperSaverValidate()
        {
            ExtentTest test = null;
            var codValido = "02T5HNLK0";
            var codInvalido = "02QAKGA89";
            test = extent.CreateTest("ValidaSuperSaverValidate").Info("Início do teste.");

            try
            {
                //Criando e enviando requisição
                test.Log(Status.Info, "Criando requisição responsável por realizar login.");
                var client = new RestClient(ConfigurationManager.AppSettings["dnsSensedia"]);
                var request = new RestRequest("ticket/v1/supersaver/validate", Method.POST);
                request.RequestFormat = DataFormat.Json;

                request.AddJsonBody(new
                {
                    code = codValido,
                    saleChannel = "0",
                    theater = "688",
                    movie = "2200",
                    theaterRoom = "1",
                    sessionType = "1",
                    sessionDate = "2018-05-09T10:56:04.941Z",
                    seatNumber = "1",
                    seatType = "1"
                }
                );
                test.Log(Status.Info, "Setando headers necessários para realizar a requisição.");
                utils.Utils.setCisToken(request);
                test.Log(Status.Info, "Enviando requisição.");
                var response = client.Execute<ModelSuperSaver>(request);

                string responseContent = response.Content.ToString();

                string[] properties = new string[] { "\"transacao\":", "\"beneficios\":", "\"codigo\":", "\"dataTransacao\":",
                "\"especificacaoIngresso\":", "\"codigo\":", "\"desconto\":", "\"isencaoTaxaConveniencia\":", "\"nome\":", "\"nomeCurto\":", "\"perfilId\":",
                "\"valorFinal\":", "\"valorNominal\":", "\"venda\":", "\"codigoCliente\":", "\"id\":", "\"nomeFantasia\":", "\"razaoSocial\":", "\"listaBeneficio\":",
                "\"mensagem\":", "\"mensagemFormatada\":", "\"metodo\":", "\"offline\":", "\"permiteUpgrade\":", "\"sessao\":" ,
                "\"canalVenda\":", "\"cinema\":", "\"filme\":", "\"inicio\":" ,"\"lugar\":", "\"numeracao\":", "\"lugar\":", "\"tid\":", "\"valorUpgradeDesconto\":", "\"valorUpgradeInteira\":"};



                //Início das validações
                test.Log(Status.Info, "Validando se o Status Code de retorno da requisição é 200.");
                Assert.That((int)response.StatusCode, Is.EqualTo(200), "Status Code divergente.");

                test.Log(Status.Info, "Validando o retorno das propriedades.");
                test.Log(Status.Info, "Validando o contrato.");
                utils.Utils.validaContrato(properties, responseContent, test);
                test.Log(Status.Info, "Valida a mensagem de retorno do SUPERSAVER.");
                Assert.That(response.Content.Contains("\"mensagem\":\"Convite inválido ou código incorreto.\""), "Status Code divergente.");
                test.Log(Status.Info, "Mensagem validada com sucesso!");
            }
            catch (Exception e)
            {
                test.Log(Status.Fail, e.ToString());
                throw new Exception("Falha ao validar dados do login do usuário: " + e.Message);
            }
        }

    }
}
