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
    class NewsPage
    {
        private IWebDriver _driver;

        public NewsPage(IWebDriver driver)
        {
            this._driver = driver;
            PageFactory.InitElements(this, new RetryingElementLocator(_driver, TimeSpan.FromSeconds(20)));
        }

        [FindsBy(How = How.XPath, Using = "//ul[@class='gs-o-list-ui--top-no-border nw-c-nav__wide-sections']/li[last()]")]
        private IWebElement _moreButton;

        [FindsBy(How = How.XPath, Using = "//div[@class='nw-c-nav__wide-overflow-list gel-layout']/ul[4]")]
        private IWebElement _haveYourSayButton;

        [FindsBy(How = How.XPath, Using = "//a[@class='gs-c-section-link gs-c-section-link--truncate nw-c-section-link nw-o-link nw-o-link--no-visited-state']/span")]
        private IWebElement _mainCategoryLabel;

        [FindsBy(How = How.Id, Using = "orb-search-q")]
        private IWebElement _searchField;

        [FindsBy(How = How.Id, Using = "orb-search-button")]
        private IWebElement _searchButton;

        [FindsBy(How = How.XPath, Using = "(//div[@class='gel-layout gel-layout--no-flex nw-c-top-stories--standard nw-c-top-stories--international']" +
            "//a[@class='gs-c-promo-heading gs-o-faux-block-link__overlay-link gel-paragon-bold nw-o-link-split__anchor'])[1]")]
        private IWebElement _mainTitle;

        public void ClickMore()
        {
            _moreButton.Click();
        }
        public HaveYourSayPage goToHaveYourSayPage()
        {
            _haveYourSayButton.Click();
            return new HaveYourSayPage(_driver);
        }
        public SearchResultsPage goToSearchResultsPage()
        {
            _searchButton.Click();
            return new SearchResultsPage(_driver);
        }
        public string GetMainCategoryLabel()
        {
            return _mainCategoryLabel.Text;
        }
        public void EnterMainCategory()
        {
            _searchField.SendKeys(GetMainCategoryLabel());
        }
        public string GetMainTitle()
        {
            return _mainTitle.Text;
        }
        public void CheckMainTitle()
        {
            Assert.AreEqual("'No chance of US deal' if Brexit hits Irish accord", GetMainTitle());
        }
        public void AreEqualOtherTitles()
        {
            List<string> titles = new List<string>();
            titles.Add("Are the markets signalling a recession is due?");
            titles.Add("ASAP Rocky found guilty of assault");
            titles.Add("Wildfires leave blackened forests in their wake");
            titles.Add("British-Iranian academic 'arrested in Iran'");
            titles.Add("Is the bystander effect a myth?");

            string xpath;
            foreach (string i in titles)
            {
                xpath = "//h3[contains(text()," + '\"' + i + '\"' + ")]";
                _driver.FindElement(By.XPath(xpath));
            }
        }
    }
}
