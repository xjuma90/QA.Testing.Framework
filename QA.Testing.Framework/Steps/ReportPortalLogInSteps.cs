using QA.Testing.Framework.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace QA.Testing.Framework.Steps
{
    [Binding]
    public sealed class ReportPortalLogInSteps
    {

        private readonly ScenarioContext _scenarioContext;
        private readonly ReportPortalLogInPage _reportPortalLogInPage;

        public ReportPortalLogInSteps(ScenarioContext scenarioContext, ReportPortalLogInPage reportPortalLogInPage)
        {
            _scenarioContext = scenarioContext;
            _reportPortalLogInPage = reportPortalLogInPage;
        }

        [Given(@"I navigate to Web Report Portal")]
        public void GivenINavigateToWebReportPortal()
        {
            _reportPortalLogInPage.StartNavigation("https://rp.epam.com");
        }
        
        [Given(@"The Login page is display")]
        public void GivenTheLoginPageIsDisplay()
        {
            _reportPortalLogInPage.ValidateRPLoginIsDisplay();
        }
        
        [When(@"I intruduce the ""(.*)"" and ""(.*)"" to get login")]
        public void WhenIIntruduceTheAndToGetLogin(string username, string password)
        {
            _reportPortalLogInPage.FillLogInCredential(username, password);
        }
        
        
      
    }
}
