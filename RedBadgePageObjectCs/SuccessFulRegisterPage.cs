using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;

namespace RedBadgePageObjectCs
{
    internal class SuccessFulRegisterPage:Page
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

        private IWebElement ContinueButton
        {
            get { return Wait.Until(d => Driver.FindElement(By.CssSelector("a.button"))); }
        }

        public SuccessFulRegisterPage(IWebDriver driver) : base(driver) {

             ContinueButton.Click();
        }

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
        private RegisterPage RegInButton()
        {
            RegButton.Click();

            return new RegisterPage(Driver);
        }
        public RegisterPage Register(String username,String email, String password)
        {
            TypeUserName(username);
            TypeEmail(email);
            TypePassword(password);
            TypePasswordAgain(password);
            AcceptTermsCheck();
            
            return RegInButton();
        }

        protected override string PageName
        {
            get { return "RegistrationSuccessfulPage"; }
        }

        protected override string PageTitle
        {
            get { return "Registration complete on the Guardian"; }
        }

   
        
    }
}
