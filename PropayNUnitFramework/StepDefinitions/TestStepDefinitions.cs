using NUnit.Framework;
using NUnit.Framework.Interfaces;
using NUnitFramework.Configs;
using NUnitFramework.Drivers;
using NUnitTestProject.Pages;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace NUnitTestProject.StepDefinitions
{
    [Binding]
   public sealed class TestStepDefinitions
    {
        DriverFixtures driverFixtures;
        TestPage page;

        [BeforeScenario]
        public void BeforeScenario()
        {
            /* var _settings = ConfigReader.ReadConfig();*/
            TestSettings settings = new TestSettings()
            {
                BrowserType = BrowserType.CHROME,
                AppURL = new Uri("https://practicetestautomation.com/practice-test-login/"),
            };
            driverFixtures = new DriverFixtures(settings);
            page = new TestPage(driverFixtures.Driver);
        }

        [Given(@"I launch the browser using ""(.*)""")]
        public void InitializeTheBrowser(string browserName)
        {
            page.RunTest();
        }

        [AfterScenario]
        public void AfterScenario()
        {
           
        }
    }
}
