using System.Configuration;
using System;
using NUnit.Framework;
using RestSharp;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Reporter.Configuration;
using EcommerceBackend.utils;

namespace EcommerceBackend
{
    [TestFixture]
    public class SnackBar
    {

        ExtentReports extent = null;

        [OneTimeSetUp]
        public void StartReport()
        {
            extent = new ExtentReports();
            var htmlReporter = new ExtentHtmlReporter(@"C:\AutomationTools\EcommerceBackendReports\Reports\SnackBar\");
            extent.AttachReporter(htmlReporter);
        }

        [OneTimeTearDown]
        public void CloseReport()
        {          
            extent.Flush();
        }

        [Test]
        public void ValidaContratoSnackPorCinema()
        {
            int idTheather = 688;
            ExtentTest test = null;
            test = extent.CreateTest("ValidaContratoSnackPorCinema").Info("Início do teste.");

            try
            {

                //Criando e enviando requisição
                test.Log(Status.Info, "Criando requisição");
                var client = new RestClient(ConfigurationManager.AppSettings["dnsSensedia"]);
                var request = new RestRequest("bus/v1/snackbar/productcategories/theaters/" + idTheather, Method.GET);
                utils.Utils.setCisToken(request);
                test.Log(Status.Info, "Setando headers necessários para realizar a requisição");
                var response = client.Execute(request);


                string responseContent = response.Content.ToString();

                string[] properties = new string[] { "\"Id\":", "\"idCat\":", "\"txCat\":", "\"listaSugestoes\":", "\"visivel\":", "\"urlImagem\":", "\"Produtos\":", "\"idProduto\":"
                , "\"txProduto\":", "\"Descricao\":", "\"Preco\":", "\"TaxaConveniencia\":", "\"TipoTaxaConveniencia\":", "\"Combo\":"
                , "\"listaSugestoes\":", "\"idSugestao\":", "\"tipoSugestao\":", "\"urlBanner\":", "\"urlImagem\":", "\"Ordem\":", "\"Promocao\":", "\"idsCategoriasNaoSugerir\":", "\"IdParceria\":"};


                test.Log(Status.Info, "Início de validações da string properties.");
                for (int i = 0; i < properties.Length; i++)
                {
                    int qtdCampos = properties.Length;
                    string indiceZero = properties[0];
                    if (qtdCampos != 23)
                    {
                        test.Log(Status.Fail, "Contrato de validação de snackbar incompleto!");

                    }
                    else if(indiceZero != "\"Id\":")
                    {
                        test.Log(Status.Fail, "Contrato Inexistente");
                    }

                }
                test.Log(Status.Info, "String properties validada com sucesso.");

                //Início das validações
                test.Log(Status.Info, "Validando se o Status Code de retorno da requisição é 200.");
                Assert.That((int)response.StatusCode, Is.EqualTo(200), "Status Code divergente.");
                test.Log(Status.Info, "Valida Contrato de snack por cinema");
                Utils.validaContrato(properties, responseContent, test);
                test.Log(Status.Info, "Finalizado todas as etapas com sucesso.");

            }
            catch (Exception e)
            {
                test.Log(Status.Fail, e.ToString());
                throw new Exception("Falha ao validar dados de SnackBar: " + e.Message);
            }
        }

        [Test]
        public void ValidaContratoBannerSnack()
        {
            ExtentTest test = null;
            test = extent.CreateTest("ValidaContratoBannerSnack").Info("Início do teste.");

            try
            {

                //Criando e enviando requisição
                test.Log(Status.Info, "Criando requisição");
                var client = new RestClient(ConfigurationManager.AppSettings["dnsSensedia"]);
                var request = new RestRequest("bus/v1/snackbar/banners", Method.GET);
                utils.Utils.setCisToken(request);
                test.Log(Status.Info, "Setando headers necessários para realizar a requisição");
                var response = client.Execute(request);


                string responseContent = response.Content.ToString();

                string[] properties = new string[] { "\"ImageUrl\":", "\"CategoryId\":", "\"ProductId\":"};


                test.Log(Status.Info, "Início de validações da string properties.");
                for (int i = 0; i < properties.Length; i++)
                {
                    int qtdCampos = properties.Length;
                    string indiceZero = properties[0];
                    if (qtdCampos != 3)
                    {
                        test.Log(Status.Fail, "Contrato de validação de snackbar incompleto!");

                    }
                    else if (indiceZero != "\"ImageUrl\":")
                    {
                        test.Log(Status.Fail, "Contrato Inexistente");
                    }

                }
                test.Log(Status.Info, "String properties validada com sucesso.");

                //Início das validações
                test.Log(Status.Info, "Validando se o Status Code de retorno da requisição é 200.");
                Assert.That((int)response.StatusCode, Is.EqualTo(200), "Status Code divergente.");
                test.Log(Status.Info, "Valida Contrato de snack por banners");
                Utils.validaContrato(properties, responseContent, test);
                test.Log(Status.Info, "Finalizado todas as etapas com sucesso.");

            }
            catch (Exception e)
            {
                test.Log(Status.Fail, e.ToString());
                throw new Exception("Falha ao validar dados de SnackBar de Banners: " + e.Message);
            }
        }

        [Test]
        public void ValidaContratoSnackPrime()
        {
            ExtentTest test = null;
            test = extent.CreateTest("ValidaContratoSnackPrime").Info("Início do teste.");

            try
            {

                //Criando e enviando requisição
                test.Log(Status.Info, "Criando requisição");
                var client = new RestClient(ConfigurationManager.AppSettings["dnsSensedia"]);
                var request = new RestRequest("bus/v2/snackbar/productcategories/theaters/785/20", Method.GET);
                utils.Utils.setCisToken(request);
                test.Log(Status.Info, "Setando headers necessários para realizar a requisição");
                var response = client.Execute(request);


                string responseContent = response.Content.ToString();

                string[] properties = new string[] { "\"Id\":", "\"idCat\":", "\"txCat\":", "\"listaSugestoes\":", "\"visivel\":"
                , "\"urlImagem\":", "\"Produtos\":", "\"SubCategories\":", "\"Name\":", "\"Description\":", "\"ImageURL\":"
                , "\"idProduto\":", "\"txProduto\":", "\"Descricao\":", "\"Preco\":", "\"TaxaConveniencia\":", "\"TipoTaxaConveniencia\":"
                , "\"Combo\":", "\"listaSugestoes\":", "\"idsCategoriasNaoSugerir\":", "\"IdParceria\":", "\"QtdPermitida\":", "\"listaSugestoesCombo\":"
                , "\"TipoMenu\":", "\"dtInicioResgate\":", "\"dtFimResgate\":"};


                test.Log(Status.Info, "Início de validações da string properties.");
                for (int i = 0; i < properties.Length; i++)
                {
                    int qtdCampos = properties.Length;
                    string indiceZero = properties[0];
                    if (qtdCampos != 26)
                    {
                        test.Log(Status.Fail, "Contrato de validação de snackbar incompleto!");

                    }
                    else if (indiceZero != "\"Id\":")
                    {
                        test.Log(Status.Fail, "Contrato Inexistente");
                    }

                }
                test.Log(Status.Info, "String properties validada com sucesso.");

                //Início das validações
                test.Log(Status.Info, "Validando se o Status Code de retorno da requisição é 200.");
                Assert.That((int)response.StatusCode, Is.EqualTo(200), "Status Code divergente.");
                test.Log(Status.Info, "Valida Contrato de snack por banners");
                Utils.validaContrato(properties, responseContent, test);
                test.Log(Status.Info, "Finalizado todas as etapas com sucesso.");

            }
            catch (Exception e)
            {
                test.Log(Status.Fail, e.ToString());
                throw new Exception("Falha ao validar dados de SnackBar de SnackPrime: " + e.Message);
            }
        }

    }
}
