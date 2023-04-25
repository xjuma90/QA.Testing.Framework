using Microsoft.Extensions.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using QA.Testing.Framework.Models;
using System.IO;
using System.Reflection;
using TechTalk.SpecFlow;

namespace QA.Testing.Framework.Hooks
{
    [Binding]
    public class HookInitialize
    {
        public static IWebDriver driver;
        public static ChromeOptions options;
        public static FirefoxOptions optionsFire;
        static ConfigSettings config;
        static string configSettingsPath = System.IO.Directory.GetParent(@"../").FullName + Path.DirectorySeparatorChar + "QA.Testing.Framework/Configuration/configsettings.json";

        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            config = new ConfigSettings();
            ConfigurationBuilder builder = new ConfigurationBuilder();
            builder.AddJsonFile(configSettingsPath);
            IConfigurationRoot configuration = builder.Build();
            configuration.Bind(config);

        }

        [BeforeScenario]
        public static void BeforeScenario()
        {
            var location = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            if (config.BrowserType.ToLower() == "chrome")
            {
                options = new ChromeOptions();
                options.AddArguments(config.DriverOptionArguments);
                driver = new ChromeDriver($@"{location}", options);
            }
            else if (config.BrowserType.ToLower() == "ie")
            {
                driver = new InternetExplorerDriver($@"{location}");
            }
            else if (config.BrowserType.ToLower() == "firefox")
            {
                driver = new FirefoxDriver($@"{location}");
                driver.Manage().Window.Maximize();
            }

        }

        [AfterScenario]
        public static void AfterScenario()
        {
            driver.Quit();
        }
    }
}
