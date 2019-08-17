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
    class HaveYourSayPage
    {
        private IWebDriver _driver;
        private WebDriverWait _wait;

        public HaveYourSayPage(IWebDriver driver)
        {
            this._driver = driver;
            PageFactory.InitElements(this, new RetryingElementLocator(_driver, TimeSpan.FromSeconds(20)));
            _wait = new WebDriverWait(driver, TimeSpan.FromSeconds(3));
        }

        [FindsBy(How = How.XPath, Using = "//div[@class='no-mpu']//a[@class='gs-c-promo-heading gs-o-faux-block-link__overlay-link gel-paragon-bold gs-u-mt+ nw-o-link-split__anchor']")]
        private IWebElement _questionLink;
        
        public IWebElement _fieldForQuestion;

        public IWebElement _nameField;

        public IWebElement _emailField;

        public IWebElement _ageField;

        public IWebElement _postCodeField;

        [FindsBy(How = How.XPath, Using = "(//div[@class='checkbox']//input)[1]")]
        private IWebElement _dailyNewsSubscribeButton;

        [FindsBy(How = How.XPath, Using = "//div[@class='button-container']/button")]
        private IWebElement _submitButton;

        [FindsBy(How = How.XPath, Using = "//div[@class='text-input']/div[@class='input-threeup-leading ']")]
        private IWebElement _nameError;

        [FindsBy(How = How.XPath, Using = "//div[@class='text-input']/div[@class='input-threeup-leading input-threeup-following ']")]
        private IWebElement _emailError;

        public void ClickQuestionLink()
        {
            _questionLink.Click();
        }
        public string GetFormXpath(string fieldName)
        {
            return "//*[@placeholder='" + fieldName + "']";
        }
        public void ClickDailyNewsSubscribe()
        {
            _dailyNewsSubscribeButton.Click();
        }
        public void ClickSubmit()
        {
            _submitButton.Click();
        }
        public void TakeScreenshot ()
        {
            ((ITakesScreenshot)_driver).GetScreenshot().SaveAsFile(@"E:\Work\epam\AT\task_2\CurrentPage.png");
        }
        public bool CheckErrorForName()
        {
            return _wait.Until(ExpectedConditions.TextToBePresentInElement(_nameError, "Name can't be blank"));
        }
        public bool CheckErrorForEmail()
        {
            return _wait.Until(ExpectedConditions.TextToBePresentInElement(_emailError, "Email address can't be blank"));
        }
    }
}
