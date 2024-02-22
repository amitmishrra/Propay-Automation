using OpenQA.Selenium;

namespace PropayTestAutomation.Driver
{
    /// <summary>
    /// Interface for managing WebDriver instances.
    /// </summary>
    public interface IWebDriverFixture
    {
        /// <summary>
        /// Gets the WebDriver instance.
        /// </summary>
        IWebDriver Driver { get; }

        /// <summary>
        /// Disposes of the WebDriver instance.
        /// </summary>
        void DisposeDriver();
    }
}
