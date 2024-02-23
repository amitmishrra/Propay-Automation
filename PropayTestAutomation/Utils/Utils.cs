using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;


namespace PropayNUnitFramework.Utils
{
    internal class Utils
    {
        private static IWebDriver driver;

        public Utils(IWebDriver _driver)
        {
            driver = _driver;
        }


        public static void WaitForWebElementToBeClickable(IWebElement element)
        {
            SetImplicitWait(TimeSpan.FromSeconds(10));
            try
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                wait.Until(ExpectedConditions.ElementToBeClickable(element));
            }
            catch (WebDriverTimeoutException e)
            {
                Console.WriteLine("Element did not become visible within the specified time.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }

        public static void WaitForWebElementToBeVisible(By locator)
        {
            SetImplicitWait(TimeSpan.FromSeconds(10));
            try
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                wait.Until(ExpectedConditions.ElementIsVisible(locator));
            }
            catch (WebDriverTimeoutException e)
            {
                Console.WriteLine("Element did not become visible within the specified time.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }




        public static void SetImplicitWait(TimeSpan timeSpan)
        {
            driver.Manage().Timeouts().ImplicitWait = timeSpan;
        }

        public static void ScrollToElement(IWebElement element)
        {
            try
            {
                ((IJavaScriptExecutor)driver)
                         .ExecuteScript("arguments[0].scrollIntoView(true);", element);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }

        public static void ScrollAndClickElement(IWebElement element)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                IWebElement clickableElement = wait.Until(ExpectedConditions.ElementToBeClickable(element));

                ((IJavaScriptExecutor)driver)
                         .ExecuteScript("arguments[0].scrollIntoView(true);", element);
                clickableElement.Click();
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }



        public static void ClickOnText(String text)
        {
            try
            {
                IWebElement element = driver.FindElement(By.XPath("//*[text()='" + text + "']"));
                WaitForWebElementToBeVisible(By.XPath("//*[text()='" + text + "']"));
                ScrollAndClickElement(element);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public static void Click(By path)
        {
            try
            {
                WaitForWebElementToBeVisible(path);
                IWebElement element = driver.FindElement(path);
                ScrollAndClickElement(element);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public static void SendKeys(By path, String text)
        {
            try
            {
                WaitForWebElementToBeVisible(path);
                IWebElement element = driver.FindElement(path);
                ScrollToElement(element);
                element.SendKeys(text);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public static void CleanAndSendKeys(By path, String text)
        {
            try
            {
                WaitForWebElementToBeVisible(path);
                IWebElement element = driver.FindElement(path);
                ScrollToElement(element);
                element.Clear();
                element.SendKeys(text);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static bool isElementPresent(By by)
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
                Console.WriteLine("An error occurred: " + ex.Message);
                return false;
            }
        }

        public static bool isTextPresent(string text)
        {
            try
            {
                By by = By.XPath("//*[contains(text(),'" + text + "')]");
                IWebElement element = driver.FindElement(by);
                WaitForWebElementToBeVisible(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
                return false;
            }
        }

        public static void FluentWait(int milliseconds)
        {
            DateTime startTime = DateTime.Now;
            TimeSpan elapsedTime;

            do
            {
                DateTime currentTime = DateTime.Now;
                elapsedTime = currentTime - startTime;
                Thread.Sleep(100);
            } while (elapsedTime.TotalMilliseconds < milliseconds);
        }

        /* public static void TakeScreenshot(string fileName)
         {
             Console.WriteLine("Take screnshort");
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