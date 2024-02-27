using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace ProPay.Test.NewGen.Runners.DriverHelpers
{
    public class DriverHelpers
    {
        protected static IWebDriver driver;
        protected static Lazy<WebDriverWait> _webDriverWait;
        protected static WebDriverWait GetDriverWait()
        {
            // Set up WebDriverWait with specified timeout and polling interval
            return new WebDriverWait(driver, timeout: TimeSpan.FromSeconds( 30))
            {
                PollingInterval = TimeSpan.FromSeconds(1)
            };
        }
        /// <summary>
        /// Finds a web element using the specified locator.
        /// </summary>
        /// <param name="by">Locator strategy.</param>
        /// <returns>Found web element.</returns>
        public static IWebElement FindElement(By by)
        {
            return _webDriverWait.Value.Until(drv => drv.FindElement(by));
        }

        /// <summary>
        /// Finds a list of web elements using the specified locator.
        /// </summary>
        /// <param name="by">Locator strategy.</param>
        /// <returns>List of found web elements.</returns>
        public static IEnumerable<IWebElement> FindElements(By by)
        {
            return _webDriverWait.Value.Until(drv => drv.FindElements(by));
        }

        /// <summary>
        /// Waits for the specified web element to be clickable.
        /// </summary>
        /// <param name="element">The web element to wait for.</param>
        public static void WaitForWebElementToBeClickable(IWebElement element)
        {
            _webDriverWait.Value.Until(driver =>
            {
                try
                {
                    return element != null && element.Displayed && element.Enabled;
                }
                catch (NoSuchElementException)
                {
                    // Element not found
                    return false;
                }
                catch (StaleElementReferenceException)
                {
                    // Element is no longer attached to the DOM
                    return false;
                }
            });
        }


        /// <summary>
        /// Waits for the specified web element to be visible.
        /// </summary>
        /// <param name="webElement">The web element to wait for.</param>
        private static void WaitForWebElementToBeVisible(IWebElement webElement)
        {
            _webDriverWait.Value.Until(drv => webElement != null && webElement.Displayed);
        }

        /// <summary>
        /// Scrolls to the specified element and clicks it.
        /// </summary>
        /// <param name="element">The web element to scroll to and click.</param>
        public static void ScrollAndClickElement(IWebElement element)
        {
            ScrollToElement(element);
            element.Click();
        }

        /// <summary>
        /// Scrolls to the specified element.
        /// </summary>
        /// <param name="element">The web element to scroll to.</param>
        public static void ScrollToElement(IWebElement element)
        {
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", element);
        }

        /// <summary>
        /// Clicks on an element identified by the specified text.
        /// </summary>
        /// <param name="text">The text of the element to click on.</param>
        protected static void ClickOnText(string text)
        {
            IWebElement element = FindElement(By.XPath($"//*[text()='{text}']"));
            element.Click();
        }

        /// <summary>
        /// Sends keys to the specified element.
        /// </summary>
        /// <param name="element">The element to send keys to.</param>
        /// <param name="text">The text to send.</param>
        protected static void SendKeys(IWebElement element, string text)
        {
            element.SendKeys(text);
        }

        /// <summary>
        /// Clears the element and sends keys to it.
        /// </summary>
        /// <param name="element">The element to clear and send keys to.</param>
        /// <param name="text">The text to send.</param>
        public static void CleanAndSendKeys(IWebElement element, string text)
        {
            element.Clear();
            element.SendKeys(text);
        }

        /// <summary>
        /// Checks if an element identified by the specified By exists.
        /// </summary>
        /// <param name="by">The locator strategy to use.</param>
        /// <returns>True if the element exists, otherwise false.</returns>
        public static bool IsElementPresent(By by)
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        /// <summary>
        /// Checks if the specified text is present in the page.
        /// </summary>
        /// <param name="text">The text
        protected static bool IsTextPresent(string text)
        {
            try
            {
                By by = By.XPath("//*[contains(text(),'" + text + "')]");
                IWebElement element = driver.FindElement(by);
                WaitForWebElementToBeVisible(element);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
            catch (Exception ex)
            {
                Assert.Fail("Test failed: " + ex.Message);
                return false;
            }
        }

        // Clicks on the specified element
        protected static void Click(IWebElement element)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                _webDriverWait.Value.Until(drv => element != null && element.Displayed);
                element.Click();
            }
            catch (Exception e)
            {
                Assert.Fail("Test failed: " + e.Message);
            }
        }
        
        // Implements a basic fluent wait
        public static void FluentWait(int seconds)
        {
            DateTime startTime = DateTime.Now;
            TimeSpan elapsedTime;

            do
            {
                DateTime currentTime = DateTime.Now;
                elapsedTime = currentTime - startTime;
                Thread.Sleep(100);
            } while (elapsedTime.TotalMilliseconds < seconds * 1000);
        }
    }
}