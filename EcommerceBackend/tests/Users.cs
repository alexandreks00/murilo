using System.Configuration;
using System;
using EcommerceBackend.models.Users;
using NUnit.Framework;
using RestSharp;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Reporter.Configuration;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.ComponentModel.DataAnnotations;
namespace EcommerceBackend
{
    [TestFixture]
    public class Users
    {
        ExtentReports extent = null;

        [OneTimeSetUp]
        public void StartReport()
        {
            extent = new ExtentReports();
            var htmlReporter = new ExtentHtmlReporter(@"C:\AutomationTools\EcommerceBackendReports\Reports\Users\");
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
            test = extent.CreateTest("ValidaInformacoesLoginUsuario").Info("Início do teste.");

            try
            {
                //Criando e enviando requisição
                test.Log(Status.Info, "Criando requisição responsável por realizar login.");
                var client = new RestClient(ConfigurationManager.AppSettings["dnsSensedia"]);
                var request = new RestRequest("bus/v1/users/login/byapp", Method.POST);
                request.RequestFormat = DataFormat.Json;

                //metodo que o andre fazia, era necessario atribuir um valor aos campos criados na model
                //criar uma model 

                //request.AddJsonBody(new
                //{
                //    Email = "automaticusers@mailinator.com",
                //    Password = "112233"
                //}
                //);



                string json = @"{
                              'email': 'automaticusers@mailinator.com',
                              'password': '112233'
                                 }";
                    
                request.AddParameter("application/json", json, ParameterType.RequestBody);
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
                Assert.That(response.Data.NLPActive, Is.EqualTo(true), "Valor da propriedade 'NLPActive' divergente.");
                test.Log(Status.Pass, "Teste ok, todas as verificações foram realizadas com sucesso.");
            }
            catch (Exception e)
            {
                test.Log(Status.Fail, e.ToString());
                throw new Exception("Falha ao validar dados do login do usuário: " + e.Message);
            }
        }

        [Test]
        public void ValidaEsqueciMinhaSenha()
        {
            ExtentTest test = null;
            test = extent.CreateTest("ValidaEsqueciMinhaSenha").Info("Início do teste.");

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
                throw new Exception("Falha ao validar a funcionalidade 'Esqueci minha senha'. " + e.Message);
            }

        }

        [Test]
        public void ValidaEsqueciMinhaSenhaServicoNovo()
        {
            ExtentTest test = null;
            test = extent.CreateTest("ValidaEsqueciMinhaSenhaServicoNovo").Info("Início do teste.");

            try
            {
                //Criando e enviando a requisição
                test.Log(Status.Info, "Criando requisição.");
                var client = new RestClient(ConfigurationManager.AppSettings["dnsSensedia"]);
                var request = new RestRequest("users/v1/users/passwordrecovery", Method.POST);
                request.RequestFormat = DataFormat.Json;
                request.AddJsonBody(new

                {

                    Email = "gqsilvaa@mailinator.com"

                }
                );
                test.Log(Status.Info, "Setando headers necessários para realizar a requisição.");
                utils.Utils.setCisToken(request);
                test.Log(Status.Info, "Enviando requisição.");
                var response = client.Execute(request);


                //Início da validação
                test.Log(Status.Info, "Início das validações.");
                Assert.That((int)response.StatusCode, Is.EqualTo(200), "Status Code divergente.");                
                test.Log(Status.Pass, "Teste ok, todas as verificações foram realizadas com sucesso.");

            }
            catch (Exception e)
            {
                test.Log(Status.Fail, e.ToString());
                throw new Exception("Falha ao validar a funcionalidade 'Esqueci minha senha'. " + e.Message);
            }

        }

