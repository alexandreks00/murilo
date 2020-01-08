using System.Configuration;
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

            }
            catch(Exception e)
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
