using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace UbsTask
{
    public static class DriverFactory
    {
        public static IWebDriver ReturnDriver(DriverType driverType)
        {
            IWebDriver driver;
            switch (driverType)
            {
                case DriverType.Chrome:
                    driver = new ChromeDriver();
                    break;
                //Any other required driver could be added here like below
                //case DriverType.Firefox:
                //    driver = new FirefoxDriver();
                //    break;

                default:
                    throw new ArgumentOutOfRangeException("No such browser supported");
            }

            return driver;
        }

        public enum DriverType
        {
            Chrome,
            //Any other required driver could be added here
        }
    }
}
