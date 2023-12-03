using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace DibrovaSeleniumProject
{
    public class UnitTest_HW14_Task1_ItemsInDropdown
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

        public void VerifyNumberOfItemsInDropdown()
        {
            // Arrange
            driver.Url = "https://www.globalsqa.com/demo-site/select-dropdown-menu/";
            
            IWebElement dropdown = driver.FindElement(By.XPath("//select"));
        
            // Act 
            
            string sizeAttribute = dropdown.GetAttribute("childElementCount");

            int numberOfItems = int.Parse(sizeAttribute);

            int expectedItems = 249;

            // Assert

            Assert.That(expectedItems == numberOfItems, $"Expected items '{expectedItems}' " +
                $"isn't equal current items '{numberOfItems}'");
        }
    }
}
