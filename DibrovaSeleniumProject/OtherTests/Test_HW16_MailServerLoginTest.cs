using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;

namespace DibrovaSeleniumProject
{

    public class Test_HW16_MailServerLoginTest
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
        public void LoginToMailServerAndVerifyLoggedIn()
        {
            // Arrange
            driver.Url = "https://accounts.ukr.net/login?client_id=9GLooZH9KjbBlWnuLkVX";

            string Username = "voltage_phm";
            string Password = "116Voltage*phm";

            // Act 
            IWebElement mailboxNameInput = driver.FindElement(By.CssSelector("[name = 'login']"));
            mailboxNameInput.SendKeys(Username);

            IWebElement passwordInput = driver.FindElement(By.CssSelector("[name = 'password']"));
            passwordInput.SendKeys(Password);

            IWebElement clickSubmitButton = driver.FindElement(By.CssSelector(".Ol0-ktls.jY4tHruE._2yaudugp"));
            clickSubmitButton.Click();

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);

            IWebElement verifyLoginInElement = driver.FindElement(By.CssSelector(".login-button__user"));
            bool statusOfLoginInElement = verifyLoginInElement.Displayed;

            // Assert

            Assert.That(statusOfLoginInElement == true, $"Expected status of login element '{statusOfLoginInElement} isn't {true}'");      
                

            

        }
    }
}
