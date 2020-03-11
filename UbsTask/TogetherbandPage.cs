using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace UbsTask
{
    public class TogetherbandPage : BasePage
    {
        public string Url => "https://togetherband.org/pages/ubs-in-society?intCampID=HPPROMOTEASER-CH-TOGETHERBAND-XMAS-P4";
        public By BuyClassicNoPovertyButtonLoc => By.XPath("//*[@data-id='20985766903872']");
        public By BuyMiniNoPovertyButtonLoc => By.XPath("//*[@data-id='20985415073856']");
        public By CookiesButtonLoc => By.XPath("//*[@aria-label='dismiss cookie message']");
        public IWebElement CookiesButton => driver.FindElement(CookiesButtonLoc);
        public IWebElement BuyClassicNoPovertyButton => driver.FindElement(BuyClassicNoPovertyButtonLoc);
        public IWebElement BuyMiniNoPovertyButton => driver.FindElement(BuyMiniNoPovertyButtonLoc);
        public IWebElement CurrencyDropdown => driver.FindElement(By.XPath("//*[@class='select-css Header__Icon Icon-Wrapper Icon-Wrapper--clickable CurrencySelector__Select']"));
        public SelectElement SelectElement => new SelectElement(CurrencyDropdown);

        public void CookiesButtonClick()
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(CookiesButtonLoc));
            CookiesButton.Click();
        }

        public void BuyClassicNoPovertyButtonClick()
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(BuyClassicNoPovertyButtonLoc));
            BuyClassicNoPovertyButton.Click();
        }

        public void BuyMiniNoPovertyButtonClick()
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(BuyMiniNoPovertyButtonLoc));
            BuyMiniNoPovertyButton.Click();
        }

        public void CurrencySelection(string currency)
        {
            SelectElement.SelectByValue(currency);
        }






    }
}