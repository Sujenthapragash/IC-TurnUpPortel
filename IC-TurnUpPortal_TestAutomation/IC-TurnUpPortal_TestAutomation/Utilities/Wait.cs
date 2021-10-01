using System;
using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace IC_TurnUpPortal_TestAutomation.Utilities
{
    class Wait
    {


        public Wait()
        {
        }

        public static void WaitForElementToBeVisible(IWebDriver driver, IWebElement webElement, int secounds)
        {
            var wait = new WebDriverWait(driver, new TimeSpan(0,0,secounds));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeSelected(webElement));
        }

        internal static void WaitForElementToBeClickable(IWebDriver driver, IWebElement webElement, int secounds)
        {
            var wait = new WebDriverWait(driver, new TimeSpan(0, 0, secounds));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(webElement));
        }

        public static void WaitForAlertToPresent(IWebDriver driver, int secounds)
        {
            var wait = new WebDriverWait(driver, new TimeSpan(0, 0, secounds));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.AlertIsPresent());
        }

        public static  void WaitForGetNumberOfWebElements(IWebDriver driver, int secounds,By TargetLocator, int expectedCount)
        {
            var wait = new WebDriverWait(driver, new TimeSpan(0, 0, secounds));
            wait.Until( e => { if (driver.FindElements(TargetLocator).Count == expectedCount) return true; return false; });

       
        } 
    }
}
