using OpenQA.Selenium;

namespace ProPay.Test.NewGen.Runners.BrowserEngine
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

    }
}
