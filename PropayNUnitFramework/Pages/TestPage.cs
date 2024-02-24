using OpenQA.Selenium;
using PropayTestAutomation.BrowserEngine;
using PropayTestAutomation.Utils;
using System;

namespace PropayNUnitFramework.Pages
{
    /// <summary>
    /// Represents a test page with elements and actions.
    /// </summary>
    public class TestPage
    {
        private readonly IBrowserEngine _browserEngine;
        private readonly Utils _utils;

        /// <summary>
        /// Constructor to initialize the TestPage with a BrowserEngine instance.
        /// </summary>
        /// <param name="_browserEngine">The BrowserEngine instance.</param>
        public TestPage(IBrowserEngine _browserEngine)
        {
            this._browserEngine = _browserEngine;
            _utils = new Utils(_browserEngine.Driver);
        }

        // Define web elements using XPath
        private IWebElement UsernameInput => _browserEngine.FindElement(By.XPath("//*[@id='username']"));
        private IWebElement PasswordInput => _browserEngine.FindElement(By.XPath("//*[@id='password']"));
        private IWebElement SubmitButton => _browserEngine.FindElement(By.XPath("//*[@id='submit']"));
        private IWebElement PracticeButton => _browserEngine.FindElement(By.XPath("//*[text()='Practice']"));

        /// <summary>
        /// Performs a sample test by interacting with elements on the page.
        /// </summary>
        public void RunTest()
        {
            Utils.Click(PracticeButton);
            Utils.ClickOnText("Test Login Page");
            Utils.SendKeys(UsernameInput, "student");
            Utils.SendKeys(PasswordInput, "Password123");
            Utils.Click(SubmitButton);

            Utils.FluentWait(5);

        }

        public void WaitTest()
        {
          Utils.FluentWait(10);
          Console.WriteLine("Wait for 10 seconds");

          Utils.ClickOnText("Start");
          Console.WriteLine("Start Clicked");

          Utils.FluentWait(30);
          Console.WriteLine("Wait for 30 seconds");

          Utils.ClickOnText("Reset");
          Console.WriteLine("Reset Clicked");

          Utils.FluentWait(10);
          Console.WriteLine("Wait for 10 seconds");
        }
    }
}
