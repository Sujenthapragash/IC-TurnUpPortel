using System;
using System.Threading;
using IC_TurnUpPortal_TestAutomation.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;

namespace IC_TurnUpPortal_TestAutomation.Pages
{
    public class TimeMaterialPage
    {
        public TimeMaterialPage()
        {
        }
        public void CreateTM(IWebDriver driver)
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);


            // click on create new button
            IWebElement createNewButton = driver.FindElement(By.XPath("//*[@id='container']/p/a"));
            createNewButton.Click();

            // Click on TypeCode dropdown
            IWebElement typeCodeDropDown = driver.FindElement(By.XPath("//*[@id='TimeMaterialEditForm']/div/div[1]/div/span[1]/span/span[1]"));
            Wait.WaitForElementToBeClickable(driver,typeCodeDropDown, 5);
            typeCodeDropDown.Click();

            // Select time from typeCode dropdown
            IWebElement timeOption = driver.FindElement(By.XPath("//*[@id='TypeCode_listbox']/li[2]"));
            Wait.WaitForElementToBeClickable(driver, timeOption, 5);
            timeOption.Click();

            // identify "Code" textbox and input code
            var newCode = "TC_TM_01";
            IWebElement codeTextbox = driver.FindElement(By.Id("Code"));
            codeTextbox.SendKeys(newCode);

            // identify "Description" textbox and input description
            var newDescription = "Create time with valid data.";
            IWebElement descriptionTextbox = driver.FindElement(By.Id("Description"));
            descriptionTextbox.SendKeys(newDescription);

            // identify "Price" textbox and input price
            var newPrice = "120.00";
            driver.FindElement(By.XPath("//*[@id='TimeMaterialEditForm']/div/div[4]/div/span[1]/span/input[1]")).Click();
            IWebElement priceTextbox = driver.FindElement(By.Id("Price"));
            priceTextbox.SendKeys(newPrice);

            // Click on "Save" button
            IWebElement saveButton = driver.FindElement(By.Id("SaveButton"));
            saveButton.Click();

            // Click on last Pagge
            Thread.Sleep(2000);
            IWebElement goToLastPageButton = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[4]/a[4]"));
            //Wait.WaitForElementToBeClickable(driver, goToLastPageButton, 5);
            goToLastPageButton.Click();

            // Assert new time entry in last line

            IWebElement lastEntryCode = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[1]"));
            IWebElement lastEnrtyDescription = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[3]"));
            IWebElement lastEntryPrice = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[4]"));


            Assert.That(lastEntryCode.Text == newCode, "Codes does not match with with as entered");
            Assert.That(lastEnrtyDescription.Text == newDescription, "Description does not match with as entered");
            Assert.That(lastEntryPrice.Text == ("$" + newPrice), "Price does not match with as entered");

        }

        public void EditTM(IWebDriver driver)
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3000);

            //Edit the Time and Material that has been created previously
            // Ammend the price to $150.00
            var ammendedPrice = "150.00";
            // Identify and click edit button
            IWebElement editButton = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[5]/a[1]"));
            editButton.Click();

            // Identify price text box and clear the text box
            driver.FindElement(By.XPath("//*[@id='TimeMaterialEditForm']/div/div[4]/div/span[1]/span/input[1]")).Click();
            IWebElement ammendPriceTextBox = driver.FindElement(By.Id("Price"));
            ammendPriceTextBox.Clear();

            // enter a new price to price box
            driver.FindElement(By.XPath("//*[@id='TimeMaterialEditForm']/div/div[4]/div/span[1]/span/input[1]")).Click();
            ammendPriceTextBox.SendKeys(ammendedPrice);

            // Identify Description text box and clear text box
            IWebElement ammendDescriptionTextBox = driver.FindElement(By.Id("Description"));
            ammendDescriptionTextBox.Clear();

            // enter a new ammented description
            var ammendedDescription = "Price has been edited";
            ammendDescriptionTextBox.SendKeys(ammendedDescription);

            // Idendify save button and click
            IWebElement editSaveButton = driver.FindElement(By.Id("SaveButton"));
            editSaveButton.Click();

            // Click on last Pagge
            var goToLastPageButton = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[4]/a[4]/span"));
            goToLastPageButton.Click();

            // Assert ammented time entry in last line
            var lastEnrtyDescription = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[3]"));
            var lastEntryPrice = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[4]"));

            Assert.That(lastEnrtyDescription.Text == ammendedDescription," Description has not been mathed with as edited");
            Assert.That(lastEntryPrice.Text == "$" + ammendedPrice,"Price has not been mathed with as edited");

        }

        public void DeleteTM(IWebDriver driver)
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

            // Click on last Pagge
            Thread.Sleep(2000);
            IWebElement goToLastPageButton = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[4]/a[4]"));
            //Wait.WaitForElementToBeClickable(driver, goToLastPageButton, 5);
            goToLastPageButton.Click();

            //Delete time and Material that has been created previously
            var tableRaws = driver.FindElements(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr"));
            Console.WriteLine(tableRaws.Count);
            var dataIdBeforeDelete = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]")).GetAttribute("data-uid");

            //Identify and click delete button
            IWebElement deleteButton = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[5]/a[2]"));
            deleteButton.Click();

            // Click ok in alert window
            Wait.WaitForAlertToPresent(driver,5);
            IAlert deleteAlert = driver.SwitchTo().Alert();
            deleteAlert.Accept();

            // assert last entry has been deleted
            Wait.WaitForGetNumberOfWebElements(driver, 5, By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr"), tableRaws.Count - 1);
            var tableRawsAfterDelete = driver.FindElements(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr"));
            var dataIdAfterDelete = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]")).GetAttribute("data-uid");

            Console.WriteLine(tableRawsAfterDelete.Count);

            Assert.That(tableRawsAfterDelete.Count == (tableRaws.Count - 1)," Table cound is not reduced");
            Assert.That(dataIdAfterDelete != dataIdBeforeDelete,"Deleted dataID is still avialable");
        }
    }
}
