using System;
using System.Threading;
using IC_TurnUpPortal_TestAutomation.Utilities;
using OpenQA.Selenium;

namespace IC_TurnUpPortal_TestAutomation.Pages
{
    public class TMHomePage
    {
        public TMHomePage()
        {
        }

        public void GoToTMPage(IWebDriver driver)
        {
            //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

            // Click on administration dropdown
            IWebElement administrationDropdown = driver.FindElement(By.XPath("/html/body/div[3]/div/div/ul/li[5]/a"));
            administrationDropdown.Click();

            // select time & Material from dropdown list
            IWebElement timeMaterialDropdownOption = driver.FindElement(By.XPath("/html/body/div[3]/div/div/ul/li[5]/ul/li[3]/a"));
            timeMaterialDropdownOption.Click();
        }
    }
}
