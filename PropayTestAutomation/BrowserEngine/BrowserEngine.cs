using System;
using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Safari;
using OpenQA.Selenium.Support.UI;
using NUnitFramework.Configs;

namespace PropayTestAutomation.BrowserEngine
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

        private readonly Lazy<WebDriverWait> _webDriverWait;
        private readonly TestSettings _testSettings;

        /// <summary>
        /// Constructor to initialize the WebDriver based on provided settings.
        /// </summary>
        /// <param name="settings">Test settings including browser type and application URL.</param>
        public BrowserEngine(TestSettings settings)
        {
            _testSettings = settings;

            // Initialize WebDriver based on the specified browser type
            Driver = GetWebDriver(settings.BrowserType);

            // Lazily initializes the WebDriverWait using a Lazy<T> to defer creation until it's first accessed.
            // This allows for delayed creation of WebDriverWait with specified timeout and polling interval.
            _webDriverWait = new Lazy<WebDriverWait>(GetDriverWait);

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

        private WebDriverWait GetDriverWait()
        {
            // Set up WebDriverWait with specified timeout and polling interval
            return new WebDriverWait(Driver, timeout: TimeSpan.FromSeconds(_testSettings.TimeoutInterval ?? 30))
            {
                PollingInterval = TimeSpan.FromSeconds(_testSettings.TimeoutInterval ?? 1)
            };
        }

        /// <summary>
        /// Finds a web element using the specified locator.
        /// </summary>
        /// <param name="by">Locator strategy.</param>
        /// <returns>Found web element.</returns>
        public IWebElement FindElement(By by)
        {
            return _webDriverWait.Value.Until(_ => Driver.FindElement(by));
        }

        /// <summary>
        /// Finds a list of web elements using the specified locator.
        /// </summary>
        /// <param name="by">Locator strategy.</param>
        /// <returns>List of found web elements.</returns>
        public IEnumerable<IWebElement> FindElements(By by)
        {
            return _webDriverWait.Value.Until(_ => Driver.FindElements(by));
        }
    }
}