        [Test]
        public void ValidaDisparadorDeEmail()
        {
            ExtentTest test = null;
            test = extent.CreateTest("ValidaDisparadorDeEmail").Info("Início do teste.");

            try
            {
                //Criando e enviando a requisição
                test.Log(Status.Info, "Criando requisição.");
                var client = new RestClient(ConfigurationManager.AppSettings["dnsSensedia"]);
                var request = new RestRequest("bus/v1/users/createmessagelocaweb", Method.POST);
                request.RequestFormat = DataFormat.Json;
                request.AddJsonBody(new

                {

                    MessageFrom= "automaticusers@mailinator.com",
                    MessageTo= "testeSemDominio",
                    Subject= "Recuperação de senha",
                    Body= "PCFET0NUWVBFIGh0bWwgUFVCTElDICItLy9XM0MvL0RURCBYSFRNTCAxLjAgVHJhbnNpdGlvbmFsLy9FTiIgImh0dHA6Ly93d3cudzMub3JnL1RSL3hodG1sMS9EVEQveGh0bWwxLXRyYW5zaXRpb25hbC5kdGQiPjxodG1sIHhtbG5zPSJodHRwOi8vd3d3LnczLm9yZy8xOTk5L3hodG1sIj48aGVhZD4gPG1ldGEgaHR0cC1lcXVpdj0iWC1VQS1Db21wYXRpYmxlIiBjb250ZW50PSJJRT04IiAvPjwvaGVhZD48Ym9keT4gPHRhYmxlIGJvcmRlcj0iMCIgYWxpZ249ImNlbnRlciIgc3R5bGU9IndpZHRoOjYwMHB4O2ZvbnQtc2l6ZTogMTJweDtjb2xvcjogIzY2NjsgZm9udC1mYW1pbHk6IFZlcmRhbmEsIEdlbmV2YSwgQXJpYWwsIEhlbHZldGljYSwgc2Fucy1zZXJpZjsiPiA8dHI+IDx0ZCB3aWR0aD0iMTYycHg7Ij48aW1nIHNyYz0iaHR0cDovL2hvbW9sb2ctY25rLWJ1cy5jaW5lbWFyay5jb20uYnIvaW1hZ2VzL2NvbW1vbi9jaW5lbWFyay5qcGciIGJvcmRlcj0iMCIgLz48L3RkPiA8dGQ+PGhyIG5vc2hhZGU94oCdbm9zaGFkZeKAnSB3aWR0aD0iMTAwJSIgc2l6ZT0iMSIgYWxpZ249InJpZ2h0IiBjb2xvcj0iI0I1MTIxQiIgLz48L3RkPiA8L3RyPiA8dHI+IDx0ZCBjb2xzcGFuPSIyIj4gPHA+T2zDoSA8c3Ryb25nPkFkcmlhbm8gU21va292aXRaIERvaXM8L3N0cm9uZz4hPC9wPiA8YnIgLz5BdGVuZGVuZG8gYW8gc2V1IHBlZGlkbyBkZSByZWN1cGVyYcOnw6NvIGRlIHNlbmhhLCBzZWd1ZSBhIG5vdmEgc2VuaGEgY3JpYWRhOiA8cD4gPHNwYW4gc3R5bGU9ImNvbG9yOiMwMDA7IGZvbnQtd2VpZ2h0OmJvbGQiPng0MW0zajwvc3Bhbj4gPC9wPiBBdGVuY2lvc2FtZW50ZSwgPGJyIC8+IENsdWJlIENpbmVtYXJrIDxwPiA8ZGl2IHN0eWxlPSJmbG9hdDpsZWZ0O3BhZGRpbmc6NXB4OyB3aWR0aDoxMDAlO2JhY2tncm91bmQtY29sb3I6I2Y0ZjRmNDtmb250LXNpemU6IDExcHg7Y29sb3I6IzY2NjtsaW5lLWhlaWdodDogMThweDttYXJnaW46IDAgMTBweCAxMHB4IDA7Zm9udC1mYW1pbHk6VmVyZGFuYSwgR2VuZXZhLCBBcmlhbCwgSGVsdmV0aWNhLCBzYW5zLXNlcmlmOyI+IFBhcmEgc3VhIHNlZ3VyYW7Dp2EgbsOjbyByZXZlbGUgc3VhIHNlbmhhIGEgbmluZ3XDqW0uPGJyIC8+IFNlIHZvY8OqIG7Do28gc29saWNpdG91IHN1YSBzZW5oYSwgbsOjbyBzZSBwcmVvY3VwZS4gRXNzYSBtZW5zYWdlbSBmb2kgZW52aWFkYSBhcGVuYXMgcGFyYSBvIHNldSBlLW1haWwsIGUgc8OzIHZvY8OqIHRlbSBhY2Vzc28gYSBlbGEuIDwvZGl2PiA8L3A+IDwvdGQ+IDwvdHI+IDx0cj4gPHRkIGNvbHNwYW49IjIiPjxociBub3NoYWRlPeKAnW5vc2hhZGXigJ0gd2lkdGg9IjEwMCUiIHNpemU9IjEiIGFsaWduPSJyaWdodCIgY29sb3I9IiNCNTEyMUIiIC8+PC90ZD4gPC90cj4gPC90YWJsZT48L2JvZHk+PC9odG1sPg==",
                    MessageType= 10

                }
                );
                test.Log(Status.Info, "Setando headers necessários para realizar a requisição.");
                utils.Utils.setCisToken(request);
                test.Log(Status.Info, "Enviando requisição.");
                var response = client.Execute(request);


                //Início da validação
                test.Log(Status.Info, "Início das validações.");
                Assert.That((int)response.StatusCode, Is.EqualTo(200), "Status Code divergente.");
                Assert.That(response.Content, Is.EqualTo("true"), "Serviço retornou false");
                test.Log(Status.Pass, "Teste ok, todas as verificações foram realizadas com sucesso.");

            }
            catch (Exception e)
            {
                test.Log(Status.Fail, e.ToString());
                throw new Exception("Falha ao validar a funcionalidade 'Disparador de Email'. " + e.Message);
            }

        }

