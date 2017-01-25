using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RocketmilesTestingFramework.Pages
{
    public class RocketmilesBasePage
    {
        private IWebDriver driver = null;
        private string url = @"https://www.rocketmiles.com/";

        public IWebDriver Driver
        {
            get
            {
                return driver;
            }
            set
            {
                driver = value;
            }
        }
        public string Url
        {
            get
            {
                return url;
            }
            set
            {
                url = value;
            }
        }


        public void Navigate()
        {
            this.Driver.Navigate().GoToUrl(this.url);
            Thread.Sleep(500);
            Driver.SwitchTo().ActiveElement();
            Driver.FindElement(By.ClassName("close")).Click();
        }
    }
}
