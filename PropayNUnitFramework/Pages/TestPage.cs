﻿using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using ProPay.Test.NewGen.Runners.BrowserEngine;
using ProPay.Test.NewGen.Runners.DriverHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProPay.Tests.NewGen.SpecFlow.PartnerPortal.UI.Pages
{
    internal class TestPage : DriverHelpers
    {
        private readonly IBrowserEngine _browserEngine;
        public TestPage(IBrowserEngine _browserEngine)
        {
            this._browserEngine = _browserEngine;
            driver = _browserEngine.Driver;
            _webDriverWait = new Lazy<WebDriverWait>(GetDriverWait);
        }

        private IWebElement startButton => FindElement(By.XPath("//*[text()='Start']"));
        private IWebElement resetButton => FindElement(By.XPath("//*[text()='Reset']"));
        public void WaitTest()
        {
            FluentWait(10);
            ScrollAndClickElement(startButton);
            ScrollAndClickElement(resetButton);
            FluentWait(10);
        }
    }
}
