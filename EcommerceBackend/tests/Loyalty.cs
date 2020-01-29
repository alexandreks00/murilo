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
    public class Loyalty
    {
        ExtentReports extent = null;

        [OneTimeSetUp]
        public void StartReport()
        {
            extent = new ExtentReports();
            var htmlReporter = new ExtentHtmlReporter(@"C:\EcommerceBackendReports\Reports\Loyalty\");
            extent.AttachReporter(htmlReporter);
        }

        [OneTimeTearDown]
        public void CloseReport()
        {
            extent.Flush();
        }

        [Test]

        public void ValidaUsuarioSemRegistro()
        {

            
            ExtentTest test = null;
            test = extent.CreateTest("ValidaConsultaDetalhesFilme").Info("Início do teste.");
            string cpfGerarVUSR1 = utils.Utils.gerarCpf();            
            string cpfGerarVUSR2 = utils.Utils.gerarCpf();
            string[] cpfGerado = new string[] { cpfGerarVUSR1, cpfGerarVUSR2 };       


            try
            {
                //Criando e enviando requisição
                test.Log(Status.Info, "Criando requisição.");
                var client = new RestClient(ConfigurationManager.AppSettings["dnsSensediaDEV"]);
                var requestConsultaCPF = new RestRequest(ConfigurationManager.AppSettings["SensediaValidateDEV"], Method.POST);
                requestConsultaCPF.RequestFormat = DataFormat.Json;
                requestConsultaCPF.AddJsonBody(new
                {
                    cpf = cpfGerado,
                    orderNumber = "112233"
                }
                );
                test.Log(Status.Info, "Setando headers necessários para realizar a requisição.");
                utils.Utils.setCisTokenDEV(requestConsultaCPF);
                test.Log(Status.Info, "Enviando requisição.");
                var responseConsultaCPF = client.Execute<ModelLoyalty>(requestConsultaCPF);

                //Início das validações
                test.Log(Status.Info, "Validando se o Status Code de retorno da requisição é 200.");

                Assert.That((int)responseConsultaCPF.StatusCode, Is.EqualTo(200), "Status Code divergente.");
                Assert.That(responseConsultaCPF.Data.Ok,Is.EqualTo(true), "Valor da propriedade 'Ok' divergente.");
                Assert.That(responseConsultaCPF.Data.Messages, Is.EqualTo(""), "Valor da propriedade 'messages' divergente.");

                test.Log(Status.Pass, "Teste ok, todas as verificações foram realizadas com sucesso.");


            }
            catch (Exception e)
            {
                test.Log(Status.Fail, e.ToString());
                throw new Exception("Falha ao validar contrato: " + e.Message);
            }

        }

        [Test]

        public void RegistrarUsuarioSemRegistro()
        {


            ExtentTest test = null;
            test = extent.CreateTest("ValidaConsultaDetalhesFilme").Info("Início do teste.");
            string cpfGerarRUSR1 = utils.Utils.gerarCpf();
            string cpfGerarRUSR2 = utils.Utils.gerarCpf();
            string[] cpfGerado = new string[] { cpfGerarRUSR1, cpfGerarRUSR2 };


            try
            {
                //Criando e enviando requisição
                test.Log(Status.Info, "Criando requisição.");
                var client = new RestClient(ConfigurationManager.AppSettings["dnsSensediaDEV"]);
                var requestConsultaCPF = new RestRequest(ConfigurationManager.AppSettings["SensediaRegisterDEV"], Method.POST);
                requestConsultaCPF.RequestFormat = DataFormat.Json;
                requestConsultaCPF.AddJsonBody(new
                {
                    cpf = cpfGerado,
                    orderNumber = "332211"
                }
                );
                test.Log(Status.Info, "Setando headers necessários para realizar a requisição.");
                utils.Utils.setCisTokenDEV(requestConsultaCPF);
                test.Log(Status.Info, "Enviando requisição.");
                var responseConsultaCPF = client.Execute<ModelLoyalty>(requestConsultaCPF);

                //Início das validações
                test.Log(Status.Info, "Validando se o Status Code de retorno da requisição é 200.");

                Assert.That((int)responseConsultaCPF.StatusCode, Is.EqualTo(200), "Status Code divergente.");
                Assert.That(responseConsultaCPF.Data.Ok, Is.EqualTo(true), "Valor da propriedade 'Ok' divergente.");
                Assert.That(responseConsultaCPF.Data.Messages, Is.EqualTo(""), "Valor da propriedade 'messages' divergente.");

                test.Log(Status.Pass, "Teste ok, todas as verificações foram realizadas com sucesso.");


            }
            catch (Exception e)
            {
                test.Log(Status.Fail, e.ToString());
                throw new Exception("Falha ao validar contrato: " + e.Message);
            }

        }


    }
}
