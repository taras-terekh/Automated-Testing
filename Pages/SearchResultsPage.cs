using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Web.XmlTransform;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;


namespace final
{
    class SearchResultsPage
    {
        private IWebDriver _driver;

        public SearchResultsPage(IWebDriver driver)
        {
            this._driver = driver;
            PageFactory.InitElements(this, new RetryingElementLocator(_driver, TimeSpan.FromSeconds(20)));
        }

        [FindsBy(How = How.CssSelector, Using = "#search-content > ol > li:nth-child(1) > article > div > h1 > a")]
        private IWebElement _firstTitle;

        public string GetFirstTitle()
        {
            return _firstTitle.Text;
        }
        public void Compare()
        {
            Assert.AreEqual("US & Canada", GetFirstTitle());
        }
    }
}