using ProPay.Test.NewGen.Runners.BrowserEngine;
using ProPay.Test.NewGen.Runners.Configs;
using ProPay.Tests.NewGen.SpecFlow.PartnerPortal.UI.Pages;

namespace ProPay.Tests.NewGen.SpecFlow.PartnerPortal.UI.StepDefinitions;

[Binding]
[Scope(Tag = "Login")]
public class LoginStepDefinitions
{
    private readonly IBrowserEngine? BrowserEngine;
    private readonly LoginPage page;

    public LoginStepDefinitions()
    {
        Console.WriteLine("LoginStepDefinitions calleddddd");

        BrowserEngine = new BrowserEngine(ConfigReader.ReadConfig());
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