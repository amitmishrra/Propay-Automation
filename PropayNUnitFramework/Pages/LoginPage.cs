using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using ProPay.Test.NewGen.Runners.BrowserEngine;
using ProPay.Test.NewGen.Runners.DriverHelpers;

namespace ProPay.Tests.NewGen.SpecFlow.PartnerPortal.UI.Pages
{
    /// <summary>
    /// Represents a test page with elements and actions.
    /// </summary>
    public class LoginPage : DriverHelpers
    {
        private readonly IBrowserEngine _browserEngine;

        /// <summary>
        /// Constructor to initialize the TestPage with a BrowserEngine instance.
        /// </summary>
        /// <param name="_browserEngine">The BrowserEngine instance.</param>
        public LoginPage(IBrowserEngine _browserEngine)
        {
            this._browserEngine = _browserEngine;
            driver = _browserEngine.Driver;
            _webDriverWait = new Lazy<WebDriverWait>(GetDriverWait);
        }

        // Define web elements using XPath
        private IWebElement UsernameInput => FindElement(By.XPath("//*[@id='username']"));
        private IWebElement PasswordInput => FindElement(By.XPath("//*[@id='password']"));
        private IWebElement SubmitButton => FindElement(By.XPath("//*[@id='submit']"));
        private IWebElement PracticeButton => FindElement(By.XPath("//*[text()='Practice']"));

        /// <summary>
        /// Performs a sample test by interacting with elements on the page.
        /// </summary>
     
        public void ClickPracticeButton()
        {
            Click(PracticeButton);
        }

        public void ClickTestLoginPage(string button)
        {
            ClickOnText(button);
        }

        public void InputCredentials(string username, string password)
        {
            SendKeys(UsernameInput, username);
            SendKeys(PasswordInput, password);
        }

        public void Submit()
        {
            Click(SubmitButton);
        }

        public void VerifyUserLoggedIn()
        {
            IsTextPresent("Logged In Successfully");
        }

        public void Logout()
        {
            ClickOnText("Log out");
        }
    }
}
