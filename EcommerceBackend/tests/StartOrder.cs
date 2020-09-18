//using System.Configuration;
//using System;
//using NUnit.Framework;
//using RestSharp;
//using AventStack.ExtentReports;
//using AventStack.ExtentReports.Reporter;
//using DemoRestSharp.models.Order;
//using System.Collections.Generic;
//using EcommerceBackend.utils;
//using Newtonsoft.Json;
//using System.Reflection;
//using Dynamitey.DynamicObjects;


//    public class StartOrder
//{
//    public string Email { get; set }
//    public string Identification { get; set; }
//    public int MyProperty { get; set; }

//}



//{   
//    [TestFixture]
//public class StartOrder
//{
//    ExtentReports extent = null;

//    [OneTimeSetUp]
//    public void StartReport()
//    {
//        extent = new ExtentReports();
//        var htmlReporter = new ExtentHtmlReporter(@"C:\AutomationTools\EcommerceBackendReports\Reports\StartOrder\");
//        extent.AttachReporter(htmlReporter);

//    }

//    [OneTimeTearDown]
//    public void CloseReport()
//    {
//        extent.Flush();
//    }

//    [Test]
//    public void ValidaRealizaPedidoSnack()
//    {
//        ExtentTest test = null;
//        test = extent.CreateTest("ValidaRealizaPedidoSnack").Info("Início do teste.");



//        try
//        {

//            string authorizationToken = utils.Utils.getAuthorization("listadepedidos@mailinator.com", "112233");

//            //Criando e enviando requisição
//            test.Log(Status.Info, "Criando requisição responsável por realizar login.");
//            var client = new RestClient(ConfigurationManager.AppSettings["dnsSensedia"]);
//            var request = new RestRequest("order/v2/startorder", Method.POST);
//            request.RequestFormat = DataFormat.Json;
//            utils.Utils.setCisToken(request);
//            test.Log(Status.Info, "Setando headers necessários para realizar a requisição.");
//            utils.Utils.setAuthorizationToken(request, authorizationToken);

//            request.AddJsonBody(body);
//            request.AddParameter("application/json", body, ParameterType.RequestBody);



//            }
//        catch (Exception e)
//        {
//            test.Log(Status.Fail, e.ToString());
//            throw new Exception("Falha ao validar dados de consulta de ingresso: " + e.Message);
//        }








//    }


//}

