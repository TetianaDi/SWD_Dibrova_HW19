using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using DibrovaSeleniumProject.PagesGlobalSQL;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace DibrovaSeleniumProject.TestsGlobalSQL
{

    public class UnitTest_HW18_VerifyDate_with_inserting_date
    {
        IWebDriver driver;

        [SetUp]

        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);
            driver.Manage().Window.Maximize();
        }

        [TearDown]

        public void TearDown()
        {
            driver.Quit();
        }

        [Test]
        public void VerifyDateFromatInsertingDate()
        {
            // Arrange
            driver.Url = "https://www.globalsqa.com/";

            string nextMonthDate = DateTime.Now.AddMonths(1).ToString("MM/dd/yyyy");

            var globalSQLDatePickerPage = new GlobalSQLDatePickerPage(driver);

            // Act

            // Navigate to Dat Picker Page

            var actions = new Actions(driver);

            actions
                .MoveToElement(globalSQLDatePickerPage.TestersHubMainMenuElement)
                .MoveToElement(globalSQLDatePickerPage.DemoTestingSiteMenuElement)
                .Click(globalSQLDatePickerPage.DatePickerMenuElement)
                .Perform();

            driver.SwitchTo().Frame(globalSQLDatePickerPage.DatePickerIFrame);

            // Insert the date and varify format

            globalSQLDatePickerPage.DatePickerInput.SendKeys(nextMonthDate);

            var checkDateFormat = globalSQLDatePickerPage.DatePickerInput.GetAttribute("value");

            // Assert

            Assert.Multiple(() =>
            {
                Assert.That(checkDateFormat == nextMonthDate,
                    $"There is '{checkDateFormat}' format in the date picker" +
                    $" but expected format is '{nextMonthDate}'.");
            });

        }
    }
}
