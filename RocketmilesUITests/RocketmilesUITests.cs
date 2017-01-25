using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Chrome;
using RocketmilesTestingFramework.Pages;
using System.Threading;

namespace RocketmilesUITests
{
    [TestClass]
    public class RocketmilesUITests
    {
        public IWebDriver Driver { get; set; }
        public WebDriverWait Wait { get; set; }

        [TestInitialize]
        public void SetupTest()
        {
            this.Driver = new ChromeDriver();
            this.Wait = new WebDriverWait(this.Driver, TimeSpan.FromSeconds(30));
        }

        [TestCleanup]
        public void TeardownTest()
        {
            this.Driver.Quit();
        }

        [TestMethod]
        public void NavigationToTheMainPageSucceeds()
        {
            RocketmilesMainPage rocketmilesMainPage = new RocketmilesMainPage(this.Driver);
            rocketmilesMainPage.Navigate();

            var rmLogo = Driver.FindElement(By.ClassName("rm-logo"));

            Assert.IsNotNull(rmLogo);

        }

        [TestMethod]
        public void SelectContactUsButton()
        {
            RocketmilesMainPage rocketmilesMainPage = new RocketmilesMainPage(this.Driver);
            rocketmilesMainPage.Navigate();

            var contactUsPage = rocketmilesMainPage.SelectContactUs();

            Assert.IsNotNull(contactUsPage);
            Assert.AreEqual("How Can We Help?", contactUsPage.ContactHeader.Text);
        }

        [TestMethod]
        public void NavigateToGetAssistancePage()
        {
            RocketmilesMainPage rocketmilesMainPage = new RocketmilesMainPage(this.Driver);
            rocketmilesMainPage.Navigate();

            var contactUsPage = rocketmilesMainPage.SelectContactUs();

            Assert.IsNotNull(contactUsPage);

            var getAssistancePage = contactUsPage.SelectGetAssistance();
            Assert.IsNotNull(getAssistancePage);

            Assert.AreEqual("Ok.", getAssistancePage.ContactHeader.Text);
        }

        [TestMethod]
        public void NavigateToLeaveFeedbackPage()
        {
            RocketmilesMainPage rocketmilesMainPage = new RocketmilesMainPage(this.Driver);
            rocketmilesMainPage.Navigate();

            var contactUsPage = rocketmilesMainPage.SelectContactUs();

            Assert.IsNotNull(contactUsPage);

            var leaveFeedbackPage = contactUsPage.SelectLeaveFeedback();
            Assert.IsNotNull(leaveFeedbackPage);

            Assert.AreEqual("Let us know what you think or how we can improve.", leaveFeedbackPage.ContactHeader.Text);
        }

        [TestMethod]
        public void VerifyChangesInLanguageFunctionsProperly()
        {
            RocketmilesMainPage rocketmilesMainPage = new RocketmilesMainPage(this.Driver);
            rocketmilesMainPage.Navigate();

            Driver.SwitchTo().ActiveElement();
            Driver.FindElement(By.ClassName("close")).Click();

            rocketmilesMainPage = rocketmilesMainPage.SelectLanguage("Deutsch");
           
            Assert.AreEqual("Buchen Sie Hotels und sammeln Sie Tausende Meilen und Punkte pro Nacht", rocketmilesMainPage.CenterText.Text);

            rocketmilesMainPage = rocketmilesMainPage.SelectLanguage("Norsk");

            Assert.AreEqual("Bestill hotell og tjen tusenvis av bonuspoeng for hver natt", rocketmilesMainPage.CenterText.Text);

            rocketmilesMainPage = rocketmilesMainPage.SelectLanguage("Español");

            Assert.AreEqual("Reserva hoteles, gana miles de millas y puntos de fidelización por noche.", rocketmilesMainPage.CenterText.Text);
        }

        [TestMethod]
        public void SearchForHotels()
        {
            var location = "Chicago, IL, United States";
            var rewardsProgram = "Amazon.com Gift Card";
            var checkIn = "27";
            var checkOut = "29";
            RocketmilesMainPage rocketmilesMainPage = new RocketmilesMainPage(this.Driver);
            rocketmilesMainPage.Navigate();

            var rocketmilesResultsPage=rocketmilesMainPage.SearchForHotels(location, rewardsProgram, checkIn, checkOut);

            Assert.IsNotNull(rocketmilesResultsPage);
            Assert.IsNotNull(rocketmilesResultsPage.Logo);
            Assert.IsNotNull(rocketmilesResultsPage.RewardsProgramLogo);

            //Verify image of rewards program logo is correct
            var src = rocketmilesResultsPage.RewardsProgramLogo.GetAttribute("src");
            Assert.AreEqual(@"https://d3b7k68rde2p0w.cloudfront.net/static/Hdym4pbhaWPVtxBtmUhkerw2xt4WvyoE5GjtSJ9n4Jh.png", src);


            Assert.AreEqual("Chicago,IL", rocketmilesResultsPage.Region.Text);
            Assert.AreEqual("Jan 27", rocketmilesResultsPage.CheckInDate.Text);
            Assert.AreEqual("Jan 29", rocketmilesResultsPage.CheckOutDate.Text);
        }

        [TestMethod]
        public void SearchUsingTopDestinationLinks()
        {
            RocketmilesMainPage rocketmilesMainPage = new RocketmilesMainPage(this.Driver);
            rocketmilesMainPage.Navigate();

            var rocketmilesResultsPage = rocketmilesMainPage.SelectTopDestinationLink("London");

            Assert.IsNotNull(rocketmilesResultsPage);
            Assert.IsNotNull(rocketmilesResultsPage.Logo);            

            Assert.AreEqual("New York City, NY", rocketmilesResultsPage.Region.Text);

        }
        [TestMethod]
        public void VerifyHowItWorksLink()
        {
            RocketmilesMainPage rocketmilesMainPage = new RocketmilesMainPage(this.Driver);
            rocketmilesMainPage.Navigate();

            var howItWorksPage=rocketmilesMainPage.SelectHowItWorks();
            Assert.IsNotNull(howItWorksPage);
            Assert.IsNotNull(howItWorksPage.Body);
            Assert.AreEqual("How Rocketmiles Works", howItWorksPage.CenterText.Text);
        }

        [TestMethod]
        public void VerifyAboutUsLink()
        {
            RocketmilesMainPage rocketmilesMainPage = new RocketmilesMainPage(this.Driver);
            rocketmilesMainPage.Navigate();

            var aboutUsPage = rocketmilesMainPage.SelectAboutUs();
            Assert.IsNotNull(aboutUsPage);
            Assert.IsNotNull(aboutUsPage.Body);
            Assert.AreEqual("Get you on vacation faster.", aboutUsPage.CenterText.Text);
        }

        [TestMethod]
        public void VerifyPressLink()
        {
            RocketmilesMainPage rocketmilesMainPage = new RocketmilesMainPage(this.Driver);
            rocketmilesMainPage.Navigate();

            var pressPage = rocketmilesMainPage.SelectPress();
            Assert.IsNotNull(pressPage);
            Assert.IsNotNull(pressPage.PressHeader);
            Assert.AreEqual("Press", pressPage.PressHeader.Text);
        }
    }
}
