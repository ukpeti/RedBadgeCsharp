using System;
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
        
        public static String goodEmail = "diamantps@gmail.com";
        public static String goodPassWord = "Kormi_78";
        public static String badEmail = "ba..d@bad.bad";
        public static String username = "ukpeti" + DateTime.Now.ToString("yyyyMMddHHmmss");
        public static String goodRegEmail = DateTime.Now.ToString("yyyyMMddHHmmss") + "@ggg.hu";
        public List<IWebElement> listoflinks;
        public IWebElement i;
         
    // Random email and username for being able to test randomly

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
        [Test]
        public void shouldAllLinkLeadSomewhere()
        {
            IWebDriver driver = new FirefoxDriver();
            driver.Navigate().GoToUrl("http://www.theguardian.com");
            var mainPage = new MainEntryPage(driver);
            listoflinks = mainPage.GetLinks (driver);
            

            for (int n = 0; n < listoflinks.Count; n++) {

                Console.WriteLine(listoflinks[n].Text);
                var beforeWindow = driver.CurrentWindowHandle;
                
                if (driver.FindElement(By.LinkText(listoflinks[n].Text)).Displayed && listoflinks[n].Text != "Sign in"){
                    
                    Console.WriteLine("Found link: " + listoflinks[n].Text);
                    driver.FindElement(By.LinkText(listoflinks[n].Text)).SendKeys(Keys.Shift + Keys.Return);

                    foreach (string handle in driver.WindowHandles)
                    {
                        if (handle != beforeWindow)
                        {
                            driver.SwitchTo().Window(handle);
                            break;
                        }
                    }
                    Console.WriteLine("UJ: " + driver.Url);
                    driver.Close();
                    driver.SwitchTo().Window(beforeWindow);
                    Console.WriteLine("REGI: " + driver.Url);
                }
                else
                {

                    Console.WriteLine("NotFound link: " + listoflinks[n].Text);
                }
                    
                //driver.Navigate().Back();
            }
            
            
            
                            
        }


    }
}
