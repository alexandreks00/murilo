﻿using System.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DemoRestSharp.Models.Users;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using RestSharp;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Reporter.Configuration;

namespace DemoRestSharp
{
    [TestFixture]
    public class Users
    {
        ExtentReports extent = null;

        [OneTimeSetUp]
        public void StartReport()
        {
            extent = new ExtentReports();
            var htmlReporter = new ExtentHtmlReporter(@"C:\Users\gqsilva\git\EcommerceBackendRestSharp\EcommerceBackend\Reports\result.html");
            extent.AttachReporter(htmlReporter);
        }

        [OneTimeTearDown]
        public void CloseReport()
        {
            extent.Flush();
        }

        [Test]
        public void ValidaInformacoesLoginUsuario()
        {
            ExtentTest test = null;
            test = extent.CreateTest("ValidaInformacoesLoginUsuario").Info("Início do teste");

            try
            {
                //Criando e enviando requisição
                test.Log(Status.Info, "Criando requisição.");
                var client = new RestClient(ConfigurationManager.AppSettings["dnsSensedia"]);
                var request = new RestRequest("bus/v1/users/login/byapp", Method.POST);
                request.RequestFormat = DataFormat.Json;
                request.AddJsonBody(new
                {
                    Email = "automaticusers@mailinator.com",
                    Password = "112233"
                }
                );
                test.Log(Status.Info, "Setando headers necessários para realizar a requisição.");
                utils.Utils.setCisToken(request);
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
            }
        }

        [Test]
        public void ValidaEsqueciMinhaSenha()
        {
            ExtentTest test = null;
            test = extent.CreateTest("ValidaEsqueciMinhaSenha").Info("Início do teste");

            try 
            {
                //Criando e enviando a requisição
                test.Log(Status.Info, "Criando requisição.");
                var client = new RestClient(ConfigurationManager.AppSettings["dnsSensedia"]);
                var request = new RestRequest("bus/v1/users/passwordrecovery", Method.POST);
                request.RequestFormat = DataFormat.Json;
                request.AddJsonBody(new
                {
                    Email = "gqsilvaa@mailinator.com"
                }
                );
                test.Log(Status.Info, "Setando headers necessários para realizar a requisição.");
                utils.Utils.setCisToken(request);
                test.Log(Status.Info, "Enviando requisição.");
                var response = client.Execute<ModelUsers>(request);


                //Início da validação
                test.Log(Status.Info, "Início das validações.");
                Assert.That((int)response.StatusCode, Is.EqualTo(200), "Status Code divergente.");
                test.Log(Status.Pass, "Teste ok, todas as verificações foram realizadas com sucesso.");

            }
            catch (Exception e)
            {
                test.Log(Status.Fail, e.ToString());
            }
            
        }

        [Test]
        public void ValidaMensagemCriticaLoginInvalido()
        {
            ExtentTest test = null;
            test = extent.CreateTest("ValidaEsqueciMinhaSenha").Info("Início do teste.");

            try {
                //Criando e enviando a requisição
                test.Log(Status.Info, "Criando requisição");
                var client = new RestClient(ConfigurationManager.AppSettings["dnsSensedia"]);
                var request = new RestRequest("bus/v1/users/login/byapp", Method.POST);
                request.RequestFormat = DataFormat.Json;
                request.AddJsonBody(new
                {
                    Email = "logininvalido@logininvalido.com",
                    Password = "112233"
                }
                );
                test.Log(Status.Info, "Setando headers necessários para realizar a requisição.");
                utils.Utils.setCisToken(request);
                test.Log(Status.Info, "Enviando requisição.");
                var response = client.Execute<ModelUsers>(request);

                //Início das validações
                test.Log(Status.Info, "Validando se o Status Code de retorno da requisição é 400.");
                Assert.That((int)response.StatusCode, Is.EqualTo(400), "Status Code divergente.");
                Assert.That(response.Data.Message, Is.EqualTo("Usuário ou Senha divergentes !"), "Valor da propriedade 'Message' divergente.");
            }
            catch(Exception e)
            {
                test.Log(Status.Fail, e.ToString());
            }
            
        }

