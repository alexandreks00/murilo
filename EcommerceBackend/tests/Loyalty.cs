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

        public void ValidarUsuarios()
        {


            ExtentTest test = null;
            test = extent.CreateTest("Consultar CPF's SEM Adesão").Info("Início do teste.");
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
                test.Log(Status.Info, "Validando se o valor da propriedade 'ok' é igual a 'true'");
                Assert.That(responseConsultaCPF.Data.Ok, Is.EqualTo(true), "Valor da propriedade 'Ok' divergente.");
                test.Log(Status.Info, "Validando se o valor da propriedade 'messages' esta vazio");
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

        public void RegistrarUsuarios()
        {


            ExtentTest test = null;
            test = extent.CreateTest("Registrar CPF's SEM Adesão").Info("Início do teste.");
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
                test.Log(Status.Info, "Validando se o valor da propriedade 'ok' é igual a 'true'");
                Assert.That(responseConsultaCPF.Data.Ok, Is.EqualTo(true), "Valor da propriedade 'Ok' divergente.");
                test.Log(Status.Info, "Validando se o valor da propriedade 'messages' esta vazio");
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

        public void RegistrarUsuariosJaCadastrados()
        {


            ExtentTest test = null;
            test = extent.CreateTest("Registrar CPF's COM Adesão").Info("Início do teste.");            
            string[] cpfGerado = new string[] { "34890392114", "73168669180" };


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
                test.Log(Status.Info, "Validando se o Status Code de retorno da requisição é 400.");
                Assert.That((int)responseConsultaCPF.StatusCode, Is.EqualTo(400), "Status Code divergente.");
                test.Log(Status.Info, "Validando se o valor da propriedade 'ok' é igual a 'false'");
                Assert.That(responseConsultaCPF.Data.Ok, Is.EqualTo(false), "Valor da propriedade 'Ok' divergente.");
                test.Log(Status.Info, "Validando o valor da propriedade 'messages' para o primeiro CPF informado");
                Assert.That(responseConsultaCPF.Data.Messages[0], Is.EqualTo("CPF '34890392114' Já possui plano de fidelidade associado!"), "Valor da propriedade 'messages' divergente.");
                test.Log(Status.Info, "Validando o valor da propriedade 'messages' para o segundo CPF informado");
                Assert.That(responseConsultaCPF.Data.Messages[1], Is.EqualTo("CPF '73168669180' Já possui plano de fidelidade associado!"), "Valor da propriedade 'messages' divergente.");

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
