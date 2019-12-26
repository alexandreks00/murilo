using System.Configuration;
using DemoRestSharp.Models.Users;
using NUnit.Framework;
using RestSharp;

namespace DemoRestSharp
{
    [TestFixture]
    public class Users
    {

        [Test]
        public void ValidaInformacoesLoginUsuario()
        {
            //Criando e enviando requisição
            var client = new RestClient(ConfigurationManager.AppSettings["dnsSensedia"]);
            var request = new RestRequest("bus/v1/users/login/byapp", Method.POST);
            request.RequestFormat = DataFormat.Json;
            request.AddJsonBody(new 
            { 
                Email = "gustavoqueiroz@mailinator.com",
                Password = "112233" 
            }
            );
            utils.Utils.setCisToken(request);
            var response = client.Execute<ModelUsers>(request);


            //Início das validações
            Assert.That((int)response.StatusCode, Is.EqualTo(200), "Status Code divergente.");
            Assert.That(response.Data.Id, Is.EqualTo("5c096959418efa0001f0c2c7"), "Valor da propriedade 'Id' divergente.");
            Assert.That(response.Data.UserId, Is.EqualTo(5639782), "Valor da propriedade 'UserId' divergente.");
            Assert.That(response.Data.Name, Is.EqualTo("Gudtavo"), "Valor da propriedade 'Name' divergente.");
            Assert.That(response.Data.LastName, Is.EqualTo("Queiroz"), "Valor da propriedade 'LastName' divergente.");
            Assert.That(response.Data.Gender, Is.EqualTo("M"), "Valor da propriedade 'Gender' divergente.");
            Assert.That(response.Data.Email, Is.EqualTo("gustavoqueiroz@mailinator.com"), "Valor da propriedade 'Email' divergente.");
            Assert.That(response.Data.UserId, Is.EqualTo(5639782), "Valor da propriedade 'UserId' divergente.");
            Assert.That(response.Data.CPF, Is.EqualTo("47072811095"), "Valor da propriedade 'CPF' divergente.");
            Assert.That(response.Data.DateOfBirth, Is.EqualTo("1996-04-12T03:00:00Z"), "Valor da propriedade 'DateOfBirth' divergente.");
            Assert.That(response.Data.CityId, Is.EqualTo("166"), "Valor da propriedade 'CityId' divergente.");
            Assert.That(response.Data.City.CityId, Is.EqualTo(166), "Valor da propriedade 'City.CityId' divergente.");
            Assert.That(response.Data.City.Name, Is.EqualTo("SÃO BRÁS"), "Valor da propriedade 'City.Name' divergente.");
            Assert.That(response.Data.City.StateId, Is.EqualTo(1), "Valor da propriedade 'City.StateId' divergente.");
            Assert.That(response.Data.City.State.Code, Is.EqualTo("AL"), "Valor da propriedade 'City.State.Code' divergente.");
            Assert.That(response.Data.City.State.Name, Is.EqualTo("Alagoas"), "Valor da propriedade 'City.State.Name' divergente.");
            Assert.That(response.Data.City.State.CountryId, Is.EqualTo(1), "Valor da propriedade 'City.State.CountryId' divergente.");
            Assert.That(response.Data.City.State.Country.CountryId, Is.EqualTo("1"), "Valor da propriedade 'City.State.Country.CountryId' divergente.");
            Assert.That(response.Data.City.State.Country.Code, Is.EqualTo("BRA"), "Valor da propriedade 'City.State.Country.Code' divergente.");
            Assert.That(response.Data.City.State.Country.Name, Is.EqualTo("Brasil"), "Valor da propriedade 'City.State.Country.Name' divergente.");
            Assert.That(response.Data.Phone1, Is.EqualTo("1133336363"), "Valor da propriedade 'Phone1' divergente.");
            Assert.That(response.Data.CpfNf, Is.EqualTo("False"), "Valor da propriedade 'CpfNf' divergente.");
        }

        [Test]
        public void ValidaEsqueciMinhaSenha()
        {
            //Criando e enviando a requisição
            var client = new RestClient(ConfigurationManager.AppSettings["dnsSensedia"]);
            var request = new RestRequest("bus/v1/users/passwordrecovery", Method.POST);
            request.RequestFormat = DataFormat.Json;
            request.AddJsonBody(new  
            { 
                Email = "gqsilvaa@mailinator.com" 
            }
            );
            utils.Utils.setCisToken(request);
            var response = client.Execute<ModelUsers>(request);

            //Início da validação
            Assert.That((int)response.StatusCode, Is.EqualTo(200), "Status Code divergente.");
        }

        [Test]
        public void ValidaMensagemCriticaLoginInvalido()
        {
            //Criando e enviando a requisição
            var client = new RestClient(ConfigurationManager.AppSettings["dnsSensedia"]);
            var request = new RestRequest("bus/v1/users/login/byapp", Method.POST);
            request.RequestFormat = DataFormat.Json;
            request.AddJsonBody(new 
            { 
                Email = "logininvalido@logininvalido.com" ,
                Password = "112233"
            }
            );
            utils.Utils.setCisToken(request);
            var response = client.Execute<ModelUsers>(request);

            //Início das validações
            Assert.That((int)response.StatusCode, Is.EqualTo(400), "Status Code divergente.");
            Assert.That(response.Data.Message, Is.EqualTo("Usuário ou Senha divergentes !"), "Valor da propriedade 'Message' divergente.");
        }

