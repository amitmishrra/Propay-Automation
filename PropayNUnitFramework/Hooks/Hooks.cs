using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using AventStack.ExtentReports.Model;
using AventStack.ExtentReports.Reporter;
using ProPay.Test.NewGen.Runners.DriverHelpers;
using System;
using System.IO;
using System.Reflection;
using System.Text.RegularExpressions;
using TechTalk.SpecFlow.Bindings;

namespace ProPay.Tests.NewGen.SpecFlow.PartnerPortal.UI.Hooks
{
    [Binding]
    public sealed class Hooks : DriverHelpers
    {
        private readonly ScenarioContext scenarioContext;
        private readonly FeatureContext featureContext;
        private static ExtentReports report;
        private ExtentTest scenario;

        // Constructor to initialize ScenarioContext and FeatureContext
        public Hooks(ScenarioContext _scenarioContext, FeatureContext _featureContext)
        {
            scenarioContext = _scenarioContext;
            featureContext = _featureContext;
        }

        // Method to execute before each scenario
        [BeforeScenario]
        public void BeforeScenario()
        {
            // Get the path for the ExtentReport HTML file based on the scenario title
            var extentReportPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "/" + scenarioContext.ScenarioInfo.Title.Trim() + ".html";
            Console.WriteLine("Current Directory: " + extentReportPath);

            // Create a new ExtentReports instance and attach ExtentSparkReporter
            report = new ExtentReports();
            var spark = new ExtentSparkReporter(extentReportPath);
            report.AttachReporter(spark);

            // Create a test for the feature and scenario
            var feature = report.CreateTest<Feature>(featureContext.FeatureInfo.Title);
            scenario = feature.CreateNode<Scenario>(scenarioContext.ScenarioInfo.Title);
        }

        // Method to execute after each step
        [AfterStep]
        public void AfterStep()
        {
            var filename = $"{featureContext.FeatureInfo.Title.Trim()}_{Regex.Replace(scenarioContext.ScenarioInfo.Title, @"\s", "")}";

            if (scenarioContext.TestError == null)
            {
                // Add step based on the step definition type (Given, When, Then)
                AddStepBasedOnType(scenarioContext.StepContext.StepInfo.StepDefinitionType);
            }
            else
            {
                // Add failed step with error message and screenshot
                AddFailedStep(scenarioContext.StepContext.StepInfo.StepDefinitionType, filename);
            }
        }

        // Method to execute after each scenario
        [AfterScenario]
        public static void AfterScenario()
        {
            // Flush the ExtentReports to generate the report
            report.Flush();
        }

        // Helper method to add a step based on the step definition type
        private void AddStepBasedOnType(StepDefinitionType stepType)
        {
            switch (stepType)
            {
                case StepDefinitionType.Given:
                    scenario.CreateNode<Given>(scenarioContext.StepContext.StepInfo.Text);
                    break;

                case StepDefinitionType.When:
                    scenario.CreateNode<When>(scenarioContext.StepContext.StepInfo.Text);
                    break;

                case StepDefinitionType.Then:
                    scenario.CreateNode<Then>(scenarioContext.StepContext.StepInfo.Text);
                    break;

                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        // Helper method to add a failed step with error message and screenshot
        private void AddFailedStep(StepDefinitionType stepType, string filename)
        {
            var errorMessage = scenarioContext.TestError.Message;

            switch (stepType)
            {
                case StepDefinitionType.Given:
                    scenario.CreateNode<Given>(scenarioContext.StepContext.StepInfo.Text)
                        .Fail(errorMessage, new ScreenCapture()
                        {
                            Path = TakeScreenshot(filename),
                            Title = "Error"
                        });
                    break;

                case StepDefinitionType.When:
                    scenario.CreateNode<When>(scenarioContext.StepContext.StepInfo.Text)
                        .Fail(errorMessage, new ScreenCapture()
                        {
                            Path = TakeScreenshot(filename),
                            Title = "Error"
                        });
                    break;

                case StepDefinitionType.Then:
                    scenario.CreateNode<Then>(scenarioContext.StepContext.StepInfo.Text)
                        .Fail(errorMessage, new ScreenCapture()
                        {
                            Path = TakeScreenshot(filename),
                            Title = "Error"
                        });
                    break;

                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}
