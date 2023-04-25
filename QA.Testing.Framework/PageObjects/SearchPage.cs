using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using QA.Testing.Framework.Base;
using QA.Testing.Framework.Hooks;
using QA.Testing.Framework.Utilities;
using SeleniumExtras.WaitHelpers;
using System;

namespace QA.Testing.Framework.PageObjects
{
    public class SearchPage
    {

        private By signUpBtn = By.Id("signin2");
        private By windowCloseBtn = By.XPath("//div[@id='signInModal']/div/div[@class='modal-content']/div[@class='modal-footer']/button[contains(text(),'Close')]");
        private By windoSignUpBtn = By.Id("//div[@id='signInModal']/div/div[@class='modal-content']/div[@class='modal-footer']/button[contains(text(),'Sign up')]");
        private By signUpTitle = By.Id("signInModalLabel");

        public SearchPage()
        {
            DriverContext.Driver = HookInitialize.driver;
        }

        public void StartNavigation(string uri)
        {
            DriverContext.Driver.NavigateTo(uri);
        }

        public void ClickSignupButton()
        {
            WebDriverWait wait = new WebDriverWait(DriverContext.Driver, TimeSpan.FromSeconds(30));
            wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(signUpBtn));
            DriverContext.Driver.FindElement(signUpBtn).Click();
        }


        public void ValidateSignUpPopUpIsDisplayed()
        {
            WebDriverWait wait = new WebDriverWait(DriverContext.Driver, TimeSpan.FromSeconds(30));
            wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(signUpTitle));
            Assert.IsTrue(DriverContext.Driver.FindElement(signUpTitle).Displayed, "Sign up pop up is not displayed ");
        }

    }
}
