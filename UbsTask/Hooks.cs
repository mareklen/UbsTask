using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace UbsTask
{
    [Binding]
    public class Hooks
    {
        private IWebDriver driver;

        [BeforeScenario]
        public void BeforeScenario()
        {
            driver = DriverFactory.ReturnDriver(DriverFactory.DriverType.Chrome);
            ScenarioContext.Current["driver"] = driver;
        }

        [AfterScenario]
        public void AfterScenario()
        {
            driver.Close();
            driver.Dispose();
        }
    }
}
