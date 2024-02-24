using NUnit.Framework;
using NUnit.Framework.Interfaces;
using NUnitFramework.Configs;
using PropayNUnitFramework.Pages;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using PropayTestAutomation.BrowserEngine;

namespace PropayNUnitFramework.StepDefinitions
{
    /// <summary>
    /// Step definitions for the test scenarios.
    /// </summary>
    [Binding]
    public sealed class TestStepDefinitions
    {
        private IBrowserEngine? BrowserEngine;
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
                AppURL = new Uri("https://practicetestautomation.com/"),
            };
            BrowserEngine = new BrowserEngine(settings);
            page = new TestPage(BrowserEngine);

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
            BrowserEngine?.DisposeDriver();
        }
    }
}
