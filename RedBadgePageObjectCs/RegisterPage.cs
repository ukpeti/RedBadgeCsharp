using System;
using OpenQA.Selenium;

namespace RedBadgePageObjectCs
{
    internal class RegisterPage : Page
    {
        private IWebElement UserNameInput
        {
            get { return Wait.Until(d => Driver.FindElement(By.Id("username"))); }
        }
       
        private IWebElement EmailInput
        {
            get { return Wait.Until(d => Driver.FindElement(By.Id("email"))); }
        }

        private IWebElement PasswordInput
        {
            get { return Wait.Until(d => Driver.FindElement(By.Id("password"))); }
        }
        
        private IWebElement PasswordInput2
        {
            get { return Wait.Until(d => Driver.FindElement(By.Id("password-again"))); }
        }
        private IWebElement AcceptTerms
        {
            get { return Wait.Until(d => Driver.FindElement(By.Id("accept-terms"))); }
        }
        
        private IWebElement RegButton
        {
            get { return Wait.Until(d => Driver.FindElement(By.CssSelector("input.button"))); }
        }
        protected override string PageName
        {
            get { return "Registration Page"; }
        }

        protected override string PageTitle
        {
            get { return "Register for the Guardian"; }
        }

        public RegisterPage(IWebDriver driver) : base(driver) { }

        private void TypeUserName(String username)
        {
            UserNameInput.SendKeys(username);
        }
        private void TypeEmail(String email)
        {
            EmailInput.SendKeys(email);
        }
        private void TypePassword(String password)
        {
            PasswordInput.SendKeys(password);
        }
        private void TypePasswordAgain(String password)
        {
            PasswordInput2.SendKeys(password);
        }
        private void AcceptTermsCheck()
        {
           AcceptTerms.Click();

            
        }
        private SuccessFulRegisterPage RegInButton()
        {
            RegButton.Click();

            return new SuccessFulRegisterPage(Driver);
        }
        public SuccessFulRegisterPage Register(String username, String email, String password)
        {
            TypeUserName(username);
            TypeEmail(email);
            TypePassword(password);
            TypePasswordAgain(password);
            AcceptTermsCheck();
            return RegInButton();
        }
    }
}
