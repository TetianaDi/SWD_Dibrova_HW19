using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;

namespace DibrovaSeleniumProject.OtherTests
{

    public class Test_HW19_Task2_Verify_error_message_invalid_login_Ukr_Net
    {
        IWebDriver driver;

        [SetUp]

        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);
            driver.Manage().Window.Maximize();
        }

        [TearDown]

        public void TearDown()
        {
            driver.Quit();
        }

        [Test]
        public void InvalidLoginToUkrNetMailVerifyErrorMessage()
        {
            // Arrange
            driver.Url = "https://www.ukr.net/ ";

            string InvalidUsername = "voltage_phm";
            string InvalidPassword = "16Voltage*phm";

            // Act

            driver.SwitchTo().Frame(driver.FindElement(By.CssSelector("[name='mail widget']")));

            IWebElement mailboxNameInput = driver.FindElement(By.CssSelector("._2p19QPd0[name='login']"));
            mailboxNameInput.SendKeys(InvalidUsername);

            IWebElement passwordInput = driver.FindElement(By.CssSelector("._2p19QPd0[type='password']"));
            passwordInput.SendKeys(InvalidPassword);

            IWebElement clickEnterButton = driver.FindElement(By.CssSelector("._1ykKPvxX"));
            clickEnterButton.Click();

            IWebElement errorMessage = driver.FindElement(By.XPath("//*[text()='Неправильні дані']"));

            bool verifyErrorMessage = errorMessage.Displayed;

            // Assert

            Assert.That(verifyErrorMessage == true, $" The error message '{errorMessage}' isn't displayed");

            
        }
    }
}
