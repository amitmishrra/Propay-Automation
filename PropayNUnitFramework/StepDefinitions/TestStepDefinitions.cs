using NUnit.Framework;
using NUnit.Framework.Interfaces;
using ProPay.Test.NewGen.Runners.Configs;
using ProPay.Tests.NewGen.SpecFlow.PartnerPortal.UI.Pages;
using ProPay.Test.NewGen.Runners.BrowserEngine;

namespace PropayNUnitFramework.StepDefinitions
{
    /// <summary>
    /// Step definitions for the test scenarios.
    /// </summary>
    [Binding]
    public sealed class TestStepDefinitions
    {
        private TestPage? page;
        private IBrowserEngine? BrowserEngine;
        /// <summary>
        /// Executes before each scenario to set up necessary resources.
        /// </summary>

        public TestStepDefinitions()
        {
            TestSettings? settings = new()
            {
                BrowserType = BrowserType.Edge,
                AppURL = new Uri("https://demoqa.com/progress-bar"),
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
            page?.WaitTest();
        }

        [AfterScenario]
        public void AfterScenario()
        {
            BrowserEngine?.DisposeDriver();
        }
    }
}
