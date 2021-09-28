using System;
using System.Threading;
using OpenQA.Selenium;

namespace IC_TurnUpPortal_TestAutomation.Pages
{
    public class LoginPage
    {
        public LoginPage()
        {
        }
        public void Login(IWebDriver driver)
        {
            driver.Navigate().GoToUrl("http://horse.industryconnect.io/Account/Login?ReturnUrl=%2f");
            driver.Manage().Window.Maximize();
            Thread.Sleep(2000);

            //identify username textbox and enter valid username "hari"
            IWebElement usernameField = driver.FindElement(By.Id("UserName"));
            usernameField.SendKeys("hari");

            //identify password textbox and enter valid password "123123"
            IWebElement passwordField = driver.FindElement(By.Id("Password"));
            passwordField.SendKeys("123123");

            //identify login button and click
            IWebElement loginButton = driver.FindElement(By.XPath("//*[@id='loginForm']/form/div[3]/input[1]"));
            loginButton.Click();

            //check if user login suceesfully

            IWebElement helloUser = driver.FindElement(By.XPath("//*[@id='logoutForm']/ul/li/a"));

            if (helloUser.Text == "Hello hari!")
            {
                Console.WriteLine("User logged in successfully, Test Passed");
            }
            else
            {
                Console.WriteLine("User login failed, Test failed");
            }
        }
    }
}
