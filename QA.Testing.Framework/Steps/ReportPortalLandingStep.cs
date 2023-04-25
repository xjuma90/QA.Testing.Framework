using QA.Testing.Framework.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace QA.Testing.Framework.Steps
{
    [Binding]
    public sealed class ReportPortalLandingStep
    {

        private readonly ScenarioContext _scenarioContext;
        private readonly ReportPortalLandingPage _reportPortalLandingPage;

        public ReportPortalLandingStep(ScenarioContext scenarioContext, ReportPortalLandingPage reportPortalLandingPage)
        {
            _scenarioContext = scenarioContext;
            _reportPortalLandingPage = reportPortalLandingPage;
        }

        [Then(@"I will navigate to Report Portal landing page")]
        public void ThenIWillNavigateToReportPortalLandingPage()
        {
            _reportPortalLandingPage.ValidateRPLandingPageIsDisplay();
        }


    }
}
