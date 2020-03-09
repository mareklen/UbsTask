using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using TechTalk.SpecFlow;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace UbsTask
{
    [Binding]
    class TestsSteps
    {
        private TogetherbandPage togetherbandPage = new TogetherbandPage();

        private IWebDriver driver;
        private WebDriverWait wait;

        public TestsSteps()
        {
            driver = (IWebDriver)ScenarioContext.Current["driver"];
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
        }

        [Given(@"I am on TogetherBand page")]
        public void GivenIAmOnTogetherBandPage()
        {
            togetherbandPage.GoToUrl(togetherbandPage.Url);
            //wait.Until(ExpectedConditions.ElementToBeClickable(togetherbandPage.buyClassicNoPovertyButtonLoc));
            wait.Until(ExpectedConditions.ElementIsVisible(togetherbandPage.cookiesButtonLoc));
            togetherbandPage.cookiesButtonClick();
        }

        [Given(@"I bought classic No Poverty band")]
        public void GivenIBoughtClassicNoPovertyBand()
        {
            togetherbandPage.buyClassicNoPovertyButtonClick();
        }


    }
}
