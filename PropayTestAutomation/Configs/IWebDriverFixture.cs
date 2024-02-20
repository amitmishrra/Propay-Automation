using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUnitFramework.Drivers
{
    public interface IWebDriverFixture
    {
        public IWebDriver Driver { get; }

    }
}
