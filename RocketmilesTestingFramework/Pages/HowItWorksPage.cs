using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RocketmilesTestingFramework.Pages
{
    public class HowItWorksPage:RocketmilesBasePage
    {
        [FindsBy(How = How.Id, Using = "how-it-works-page")]
        public IWebElement Body { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[contains(@class, 'text-center')]")]
        public IWebElement CenterText { get; set; }

        public HowItWorksPage(IWebDriver browser)
        {
            this.Driver = browser;

            PageFactory.InitElements(browser, this);
        }
    }
}
