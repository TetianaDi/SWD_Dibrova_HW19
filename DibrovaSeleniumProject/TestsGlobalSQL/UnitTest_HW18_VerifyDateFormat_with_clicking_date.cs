using DibrovaSeleniumProject.PagesGlobalSQL;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using System;

namespace DibrovaSeleniumProject.TestsGlobalSQL
{
    
    public class UnitTest_HW18_VerifyDateFormat_with_clicking_date
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
        public void VerifyDateFromatClickingDate()
        {
            // Arrange
            driver.Url = "https://www.globalsqa.com/";

            //string nextMonthDate = DateTime.Now.AddMonths(1).ToString("MM/dd/yyyy");

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

            globalSQLDatePickerPage.DatePickerInput.Click();
            globalSQLDatePickerPage.DatePickerNextMonthButton.Click();
            globalSQLDatePickerPage.DatePickerChosenDate.Click();
                        

            var checkDateFormat = globalSQLDatePickerPage.DatePickerInput.GetAttribute("value");
           
            var nextMonthDate = DateTime.Now.AddMonths(1).ToString("MM/dd/yyyy");
            nextMonthDate = nextMonthDate.Replace(".", "/");

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
