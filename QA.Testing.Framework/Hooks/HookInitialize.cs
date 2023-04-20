using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using TechTalk.SpecFlow;

namespace QA.Testing.Framework.Hooks
{
    [Binding]
    public class HookInitialize
    {
        public static IWebDriver driver;
        

        [BeforeScenario]
        public static void BeforeScenario()
        {
            var location = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            
            //driver = new ChromeDriver(AppDomain.CurrentDomain.BaseDirectory);
           driver = new ChromeDriver($@"{location}");
           driver.Manage().Window.Maximize();
        }

        [AfterScenario]
        public static void AfterScenario()
        {
            driver.Quit(); 
        }
    }
}