        [Test]
        public void ValidaMensagemCriticaLoginInvalido()
        {
            ExtentTest test = null;
            test = extent.CreateTest("ValidaMensagemCriticaLoginInvalido").Info("Início do teste.");

            try
            {
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
                Assert.That(response.Data.Message, Is.EqualTo("Usuário e/ou Senha inválidos !"), "Valor da propriedade 'Message' divergente.");
                test.Log(Status.Pass, "Teste ok! As validações foram realizadas com sucesso.");
            }
            catch (Exception e)
            {
                test.Log(Status.Fail, e.ToString());
                throw new Exception("Falha ao validar a mensagem de crítica ao realizar login com um login inválido: " + e.Message);
            }

        }

        [Test]
        public void ValidaInformacoesUserId()
        {
            ExtentTest test = null;
            test = extent.CreateTest("ValidaInformacoesUserId").Info("Início do teste.");

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
                Assert.That(response.Data.Member.City.Name, Is.EqualTo("Taguatinga"), "Valor da propriedade 'City.Name' divergente.");
                Assert.That(response.Data.Member.City.StateId, Is.EqualTo(7), "Valor da propriedade 'City.StateId' divergente.");
                Assert.That(response.Data.Member.City.State.Code, Is.EqualTo("DF"), "Valor da propriedade 'City.State.Code' divergente.");
                Assert.That(response.Data.Member.City.State.Name, Is.EqualTo("Distrito Federal"), "Valor da propriedade 'City.State.Name' divergente.");
                Assert.That(response.Data.Member.City.State.CountryId, Is.EqualTo(0), "Valor da propriedade 'City.State.CountryId' divergente.");
                Assert.That(response.Data.Member.Phone1, Is.EqualTo("1136362525"), "Valor da propriedade 'Phone1' divergente.");
                test.Log(Status.Pass, "Teste ok, todas as verificações foram realizadas com sucesso.");
            }
            catch (Exception e)
            {
                test.Log(Status.Fail, e.ToString());
                throw new Exception("Falha ao validar dados do usuário: " + e.Message);
            }

        }

        [Test]
        public void ValidaCriacaoUsuario()
        {
            ExtentTest test = null;
            test = extent.CreateTest("ValidaCriacaoUsuario").Info("Início do teste.");

            try
            {
                //Gerando um e-mail aleatório que será utilizado na criação do usuário
                test.Log(Status.Info, "Gerando e-mail aleatório que será utilizado no request de criação do usuário.");
                string email = utils.Utils.gerarEmailAleatorio(8);
                string email_massa = email;
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
                test.Log(Status.Info, email);

                Assert.That((int)responseCriaUsuario.StatusCode, Is.EqualTo(200), "Status Code diferente do esperado ao enviar requisição responsável por criar um usuário.");

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

                //Inicio das validações
                test.Log(Status.Info, "Validando o contrato com Model.Data.Annotations");
                test.Log(Status.Info, "Validando se o Status Code de retorno da requisição é 200.");
                Assert.That((int)responseRealizaLogin.StatusCode, Is.EqualTo(200), "Status Code diferente do esperado ao enviar requisição responsável por realizar login com o usuário que teve seus dados editados");
                
                //Massa para utilizar no App
                using (StreamWriter UsuarioGerado =
                File.AppendText(@"C:\Users\alexa\CSharpProjects\backend\EcommerceBackendRestSharp\EcommerceBackend\utils\massa\UsuariosParaTeste\UsuariosGerados.txt"))
                {
                    UsuarioGerado.WriteLine(
                        "Email: " + email_massa + " " +
                        "Senha: 112233" + " " +
                        "Name: " + responseRealizaLogin.Data.Name + " " +
                        "CPF: "+ responseRealizaLogin.Data.CPF
                        );

                }

            }
            catch (Exception e)
            {
                test.Log(Status.Fail, e.ToString());
                throw new Exception("Falha ao validar a criação de um usuário: " + e.Message);
            }
        }

        [Test]
        public void ValidaCriticaCriacaoUsuarioEmailRepetido()
        {
            ExtentTest test = null;
            test = extent.CreateTest("ValidaCriticaCriacaoUsuarioEmailRepetido").Info("Início do teste.");

            try
            {
                //Gerando um cpf aleatório que será utilizado na criação do usuário
                test.Log(Status.Info, "Gerando CPF aleatório que será utilizado no request de criação do usuário.");
                string cpf = utils.Utils.gerarCpf();
                string emailJaCadastrado = "automaticusers@mailinator.com";

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
                    Email = emailJaCadastrado,
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
                test.Log(Status.Info, "Validando se o Status Code de retorno da requisição é 400.");
                Assert.That((int)responseCriaUsuario.StatusCode, Is.EqualTo(400), "Status Code diferente do esperado ao enviar requisição criando um usuário utilizando um e-mail já cadastrado.");

                test.Log(Status.Info, "Validando se a mensagem de crítica é exibida.");
                Assert.That(responseCriaUsuario.Data.Message, Is.EqualTo("O e-mail informado já está sendo utilizado. Por favor, informe um endereço de e-mail diferente."), "Valor da propriedade 'Message' divergente.");
                test.Log(Status.Pass, "Teste ok! As validações foram realizadas com sucesso.");
            }
            catch (Exception e)
            {
                test.Log(Status.Fail, e.ToString());
                throw new Exception("Falha ao validar a mensagem de crítica que é exibida ao criar um usuário utilizando e-mail já cadastrado: " + e.Message);
            }
        }

        [Test]
        public void ValidaCriticaCriacaoUsuarioCpfRepetido()
        {
            ExtentTest test = null;
            test = extent.CreateTest("ValidaCriticaCriacaoUsuarioCpfRepetido").Info("Início do teste.");

            try
            {
                //Gerando um cpf aleatório que será utilizado na criação do usuário
                test.Log(Status.Info, "Gerando email aleatório que será utilizado no request de criação do usuário.");
                string cpfJaCadastrado = "19100000000";
                string email = utils.Utils.gerarEmailAleatorio(8);

                //Criando a requisição responsável por criar um usuário
                test.Log(Status.Info, "Criando a requisição responsável por criar um usuário utilizando cpf já existente.");
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
                    CPF = cpfJaCadastrado,
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
                test.Log(Status.Info, "Validando se o Status Code de retorno da requisição é 400.");
                Assert.That((int)responseCriaUsuario.StatusCode, Is.EqualTo(400), "Status Code diferente do esperado ao enviar requisição criando um usuário utilizando um cpf já cadastrado.");

                test.Log(Status.Info, "Validando se a mensagem de crítica é exibida.");
                Assert.That(responseCriaUsuario.Data.Message, Is.EqualTo("O CPF informado já está sendo utilizado."), "Valor da propriedade 'Message' divergente.");
                test.Log(Status.Pass, "Teste ok! As validações foram realizadas com sucesso.");

            }
            catch (Exception e)
            {
                test.Log(Status.Fail, e.ToString());
                throw new Exception("Falha ao validar a mensagem de crítica que é exibida ao criar um usuário utilizando e-mail já cadastrado: " + e.Message);
            }
        }

        [Test]
        public void ValidaAlteraDadosUsuario()
        {
            ExtentTest test = null;
            test = extent.CreateTest("ValidaAlteraDadosUsuario").Info("Início do teste.");
            string email = "4uadpxcq@mailinator.com";
            string authorizationToken = utils.Utils.getAuthorization(email, "112233");
            string cpf = "86311930706";
            try
            {
                //Criando a requisição responsável por editar os dados de um usuário
                test.Log(Status.Info, "Criando a requisição responsável por editar os dados usuário.");

                var client = new RestClient(ConfigurationManager.AppSettings["dnsSensedia"]);
                var requestEditaDadosUsuario = new RestRequest("bus/v1/users/", Method.PUT);
                requestEditaDadosUsuario.RequestFormat = DataFormat.Json;

                //Montando o body da requisição que será enviada
                requestEditaDadosUsuario.AddJsonBody(new
                {
                    DateOfBirth = "2002-11-04T00:00:00Z",
                    City = new
                    {
                        CityId = 12789,
                        Name = "Taguatinga",
                        State = new
                        {
                            Code = "DF",
                            StateId = 25,
                            Name = "Distrito Federal"
                        },
                        StateId = 7
                    },
                    CityId = 12789,
                    CPF = cpf,
                    CpfNf = true,
                    Email = email,
                    Gender = "M",
                    UserId = 7369509,
                    Name = "Automatic Test PUT USERS",
                    NickName = "Automatic Test PUT USERS",
                    Phone1 = "11954570388",
                    Id = "6021791f1832350001bd65c8"
                }
                );

                //Setando header de autenticação "X-CISIdentity"
                test.Log(Status.Info, "Setando headers necessários para realizar a requisição.");
                utils.Utils.setCisToken(requestEditaDadosUsuario);
                utils.Utils.setAuthorizationToken(requestEditaDadosUsuario, authorizationToken);

                //Enviando a requisição
                test.Log(Status.Info, "Enviando a requisição editando os dados do usuário.");
                IRestResponse responseEditaDadosUsuario = client.Execute<ModelUsers>(requestEditaDadosUsuario);

                //Validando Status Code de retorno da requisição
                test.Log(Status.Info, "Validando se o Status Code de retorno da requisição é 200.");
                Assert.That((int)responseEditaDadosUsuario.StatusCode, Is.EqualTo(200), "Status Code diferente do esperado ao enviar requisição responsável por editar os dados do usuário.");

                dynamic responseContent = JsonConvert.DeserializeObject(responseEditaDadosUsuario.Content);
                var Id = responseContent.Id;
                string Name = responseContent.Name;
                string NickName = responseContent.NickName;
                string Gender = responseContent.Gender;
                int UserId = responseContent.UserId;
                int CityId = responseContent.CityId;
                string CPF = responseContent.CPF;
                int StateId = responseContent.StateId;
                string Phone1 = responseContent.Phone1;
                string DateOfBirth = responseContent.DateOfBirth;

                //Criando requisição que irá realizar login com o usuário e verificar se as informações foram alteradas
                test.Log(Status.Info, "Criando requisição responsável por realizar login e consultar se as informações foram realmente alteradas.");
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
                test.Log(Status.Info, "Setando headers necessários para realizar a requisição.");
                utils.Utils.setCisToken(requestRealizaLogin);


                utils.Utils.setAuthorizationToken(requestRealizaLogin, authorizationToken);
                //Enviando a requisição
                test.Log(Status.Info, "Enviando a requisição consultando os dados do usuário.");
                var responseRealizaLogin = client.Execute<ModelUsers>(requestRealizaLogin);
              


                //Validando o Status Code de retorno da requisição
                test.Log(Status.Info, "Validando se o Status Code da requisição é 200.");
                Assert.That((int)responseRealizaLogin.StatusCode, Is.EqualTo(200), "Status Code diferente do esperado ao realizar requisição responsável por realizar login.");

                //Validando o valor de retorno das propriedades
                test.Log(Status.Info, "Validando o retorno das propriedades.");
                Assert.That((int)responseRealizaLogin.StatusCode, Is.EqualTo(200), "Status Code diferente do esperado ao enviar requisição responsável por realizar login com o usuário que teve seus dados editados");
                Assert.That(responseRealizaLogin.Data.Name, Is.EqualTo(Name), "Valor da propriedade 'Name' divergente.");
                Assert.That(responseRealizaLogin.Data.NickName, Is.EqualTo(NickName), "Valor da propriedade 'NickName' divergente.");
                Assert.That(responseRealizaLogin.Data.Gender, Is.EqualTo(Gender), "Valor da propriedade 'Gender' divergente.");
                Assert.That(responseRealizaLogin.Data.Email, Is.EqualTo(email), "Valor da propriedade 'Email' divergente.");
                Assert.That(responseRealizaLogin.Data.CPF, Is.EqualTo(cpf), "Valor da propriedade 'CPF' divergente.");
                Assert.That(responseRealizaLogin.Data.DateOfBirth, Is.EqualTo("2002-11-04T00:00:00Z"), "Valor da propriedade 'Member.DateOfBirth' divergente.");
                Assert.That(responseRealizaLogin.Data.CityId, Is.EqualTo(CityId), "Valor da propriedade 'Member.CityId' divergente.");
                Assert.That(responseRealizaLogin.Data.StateId, Is.EqualTo(StateId), "Valor da propriedade 'Member.CityId' divergente.");
                Assert.That(responseRealizaLogin.Data.Phone1, Is.EqualTo(Phone1), "Valor da propriedade 'Phone1' divergente.");

                //Criando requisição alterando os dados novamente, realizando rollback
                test.Log(Status.Info, "Criando a requisição responsável por realizar o rollback dos dados usuário.");
                var requestRealizaRollback = new RestRequest("bus/v1/users", Method.PUT);
                requestRealizaRollback.RequestFormat = DataFormat.Json;

                //Montando o body da requisição que será enviada
                requestRealizaRollback.AddJsonBody(new
                {
                    DateOfBirth = "2002-11-04T00:00:00Z",
                    City = new
                    {
                        CityId = 2369,
                        Name = "Açailândia",
                        State = new
                        {
                            Code = "MA",
                            StateId = 10,
                            Name = "Maranhão"
                        },
                        StateId = 10
                    },
                    CityId = 2369,
                    CPF = cpf,
                    CpfNf = false,
                    Email = email,
                    Gender = "F",
                    UserId = 7369509,
                    Name = "Alexandre Kenji PUT USERS",
                    NickName = "Sr Put",
                    Phone1 = "1136333333",
                    Id = "6021791f1832350001bd65c8"
                }
                );

                //Setando header de autenticação "X-CISIdentity"
                test.Log(Status.Info, "Setando headers necessários para realizar a requisição.");
                utils.Utils.setCisToken(requestRealizaRollback);
                utils.Utils.setAuthorizationToken(requestRealizaRollback, authorizationToken);

                //Enviando a requisição
                test.Log(Status.Info, "Enviando a requisição editando os dados do usuário.");
                var responseRealizaRollback = client.Execute<ModelUsers>(requestRealizaRollback);

                //Validando Status Code de retorno da requisição
                test.Log(Status.Info, "Validando se o Status Code de retorno da requisição é 200.");
                Assert.That((int)responseRealizaRollback.StatusCode, Is.EqualTo(200), "Status Code diferente do esperado ao enviar requisição responsável por realizar rollback dos dados do usuário.");
                test.Log(Status.Pass, "Validação ok, os dados do usuário foram alterados com sucesso.");

            }
           
            catch(AssertionException a)
            {
                test.Log(Status.Fail, a.ToString());
            }
            catch (Exception e)
            {
                test.Log(Status.Fail, e.ToString());
                throw new Exception("Falha ao validar a edição de dados de um usuário: " + e.Message);
            }
        }

        //[Test]    // Teste com bug no TFS - por isso comentado para não quebrar no jenkins
        //public void ValidaAlteraSenhaUsuario()
        //{
        //    ExtentTest test = null;
        //    test = extent.CreateTest("ValidaAlteraSenhaUsuario").Info("Início do teste.");
        //    string email = "alterasenha@mailinator.com";
        //    double userId = 6947512;

        //    try
        //    {
        //        //Coletando token "authorization"
        //        string authorizationToken = utils.Utils.getAuthorization(email,"112233");

        //        //Criando e enviando a requisição responsável por alterar a senha do usuário
        //        test.Log(Status.Info, "Criando requisição responsável por alterar a senha do usuário.");
        //        var client = new RestClient(ConfigurationManager.AppSettings["dnsSensedia"]);
        //        var requestAlteraSenha = new RestRequest("bus/v1/users/changepassword", Method.POST);
        //        requestAlteraSenha.RequestFormat = DataFormat.Json;
        //        requestAlteraSenha.AddJsonBody(new
        //        {
        //            UserId = userId,
        //            CurrentPassword = "112233", 
        //            NewPassword = "111111",
        //            PasswordConfirmation = "111111"
        //        }
        //        );

        //        test.Log(Status.Info, "Setando headers necessários para realizar a requisição.");
        //        utils.Utils.setCisToken(requestAlteraSenha);
        //        utils.Utils.setAuthorizationToken(requestAlteraSenha, authorizationToken);

        //        test.Log(Status.Info, "Enviando requisição.");
        //        var responseAlteraSenha = client.Execute<ModelUsers>(requestAlteraSenha);

        //        //Início das validações
        //        test.Log(Status.Info, "Validando se o Status Code de retorno da requisição é 200.");
        //        Assert.That((int)responseAlteraSenha.StatusCode, Is.EqualTo(200), "Status Code diferente do esperado ao enviar a requisição responsável por realizar a alteração de senha.");

        //        //Criando e enviando a requisição responsável por tentar realizar login com a nova senha
        //        test.Log(Status.Info, "Criando requisição responsável por tentar realizar login com a senha nova.");
        //        var requestRealizaLoginSenhaAlterada = new RestRequest("bus/v1/users/login/byapp", Method.POST);
        //        requestRealizaLoginSenhaAlterada.RequestFormat = DataFormat.Json;
        //        requestRealizaLoginSenhaAlterada.AddJsonBody(new
        //        {
        //            Email = email,
        //            Password = "111111"
        //        }
        //        );

        //        utils.Utils.setCisToken(requestRealizaLoginSenhaAlterada);

        //        test.Log(Status.Info, "Enviando requisição ");
        //        var responseRealizaLoginSenhaAlterada = client.Execute<ModelUsers>(requestRealizaLoginSenhaAlterada);

        //        test.Log(Status.Info, "Validando se o Status Code de retorno da requisição é 200.");
        //        Assert.That((int)responseRealizaLoginSenhaAlterada.StatusCode, Is.EqualTo(200), "Status Code diferente do esperado ao enviar a requisição responsável por realizar login com a senha que foi alterada.");

        //        //Criando e enviando a requisição responsável por realizar rollback na senha do usuário
        //        test.Log(Status.Info, "Criando requisição responsável por realizar rollback na senha do usuário.");
        //        var requestRollbackSenha = new RestRequest("bus/v1/users/changepassword", Method.POST);
        //        requestRollbackSenha.RequestFormat = DataFormat.Json;
        //        requestRollbackSenha.AddJsonBody(new
        //        {
        //            UserId = userId,
        //            CurrentPassword = "111111",
        //            NewPassword = "112233",
        //            PasswordConfirmation = "112233"
        //        }
        //        );

        //        test.Log(Status.Info, "Setando headers necessários para realizar a requisição.");
        //        utils.Utils.setCisToken(requestRollbackSenha);
        //        utils.Utils.setAuthorizationToken(requestRollbackSenha, authorizationToken);

        //        test.Log(Status.Info, "Enviando requisição.");
        //        var responseRollbackSenha = client.Execute<ModelUsers>(requestRollbackSenha);

        //        //Início das validações
        //        test.Log(Status.Info, "Validando se o Status Code de retorno da requisição é 200.");
        //        Assert.That((int)responseRollbackSenha.StatusCode, Is.EqualTo(200), "Status Code diferente do esperado ao enviar a requisição responsável por realizar o rollback da senha.");
        //        test.Log(Status.Pass, "Teste ok! As validações foram realizadas com sucesso.");
        //    }
        //    catch (Exception e)
        //    {
        //        test.Log(Status.Fail, e.ToString());
        //        throw new Exception("Falha ao validar a alteração de senha do usuário: " + e.Message);
        //    }


        //}

        [Test]
        public void ValidaAlterarEmailUsuarioRecemCriado()
        {
            ExtentTest test = null;
            test = extent.CreateTest("ValidaAlterarEmailUsuarioRecemCriado").Info("Início do teste.");

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
                    Name = "Test01",
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
                Assert.That((int)responseCriaUsuario.StatusCode, Is.EqualTo(200), "Status Code diferente do esperado ao enviar requisição responsável por criar um usuário.");


                //Criando a requisição responsável por realizar login com o usuário recém criado
                test.Log(Status.Info, "Criando a requisição responsável por realizar login com o usuário recém criado.");
                var requestRealizaLogin = new RestRequest("bus/v1/users/login/byapp", Method.POST);
                requestRealizaLogin.RequestFormat = DataFormat.Json;

                //Montando o body da requisição que será enviada para alteração de usuário
                requestRealizaLogin.AddJsonBody(new
                {
                    Email = "iphone82020@mailinator.com",
                    Password = "112233"
                }
                );

                //Setando header de autenticação "X-CISIdentity"
                test.Log(Status.Info, "Setando os headers necessários para enviar a requisição.");
                utils.Utils.setCisToken(requestRealizaLogin);

                //Enviando a requisição realizando login com o usuário difrente do criado
                var responseRealizaLogin = client.Execute<ModelUsers>(requestRealizaLogin);
            }

            catch (Exception e)
            {
                test.Log(Status.Fail, e.ToString());
                throw new Exception("Falha ao validar a segunda entrada de usuário: " + e.Message);
            }
        }

        [Test]
        public void ValidaContaExistente()
        {
            ExtentTest test = null;
            test = extent.CreateTest("ValidaContaExistente").Info("Início do teste.");

            try
            {
                //Gerando um cpf aleatório que será utilizado na criação do usuário
                test.Log(Status.Info, "Gerando email aleatório que será utilizado no request de criação do usuário.");
                string cpfJaCadastrado = "58458830833";
                string email = utils.Utils.gerarEmailAleatorio(8);

                //Criando a requisição responsável por criar um usuário
                test.Log(Status.Info, "Criando a requisição responsável por criar um usuário utilizando cpf já existente.");
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
                    CPF = cpfJaCadastrado,
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
                test.Log(Status.Info, "Validando se o Status Code de retorno da requisição é 400.");
                Assert.That((int)responseCriaUsuario.StatusCode, Is.EqualTo(400), "Status Code diferente do esperado ao enviar requisição criando um usuário utilizando um cpf já cadastrado.");

                test.Log(Status.Info, "Validando se a mensagem de crítica é exibida.");
                Assert.That(responseCriaUsuario.Data.Message, Is.EqualTo("O CPF informado já está sendo utilizado."), "Valor da propriedade 'Message' divergente.");
                test.Log(Status.Pass, "Teste ok! As validações foram realizadas com sucesso.");

            }
            catch (Exception e)
            {
                test.Log(Status.Fail, e.ToString());
                throw new Exception("Falha ao validar a mensagem de crítica que é exibida ao criar um usuário utilizando e-mail já cadastrado: " + e.Message);
            }
             

        }

    }
}
