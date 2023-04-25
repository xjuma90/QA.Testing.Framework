using OpenQA.Selenium;
using QA.Testing.Framework.Hooks;
using QA.Testing.Framework.PageObjects;
using QA.Testing.Framework.Utilities;
using TechTalk.SpecFlow;

namespace QA.Testing.Framework.Steps
{
    [Binding]
    public class SearchingSteps
    {
        public IWebDriver driver = HookInitialize.driver;
        SearchPage _searchPage = new SearchPage();

        [Given(@"I navigate to demoblaze online store")]
        public void GivenINavigateToDemoblazeOnlineStore()
        {
            _searchPage.StartNavigation("https://www.demoblaze.com/index.html");
        }

        [When(@"I click a SignUp button")]
        public void WhenIClickASignUpButton()
        {
            _searchPage.ClickSignupButton();
        }

        [Then(@"Sign up window will display")]
        public void ThenSignUpWindowWillDisplay()
        {
            _searchPage.ValidateSignUpPopUpIsDisplayed();
        }

        //[Then(@"I click close button")]
        //public void ThenIClickCloseButton()
        //{
        //    ScenarioContext.Current.Pending();
        //}

        //[Then(@"Sign up window will closed")]
        //public void ThenSignUpWindowWillClosed()
        //{
        //    ScenarioContext.Current.Pending();
        //}
    }
}
