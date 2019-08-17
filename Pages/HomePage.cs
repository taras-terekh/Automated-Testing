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
    class HomePage
    {
        private IWebDriver _driver;

        public HomePage(IWebDriver driver)
        {
            this._driver = driver;
            PageFactory.InitElements(this, new RetryingElementLocator(_driver, TimeSpan.FromSeconds(20)));
        }

        [FindsBy(How = How.XPath, Using = "(//div[@id='orb-nav-links']//a)[2]")]
        private IWebElement _newsButton;
        public void GoToBBCPage()
        {
            _driver.Navigate().GoToUrl("https://www.bbc.com/");
        }
        
        public NewsPage goToNewsPage()
        {
            _newsButton.Click();
            return new NewsPage(_driver);
        }
    }
}
