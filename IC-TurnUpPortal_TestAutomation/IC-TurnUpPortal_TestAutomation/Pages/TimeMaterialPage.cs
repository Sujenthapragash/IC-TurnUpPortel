using System;
using System.Threading;
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
            // click on create new button
            IWebElement createNewButton = driver.FindElement(By.XPath("//*[@id='container']/p/a"));
            createNewButton.Click();
            Thread.Sleep(2000);

            // Click on TypeCode dropdown
            IWebElement typeCodeDropDown = driver.FindElement(By.XPath("//*[@id='TimeMaterialEditForm']/div/div[1]/div/span[1]/span/span[1]"));
            typeCodeDropDown.Click();
            Thread.Sleep(2000);

            // Select time from typeCode dropdown
            IWebElement timeOption = driver.FindElement(By.XPath("//*[@id='TypeCode_listbox']/li[2]"));
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
            var newPrice = "120";
            driver.FindElement(By.XPath("//*[@id='TimeMaterialEditForm']/div/div[4]/div/span[1]/span/input[1]")).Click();
            IWebElement priceTextbox = driver.FindElement(By.Id("Price"));
            priceTextbox.SendKeys(newPrice);

            // Click on "Save" button
            IWebElement saveButton = driver.FindElement(By.Id("SaveButton"));
            saveButton.Click();
            Thread.Sleep(2000);

            // Click on last Pagge
            IWebElement goToLastPageButton = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[4]/a[4]/span"));
            goToLastPageButton.Click();
            Thread.Sleep(2000);

            // Assert new time entry in last line
            IWebElement lastEntryCode = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[1]"));
            IWebElement lastEnrtyDescription = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[3]"));
            IWebElement lastEntryPrice = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[4]"));

            if (lastEntryCode.Text == newCode && lastEnrtyDescription.Text == newDescription && lastEntryPrice.Text == "$" + newPrice + ".00")
            {
                Console.WriteLine("Your new entry has been succesfully added , TEST PASSED!");
            }
            else
            {
                Console.WriteLine("Your new enty has not been added successfully, TEST FAILED!");
            }
        }

        public void EditTM(IWebDriver driver)
        {
            //Edit the Time and Material that has been created previously
            // Ammend the price to $150.00
            var ammendedPrice = "150";
            // Identify and click edit button
            IWebElement editButton = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[5]/a[1]"));
            editButton.Click();
            Thread.Sleep(2000);

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
            Thread.Sleep(2000);

            // Click on last Pagge
            var goToLastPageButton = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[4]/a[4]/span"));
            goToLastPageButton.Click();
            Thread.Sleep(2000);

            // Assert ammented time entry in last line
            var lastEnrtyDescription = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[3]"));
            var lastEntryPrice = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[4]"));


            if (lastEnrtyDescription.Text == ammendedDescription && lastEntryPrice.Text == "$" + ammendedPrice + ".00")
            {
                Console.WriteLine("Entry has been succesfully ammended , TEST PASSED!");
            }
            else
            {
                Console.WriteLine("Enty has not been ammended successfully, TEST FAILED!");
            }

        }

        public void DeleteTM(IWebDriver driver)
        {
            //Delete time and Material that has been created previously
            var tableRaws = driver.FindElements(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr"));
            var dataIdBeforeDelete = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]")).GetAttribute("data-uid");

            //Identify and click delete button
            IWebElement deleteButton = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[5]/a[2]"));
            deleteButton.Click();
            Thread.Sleep(2000);

            // Click ok in alert window
            IAlert deleteAlert = driver.SwitchTo().Alert();
            deleteAlert.Accept();
            Thread.Sleep(2000);
            // assert last entry has been deleted
            var tableRawsAfterDelete = driver.FindElements(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr"));
            var dataIdAfterDelete = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]")).GetAttribute("data-uid");
            if (tableRawsAfterDelete.Count == (tableRaws.Count - 1) && dataIdAfterDelete != dataIdBeforeDelete)
            {
                Console.WriteLine("Your last entery has been deleted, TEST PASSED!");
            }
            else
            {
                Console.WriteLine("You last entery has not been deleted, TEST FAILED!");
            }
        }
    }
}
