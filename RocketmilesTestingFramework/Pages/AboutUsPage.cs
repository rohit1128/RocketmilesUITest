using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;


namespace RocketmilesTestingFramework.Pages
{
    public class AboutUsPage:RocketmilesBasePage
    {
        [FindsBy(How = How.Id, Using = "about-page")]
        public IWebElement Body { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[contains(@class, 'text-center')]")]
        public IWebElement CenterText { get; set; }

        public AboutUsPage(IWebDriver browser)
        {
            this.Driver = browser;

            PageFactory.InitElements(browser, this);
        }
    }
}
