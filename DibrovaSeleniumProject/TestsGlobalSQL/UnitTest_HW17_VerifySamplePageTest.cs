using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using DibrovaSeleniumProject.Pages;
using OpenQA.Selenium.Interactions;

namespace DibrovaSeleniumProject.Tests
{

    public class UnitTest_HW17_VerifySamplePageTest
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
        public void VerifyInformatioSamplePageTest()
        {
            // Arrange
            driver.Url = "https://www.globalsqa.com/samplepagetest/";
            string filePath = @"C:\Users\Tetiana.Dibrova\Desktop\AQA\testPic.gif";

            string userName = "User Name";

            string userEmail = "voltage_phm@ukr.net";

            string userComment = "test comment";

            // Act 

            // Fill in form 
            var globalSQLSamplePage = new GlobalSQLSamplePageTest(driver);                
            
            globalSQLSamplePage.ProfilePicChoseFileButton.SendKeys(filePath);
            string exepectedFileValue = globalSQLSamplePage.ProfilePicChoseFileButton.GetAttribute("value");

            globalSQLSamplePage.ProfileNameTextElement.SendKeys(userName);
            string exepectedUserNameValue = globalSQLSamplePage.ProfileNameTextElement.GetAttribute("value");

            globalSQLSamplePage.ProfileEmailImput.SendKeys(userEmail);
            string exepectedEmailValue = globalSQLSamplePage.ProfileNameTextElement.GetAttribute("value");

            globalSQLSamplePage.ExperienceDropdown.Click();                   
            string expectedExperienceDropdownValue = globalSQLSamplePage.ExperienceDropdown.GetAttribute("value");

            var yCord = globalSQLSamplePage.ExpertiseCheckBox.Location.Y;
            var windowHeight = driver.Manage().Window.Size.Height;

            Actions actions = new Actions(driver);
            actions.ScrollByAmount(0, windowHeight / 2).Perform();

            globalSQLSamplePage.ExpertiseCheckBox.Click();
            string expectedSelectedExpertiseCheckBox = globalSQLSamplePage.ExpertiseCheckBox.GetAttribute("textContent");


            globalSQLSamplePage.EducationRadioButton.Click();
            string expectedSelectedEducationRadioButton = globalSQLSamplePage.EducationRadioButton.GetAttribute("textContent");

            globalSQLSamplePage.CommentTextElement.SendKeys(userComment);
            string expectedCommentTextContent = globalSQLSamplePage.CommentTextElement.GetAttribute("value");


            actions.ScrollByAmount(0, yCord).Perform();

            globalSQLSamplePage.SubmitButton.Click();

            // Verify submitted form
            var globalSQLSubmittedSamplePageTest = new GlobalSQLSubmittedSamplePageTest(driver);

            string checkFileValue = globalSQLSubmittedSamplePageTest.ProfileChossenFile.GetAttribute("value");
            string checkUserNameValue = globalSQLSubmittedSamplePageTest.ProfileNameTextContent.GetAttribute("textContent");

            string checkEmailValue = globalSQLSubmittedSamplePageTest.ProfileEmailContent.GetAttribute("textContent");
            string checkExperienceDropdownValue = globalSQLSubmittedSamplePageTest.SelectedExperienceDropdown.GetAttribute("textContent");

            string checkSelectedExpertiseCheckBox = globalSQLSubmittedSamplePageTest.SelectedExpertiseCheckBox.GetAttribute("textContent");
            string checkSelectedEducationRadioButton = globalSQLSubmittedSamplePageTest.SelectedEducationRadioButton.GetAttribute("textContent");

            string checkCommentTextContent = globalSQLSubmittedSamplePageTest.CommentTextContent.GetAttribute("textContent");




            // Assert 
            Assert.Multiple(() =>
            {
                Assert.That(checkFileValue == exepectedFileValue,
                    $"There is '{checkFileValue}' value for the Profice Pic file name " +
                    $"but expected value is '{exepectedFileValue}'.");

                Assert.That(checkUserNameValue.Contains(userName),
                    $"User name doesn't contains '{userName}' " +
                    $"but actual value for user name is '{exepectedUserNameValue}'.");

                Assert.That(checkEmailValue.Contains(userEmail),
                    $"Email doesn't contains '{userEmail}' " +
                    $"but actual value for email is '{exepectedEmailValue}'.");

                Assert.That(checkExperienceDropdownValue.Contains(expectedExperienceDropdownValue),
                    $"There is '{checkExperienceDropdownValue}' value for the Experience dropdown" +
                    $" but expected value is '{expectedExperienceDropdownValue}'.");

                Assert.That(checkSelectedExpertiseCheckBox.Contains(expectedSelectedExpertiseCheckBox),
                    $"There is '{checkSelectedExpertiseCheckBox}' value for the Expertise check box" +
                    $" but expected value is '{expectedSelectedExpertiseCheckBox}'.");

                Assert.That(checkSelectedEducationRadioButton.Contains(expectedSelectedEducationRadioButton),
                    $"There is '{checkSelectedEducationRadioButton}' value for the Education radio button" +
                    $" but expected value is '{expectedSelectedEducationRadioButton}'.");

                Assert.That(checkCommentTextContent.Contains(expectedCommentTextContent),
                    $"User comment contains '{checkCommentTextContent}'" +
                    $" but actual value for user comment is '{expectedCommentTextContent}'.");


            });

        }
    }
}
