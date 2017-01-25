using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RocketmilesTestingFramework.Pages
{
    public class RocketmilesResultsPage:RocketmilesBasePage
    {
        [FindsBy(How = How.ClassName, Using = "logo")]
        public IWebElement Logo { get; set; }

        [FindsBy(How = How.ClassName, Using = "reward-program-logo")]
        public IWebElement RewardsProgramLogo { get; set; }

        [FindsBy(How = How.ClassName, Using = "region")]
        public IWebElement Region { get; set; }

        [FindsBy(How = How.ClassName, Using = "checkin-date")]
        public IWebElement CheckInDate { get; set; }

        [FindsBy(How = How.ClassName, Using = "checkout-date")]
        public IWebElement CheckOutDate { get; set; }

        public RocketmilesResultsPage(IWebDriver browser)
        {
            this.Driver = browser;

            PageFactory.InitElements(browser, this);
        }
    }
}
