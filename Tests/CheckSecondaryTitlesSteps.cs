using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Web.XmlTransform;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using TechTalk.SpecFlow;


namespace final
{
    [Binding]
    public class CheckSecondaryTitlesSteps
    {
        private readonly IWebDriver _driver;

        public CheckSecondaryTitlesSteps()
        {
            _driver = ScenarioContext.Current.Get<IWebDriver>("currentDriver");
        }

        [Given(@"I navigate to the Home page")]
        public void GivenINavigateToTheHomePage()
        {
            HomePage home = new HomePage(_driver);
            home.GoToBBCPage();
        }
        
        [When(@"I click News")]
        public void WhenIClickNews()
        {
            HomePage home = new HomePage(_driver);
            NewsPage news;
            news = home.goToNewsPage();
        }
        
        [Then(@"secondary news should be equal")]
        public void ThenSecondaryNewsShouldBeEqual()
        {
            NewsPage news = new NewsPage(_driver);
            news.AreEqualOtherTitles();
        }
    }
}
