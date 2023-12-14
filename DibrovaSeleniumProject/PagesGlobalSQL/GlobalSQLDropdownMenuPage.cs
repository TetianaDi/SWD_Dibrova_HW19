using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DibrovaSeleniumProject.PagesGlobalSQL
{
    internal class GlobalSQLDropdownMenuPage
    {
        IWebDriver driver;

        public GlobalSQLDropdownMenuPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public IWebElement DropdownSelectCountry => driver.FindElement(By.XPath("//select"));

    }
}