        [Test]
        public void ValidaInformacoesUserId()
        {
            string userId = "5639782";
            string authorizationToken = utils.Utils.getAuthorization("gustavoqueiroz@mailinator.com", "112233");

            //Criando e enviando requisição
            var client = new RestClient(ConfigurationManager.AppSettings["dnsSensedia"]);
            var request = new RestRequest("bus/v1/users/"+userId, Method.GET);
            request.RequestFormat = DataFormat.Json;
            utils.Utils.setCisToken(request);
            utils.Utils.setAuthorizationToken(request, authorizationToken);
            var response = client.Execute<ModelUsers>(request);

            //Início das validações
            Assert.That((int)response.StatusCode, Is.EqualTo(200), "Status Code divergente.");
            Assert.That(response.Data.Id, Is.EqualTo("5c096959418efa0001f0c2c7"), "Valor da propriedade 'Id' divergente.");
            Assert.That(response.Data.UserId, Is.EqualTo(5639782), "Valor da propriedade 'UserId' divergente.");
            Assert.That(response.Data.Name, Is.EqualTo("Gudtavo"), "Valor da propriedade 'Name' divergente.");
            Assert.That(response.Data.LastName, Is.EqualTo("Queiroz"), "Valor da propriedade 'LastName' divergente.");
            Assert.That(response.Data.Gender, Is.EqualTo("M"), "Valor da propriedade 'Gender' divergente.");
            Assert.That(response.Data.Email, Is.EqualTo("gustavoqueiroz@mailinator.com"), "Valor da propriedade 'Email' divergente.");
            Assert.That(response.Data.UserId, Is.EqualTo(5639782), "Valor da propriedade 'UserId' divergente.");
            Assert.That(response.Data.CPF, Is.EqualTo("47072811095"), "Valor da propriedade 'CPF' divergente.");
            Assert.That(response.Data.Member.Code, Is.EqualTo("CIS-05639782"), "Valor da propriedade 'Member.Code' divergente.");
            Assert.That(response.Data.Member.DateOfBirth, Is.EqualTo("1996-04-12T03:00:00Z"), "Valor da propriedade 'Member.DateOfBirth' divergente.");
            Assert.That(response.Data.Member.CityId, Is.EqualTo("166"), "Valor da propriedade 'Member.CityId' divergente.");
            Assert.That(response.Data.Member.City.CityId, Is.EqualTo(166), "Valor da propriedade 'City.CityId' divergente.");
            Assert.That(response.Data.Member.City.Name, Is.EqualTo("SÃO BRÁS"), "Valor da propriedade 'City.Name' divergente.");
            Assert.That(response.Data.Member.City.StateId, Is.EqualTo(1), "Valor da propriedade 'City.StateId' divergente.");
            Assert.That(response.Data.Member.City.State.Code, Is.EqualTo("AL"), "Valor da propriedade 'City.State.Code' divergente.");
            Assert.That(response.Data.Member.City.State.Name, Is.EqualTo("Alagoas"), "Valor da propriedade 'City.State.Name' divergente.");
            Assert.That(response.Data.Member.City.State.CountryId, Is.EqualTo(1), "Valor da propriedade 'City.State.CountryId' divergente.");
            Assert.That(response.Data.Member.City.State.Country.CountryId, Is.EqualTo("1"), "Valor da propriedade 'City.State.Country.CountryId' divergente.");
            Assert.That(response.Data.Member.City.State.Country.Code, Is.EqualTo("BRA"), "Valor da propriedade 'City.State.Country.Code' divergente.");
            Assert.That(response.Data.Member.City.State.Country.Name, Is.EqualTo("Brasil"), "Valor da propriedade 'City.State.Country.Name' divergente.");
            Assert.That(response.Data.Member.Phone1, Is.EqualTo("1133336363"), "Valor da propriedade 'Phone1' divergente.");
            Assert.That(response.Data.CpfNf, Is.EqualTo("False"), "Valor da propriedade 'CpfNf' divergente.");
        }

        [Test]
        public void ValidaCriacaoUsuario () 
        {
            ModelAppInfo model = new ModelAppInfo();

            //Gerando um e-mail aleatório que será utilizado na criação do usuário
            string email = utils.Utils.gerarEmailAleatorio(8);
            
            //Gerando um cpf aleatório que será utilizado na criação do usuário
            string cpf = utils.Utils.gerarCpf();

            //Criando e enviando a requisição
            var client = new RestClient(ConfigurationManager.AppSettings["dnsSensedia"]);
            var request = new RestRequest("bus/v1/users", Method.POST);
            request.RequestFormat = DataFormat.Json;
            request.AddJsonBody(new
            {
                AppInfo = new {
                    deviceModel = "Moto G Play",
                    devicePlatform = "Android",
                    deviceUUID = "62a0391e-9b4c-4870-ba11-40896b488506",
                    version = "4.0.20",
                },
                DateOfBirth = "2002-11-04T00:00:00.000Z",
                CardNumber =  "",
                City = new {
                    CityId =  12789,
                    Name = "Taguatinga",
                        State = new {
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
                Name = "Gustavo Silva",
                NickName = "Gustavo",
                Password = "112233",
                Phone1 = "1136563256"
            }
            );
            utils.Utils.setCisToken(request);
            var response = client.Execute<ModelUsers>(request);
            
            //Início das validações
            Assert.That((int)response.StatusCode, Is.EqualTo(200), "Status Code divergente.");
        }
    }
}
