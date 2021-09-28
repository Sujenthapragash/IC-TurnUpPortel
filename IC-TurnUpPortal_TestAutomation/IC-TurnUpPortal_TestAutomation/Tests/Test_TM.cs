using System;
using System.Threading;
using IC_TurnUpPortal_TestAutomation.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace IC_TurnUpPortal_TestAutomation
{
    class Test_TM
    {
        static void Main(string[] args)
        {

            //open chrome browser
            IWebDriver driver = new ChromeDriver();

            LoginPage loginPage = new LoginPage();
            loginPage.Login(driver);

            HomePage homePage = new HomePage();
            homePage.GoToTMPage(driver);

            TimeMaterialPage timeMaterialPage = new TimeMaterialPage();
            timeMaterialPage.CreateTM(driver);

            timeMaterialPage.EditTM(driver);

            timeMaterialPage.DeleteTM(driver);

            
        }
    }
}
