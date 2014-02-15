﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using System.IO;
using NUnit.Framework;


namespace RedBadgePageObjectCs
{
[TestFixture]
    public class TestLogin
    {
        
        public static String goodEmail = "FILLIN";
        public static String goodPassWord = "FILLIN";
        public static String badEmail = "ba..d@bad.bad";
        public static String username = "FILLIN";
        public static String goodRegEmail = "FILLIN";
        

        [Test]
        public void shouldUserBeAbleToLoginIn ()
        {
                   
            IWebDriver driver = new FirefoxDriver();
            driver.Navigate().GoToUrl("https://id.theguardian.com/signin");
            var loginPage = new LoginPage(driver);
            var MainEntryPage = loginPage.LogIn(goodEmail, goodPassWord);
            Assert.IsTrue(MainEntryPage != null);
        }

        [Test,ExpectedException(typeof(NoSuchWindowException))]
        public void shouldNotUserBeAbleToLoginIn()
        {

            IWebDriver driver = new FirefoxDriver();
            driver.Navigate().GoToUrl("https://id.theguardian.com/signin");
            var loginPage = new LoginPage(driver);
            var MainEntryPage = loginPage.LogIn(badEmail, goodPassWord);
            Assert.IsFalse(MainEntryPage != null);
        }
        [Test]
        public void shouldUserBeAbleToRegister()
        {
            IWebDriver driver = new FirefoxDriver();
            driver.Navigate().GoToUrl("https://id.theguardian.com/register");
            var registerPage = new RegisterPage(driver);
            var SuccessfulRegisterPage = registerPage.Register(username, goodRegEmail, goodPassWord);
            Assert.IsTrue(SuccessfulRegisterPage != null);
        }
        [Test, ExpectedException(typeof(NoSuchWindowException))]
        public void shouldNotUserBeAbleToRegister()
        {
            IWebDriver driver = new FirefoxDriver();
            driver.Navigate().GoToUrl("https://id.theguardian.com/register");
            var registerPage = new RegisterPage(driver);
            var SuccessfulRegisterPage = registerPage.Register(username, badEmail, goodPassWord);
            Assert.IsTrue(SuccessfulRegisterPage != null);
        }
    }
}
