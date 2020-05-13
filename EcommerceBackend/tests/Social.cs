using System.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// using EcommerceBackend.models.Loyalty;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using RestSharp;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Reporter.Configuration;
using DemoRestSharp.models.Social;

namespace EcommerceBackend
{
    [TestFixture]
    public class Social
    {
        ExtentReports extent = null;

        [OneTimeSetUp]
        public void StartReport()
        {
            extent = new ExtentReports();
            var htmlReporter = new ExtentHtmlReporter(@"C:\AutomationTools\EcommerceBackendReports\Reports\Social\");
            extent.AttachReporter(htmlReporter);
        }

        [OneTimeTearDown]
        public void CloseReport()
        {
            extent.Flush();
        }


        [Test]
        public void ValidaCinemasFavoritados()
        {
            ExtentTest test = null;
            test = extent.CreateTest("ValidaCinemasFavoritados").Info("Início do teste.");
            
            string userId = "5640112";
            string email = "cinemasfavoritados@mailinator.com";
            string authorizationToken = utils.Utils.getAuthorization(email, "112233");
            
            try
            {           
                //Criando e enviando requisição verificando os cinemas que o usuário possui favoritado
                test.Log(Status.Info, "Criando requisição responsável por consultar os cinemas favoritados.");
                var client = new RestClient(ConfigurationManager.AppSettings["dnsSensedia"]);
                var requestConsultaCinema = new RestRequest("bus/v1/social/likes/" +userId+ "/theaters", Method.GET);
                test.Log(Status.Info, "Setando headers necessários para enviar a requisição.");
                utils.Utils.setAuthorizationToken(requestConsultaCinema, authorizationToken);
                utils.Utils.setCisToken(requestConsultaCinema);
                test.Log(Status.Info, "Enviando requisição responsável por consultar os cinemas favoritados.");
                var responseConsultaCinema = client.Execute<List<ModelSocial>>(requestConsultaCinema);

                //Início das validações
                test.Log(Status.Info, "Validando se o Status Code de retorno da requisição é 200.");
                Assert.That((int)responseConsultaCinema.StatusCode, Is.EqualTo(200), "Status Code divergente.");
                test.Log(Status.Info, "Validando o retorno das propriedades.");
                Assert.That(responseConsultaCinema.Data[0].EntityId, Is.EqualTo(710), "Valor da propriedade 'EntityId[0]' divergente");
                Assert.That(responseConsultaCinema.Data[1].EntityId, Is.EqualTo(682), "Valor da propriedade 'EntityId[1]' divergente");
                Assert.That(responseConsultaCinema.Data[2].EntityId, Is.EqualTo(723), "Valor da propriedade 'EntityId[2]' divergente");
                Assert.That(responseConsultaCinema.Data[3].EntityId, Is.EqualTo(684), "Valor da propriedade 'EntityId[3]' divergente");
                test.Log(Status.Pass, "Testes ok! Todas as validações foram realizadas com sucesso.");    
            }
            catch (Exception e)
            {
                test.Log(Status.Fail, e.ToString());
                throw new Exception("Falha ao validar a verificação de cinemas favoritados: " + e.Message);
            }
        }


        [Test]
        public void ValidaFavoritaCinema()
        {
            ExtentTest test = null;
            test = extent.CreateTest("ValidaFavoritaCinema").Info("Início do teste.");

            double userId = 5640111;
            string email = "favoritacinema@mailinator.com";
            string authorizationToken = utils.Utils.getAuthorization(email, "112233");

            try
            {
                //Criando e enviando requisição favoritando um usuário
                test.Log(Status.Info, "Criando requisição responsável por favoritar um usuário.");
                var client = new RestClient(ConfigurationManager.AppSettings["dnsSensedia"]);
                var requestFavoritaCinema = new RestRequest("bus/v1/social/theater/688/like", Method.POST);
                requestFavoritaCinema.RequestFormat = DataFormat.Json;
                requestFavoritaCinema.AddJsonBody(new
                {
                    Coment = "string",
                    UserId = userId
                }
                );
                utils.Utils.setCisToken(requestFavoritaCinema);
                test.Log(Status.Info, "Setando headers necessários para realizar a requisição.");
                utils.Utils.setAuthorizationToken(requestFavoritaCinema, authorizationToken);
                test.Log(Status.Info, "Enviando requisição responsável por favoritar o cinema.");
                var responseFavoritaCinema = client.Execute<List<ModelSocial>>(requestFavoritaCinema);

                //Validando Status Code de retorno da requisição
                test.Log(Status.Info, "Validando se o Status Code de retorno da requisição é 200.");
                Assert.That((int)responseFavoritaCinema.StatusCode, Is.EqualTo(200), "Status Code divergente.");

                //Criando e enviando requisição verificando se o cinema foi favoritado
                test.Log(Status.Info, "Criando requisição responsável por verificar se o cinema foi favoritado.");
                var requestConsultaCinema = new RestRequest("bus/v1/social/likes/"+userId+"/theaters", Method.GET);
                utils.Utils.setAuthorizationToken(requestConsultaCinema, authorizationToken);
                utils.Utils.setCisToken(requestConsultaCinema);
                test.Log(Status.Info, "Enviando requisição responsável por consultar se o cinema foi favoritado.");
                var responseConsultaCinema = client.Execute<List<ModelSocial>>(requestConsultaCinema);

                
                //Início das validações
                test.Log(Status.Info, "Validando se o Status Code de retorno da requisição é 200.");
                Assert.That((int)responseConsultaCinema.StatusCode, Is.EqualTo(200), "Status Code divergente.");
                test.Log(Status.Info, "Validando o retorno das propriedades.");
                Assert.That(responseConsultaCinema.Data[0].VoteId, Is.EqualTo(0), "Valor da propriedade 'VoteId' divergente");
                Assert.That(responseConsultaCinema.Data[0].EntityId, Is.EqualTo(688), "Valor da propriedade 'EntityId' divergente");
                Assert.That(responseConsultaCinema.Data[0].EntityType, Is.EqualTo(10), "Valor da propriedade 'EntityType' divergente");
                Assert.That(responseConsultaCinema.Data[0].Comment, Is.EqualTo("string"), "Valor da propriedade 'Comment' divergente");
                Assert.That(responseConsultaCinema.Data[0].Cancelled, Is.EqualTo(false), "Valor da propriedade 'Cancelled' divergente");

                test.Log(Status.Pass, "Teste ok! Todas as validações foram realizadas com sucesso!");

                //Criando e enviando requisição realizando rollback
                test.Log(Status.Info, "Criando requisição responsável por realizar rollback (desfavorita cinema).");
                var requestRealizaRollback = new RestRequest("bus/v1/social/theater/688/like", Method.DELETE);
                requestRealizaRollback.RequestFormat = DataFormat.Json;
                requestRealizaRollback.AddJsonBody(new
                {
                    Coment = "string",
                    UserId = userId
                }
                );
                utils.Utils.setAuthorizationToken(requestRealizaRollback, authorizationToken);
                utils.Utils.setCisToken(requestRealizaRollback);     
                test.Log(Status.Info, "Enviando requisição responsável por realizar o rollback.");
                var responseRealizaRollback = client.Execute(requestRealizaRollback);

                //Verificando Status Code de retorno da requisição de rollback
                test.Log(Status.Info, "Validando que o Status Code de resposta da requisição ao desfavoritar o cinema foi 200.");
                Assert.That((int)responseRealizaRollback.StatusCode, Is.EqualTo(200), "Status Code divergente.");
             
            }
            catch (Exception e)
            {
                test.Log(Status.Fail, e.ToString());
                throw new Exception("Falha ao favoritar um cinema: " + e.Message);
            }
        }


        [Test]
        public void ValidaDesfavoritaCinema()
        {
            ExtentTest test = null;
            test = extent.CreateTest("ValidaDesfavoritaCinema").Info("Início do teste.");

            string userId = "5639782";
            string email = "gustavoqueiroz@mailinator.com";
            string authorizationToken = utils.Utils.getAuthorization(email, "112233");

            try
            {
                //Criando e enviando requisição desfavoritando o cinema
                test.Log(Status.Info, "Criando requisição responsável por desfavoritar o cinema.");
                var client = new RestClient(ConfigurationManager.AppSettings["dnsSensedia"]);
                var requestDesfavoritaCinema = new RestRequest("bus/v1/social/theater/688/like", Method.DELETE);
                requestDesfavoritaCinema.RequestFormat = DataFormat.Json;
                requestDesfavoritaCinema.AddJsonBody(new
                {
                    Coment = "string",
                    UserId = userId
                }
                );
                utils.Utils.setAuthorizationToken(requestDesfavoritaCinema, authorizationToken);
                utils.Utils.setCisToken(requestDesfavoritaCinema);
                test.Log(Status.Info, "Enviando requisição responsável por desfavoritar cinema.");
                var responseRealizaRollback = client.Execute(requestDesfavoritaCinema);

                //Verificando Status Code de retorno da requisição de rollback
                test.Log(Status.Info, "Validando que o Status Code de resposta da requisição ao desfavoritar o cinema foi 200.");
                Assert.That((int)responseRealizaRollback.StatusCode, Is.EqualTo(200), "Status Code divergente.");

                //Criando e enviando requisição verificando se o cinema foi desfavoritado
                test.Log(Status.Info, "Criando requisição responsável por verificar se o cinema foi desfavoritado.");
                var requestConsultaCinema = new RestRequest("bus/v1/social/likes/" + userId + "/theaters", Method.GET);
                utils.Utils.setAuthorizationToken(requestConsultaCinema, authorizationToken);
                utils.Utils.setCisToken(requestConsultaCinema);
                test.Log(Status.Info, "Enviando requisição responsável por consultar se o cinema foi desfavoritado.");
                var responseConsultaCinema = client.Execute<List<ModelSocial>>(requestConsultaCinema);

                //Início das validações
                test.Log(Status.Info, "Validando se o Status Code de retorno da requisição é 200.");
                Assert.That((int)responseConsultaCinema.StatusCode, Is.EqualTo(200), "Status Code divergente.");
                test.Log(Status.Info, "Validando o retorno das propriedades.");
                string responseContent = responseConsultaCinema.Content;
                Assert.That(responseConsultaCinema.Content, Is.EqualTo("[]"), "Resposta obtida no serviço divergente");
                test.Log(Status.Info, "Validação ok.");


                //Criando e enviando requisição realizando rollback (favoritando cinema)
                var requestRealizaRollback = new RestRequest("bus/v1/social/theater/688/like", Method.POST);
                requestRealizaRollback.RequestFormat = DataFormat.Json;
                requestRealizaRollback.AddJsonBody(new
                {
                    Coment = "string",
                    UserId = userId
                }
                );
                utils.Utils.setCisToken(requestRealizaRollback);
                test.Log(Status.Info, "Setando headers necessários para realizar a requisição.");
                utils.Utils.setAuthorizationToken(requestRealizaRollback, authorizationToken);
                test.Log(Status.Info, "Enviando requisição responsável por favoritar o cinema.");
                var responseFavoritaCinema = client.Execute(requestRealizaRollback);

                //Validando Status Code de retorno da requisição
                test.Log(Status.Info, "Validando se o Status Code de retorno da requisição é 200.");
                Assert.That((int)responseFavoritaCinema.StatusCode, Is.EqualTo(200), "Status Code divergente.");
                test.Log(Status.Pass, "Teste ok! Todas as validações foram realizadas com sucesso.");
            }
            catch(Exception e)
            {
                test.Log(Status.Fail, e.ToString());
                throw new Exception("Falha ao desfavoritar um cinema: " + e.Message);
            }
        }
    }
}
