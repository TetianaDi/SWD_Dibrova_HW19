using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DibrovaSeleniumProject.Pages
{
    public class GlobalSQLSamplePageTest
    {
        IWebDriver driver;

        public GlobalSQLSamplePageTest(IWebDriver driver)
        {
            this.driver = driver;
        }

        public IWebElement ProfilePicChoseFileButton => driver.FindElement(By.CssSelector("[name='file-553']"));

        public IWebElement ProfileNameTextElement => driver.FindElement(By.Id("g2599-name"));

        public IWebElement ProfileEmailImput => driver.FindElement(By.Id("g2599-email"));

        public IWebElement ExperienceDropdown => driver.FindElement(By.CssSelector("[id='g2599-experienceinyears'] [value='3-5']"));

        public IWebElement ExpertiseCheckBox => driver.FindElement(By.CssSelector("[value='Functional Testing']"));

        public IWebElement EducationRadioButton => driver.FindElement(By.XPath("//*[text() = ' Graduate']"));

        public IWebElement CommentTextElement => driver.FindElement(By.Id("contact-form-comment-g2599-comment"));

        public IWebElement SubmitButton => driver.FindElement(By.CssSelector(".pushbutton-wide"));
    }
}