        [Test]
        public void ValidaInformacoesUserId()
        {
            ExtentTest test = null;
            test = extent.CreateTest("ValidaInformacoesUserId").Info("Início do teste");

            try
            {
                string userId = "6947486";
                string authorizationToken = utils.Utils.getAuthorization("automaticusers@mailinator.com", "112233");

                //Criando e enviando requisição
                test.Log(Status.Info, "Criando requisição");
                var client = new RestClient(ConfigurationManager.AppSettings["dnsSensedia"]);
                var request = new RestRequest("bus/v1/users/" + userId, Method.GET);
                request.RequestFormat = DataFormat.Json;
                utils.Utils.setCisToken(request);
                test.Log(Status.Info, "Setando headers necessários para realizar a requisição");
                utils.Utils.setAuthorizationToken(request, authorizationToken);
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
                Assert.That(response.Data.Member.DateOfBirth, Is.EqualTo("1996-04-12T00:00:00Z"), "Valor da propriedade 'DateOfBirth' divergente.");
                Assert.That(response.Data.Member.CityId, Is.EqualTo("12789"), "Valor da propriedade 'CityId' divergente.");
                Assert.That(response.Data.Member.City.CityId, Is.EqualTo(12789), "Valor da propriedade 'City.CityId' divergente.");
                Assert.That(response.Data.City.Name, Is.EqualTo("Taguatinga"), "Valor da propriedade 'City.Name' divergente.");
                Assert.That(response.Data.Member.City.StateId, Is.EqualTo(7), "Valor da propriedade 'City.StateId' divergente.");
                Assert.That(response.Data.Member.City.State.Code, Is.EqualTo("DF"), "Valor da propriedade 'City.State.Code' divergente.");
                Assert.That(response.Data.Member.City.State.Name, Is.EqualTo("Distrito Federal"), "Valor da propriedade 'City.State.Name' divergente.");
                Assert.That(response.Data.Member.City.State.CountryId, Is.EqualTo(0), "Valor da propriedade 'City.State.CountryId' divergente.");
                Assert.That(response.Data.Member.Phone1, Is.EqualTo("11923236362525"), "Valor da propriedade 'Phone1' divergente.");
                test.Log(Status.Pass, "Teste ok, todas as verificações foram realizadas com sucesso.");
            }
            catch(Exception e)
            {
                test.Log(Status.Fail, e.ToString());
            }
            
        }

