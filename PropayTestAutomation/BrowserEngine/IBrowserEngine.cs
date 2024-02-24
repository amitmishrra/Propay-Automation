using OpenQA.Selenium;

namespace PropayTestAutomation.BrowserEngine
{
    /// <summary>
    /// Interface for managing WebDriver instances.
    /// </summary>
    public interface IBrowserEngine
    {
        /// <summary>
        /// Gets the WebDriver instance.
        /// </summary>
        IWebDriver Driver { get; }

        /// <summary>
        /// Disposes of the WebDriver instance.
        /// </summary>
        void DisposeDriver();

        IWebElement FindElement(By by);
        IEnumerable<IWebElement> FindElements(By by);
    }
}
