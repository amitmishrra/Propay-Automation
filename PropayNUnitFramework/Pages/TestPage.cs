using OpenQA.Selenium;

namespace PropayNUnitFramework.Pages
{
    /// <summary>
    /// Represents a test page with elements and actions.
    /// </summary>
    public class TestPage
    {
        private readonly IWebDriver Driver;

        /// <summary>
        /// Constructor to initialize the TestPage with a WebDriver instance.
        /// </summary>
        /// <param name="_driver">The WebDriver instance.</param>
        public TestPage(IWebDriver _driver)
        {
            this.Driver = _driver;
        }

        private IWebElement UsernameInput => Driver.FindElement(By.XPath("//*[@id='username']"));
        private IWebElement PasswordInput => Driver.FindElement(By.XPath("//*[@id='password']"));
        private IWebElement SubmitButton => Driver.FindElement(By.XPath("//*[@id='submit']"));

        /// <summary>
        /// Performs a sample test by entering username, password, and clicking the submit button.
        /// </summary>
        public void RunTest()
        {
            UsernameInput.SendKeys("student");
            PasswordInput.SendKeys("Password123");
            SubmitButton.Click();
        }
    }
}
