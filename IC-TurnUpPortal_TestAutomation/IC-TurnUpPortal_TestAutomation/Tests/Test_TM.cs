using System;
using System.Threading;
using IC_TurnUpPortal_TestAutomation.Pages;
using IC_TurnUpPortal_TestAutomation.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace IC_TurnUpPortal_TestAutomation
{
    [TestFixture]
    class Test_TM : CommonDriver
    {

        [SetUp]
        public void GoToTMHomePage()
        {
            LoginPage loginPage = new();
            loginPage.Login(driver);
            TMHomePage homePage = new();
            homePage.GoToTMPage(driver);
        }
        [Test,Order(1),Description("Check if user able to create new Material")]
        public void Test_CreateTM()
        {
            TimeMaterialPage timeMaterialPage = new();
            timeMaterialPage.CreateTM(driver);
        }
        [Test, Order(2),Description("Check if user able to edit last created material")]
        public void Test_EditTM()
        {
            TimeMaterialPage timeMaterialPage = new();
            timeMaterialPage.EditTM(driver);

        }
        [Test, Order(3), Description("Check if user able to delete last edited material")]
        public void Test_DeleteTM()
        {
            TimeMaterialPage timeMaterialPage = new();
            timeMaterialPage.DeleteTM(driver);

        }

        [TearDown]
        public void Teardown()
        {
            //driver.Close();
        }
    }
}
