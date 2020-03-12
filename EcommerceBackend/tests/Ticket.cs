﻿using System.Configuration;
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
    public class Ticket
    {
        ExtentReports extent = null;

        [OneTimeSetUp]
        public void StartReport()
        {
            extent = new ExtentReports();
            var htmlReporter = new ExtentHtmlReporter(@"C:\EcommerceBackendReports\Reports\Ticket\");
            extent.AttachReporter(htmlReporter);
        }

        [OneTimeTearDown]
        public void CloseReport()
        {
            extent.Flush();
        }

        [Test]
        public void ValidaTipoIngresso()
        {

            ExtentTest test = null;
            test = extent.CreateTest("ValidaTipoIngresso").Info("Início do teste.");

            try
            {
                //Criando e enviando requisição
                test.Log(Status.Info, "Criando requisição responsável por realizar login.");
                var client = new RestClient(ConfigurationManager.AppSettings["dnsSensedia"]);
                var request = new RestRequest("ticket/v1/types?TheaterId=688&SessionCode=031052EC-06B8-43DE-B95B-82A1950B2044", Method.GET);
                request.RequestFormat = DataFormat.Json;
                test.Log(Status.Info, "Setando headers necessários para realizar a requisição.");
                Utils.setCisToken(request);
                test.Log(Status.Info, "Enviando requisição.");
                var response = client.Execute(request);

                //Início das validações
                test.Log(Status.Info, "Validando se o Status Code de retorno da requisição é 200.");
                Assert.That((int)response.StatusCode, Is.EqualTo(200), "Status Code divergente.");

                string responseContent = response.Content.ToString();

                string[] properties = new string[] {"\"result\":", "\"internalId\":", "\"name\":", "\"price\":",
                 "\"service\":", "\"serviceType\":", "\"total\":", "\"maxQuantity\":", "\"messageHelp\":", "\"order\":", "\"typeId\":",
                 "\"typeName\":", "\"ticketAvailable\":", "\"partner\":", "\"dynamic\":"};

                test.Log(Status.Info,"Pré validação - Valida se existe o corpo do json");
                if (responseContent != null)
                {
                    test.Log(Status.Info, "Validando o retorno das propriedades.");
                    test.Log(Status.Info, "Validando o contrato.");
                    utils.Utils.validaContrato(properties, responseContent, test);
                    test.Log(Status.Info, "Termino de cenário com sucesso.");
                }
 
            }
            catch (Exception e)
            {
                test.Log(Status.Fail, e.ToString());
                throw new Exception("Falha ao validar dados de consulta de ingresso: " + e.Message);
            }
        }

        [Test]
        public void ValidaBinBradescoValido()
        {

            ExtentTest test = null;

            test = extent.CreateTest("ValidaBinBradescoValido").Info("Início do teste.");

            try
            {
                //Criando e enviando requisição
                test.Log(Status.Info, "Criando requisição responsável por realizar login.");
                var client = new RestClient(ConfigurationManager.AppSettings["dnsSensedia"]);
                var request = new RestRequest("ticket/v1/card/validate", Method.POST);
                request.RequestFormat = DataFormat.Json;

                request.AddJsonBody(new
                {
                    theater = "688",
                    code = "411111"
                }
               );
                test.Log(Status.Info, "Setando headers necessários para realizar a requisição.");
                Utils.setCisToken(request);
                test.Log(Status.Info, "Enviando requisição.");
                var response = client.Execute(request);

                //Início das validações
                test.Log(Status.Info, "Validando se o Status Code de retorno da requisição é 200.");
                Assert.That((int)response.StatusCode, Is.EqualTo(200), "Status Code divergente.");

                string responseContent = response.Content.ToString();

                string[] properties = new string[] {"\"transacao\":", "\"beneficios\":", "\"desconto\":", "\"descricao\":",
                 "\"id\":", "\"quantidade\":", "\"resgatado\":", "\"tipo\":", "\"validade\":", "\"codigo\":", "\"dataTransacao\":",
                 "\"especificacaoIngresso\":", "\"listaBeneficio\":", "\"mensagem\":", "\"mensagemFormatada\":", "\"metodo\":",
                 "\"offline\":", "\"permiteUpgrade\":", "\"sessao\":", "\"tid\":", "\"valorUpgradeDesconto\":", "\"valorUpgradeInteira\":"};

                test.Log(Status.Info, "Pré validação - Valida se existe o corpo do json");
                if (responseContent != null)
                {
                    test.Log(Status.Info, "Validando o retorno das propriedades.");
                    test.Log(Status.Info, "Validando o contrato.");
                    utils.Utils.validaContrato(properties, responseContent, test);
                    test.Log(Status.Info, "Contrato validado com sucesso.");
                }
                if (properties != null)
                {
                    test.Log(Status.Info, "Validando código de retorno.");

                    if (responseContent.Contains("\"transacao\":") && responseContent.Contains("\"codigo\":0"))
                    {
                        test.Log(Status.Info, "Código de retorno validado com sucesso.");
                    }
                    else
                    {
                        test.Log(Status.Fail, "Código Incorreto.");
                    }

                    test.Log(Status.Info, "Termino de cenário com sucesso.");
                }

               
            }
            catch (Exception e)
            {
                test.Log(Status.Fail, e.ToString());
                throw new Exception("Falha ao validar dados de consulta de ingresso: " + e.Message);
            }
        }

        [Test]
        public void ValidaBinBradescoInvalido()
        {

            ExtentTest test = null;

            test = extent.CreateTest("ValidaBinBradescoInvalido").Info("Início do teste.");

            try
            {
                //Criando e enviando requisição
                test.Log(Status.Info, "Criando requisição responsável por realizar login.");
                var client = new RestClient(ConfigurationManager.AppSettings["dnsSensedia"]);
                var request = new RestRequest("ticket/v1/card/validate", Method.POST);
                request.RequestFormat = DataFormat.Json;

                request.AddJsonBody(new
                {
                    theater = "688",
                    code = "999999"
                }
               );
                test.Log(Status.Info, "Setando headers necessários para realizar a requisição.");
                Utils.setCisToken(request);
                test.Log(Status.Info, "Enviando requisição.");
                var response = client.Execute(request);

                //Início das validações
                test.Log(Status.Info, "Validando se o Status Code de retorno da requisição é 200.");
                Assert.That((int)response.StatusCode, Is.EqualTo(200), "Status Code divergente.");

                string responseContent = response.Content.ToString();

                string[] properties = new string[] {"\"transacao\":", "\"beneficios\":", "\"desconto\":", "\"descricao\":",
                 "\"id\":", "\"quantidade\":", "\"resgatado\":", "\"tipo\":", "\"validade\":", "\"codigo\":", "\"dataTransacao\":",
                 "\"especificacaoIngresso\":", "\"listaBeneficio\":", "\"mensagem\":", "\"mensagemFormatada\":", "\"metodo\":",
                 "\"offline\":", "\"permiteUpgrade\":", "\"sessao\":", "\"tid\":", "\"valorUpgradeDesconto\":", "\"valorUpgradeInteira\":"};

                test.Log(Status.Info, "Pré validação - Valida se existe o corpo do json");
                if (responseContent != null)
                {
                    test.Log(Status.Info, "Validando o retorno das propriedades.");
                    test.Log(Status.Info, "Validando o contrato.");
                    utils.Utils.validaContrato(properties, responseContent, test);                            
                    test.Log(Status.Info, "Contrato validado com sucesso.");
                }
                if (properties != null)
                {
                    test.Log(Status.Info, "Validando código de retorno.");

                    if (responseContent.Contains("\"transacao\":") && responseContent.Contains("\"codigo\":1") && responseContent.Contains("\"mensagem\":\"Cartão Inválido!\""))
                    {
                        test.Log(Status.Info, "mensagem retorno de cartão inválido validado com sucesso.");
                    }
                    else
                    {
                        test.Log(Status.Fail, "Código ou mensagem fora do contexto acima.");
                    }

                    test.Log(Status.Info, "Termino de cenário com sucesso.");
                }


            }
            catch (Exception e)
            {
                test.Log(Status.Fail, e.ToString());
                throw new Exception("Falha ao validar dados de consulta de ingresso: " + e.Message);
            }
        }

    }
}