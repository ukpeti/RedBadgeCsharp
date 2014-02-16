using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace RedBadgePageObjectCs
{
    internal class MainEntryPage : Page
    {
        private List<IWebElement> _pageLinks;
        

        protected override string PageName
        {
            get { return "Main Page"; }
        }

        protected override string PageTitle
        {
            get { return "Latest news, sport and comment from the Guardian | The Guardian"; }
        }

        	public MainEntryPage(IWebDriver driver) : base(driver)
{
}

            public List<IWebElement> GetLinks (IWebDriver driver)
            {
                
                if (_pageLinks == null)
                {
                    _pageLinks = driver.FindElements(By.TagName("a")).ToList();
                }

                return _pageLinks;
            }
    }
}
