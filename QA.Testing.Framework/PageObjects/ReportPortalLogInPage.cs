using NUnit.Framework;
using OpenQA.Selenium;
using QA.Testing.Framework.Base;
using QA.Testing.Framework.Hooks;
using QA.Testing.Framework.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace QA.Testing.Framework.PageObjects
{
    public class ReportPortalLogInPage
    {
        private By nameBox = By.CssSelector("input.inputOutside__input--1Sg9p[placeholder='Login']");
        private By passwordBox = By.CssSelector("input.inputOutside__input--1Sg9p[placeholder='Password']");
        private By siginBtn = By.CssSelector("div.loginForm__login-button-container--1mHGW>button");

        public ReportPortalLogInPage()
        {
            DriverContext.Driver = HookInitialize.driver;
        }

        public void StartNavigation(string uri)
        {
            DriverContext.Driver.NavigateTo(uri);
        }

        public void ValidateRPLoginIsDisplay()
        {
            DriverContext.Driver.WaitUntilElementIsVisible(nameBox, TimeSpan.FromSeconds(60), TimeSpan.FromSeconds(1));
            Assert.IsTrue(DriverContext.Driver.FindElement(nameBox).Displayed, "Sign In page is not displayed ");
        }

        public void FillLogInCredential(string name, string password)
        {
            DriverContext.Driver.WaitUntilElementIsVisible(nameBox, TimeSpan.FromSeconds(30), TimeSpan.FromSeconds(1));
            SetText(DriverContext.Driver.FindElement(nameBox), name);
            SetText(DriverContext.Driver.FindElement(passwordBox), password);
            DriverContext.Driver.FindElement(siginBtn).Click();
        }



        protected void SetText(IWebElement webElement, object text, bool selectFirstOption = false)
        {
            webElement.Clear();
            if (!string.IsNullOrEmpty(text.ToString()))
                webElement.SendKeys(text.ToString());
            else
            {
                Assert.Fail("This string could no be null");
            }
            
        }

    }
}
