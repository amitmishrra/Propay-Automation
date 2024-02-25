using System;

namespace ProPay.Test.NewGen.Runners.Configs
{
    /// <summary>
    /// Represents configuration settings for tests.
    /// </summary>
    public class TestSettings
    {
        /// <summary>
        /// Gets or sets the browser type to be used for testing.
        /// </summary>
        public BrowserType BrowserType { get; set; }

        /// <summary>
        /// Gets or sets the URL of the application under test.
        /// </summary>
        public Uri AppURL { get; set; }

        /// <summary>
        /// Gets or sets the timeout interval for tests (nullable).
        /// </summary>
        public float? TimeoutInterval { get; set; }
    }
}
