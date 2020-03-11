using OpenQA.Selenium;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace UbsTask
{
    class CartPage: BasePage
    {
        public By CheckoutButtonLoc => By.Name("checkout");
        public By ClassicCartLabelLoc => By.XPath("//*[@class='CartItem__Variant'][contains(text(),'Classic')]");
        public By MiniCartLabelLoc => By.XPath("//*[@class='CartItem__Variant'][contains(text(),'Mini')]");
        public By PlusButtonLoc => By.XPath("//*[@title='Set quantity to 2']");
        public By TotalPriceLoc => By.CssSelector("button[name = 'checkout'] > [data-money-convertible]");
        public By BandsCounterLoc => By.ClassName("QuantitySelector__CurrentQuantity");
        public By RemoveAllLoc => By.XPath("//*[@data-action='remove-item']");
        public By CartIsEmptyInfoLoc => By.XPath("//*[@class='Cart__Empty Heading u-h5']"); 
        public IWebElement CheckoutButton => driver.FindElement(CheckoutButtonLoc);
        public IWebElement PlusButton => driver.FindElement(PlusButtonLoc);
        public IWebElement BandsCounter => driver.FindElement(BandsCounterLoc);
        public IWebElement RemoveAllButton => driver.FindElement(RemoveAllLoc);
        public IWebElement CartIsEmptyInfo => driver.FindElement(CartIsEmptyInfoLoc);
        public IWebElement TotalPrice => driver.FindElement(TotalPriceLoc);

        public void PlusButtonClick()
        {
            string howManybands = BandsCounter.GetAttribute("value");
            wait.Until(ExpectedConditions.ElementToBeClickable(PlusButtonLoc));
            PlusButton.Click();
            wait.Until(x => BandsCounter.GetAttribute("value")!=howManybands);
        }

        public void CheckoutButtonClick()
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(CheckoutButtonLoc));
            CheckoutButton.Click();
        }

        public string GetTotalPrice()
        {
            wait.Until(ExpectedConditions.ElementIsVisible(TotalPriceLoc));
            return TotalPrice.Text;
        }

        public void RemoveAllBands()
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(RemoveAllLoc));
            RemoveAllButton.Click();
        }
    }
}