        [Test]
        public void ValidaCriacaoUsuario () 
        {
            ExtentTest test = null;
            test = extent.CreateTest("ValidaCriacaoUsuario").Info("Início do teste");

            try 
            {
                //Gerando um e-mail aleatório que será utilizado na criação do usuário
                test.Log(Status.Info, "Gerando e-mail aleatório que será utilizado no request de criação do usuário.");
                string email = utils.Utils.gerarEmailAleatorio(8);

                //Gerando um cpf aleatório que será utilizado na criação do usuário
                test.Log(Status.Info, "Gerando CPF aleatório que será utilizado no request de criação do usuário.");
                string cpf = utils.Utils.gerarCpf();



                //Criando a requisição responsável por criar um usuário
                test.Log(Status.Info, "Criando a requisição responsável por criar usuário.");
                var client = new RestClient(ConfigurationManager.AppSettings["dnsSensedia"]);
                var requestCriaUsuario = new RestRequest("bus/v1/users", Method.POST);
                requestCriaUsuario.RequestFormat = DataFormat.Json;

                //Montando o body da requisição que será enviada
                requestCriaUsuario.AddJsonBody(new
                {
                    AppInfo = new
                    {
                        deviceModel = "Moto G Play",
                        devicePlatform = "Android",
                        deviceUUID = "62a0391e-9b4c-4870-ba11-40896b488506",
                        version = "4.0.20",
                    },
                    DateOfBirth = "2002-11-04T00:00:00.000Z",
                    CardNumber = "",
                    City = new
                    {
                        CityId = 12789,
                        Name = "Taguatinga",
                        State = new
                        {
                            Code = "DF",
                            StateId = 7,
                            Name = "Distrito Federal"
                        },
                        StateId = 7
                    },
                    CityId = 12789,
                    CPF = cpf,
                    CpfNf = false,
                    Email = email,
                    EndUserPolicyId = 3,
                    Gender = "M",
                    Name = "Automatic Test",
                    NickName = "QA",
                    Password = "112233",
                    Phone1 = "1133333336"
                }
                );

                //Setando header de autenticação "X-CISIdentity"
                test.Log(Status.Info, "Setando headers necessários para realizar a requisição.");
                utils.Utils.setCisToken(requestCriaUsuario);

                //Enviando a requisição
                test.Log(Status.Info, "Enviando a requisição.");
                var responseCriaUsuario = client.Execute<ModelUsers>(requestCriaUsuario);

                //Validando Status Code de retorno da requisição
                test.Log(Status.Info, "Validando se o Status Code de retorno da requisição é 200.");
                Assert.That((int)responseCriaUsuario.StatusCode, Is.EqualTo(200), "Status Code divergente.");

                //Criando a requisição responsável por realizar login com o usuário recém criado
                test.Log(Status.Info, "Criando a requisição responsável por realizar login com o usuário recém criado.");
                var requestRealizaLogin = new RestRequest("bus/v1/users/login/byapp", Method.POST);
                requestRealizaLogin.RequestFormat = DataFormat.Json;

                //Montando o body da requisição que será enviada
                requestRealizaLogin.AddJsonBody(new
                {
                    Email = email,
                    Password = "112233"
                }
                );

                //Setando header de autenticação "X-CISIdentity"
                test.Log(Status.Info, "Setando os headers necessários para enviar a requisição.");
                utils.Utils.setCisToken(requestRealizaLogin);

                //Enviando a requisição realizando login com o usuário que acabou de ser criado
                var responseRealizaLogin = client.Execute<ModelUsers>(requestRealizaLogin);
                //
                //Inicio das validações
                test.Log(Status.Info, "Validando se o Status Code de retorno da requisição é 200.");
                Assert.That((int)responseRealizaLogin.StatusCode, Is.EqualTo(200), "Status Code divergente.");
                test.Log(Status.Info, "Validando o retorno das propriedades.");
                Assert.That(responseRealizaLogin.Data.Name, Is.EqualTo("Automatic Test"), "Valor da propriedade 'Name' divergente.");
                Assert.That(responseRealizaLogin.Data.NickName, Is.EqualTo("QA"), "Valor da propriedade 'NickName' divergente.");
                Assert.That(responseRealizaLogin.Data.Gender, Is.EqualTo("M"), "Valor da propriedade 'Gender' divergente.");
                Assert.That(responseRealizaLogin.Data.Email, Is.EqualTo(email), "Valor da propriedade 'Email' divergente.");
                Assert.That(responseRealizaLogin.Data.CPF, Is.EqualTo(cpf), "Valor da propriedade 'CPF' divergente.");
                Assert.That(responseRealizaLogin.Data.DateOfBirth, Is.EqualTo("2002-11-04T00:00:00Z"), "Valor da propriedade 'Member.DateOfBirth' divergente.");
                Assert.That(responseRealizaLogin.Data.CityId, Is.EqualTo("12789"), "Valor da propriedade 'Member.CityId' divergente.");
                Assert.That(responseRealizaLogin.Data.Member.City.CityId, Is.EqualTo(12789), "Valor da propriedade 'City.CityId' divergente.");
                Assert.That(responseRealizaLogin.Data.Member.City.Name, Is.EqualTo("Taguatinga"), "Valor da propriedade 'City.Name' divergente.");
                Assert.That(responseRealizaLogin.Data.Member.City.StateId, Is.EqualTo(7), "Valor da propriedade 'City.StateId' divergente.");
                Assert.That(responseRealizaLogin.Data.Member.City.State.Code, Is.EqualTo("DF"), "Valor da propriedade 'City.State.Code' divergente.");
                Assert.That(responseRealizaLogin.Data.Member.City.State.Name, Is.EqualTo("Distrito Federal"), "Valor da propriedade 'City.State.Name' divergente.");
                Assert.That(responseRealizaLogin.Data.Member.Phone1, Is.EqualTo("1133333336"), "Valor da propriedade 'Phone1' divergente.");
            }
            catch (Exception e) 
            {
                test.Log(Status.Fail, e.ToString());
            }
            
        }
    }
}
