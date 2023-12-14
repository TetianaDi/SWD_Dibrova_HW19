using OpenQA.Selenium;


namespace DibrovaSeleniumProject.PagesGlobalSQL
{
    internal class GlobalSQLDatePickerPage
    {
        IWebDriver driver;

        public GlobalSQLDatePickerPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public IWebElement TestersHubMainMenuElement => driver.FindElement(By.Id("menu-item-2822"));
        public IWebElement DemoTestingSiteMenuElement => driver.FindElement(By.Id("menu-item-2823"));
        public IWebElement DatePickerMenuElement => driver.FindElement(By.Id("menu-item-2827"));

        public IWebElement DatePickerIFrame => driver.FindElement(By.CssSelector(".demo-frame.lazyloaded"));
        public IWebElement DatePickerInput => driver.FindElement(By.CssSelector(".hasDatepicker"));
        public IWebElement DatePickerNextMonthButton => driver.FindElement(By.CssSelector(".ui-datepicker-next.ui-corner-all"));

        public IWebElement DatePickerChosenDate => driver.FindElement(By.XPath("//td//*[text()='14']"));

    }
}
