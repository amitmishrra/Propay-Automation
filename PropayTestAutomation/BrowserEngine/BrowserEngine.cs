using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Safari;
using ProPay.Test.NewGen.Runners.Configs;

namespace ProPay.Test.NewGen.Runners.BrowserEngine
{
    /// <summary>
    /// Fixture to initialize and manage WebDriver instances for tests.
    /// </summary>
    public class BrowserEngine : IBrowserEngine
    {
        /// <summary>
        /// Gets the WebDriver instance.
        /// </summary>
        public IWebDriver Driver { get; }

        /// <summary>
        /// Constructor to initialize the WebDriver based on provided settings.
        /// </summary>
        /// <param name="settings">Test settings including browser type and application URL.</param>
        public BrowserEngine(TestSettings settings)
        {
            // Initialize WebDriver based on the specified browser type
            Driver = GetWebDriver(settings.BrowserType);

            // Set implicit wait, maximize window, and navigate to the specified URL
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            Driver.Manage().Window.Maximize();
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
                BrowserType.Chrome => new ChromeDriver(),
                BrowserType.Edge => new EdgeDriver(),
                BrowserType.Firefox => new FirefoxDriver(),
                BrowserType.Safari => new SafariDriver(),
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


