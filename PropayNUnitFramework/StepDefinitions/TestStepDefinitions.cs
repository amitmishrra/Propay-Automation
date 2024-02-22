using NUnit.Framework;
using NUnit.Framework.Interfaces;
using NUnitFramework.Configs;
using NUnitFramework.Drivers;
using PropayNUnitFramework.Pages;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using PropayTestAutomation.Driver;

namespace PropayNUnitFramework.StepDefinitions
{
    /// <summary>
    /// Step definitions for the test scenarios.
    /// </summary>
    [Binding]
    public sealed class TestStepDefinitions
    {
        private IWebDriverFixture? DriverFixtures;
        private TestPage? page;

        /// <summary>
        /// Executes before each scenario to set up necessary resources.
        /// </summary>
        [BeforeScenario]
        public void BeforeScenario()
        {
            TestSettings? settings = new()
            {
                BrowserType = BrowserType.CHROME,
                AppURL = new Uri("https://practicetestautomation.com/practice-test-login/"),
            };
            DriverFixtures = new DriverFixtures(settings);
            page = new TestPage(DriverFixtures.Driver);
        }

        /// <summary>
        /// Initializes the browser and performs the test steps.
        /// </summary>
        /// <param name="browserName">Name of the browser.</param>
        [Given(@"I launch the browser using ""(.*)""")]
        public void InitializeTheBrowser(string browserName)
        {
            page?.RunTest();
        }

        /// <summary>
        /// Executes after each scenario to clean up resources.
        /// </summary>
        [AfterScenario]
        public void AfterScenario()
        {
            DriverFixtures?.DisposeDriver();
        }
    }
}
