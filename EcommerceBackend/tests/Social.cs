using System.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EcommerceBackend.Models.Users;
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
            var htmlReporter = new ExtentHtmlReporter(@"C:\EcommerceBackendReports\Reports\Social\");
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

            try
            {
                
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

            try
            {
                double userId = 5640111;
                string email = "favoritacinema@mailinator.com";
                string authorizationToken = utils.Utils.getAuthorization(email, "112233");

                //Criando e enviando requisição favoritando um usuário
                test.Log(Status.Info, "Criando requisição");
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
                test.Log(Status.Info, "Setando headers necessários para realizar a requisição");
                utils.Utils.setAuthorizationToken(requestFavoritaCinema, authorizationToken);
                test.Log(Status.Info, "Enviando requisição responsável por favoritar o cinema");
                var responseFavoritaCinema = client.Execute<ModelSocial>(requestFavoritaCinema);

                //Validando Status Code de retorno da requisição
                test.Log(Status.Info, "Validando se o Status Code de retorno da requisição é 200.");
                Assert.That((int)responseFavoritaCinema.StatusCode, Is.EqualTo(200), "Status Code divergente.");

                //Criando e enviando requisição verificando se o cinema foi favoritado
                test.Log(Status.Info, "Criando requisição responsável por verificar se o cinema foi favoritado");
                var requestConsultaCinema = new RestRequest("bus/v1/social/likes/"+userId+"/theaters", Method.GET);
                utils.Utils.setAuthorizationToken(requestConsultaCinema, authorizationToken);
                utils.Utils.setCisToken(requestConsultaCinema);
                test.Log(Status.Info, "Enviando requisição responsável por consultar se o cinema foi favoritado");
                var responseConsultaCinema = client.Execute<ModelSocial>(requestConsultaCinema);

                
                //Início das validações
                test.Log(Status.Info, "Validando se o Status Code de retorno da requisição é 200.");
                Assert.That((int)responseConsultaCinema.StatusCode, Is.EqualTo(200), "Status Code divergente.");
                
                //Assert.That(responseConsultaCinema.Data.Lists, Is.EqualTo(688), "Valor da propriedade 'EntityId' divergente");
                test.Log(Status.Info, "Validações ok!");

                //Criando e enviando requisição realizando rollback
                test.Log(Status.Info, "Criando requisição responsável por realizar rollback (desfavorita cinema)");
                var requestRealizaRollback = new RestRequest("bus/v1/social/theater/688/like", Method.DELETE);
                utils.Utils.setAuthorizationToken(requestRealizaRollback, authorizationToken);
                utils.Utils.setCisToken(requestRealizaRollback);
                test.Log(Status.Info, "Enviando requisição responsável por realizar o rollback");
                var responseRealizaRollback = client.Execute<ModelSocial>(requestRealizaRollback);

                //Verificando Status Code de retorno da requisição de rollback
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

            try
            {


            }
            catch(Exception e)
            {
                test.Log(Status.Fail, e.ToString());
                throw new Exception("Falha ao desfavoritar um cinema: " + e.Message);
            }
        }
    }
}
