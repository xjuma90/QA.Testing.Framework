using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using QA.Testing.Framework.Hooks;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace QA.Testing.Framework.PageObjects
{
    class SearchPage
    {
        public IWebDriver driver;

        private By signUpBtn = By.Id("signin2");
        private By windowCloseBtn = By.XPath("//div[@id='signInModal']/div/div[@class='modal-content']/div[@class='modal-footer']/button[contains(text(),'Close')]");
        private By windoSignUpBtn = By.Id("//div[@id='signInModal']/div/div[@class='modal-content']/div[@class='modal-footer']/button[contains(text(),'Sign up')]");
        private By signUpTitle = By.Id("signInModalLabel");

        public SearchPage()
        {
            driver = HookInitialize.driver;
        }

        public void ClickSignupButton()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(signUpBtn));
            driver.FindElement(signUpBtn).Click();
        }


        public void ValidateSignUpPopUpIsDisplayed()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(signUpTitle));
            Assert.IsTrue(driver.FindElement(signUpTitle).Displayed, "Sign up pop up is not displayed ");
        }

    }
}
