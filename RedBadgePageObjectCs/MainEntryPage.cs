using OpenQA.Selenium;

namespace RedBadgePageObjectCs
{
    internal class MainEntryPage : Page
    {
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
    }
}
