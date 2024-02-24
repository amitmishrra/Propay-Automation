using System;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace PropayTestAutomation.Utils
{
    public class Utils
    {
        private static IWebDriver driver;

        public Utils(IWebDriver _driver)
        {
            driver = _driver;
        }

        // Waits for the specified web element to be clickable
        public static void WaitForWebElementToBeClickable(IWebElement element)
        {
            SetImplicitWait(TimeSpan.FromSeconds(10));

            try
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                wait.Until(driver => (element != null && element.Displayed && element.Enabled));
            }
            catch (WebDriverTimeoutException e)
            {
                Console.WriteLine("Element did not become clickable within the specified time.");
            }
            catch (Exception ex)
            {
                Assert.Fail("Test failed: " + ex.Message);
            }
        }

        // Waits for the specified web element to be visible
        public static void WaitForWebElementToBeVisible(IWebElement webElement)
        {
            SetImplicitWait(TimeSpan.FromSeconds(10));

            try
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                wait.Until(driver => (webElement != null && webElement.Displayed));
            }
            catch (WebDriverTimeoutException e)
            {
                Console.WriteLine("Element did not become visible within the specified time.");
            }
            catch (Exception ex)
            {
                Assert.Fail("Test failed: " + ex.Message);
            }
        }

        // Scrolls to the specified element and clicks it
        public static void ScrollAndClickElement(IWebElement element)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                wait.Until(driver => (element != null && element.Displayed && element.Enabled));

                ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", element);
                element.Click();
            }
            catch (Exception ex)
            {
                Assert.Fail("Test failed: " + ex.Message);
            }
        }

        // Sets the implicit wait time for the driver
        public static void SetImplicitWait(TimeSpan timeSpan)
        {
            driver.Manage().Timeouts().ImplicitWait = timeSpan;
        }

        // Scrolls to the specified element
        public static void ScrollToElement(IWebElement element)
        {
            try
            {
                ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", element);
            }
            catch (Exception ex)
            {
                Assert.Fail("Test failed: " + ex.Message);
            }
        }

        // Clicks on an element identified by the specified text
        public static void ClickOnText(String text)
        {
            try
            {
                IWebElement element = driver.FindElement(By.XPath("//*[text()='" + text + "']"));
                WaitForWebElementToBeVisible(element);
                ScrollAndClickElement(element);
            }
            catch (Exception e)
            {
                Assert.Fail("Test failed: " + e.Message);
            }
        }

        // Clicks on the specified element
        public static void Click(IWebElement element)
        {
            try
            {
                ScrollAndClickElement(element);
            }
            catch (Exception e)
            {
                Assert.Fail("Test failed: " + e.Message);
            }
        }

        // Sends keys to the specified element
        public static void SendKeys(IWebElement element, String text)
        {
            try
            {
                WaitForWebElementToBeVisible(element);
                ScrollToElement(element);
                element.SendKeys(text);
            }
            catch (Exception e)
            {
                Assert.Fail("Test failed: " + e.Message);
            }
        }

        // Clears the element and sends keys to it
        public static void CleanAndSendKeys(IWebElement element, String text)
        {
            try
            {
                WaitForWebElementToBeVisible(element);
                ScrollToElement(element);
                element.Clear();
                element.SendKeys(text);
            }
            catch (Exception ex)
            {
                Assert.Fail("Test failed: " + ex.Message);
            }
        }

        // Checks if an element identified by the specified By exists
        public static bool IsElementPresent(By by)
        {
            try
            {
                IWebElement element = driver.FindElement(by);
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

        // Checks if the specified text is present in the page
        public static bool IsTextPresent(string text)
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

        /* public static void TakeScreenshot(string fileName)
         {
             Console.WriteLine("Take screenshot");
             ITakesScreenshot screenshotDriver = driver as ITakesScreenshot;
             Screenshot screenshot = screenshotDriver.GetScreenshot();

             try
             {
                 screenshot.SaveAsFile(fileName, ScreenshotImageFormat.Png);
             }
             catch (Exception e)
             {
                 Console.WriteLine("An error occurred while taking a screenshot: " + e.Message);
             }
         }*/

    }
}
