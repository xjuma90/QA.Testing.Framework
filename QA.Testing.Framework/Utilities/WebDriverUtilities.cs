using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Threading;

namespace QA.Testing.Framework.Utilities
{
    public static class WebDriverUtilities
    {

        public static void NavigateTo(this IWebDriver webDriver, string url)
        {
            webDriver.Navigate().GoToUrl(url);
        }

        public static bool CheckElementIsStale(IWebDriver Driver, IWebElement webElement)
        {
            return ExpectedConditions.StalenessOf(webElement)(Driver);
        }

        public static void WaitUntilStalenessOfElement(this IWebDriver webDriver, IWebElement element, TimeSpan timeout, TimeSpan pollingInterval)
        {
            if (element is null)
                throw new ArgumentNullException(nameof(element));

            var wait = new WebDriverWait(new SystemClock(), webDriver, timeout, pollingInterval);

            wait.Until(ExpectedConditions.StalenessOf(element));
        }

        public static void WaitPageLoad(IWebDriver driver)
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(30)).Until(
                d => ((IJavaScriptExecutor)d).ExecuteScript("return document.readyState").Equals("complete")
            );
        }

        public static void ScrollToBottom(IWebDriver driver)
        {
            var js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("window.scrollBy(0, document.body.scrollHeight)");
        }

        public static void WaitUntilElementIsNoLongerDisplayed(this IWebDriver webDriver, By locator, TimeSpan timeout)
        {
            var wait = new WebDriverWait(webDriver, timeout);
            wait.Until(ExpectedConditions.InvisibilityOfElementLocated(locator));
        }

        public static void ScrollIntoMiddle(this IWebDriver webDriver, IWebElement webElement)
        {
            var js = (IJavaScriptExecutor)webDriver;
            int height = webDriver.Manage().Window.Size.Height;
            var hoverItem = (ILocatable)webElement;
            var locationY = hoverItem.LocationOnScreenOnceScrolledIntoView.Y;

            js.ExecuteScript(string.Format(CultureInfo.InvariantCulture, "javascript:window.scrollBy(0,{0})", locationY - (height / 2)));
        }

        public static void WaitUntilElementIsVisible(this IWebDriver webDriver, By locator, TimeSpan timeout, TimeSpan pollingInterval)
        {
            if (locator is null)
                throw new ArgumentNullException(nameof(locator));

            var wait = new WebDriverWait(new SystemClock(), webDriver, timeout, pollingInterval);

            wait.Until(ExpectedConditions.ElementIsVisible(locator));
        }

        public static void SetText(this IWebElement webElement, object text, bool selectFirstOption = false)
        {
            webElement.Clear();
            if (!string.IsNullOrEmpty(text.ToString()))
                webElement.SendKeys(text.ToString());

            if (selectFirstOption)
            {
                Thread.Sleep(1000);
                webElement.SendKeys(Keys.Down);
                webElement.SendKeys(Keys.Enter);
                Thread.Sleep(500);
            }
            else
                Thread.Sleep(150);
        }



    }
}
