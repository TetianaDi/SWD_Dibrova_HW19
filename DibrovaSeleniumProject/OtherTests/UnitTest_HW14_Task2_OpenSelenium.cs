using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;

namespace DibrovaSeleniumProject
{
    public class UnitTest_HW14_Task2_OpenSelenium
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

        public void VerifyOpeningSeleniumSite()
        {
            // Arrange
            driver.Url = "https://www.google.com";

            var expectedUrl = "https://www.selenium.dev/";

            var actualURL = "https://www.selenium.dev/";

            // Act 

            IWebElement searchInput = driver.FindElement(By.XPath("//*[@jsname='yZiJbe']"));
            searchInput.SendKeys("Selenium");

            IWebElement searchButton = driver.FindElement(By.XPath("//*[@class='gNO89b'][@role='button']"));
            searchButton.Click();

            IWebElement seleniumLink = driver.FindElement(By.CssSelector("[href='https://www.selenium.dev/']"));
            seleniumLink.Click();

            // Assert

            Assert.That(expectedUrl == actualURL, $"Expected page URL '{expectedUrl}' " +
                $"isn't equal actual page URL '{driver.Url}'");
        }
    }
}
