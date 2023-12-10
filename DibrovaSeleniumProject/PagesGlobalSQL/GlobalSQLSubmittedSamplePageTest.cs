using OpenQA.Selenium;

namespace DibrovaSeleniumProject.Pages
{
    internal class GlobalSQLSubmittedSamplePageTest
    {
        IWebDriver driver;

        public GlobalSQLSubmittedSamplePageTest(IWebDriver driver)
        {
            this.driver = driver;
        }

        public IWebElement ProfileChossenFile => driver.FindElement(By.CssSelector("[name='file-553']"));

        public IWebElement ProfileNameTextContent => driver.FindElement(By.XPath("//blockquote/descendant::*[contains (text(), 'Name')]"));

        public IWebElement ProfileEmailContent => driver.FindElement(By.XPath("//blockquote/descendant::*[contains (text(), 'Email')]"));

        public IWebElement SelectedExperienceDropdown => driver.FindElement(By.XPath("//blockquote/descendant::*[contains (text(), 'Experience')]"));

        public IWebElement SelectedExpertiseCheckBox => driver.FindElement(By.XPath("//blockquote/descendant::*[contains (text(), 'Expertise')]"));

        public IWebElement SelectedEducationRadioButton => driver.FindElement(By.XPath("//blockquote/descendant::*[contains (text(), 'Education')]"));

        public IWebElement CommentTextContent => driver.FindElement(By.XPath("//blockquote/descendant::*[contains (text(), 'Comment')]"));



    }


}
