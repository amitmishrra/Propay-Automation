using NUnitFramework.Configs;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Safari;
using PropayTestAutomation.Driver;

namespace NUnitFramework.Drivers
{
    /// <summary>
    /// Fixture to initialize and manage WebDriver instances for tests.
    /// </summary>
    public class DriverFixtures : IWebDriverFixture
    {
        /// <summary>
        /// Gets the WebDriver instance.
        /// </summary>
        public IWebDriver Driver { get; }

        /// <summary>
        /// Constructor to initialize the WebDriver based on provided settings.
        /// </summary>
        /// <param name="settings">Test settings including browser type and application URL.</param>
        public DriverFixtures(TestSettings settings)
        {
            // Initialize WebDriver based on the specified browser type
            Driver = GetWebDriver(settings.BrowserType);

            // Navigate to the application URL
            Driver.Navigate().GoToUrl(settings.AppURL);
        }

        /// <summary>
        /// Gets the appropriate WebDriver instance based on the specified browser type.
        /// </summary>
        /// <param name="browserType">Type of the browser.</param>
        /// <returns>Initialized WebDriver instance.</returns>
        private static IWebDriver GetWebDriver(BrowserType browserType)
        {
            return browserType switch
            {
                BrowserType.CHROME => new ChromeDriver(),
                BrowserType.EDGE => new EdgeDriver(),
                BrowserType.FIREFOX => new FirefoxDriver(),
                BrowserType.SAFARI => new SafariDriver(),
                _ => new ChromeDriver() // Default to Chrome if the specified browser type is not recognized
            };
        }

        /// <summary>
        /// Disposes of the WebDriver instance.
        /// </summary>
        public void DisposeDriver()
        {
            Driver?.Dispose();
        }

    }
}

/// <summary>
/// Enum representing different browser types.
/// </summary>
public enum BrowserType
{
    CHROME,
    FIREFOX,
    SAFARI,
    EDGE
}
