using NUnit.Framework;
using OpenQA.Selenium;
using QA.Testing.Framework.Base;
using QA.Testing.Framework.Utilities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace QA.Testing.Framework.PageObjects
{
    public class ReportPortalLandingPage
    {
        private By sideBarBottomBlock= By.CssSelector("div.sidebar__bottom-block--3EH2A");

        public void ValidateRPLandingPageIsDisplay()
        {
            DriverContext.Driver.WaitUntilElementIsVisible(sideBarBottomBlock, TimeSpan.FromSeconds(60), TimeSpan.FromSeconds(1));
            Assert.IsTrue(DriverContext.Driver.FindElement(sideBarBottomBlock).Displayed, "Sign In page is not displayed ");
        }

    }
}
