using System;
using OpenQA.Selenium;


namespace RedBadgePageObjectCs
{
    internal class LoginPage : Page
    {
        private IWebElement EmailInput
        {
            get { return Wait.Until(d => Driver.FindElement(By.Id("email"))); }
        }

        private IWebElement PasswordInput
        {
            get { return Wait.Until(d => Driver.FindElement(By.Id("password"))); }
        }
        
        private IWebElement LogInButton
        {
            get { return Wait.Until(d => Driver.FindElement(By.CssSelector("input.button"))); }
        }

        protected override string PageName
        {
            get { return "Sign In"; }
        }

        protected override string PageTitle
        {
            get { return "Sign in to the Guardian"; }
        }

        public LoginPage(IWebDriver driver)
            : base(driver)
        {
        }
        private void TypeEmail(String email)
        {
            EmailInput.SendKeys(email);
        }
        private void TypePassword(String password)
        {
            PasswordInput.SendKeys(password);
        }
        private MainEntryPage ClickLoginButton()
        {
            LogInButton.Click();

            return new MainEntryPage(Driver);
        }
        public MainEntryPage LogIn(String email, String password)
        {
            TypeEmail(email);
            TypePassword(password);

            return ClickLoginButton();
        }
    }
}
