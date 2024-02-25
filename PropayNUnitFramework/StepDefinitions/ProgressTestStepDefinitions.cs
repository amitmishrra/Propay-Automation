using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using ProPay.Test.NewGen.Runners.BrowserEngine;
using ProPay.Test.NewGen.Runners.Configs;
using ProPay.Tests.NewGen.SpecFlow.PartnerPortal.UI.Pages;
using System;
using TechTalk.SpecFlow;

namespace ProPay.Tests.NewGen.SpecFlow.PartnerPortal.UI.StepDefinitions
{
    [Binding]
    [Scope(Tag = "Progress")]
    public class ProgressTestStepDefinitions
    {

        private IBrowserEngine? BrowserEngine;
        private ProgressPage page;
        /// <summary>
        /// Executes before each scenario to set up necessary resources.
        /// </summary>

        
        public ProgressTestStepDefinitions()
        {
            Console.WriteLine("TestStepDefinitions calleddddd");
            TestSettings? settings = new()
            {
                BrowserType = BrowserType.Edge,
                AppURL = new Uri("https://demoqa.com/progress-bar"),
            };
            BrowserEngine = new BrowserEngine(settings);
            page = new ProgressPage(BrowserEngine);
        }


        [Given(@"I launch the browser using ""([^""]*)""")]
        public void GivenILaunchTheBrowserUsing(string chrome)
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
