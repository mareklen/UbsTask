using OpenQA.Selenium;
using System;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace UbsTask
{
    public class TogetherbandPage : BasePage
    {
        public string Url => "https://togetherband.org/pages/ubs-in-society?intCampID=HPPROMOTEASER-CH-TOGETHERBAND-XMAS-P4";
        public By buyClassicNoPovertyButtonLoc => By.XPath("//*[@data-id='20985766903872']");
        public By cookiesButtonLoc => By.XPath("//*[@aria-label='dismiss cookie message']");
        private IWebElement cookiesButton => driver.FindElement(cookiesButtonLoc);
        private IWebElement buyClassicNoPovertyButton => driver.FindElement(buyClassicNoPovertyButtonLoc);

        public void buyClassicNoPovertyButtonClick()
        {
            ExpectedConditions.ElementToBeClickable(buyClassicNoPovertyButtonLoc);
            buyClassicNoPovertyButton.Click();
        }

        public void cookiesButtonClick()
        {
            //wait.Until(x => cookiesButton.Displayed);
            wait.Until(ExpectedConditions.ElementToBeClickable(cookiesButtonLoc));
            cookiesButton.Click();
        }
    }
}