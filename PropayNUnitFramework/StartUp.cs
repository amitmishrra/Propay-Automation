using Microsoft.Extensions.DependencyInjection;
using ProPay.Test.NewGen.Runners.BrowserEngine;
using ProPay.Test.NewGen.Runners.Configs;
using ProPay.Test.NewGen.Runners.DriverHelpers;
using ProPay.Tests.NewGen.SpecFlow.PartnerPortal.UI.Pages;
using SolidToken.SpecFlow.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProPay.Tests.NewGen.SpecFlow.PartnerPortal.UI
{
    public class StartUp
    {
        [ScenarioDependencies]
        public static IServiceCollection CreateServices()
        {
            Console.WriteLine("Start up file");
            var services = new ServiceCollection();
            services.AddScoped<IBrowserEngine, BrowserEngine>().
                AddScoped<DriverHelpers>().
                AddScoped<ConfigReader>().
                AddScoped<LoginPage>();
            return services;
        }
    }
}