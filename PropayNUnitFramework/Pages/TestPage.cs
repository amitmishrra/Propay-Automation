using NUnitFramework.Drivers;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUnitTestProject.Pages
{
    public class TestPage
    {
        IWebDriver driver;
        public TestPage(IWebDriver _driver)
        {
            this.driver = _driver;
        }
        public void RunTest()
        {
            driver.FindElement(By.XPath("//*[@id=\"username\"]")).SendKeys("student");
            driver.FindElement(By.XPath("//*[@id=\"password\"]")).SendKeys("Password123");
            driver.FindElement(By.XPath("//*[@id=\"submit\"]")).Click();
            driver.Close();
        }
    }
}
