using System.Configuration;
using System;
using EcommerceBackend.models.Loyalt;
using NUnit.Framework;
using RestSharp;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Reporter.Configuration;
using EcommerceBackend.utils;
using System.Collections.Generic;
using System.IO;

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
            var htmlReporter = new ExtentHtmlReporter(@"C:\AutomationTools\EcommerceBackendReports\Reports\Loyalty\");
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
                var client = new RestClient(ConfigurationManager.AppSettings["dnsSensedia"]);
                var requestConsultaCPF = new RestRequest(ConfigurationManager.AppSettings["SensediaValidate"], Method.POST);
                requestConsultaCPF.RequestFormat = DataFormat.Json;
                requestConsultaCPF.AddJsonBody(new
                {
                    cpf = cpfGerado,
                    orderNumber = "112233"
                }
                );
                test.Log(Status.Info, "Setando headers necessários para realizar a requisição.");
                utils.Utils.setCisToken(requestConsultaCPF);
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
                var client = new RestClient(ConfigurationManager.AppSettings["dnsSensedia"]);
                var requestConsultaCPF = new RestRequest(ConfigurationManager.AppSettings["SensediaRegister"], Method.POST);
                requestConsultaCPF.RequestFormat = DataFormat.Json;
                requestConsultaCPF.AddJsonBody(new
                {
                    cpf = cpfGerado,
                    orderNumber = "332211"
                }
                );
                test.Log(Status.Info, "Setando headers necessários para realizar a requisição.");
                utils.Utils.setCisToken(requestConsultaCPF);
                test.Log(Status.Info, "Enviando requisição.");
                var responseConsultaCPF = client.Execute<ModelLoyalty>(requestConsultaCPF);

                //Início das validações
                test.Log(Status.Info, "Validando se o Status Code de retorno da requisição é 200.");
                Assert.That((int)responseConsultaCPF.StatusCode, Is.EqualTo(200), "Status Code divergente.");
                test.Log(Status.Info, "Validando se o valor da propriedade 'ok' é igual a 'true'");
                Assert.That(responseConsultaCPF.Data.Ok, Is.EqualTo(true), "Valor da propriedade 'Ok' divergente.");
                test.Log(Status.Info, "Validando se o valor da propriedade 'messages' esta vazio");
                Assert.That(responseConsultaCPF.Data.Messages, Is.EqualTo(""), "Valor da propriedade 'messages' divergente.");

                using (StreamWriter UsuarioNLP = File.AppendText(@"C:\Users\alexa\CSharpProjects\backend\EcommerceBackendRestSharp\EcommerceBackend\utils\UsuariosNLP\RegistrarUsuarios.txt"))
                {
                    UsuarioNLP.WriteLine("Email: " + responseConsultaCPF.Data.Email + " Senha: "+ responseConsultaCPF.Data.Password);

                }
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
                var client = new RestClient(ConfigurationManager.AppSettings["dnsSensedia"]);
                var requestConsultaCPF = new RestRequest(ConfigurationManager.AppSettings["SensediaRegister"], Method.POST);
                requestConsultaCPF.RequestFormat = DataFormat.Json;
                requestConsultaCPF.AddJsonBody(new
                {
                    cpf = cpfGerado,
                    orderNumber = "332211"
                }
                );
                test.Log(Status.Info, "Setando headers necessários para realizar a requisição.");
                utils.Utils.setCisToken(requestConsultaCPF);
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

        [Test]

        public void RegistrarUsuariosCPFDuplicado()
        {


            ExtentTest test = null;
            test = extent.CreateTest("Registrar CPF's SEM Adesão").Info("Início do teste.");
            string cpfGerarRUSR1 = utils.Utils.gerarCpf();            
            string[] cpfGerado = new string[] { cpfGerarRUSR1, cpfGerarRUSR1 };


            try
            {
                //Criando e enviando requisição
                test.Log(Status.Info, "Criando requisição.");
                var client = new RestClient(ConfigurationManager.AppSettings["dnsSensedia"]);
                var requestConsultaCPF = new RestRequest(ConfigurationManager.AppSettings["SensediaRegister"], Method.POST);
                requestConsultaCPF.RequestFormat = DataFormat.Json;
                requestConsultaCPF.AddJsonBody(new
                {
                    cpf = cpfGerado,
                    orderNumber = "332211"
                }
                );
                test.Log(Status.Info, "Setando headers necessários para realizar a requisição.");
                utils.Utils.setCisToken(requestConsultaCPF);
                test.Log(Status.Info, "Enviando requisição.");
                var responseConsultaCPF = client.Execute<ModelLoyalty>(requestConsultaCPF);

                //Início das validações
                test.Log(Status.Info, "Validando se o Status Code de retorno da requisição é 200.");
                Assert.That((int)responseConsultaCPF.StatusCode, Is.EqualTo(400), "Status Code divergente.");
                test.Log(Status.Info, "Validando se o valor da propriedade 'ok' é igual a 'true'");
                Assert.That(responseConsultaCPF.Data.Ok, Is.EqualTo(false), "Valor da propriedade 'Ok' divergente.");
                test.Log(Status.Info, "Validando o valor da propriedade 'messages' para CPF's duplicados");
                Assert.That(responseConsultaCPF.Data.Messages[0], Is.EqualTo("CPF(s) '"+cpfGerarRUSR1+"' duplicado(s)!"), "Valor da propriedade 'messages' divergente.");

                test.Log(Status.Pass, "Teste ok, todas as verificações foram realizadas com sucesso.");


            }
            catch (Exception e)
            {
                test.Log(Status.Fail, e.ToString());
                throw new Exception("Falha ao validar contrato: " + e.Message);
            }

        }

        [Test]

        public void ValidaExibePlanosNlp()
        {


            ExtentTest test = null;
            test = extent.CreateTest("ValidaExibePlanosNlp").Info("Início do teste.");

            try
            {
                //Criando e enviando requisição
                test.Log(Status.Info, "Criando requisição.");
                var client = new RestClient(ConfigurationManager.AppSettings["dnsSensedia"]);
                var request = new RestRequest("loyalty/v1/plans", Method.GET);
                request.RequestFormat = DataFormat.Json;

                test.Log(Status.Info, "Setando headers necessários para realizar a requisição.");
                utils.Utils.setCisToken(request);
                test.Log(Status.Info, "Enviando requisição.");
                var response = client.Execute<List<ModelLoyalty>>(request);


                string responseContent = response.Content.ToString();

                string[] properties = new string[] { "\"id\":", "\"name\":", "\"description\":", "\"buttonDescription\":", "\"benefits\":"
                , "\"type\":", "\"description\":", "\"asset\":", "\"asset\":", "\"url\":", "\"price\":"
                , "\"chargeType\":", "\"asset\":", "\"url\":"};


                test.Log(Status.Info, "Início de validações da string properties.");
                for (int i = 0; i < properties.Length; i++)
                {
                    int qtdCampos = properties.Length;
                    string indiceZero = properties[0];
                    if (qtdCampos != 14)
                    {
                        test.Log(Status.Fail, "Contrato de validação de NLP incompleto!");

                    }
                    else if (indiceZero != "\"id\":")
                    {
                        test.Log(Status.Fail, "Contrato Inexistente");
                    }

                }
                test.Log(Status.Info, "String properties validada com sucesso.");


                //Início das validações
                test.Log(Status.Info, "Validando se o Status Code de retorno da requisição é 200.");
                Assert.That((int)response.StatusCode, Is.EqualTo(200), "Status Code divergente.");
                test.Log(Status.Info, "Valida Contrato de NLP");
                Utils.validaContrato(properties, responseContent, test);
                test.Log(Status.Info, "Contrato NLP validado com sucesso.");


                test.Log(Status.Info, "Início da validação de NLP.");

                if (response.Data[0].id == null || response.Data[0].id == "")
                {
                    test.Log(Status.Fail, "Plano Inexistente!");
                }
                else if (response.Data[0].id != null && response.Data[0].id != "")
                {
                    Assert.That(response.Data[0].id, Is.EqualTo("20261086-432f-443e-a650-c9ccb8d7acaa"), "id divergente.");
                    Assert.That(response.Data[0].name, Is.EqualTo("Fã de carteirinha"), "name divergente.");
                    Assert.That(response.Data[0].buttonDescription, Is.EqualTo("Quero ser fã de carteirinha"), "buttonDescription divergente.");
                    Assert.That(response.Data[0].price, Is.EqualTo(14.99), "price divergente.");
                    Assert.That(response.Data[0].benefits[0].description, Is.EqualTo("Ganhe um ingresso grátis por ano."), "benefits divergente.");
                }
                test.Log(Status.Pass, "Teste ok, todas as verificações foram realizadas com sucesso.");


            }
            catch (Exception e)
            {
                test.Log(Status.Fail, e.ToString());
                throw new Exception("Falha ao validar contrato: " + e.Message);
            }

        }

        [Test]

        public void ValidaExibeMenusNlp()
        {

            string email = "massanlp@mailinator.com";
            string authorizationToken = utils.Utils.getAuthorization(email, "112233");


            ExtentTest test = null;
            test = extent.CreateTest("ValidaConsultaSaldoCliente").Info("Início do teste.");

            try
            {
                //Criando e enviando requisição
                test.Log(Status.Info, "Criando requisição responsável por realizar login.");
                var client = new RestClient(ConfigurationManager.AppSettings["dnsSensedia"]);
                var request = new RestRequest("/loyalty/v1/balance", Method.GET);
                request.RequestFormat = DataFormat.Json;

                test.Log(Status.Info, "Setando headers necessários para realizar a requisição.");
                utils.Utils.setCisToken(request);
                utils.Utils.setAuthorizationToken(request, authorizationToken);

                test.Log(Status.Info, "Enviando requisição.");
                var response = client.Execute<List<ModelLoyalty>>(request);
                string responseContent = response.Content.ToString();


                //Início das validações
                test.Log(Status.Info, "Validando se o Status Code de retorno da requisição é 200.");
                Assert.That((int)response.StatusCode, Is.EqualTo(200), "Status Code divergente.");

                Assert.That(response.Data[0].category, Is.EqualTo("Fã sortudo"), "category divergente.");
                //Assert.That(response.Data[0].balance, Is.EqualTo(322.0), "category divergente.");
                //Assert.That(response.Data[0].expired, Is.EqualTo("False"), "expired divergente.");
                Assert.That(response.Data[0].menus[0].title, Is.EqualTo("Extrato"), "title divergente.");

                Assert.That(response.Data[0].menus[1].title, Is.EqualTo("Resgatar Prêmios"), "title divergente.");
                Assert.That(response.Data[0].menus[2].title, Is.EqualTo("Meus Resgates"), "title divergente.");
                Assert.That(response.Data[0].menus[3].title, Is.EqualTo("Atendimento"), "title divergente.");


                test.Log(Status.Info, "Verifica se existe a tag link no serviço.");
                Assert.That(responseContent.Contains("link"), "Não existe a tag link neste serviço.");
                test.Log(Status.Info, "Tag validada com sucesso.");

            }
            catch (Exception e)
            {
                test.Log(Status.Fail, e.ToString());
                throw new Exception("Falha ao validar contrato: " + e.Message);
            }

        }

        [Test]

        public void ValidaConsultaSaldoClienteInexistente()
        {

            string email = "automaticusers@mailinator.com";
            string authorizationToken = utils.Utils.getAuthorization(email, "112233");


            ExtentTest test = null;
            test = extent.CreateTest("ValidaExibeMenusNlp").Info("Início do teste.");

            try
            {
                //Criando e enviando requisição
                test.Log(Status.Info, "Criando requisição responsável por realizar login.");
                var client = new RestClient(ConfigurationManager.AppSettings["dnsSensedia"]);
                var request = new RestRequest("/loyalty/v1/balance", Method.GET);
                request.RequestFormat = DataFormat.Json;

                test.Log(Status.Info, "Setando headers necessários para realizar a requisição.");
                utils.Utils.setCisToken(request);


                test.Log(Status.Info, "Enviando requisição.");
                var response = client.Execute<ModelLoyalty>(request);


                //Início das validações
                test.Log(Status.Info, "Validando se o Status Code de retorno da requisição é 401.");
                Assert.That((int)response.StatusCode, Is.EqualTo(401), "Status Code divergente.");

                test.Log(Status.Info, "Autorização inválida validada com sucesso.");



            }
            catch (Exception e)
            {
                test.Log(Status.Fail, e.ToString());
                throw new Exception("Falha ao validar contrato: " + e.Message);
            }

        }

        [Test]

        public void ValidaConsultaSaldoCliente()
        {
            //Erro de massa, user expirado
            string email = "massanlp@mailinator.com";
            string authorizationToken = utils.Utils.getAuthorization(email, "112233");


            ExtentTest test = null;
            test = extent.CreateTest("ValidaConsultaSaldoCliente").Info("Início do teste.");

            try
            {
                //Criando e enviando requisição
                test.Log(Status.Info, "Criando requisição responsável por realizar login.");
                var client = new RestClient(ConfigurationManager.AppSettings["dnsSensedia"]);
                var request = new RestRequest("/loyalty/v1/balance", Method.GET);
                request.RequestFormat = DataFormat.Json;

                test.Log(Status.Info, "Setando headers necessários para realizar a requisição.");
                utils.Utils.setCisToken(request);
                utils.Utils.setAuthorizationToken(request, authorizationToken);

                test.Log(Status.Info, "Enviando requisição.");
                var response = client.Execute<List<ModelLoyalty>>(request);
                string responseContent = response.Content.ToString();


                //Início das validações
                test.Log(Status.Info, "Validando se o Status Code de retorno da requisição é 200.");
                Assert.That((int)response.StatusCode, Is.EqualTo(200), "Status Code divergente.");

                Assert.That(response.Data[0].category, Is.EqualTo("Fã sortudo"), "category divergente.");
                Utils.IsNullDouble(response.Data[0].balance);
                Assert.That(response.Data[0].expired, Is.EqualTo("False"), "expired divergente.");
                Assert.That(response.Data[0].menus[0].title, Is.EqualTo("Extrato"), "title divergente.");

                Assert.That(response.Data[0].menus[1].title, Is.EqualTo("Resgatar Prêmios"), "title divergente.");
                Assert.That(response.Data[0].menus[2].title, Is.EqualTo("Meus Resgates"), "title divergente.");
                Assert.That(response.Data[0].menus[3].title, Is.EqualTo("Atendimento"), "title divergente.");


                test.Log(Status.Info, "Verifica se existe a tag link no serviço.");
                Assert.That(responseContent.Contains("link"), "Não existe a tag link neste serviço.");
                test.Log(Status.Info, "Tag validada com sucesso.");







            }
            catch (Exception e)
            {
                test.Log(Status.Fail, e.ToString());
                throw new Exception("Falha ao validar contrato: " + e.Message);
            }

        }





    }
}
