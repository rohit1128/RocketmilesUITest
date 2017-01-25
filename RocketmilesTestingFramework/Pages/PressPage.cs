using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace RocketmilesTestingFramework.Pages
{
    public class PressPage:RocketmilesBasePage
    {
        [FindsBy(How = How.Id, Using = "press-header")]
        public IWebElement PressHeader { get; set; }

        public PressPage(IWebDriver browser)
        {
            this.Driver = browser;

            PageFactory.InitElements(browser, this);
        }
    }
}
