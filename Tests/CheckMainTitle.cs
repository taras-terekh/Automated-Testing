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
    public class CheckMainTitle
    {
        private readonly IWebDriver _driver;

        public CheckMainTitle()
        {
            _driver = ScenarioContext.Current.Get<IWebDriver>("currentDriver");
        }

        [Given(@"I Navigate to the Home page")]
        public void GivenINavigateToTheHomePage()
        {
            HomePage home = new HomePage(_driver);
            home.GoToBBCPage();
        }
        
        [When(@"I press News")]
        public void WhenIPressNews()
        {
            HomePage home = new HomePage(_driver);
            NewsPage news;
            news = home.goToNewsPage();
        }
        
        [Then(@"main news should be equal")]
        public void ThenMainNewsShouldBeEqual()
        {
            NewsPage news = new NewsPage(_driver);
            news.GetMainTitle();
            news.CheckMainTitle();
        }
    }
}
