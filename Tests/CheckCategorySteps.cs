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
    public class CheckCategorySteps
    {
        private readonly IWebDriver _driver;

        public CheckCategorySteps()
        {
            _driver = ScenarioContext.Current.Get<IWebDriver>("currentDriver");
        }

        [Given(@"I Navigate to the Home Page")]
        public void GivenINavigateToTheHomePage()
        {
            HomePage home = new HomePage(_driver);
            home.GoToBBCPage();
        }
        
        [When(@"I fill the search field")]
        public void WhenIFillTheSearchField()
        {
            HomePage home = new HomePage(_driver);
            NewsPage news;
            news = home.goToNewsPage();
            news.GetMainCategoryLabel();
            news.EnterMainCategory();
        }
        
        [Then(@"the result should correspond category")]
        public void ThenTheResultShouldCorrespondCategory()
        {
            NewsPage news = new NewsPage(_driver);
            SearchResultsPage searchResults;
            searchResults = news.goToSearchResultsPage();
            searchResults.GetFirstTitle();
            searchResults.Compare();
        }
    }
}
