using ProPay.Test.NewGen.Runners.BrowserEngine;
using ProPay.Test.NewGen.Runners.Configs;
using ProPay.Tests.NewGen.SpecFlow.PartnerPortal.UI.Pages;
using System;
using TechTalk.SpecFlow;

namespace ProPay.Tests.NewGen.SpecFlow.PartnerPortal.UI.StepDefinitions
{
    [Binding]
    public class LoginStepDefinitions
    {
        private LoginPage? page;
        private IBrowserEngine? BrowserEngine;

        /// <summary>
        /// Executes before each scenario to set up necessary resources.
        /// </summary>

        public LoginStepDefinitions()
        {
            TestSettings? settings = new()
            {
                BrowserType = BrowserType.Chrome,
                AppURL = new Uri("https://practicetestautomation.com/"),
            };
            BrowserEngine = new BrowserEngine(settings);
            page = new LoginPage(BrowserEngine);

        }

        [Given(@"Navigate to Practice page")]
        public void GivenNavigateToPracticePage()
        {
            page?.ClickPracticeButton();
        }

        [Then(@"Click on ""([^""]*)"" button")]
        public void ThenClickOnButton(string button)
        {
            page?.ClickTestLoginPage(button);
        }

        [When(@"Enter Credentials ""([^""]*)"" and ""([^""]*)""")]
        public void WhenEnterCredentialsAnd(string username, string password)
        {
            page?.InputCredentials(username, password);
        }

        [Then(@"Click on submit button")]
        public void ThenClickOnSubmitButton()
        {
            page?.Submit();
        }

        [Then(@"Verify that Logout button is present")]
        public void ThenVerifyThatLogoutButtonIsPresent()
        {
            page?.VerifyUserLoggedIn();
        }

        [Then(@"Click on Logout button")]
        public void ThenClickOnLogoutButton()
        {
            page?.Logout();
        }


        [AfterScenario]
        public void AfterScenario()
        {
            BrowserEngine?.DisposeDriver();
        }
    }
}
