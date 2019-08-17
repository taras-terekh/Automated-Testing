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
    class LoremIpsumPage
    {
        private IWebDriver _driver;

        public LoremIpsumPage(IWebDriver driver)
        {
            this._driver = driver;
            PageFactory.InitElements(this, new RetryingElementLocator(_driver, TimeSpan.FromSeconds(20)));
        }

        [FindsBy(How = How.Id, Using = "bytes")]
        private IWebElement _bytesButton;

        [FindsBy(How = How.Id, Using = "amount")]
        private IWebElement _inputField;

        [FindsBy(How = How.Id, Using = "generate")]
        private IWebElement _generateButton;

        [FindsBy(How = How.Id, Using = "lipsum")]
        private IWebElement _loremText;

        public void GoToLoremPage()
        {
            _driver.Navigate().GoToUrl("https://www.lipsum.com/");
        }
        public void ClickBytes()
        {
            _bytesButton.Click();
        }
        public void ClearInputField()
        {
            _inputField.Clear();
        }
        public void InputData(int amount)
        {
            _inputField.SendKeys(amount.ToString());
        }
        public void ClickGenerate()
        {
            _generateButton.Click();
        }
        public string GetLoremText()
        { 
            return _loremText.Text;
        }
        public HomePage goToNewsPage()
        {
            _driver.Navigate().GoToUrl("https://www.bbc.com/");
            return new HomePage(_driver);
        }
    }
}
