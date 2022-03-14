using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using TechTalk.SpecFlow;
using TFL_Jonathan_Alade;

namespace TFL.Steps
{
    [Binding]
    public sealed class TFLStepDefinition
    {
        ElementPage ele = new ElementPage();

        IWebDriver driver = new ChromeDriver();

        [Given(@"the user navigates to the TFL website")]
        public void GivenTheUserNavigatesToTheTFLWebsite()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://tfl.gov.uk/plan-a-journey/");
            driver.Manage().Window.Maximize();
            Console.WriteLine("Launch the TFL website successfully");
            Thread.Sleep(1000);
            driver.FindElement(By.Id(ele.cookies)).Click();
            Thread.Sleep(1000);

            driver.FindElement(By.XPath(ele.EndFinalCookies)).Click();

        }

        [Given(@"the user enters a valid (.*) station")]
        public void GivenTheEntersAValidStation(string p0) 
        {

            IWebElement InputFrom = driver.FindElement(By.Name("InputFrom"));
            InputFrom.SendKeys(p0);

        }

        [Given(@"enters a valid (.*) station")]
        public void GivenEntersAValidStation(string p0)
        {
            IWebElement InputTo = driver.FindElement(By.Name("InputTo"));
            InputTo.SendKeys(p0);
            Console.WriteLine("Entered the InputFrom & InputTo destinations successfully");
        }

        [When(@"the user clicks Plan my Journey")]
        public void WhenTheUserClicksPlanMyJourney()
        {
            IWebElement PlanJourneyButton = driver.FindElement(By.Id("plan-journey-button"));
            PlanJourneyButton.Click();
            Console.WriteLine("Plan my Journey page is displayed in Chrome");

        }

        [Then(@"the user should see the journey information containing (.*), (.*)")]
        public void ThenTheUserShouldSeeTheJourneyInformationContainingKnightsbridgeUndergroundStationSudburyHillUndergroundStation(string p0, string p1)
        {
            Assert.True(driver.FindElement(By.XPath("//*[@id='plan-a-journey']/div[1]/div[1]/div[1]/span[2]/strong")).Text.Contains(p0));
            Assert.True(driver.FindElement(By.XPath("//*[@id='plan-a-journey']/div[1]/div[1]/div[2]/span[2]/strong")).Text.Contains(p1));
        }


        [Then(@"the user should see two warning signs on the page which says the fields are required")]
        public void ThenTheUserShouldSeeTwoWarningSignsOnThePageWhichSaysTheFieldsAreRequired()
        {
            Assert.True(driver.FindElement(By.XPath("//span[@id='InputFrom-error']")).Text.Contains("The From field is required."));
            Assert.True(driver.FindElement(By.XPath("//span[@id='InputTo-error']")).Text.Contains("The To field is required."));
        }

        [Then(@"the user navigates back to the HomePage")]
        public void ThenTheUserNavigatesBackToTheHomePage()
        {
            //
            IWebElement HomePage = driver.FindElement(By.LinkText("Plan a journey"));
            HomePage.Click();
        }

        [Then(@"the user clicks on the Recents Tab, to view the previous journeys")]
        public void ThenTheUserClicksOnTheRecentsTabToViewThePreviousJourneys()
        {
            IWebElement Recents = driver.FindElement(By.LinkText("Recents"));
            Recents.Click();
        }

        [When(@"the user edits the journey in the (.*) field")]
        public void WhenTheUserEditsTheJourneyInTheField(string p0)
        {
            IWebElement EditJourney = driver.FindElement(By.XPath("//*[@id=\"plan-a-journey\"]/div[1]/div[3]/a/span"));
            EditJourney.Click();

            Thread.Sleep(2000);

            IWebElement InputFromClear = driver.FindElement(By.XPath("//*[@id=\"search-filter-form-0\"]/div/div/a"));
            InputFromClear.Click();


            IWebElement InputFrom = driver.FindElement(By.Name("InputFrom"));
            InputFrom.SendKeys(p0);
        }

        [Then(@"the user updates the journey")]
        public void ThenTheUserUpdatesTheJourney()
        {
            IWebElement Update = driver.FindElement(By.Id("plan-journey-button"));
            Update.Click();
        }

        [Given(@"enters a invalid (.*) station")]
        public void GivenEntersAInvalidStation(string p0)

        {
            IWebElement InputTo = driver.FindElement(By.Name("InputTo"));
            InputTo.SendKeys(p0);
        }



    }
}

