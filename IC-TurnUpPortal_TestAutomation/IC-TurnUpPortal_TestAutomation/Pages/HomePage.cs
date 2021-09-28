using System;
using System.Threading;
using OpenQA.Selenium;

namespace IC_TurnUpPortal_TestAutomation.Pages
{
    public class HomePage
    {
        public HomePage()
        {
        }

        public void GoToTMPage(IWebDriver driver)
        {
            // Click on administration dropdown
            IWebElement administrationDropdown = driver.FindElement(By.XPath("/html/body/div[3]/div/div/ul/li[5]/a"));
            administrationDropdown.Click();
            Thread.Sleep(2000);

            // select time & Material from dropdown list
            IWebElement timeMaterialDropdownOption = driver.FindElement(By.XPath("/html/body/div[3]/div/div/ul/li[5]/ul/li[3]/a"));
            timeMaterialDropdownOption.Click();
            Thread.Sleep(2000);
        }
    }
}
