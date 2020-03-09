using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using TechTalk.SpecFlow;

namespace UbsTask
{
    public class BasePage
    {
        protected IWebDriver driver;
        protected WebDriverWait wait;

        public BasePage()
        {
            driver = (IWebDriver)ScenarioContext.Current["driver"];
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
        }

        public void GoToUrl(string url)
        {
            driver.Navigate().GoToUrl(url);
        }

        public bool IsElementPresent(By locator)
        {
            try
            {
                driver.FindElement(locator);
                return true;
            }
            catch (OpenQA.Selenium.NoSuchElementException e)
            {
                return false;
            }
        }
    }
}