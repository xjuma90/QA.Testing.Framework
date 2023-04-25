using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace QA.Testing.Framework.Base
{
    public class DriverContext
    {
        [field: ThreadStatic]
        public static IWebDriver Driver { get; set; }

        public static IWebElement IElement { get; set; }
    }
}
