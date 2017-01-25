using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RocketmilesTestingFramework.Pages
{
    public class GetAssistancePage:RocketmilesBasePage
    {
        [FindsBy(How = How.ClassName, Using = "contact-header")]
        public IWebElement ContactHeader { get; set; }

        public GetAssistancePage(IWebDriver browser)
        {
            this.Driver = browser;

            PageFactory.InitElements(browser, this);
        }
    }
}
