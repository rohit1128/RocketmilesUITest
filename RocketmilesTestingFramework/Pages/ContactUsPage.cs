using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RocketmilesTestingFramework.Pages
{
    public class ContactUsPage:RocketmilesBasePage
    {
        [FindsBy(How = How.ClassName, Using = "contact-header")]
        public IWebElement ContactHeader { get; set; }

        [FindsBy(How = How.Id, Using = "get-assistance")]
        public IWebElement GetAssistance { get; set; }

        [FindsBy(How = How.Id, Using = "leave-feedback")]
        public IWebElement LeaveFeedback { get; set; }


        public ContactUsPage(IWebDriver browser)
        {
            this.Driver = browser;

            PageFactory.InitElements(browser, this);
        }

        public LeaveFeedbackPage SelectLeaveFeedback()
        {
            LeaveFeedback.Click();

            return new LeaveFeedbackPage(Driver);
        }

        public GetAssistancePage SelectGetAssistance()
        {
            LeaveFeedback.Click();

            return new GetAssistancePage(Driver);
        }
    }
}
