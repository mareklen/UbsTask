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
        private CartPage cartPage = new CartPage();

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
            wait.Until(ExpectedConditions.ElementIsVisible(togetherbandPage.BuyClassicNoPovertyButtonLoc));
            togetherbandPage.CookiesButtonClick();
        }

        [Given(@"I buy classic No Poverty band")]
        public void GivenIBoughtClassicNoPovertyBand()
        {
            togetherbandPage.BuyClassicNoPovertyButtonClick();
        }

        [When(@"I buy (.*) No Poverty band")]
        public void GivenIBuyNoPovertyBand(string bandSize)
        {
            if (bandSize == "classic")
            {
                togetherbandPage.BuyClassicNoPovertyButtonClick();
            }
            else
            {
                togetherbandPage.BuyMiniNoPovertyButtonClick();
            }
        }

        [Then(@"I can see shopping cart opened")]
        public void ThenICanSeeShoppingCartOpened()
        {
            Assert.That(wait.Until(ExpectedConditions.ElementIsVisible(cartPage.CheckoutButtonLoc)).Displayed,
                    "cart is not opened");
        }

        [Given(@"there is (.*) No Poverty band added to the cart")]
        [Then(@"there is (.*) No Poverty band added to the cart")]
        public void ThenThereIsClassicNoPovertyBandAddedToTheCart(string bandSize)
        {
            if (bandSize == "classic")
            {
                Assert.That(wait.Until(ExpectedConditions.ElementIsVisible(cartPage.ClassicCartLabelLoc)).Displayed,
                    "classic band is not in the cart");
            }
            else
            {
                Assert.That(wait.Until(ExpectedConditions.ElementIsVisible(cartPage.MiniCartLabelLoc)).Displayed,
                    "classic band is not in the cart");
            }
        }

        [Given(@"I set (.*) currency")]
        public void GivenISetCurrency(string currency)
        {
            togetherbandPage.CurrencySelection(currency);
        }

        [When(@"I add one more band in the Cart")]
        public void WhenIAddOneMoreBandInTheCart()
        {
            cartPage.PlusButtonClick();
        }

        [When(@"I proceed to checkout")]
        public void WhenIProceedToCheckout()
        {
            cartPage.CheckoutButtonClick();
        }

        [Given(@"I can see total price is (.*)")]
        [Then(@"I can see total price is updated to (.*)")]
        public void ThenICanSeeTotalPriceIs(string value)
        {
            Assert.AreEqual(value, cartPage.GetTotalPrice());
        }

        [When(@"I click remove all optiion")]
        public void WhenIClickRemoveAllOptiion()
        {
            cartPage.RemoveAllBands();
        }

        [Then(@"I can see cart is empty")]
        public void ThenICanSeeCartIsEmpty()
        {
            Assert.That(wait.Until(ExpectedConditions.ElementIsVisible(cartPage.CartIsEmptyInfoLoc)).Displayed,
                   "cart is not empty");
        }
    }
}
