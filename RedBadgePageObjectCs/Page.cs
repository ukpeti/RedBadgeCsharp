using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;


namespace RedBadgePageObjectCs
{
    internal abstract class Page
    {
        protected readonly IWebDriver Driver;
        protected readonly WebDriverWait Wait;

        protected abstract string PageName { get; }
        protected abstract string PageTitle { get; }

        protected Page(IWebDriver driver)
        {
            Driver = driver;
            Wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            VerifyPage();
        }

        private void VerifyPage()
        {
           if (Driver.Title != PageTitle)
                throw new NoSuchWindowException("This is not the " + PageName + " page.");
        }
    }
}
