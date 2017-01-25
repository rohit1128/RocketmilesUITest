using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System.Threading;

namespace RocketmilesTestingFramework.Pages
{
    public class RocketmilesMainPage : RocketmilesBasePage
    {
        private string url = @"https://www.rocketmiles.com";

        [FindsBy(How = How.ClassName, Using = "rm-logo")]
        public IWebElement RmLogo { get; set; }

        [FindsBy(How = How.ClassName, Using = "text-center")]
        public IWebElement CenterText { get; set; }

        [FindsBy(How = How.ClassName, Using = "contact-widget")]
        public IWebElement ContactUs { get; set; }

        [FindsBy(How = How.ClassName, Using = "lang")]
        public IWebElement LanguageSelector { get; set; }

        [FindsBy(How = How.ClassName, Using = "region")]
        public IWebElement LocationSelector { get; set; }


        [FindsBy(How = How.XPath, Using = "//span[contains(text(), 'Select reward program')]")]
        public IWebElement RewardsSelector { get; set; }

        [FindsBy(How = How.ClassName, Using = "checkin")]
        public IWebElement CheckIn { get; set; }

        [FindsBy(How = How.ClassName, Using = "checkout")]
        public IWebElement CheckOut { get; set; }

        [FindsBy(How = How.ClassName, Using = "search-submit-btn")]
        public IWebElement SubmitBtn { get; set; }


        [FindsBy(How = How.XPath, Using = "//div[contains(text(), 'New York')]")]
        public IWebElement NewYorkLink { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[contains(text(), 'Chicago')]")]
        public IWebElement ChicagoLink { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[contains(text(), 'London')]")]
        public IWebElement LondonLink { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[contains(text(), 'San Francisco')]")]
        public IWebElement SanFranciscoLink { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[contains(@href, '/how-it-works')]")]
        public IWebElement HowItWorksLink{ get; set; }

        [FindsBy(How = How.XPath, Using = "//a[contains(@href, '/about')]")]
        public IWebElement AboutUsLink { get; set; }

        public RocketmilesMainPage(IWebDriver browser)
        {
            this.Driver = browser;
            this.Url = url;
            Driver.Manage().Window.Maximize();
            PageFactory.InitElements(browser, this);
        }


        public ContactUsPage SelectContactUs()
        {
            ContactUs.Click();

            return new ContactUsPage(Driver);
        }

        public HowItWorksPage SelectHowItWorks()
        {
            HowItWorksLink.Click();

            return new HowItWorksPage(Driver);
        }

        public AboutUsPage SelectAboutUs()
        {
            AboutUsLink.Click();

            return new AboutUsPage(Driver);
        }

        public PressPage SelectPress()
        {
            AboutUsLink.Click();

            return new PressPage(Driver);
        }

        public RocketmilesMainPage SelectLanguage(string language="English")
        {
            LanguageSelector.Click();
            Driver.FindElement(By.XPath("//a[contains(text(), '"+language+"')]")).Click();
            Thread.Sleep(3000);

            return new RocketmilesMainPage(Driver);
        }


        public RocketmilesResultsPage SelectTopDestinationLink(string location="New York")
        {
            switch (location)
            {
                case "New York":
                    NewYorkLink.Click();
                    break;
                case "Chicago":
                    ChicagoLink.Click();
                    break;
                case "London":
                    LondonLink.Click();
                    break;
                case "San Francisco":
                    SanFranciscoLink.Click();
                    break;
                default:
                    break;
            }
            Thread.Sleep(5000);

            return new RocketmilesResultsPage(Driver);
        }

        public RocketmilesResultsPage SearchForHotels(string location, string rewardsProgram, string checkIn, string checkOut)
        {
            LocationSelector.Click();

            Driver.FindElement(By.XPath("//*[contains(text(), '" + location + "')]")).Click();

            RewardsSelector.Click();
            Driver.FindElement(By.XPath("//a[contains(text(), '" + rewardsProgram + "')]")).Click();

            CheckIn.Click();
            Driver.FindElement(By.XPath("//a[contains(text(), '" + checkIn + "')]")).Click();

            CheckOut.Click();
            Driver.FindElement(By.XPath("//a[contains(text(), '" + checkOut + "')]")).Click();

            SubmitBtn.Click();
            Thread.Sleep(8000);
            return new RocketmilesResultsPage(Driver);
        }
    }
}
