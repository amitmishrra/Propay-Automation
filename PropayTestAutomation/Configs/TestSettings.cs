using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUnitFramework.Configs
{
    public class TestSettings
    {
        public BrowserType BrowserType { get; set; }
        public Uri AppURL { get; set; }
        public float? TimeoutInterval { get; set; }
    }
}
