using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Web.XmlTransform;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace final.BusinessLogic
{
    class BusHaveYourSay
    {
        private IWebDriver _driver;

        public BusHaveYourSay(IWebDriver driver)
        {
            this._driver = driver;
        }

        public void SubmitQuestion(Dictionary<string, string> fields)
        {
            HomePage home = new HomePage(_driver);
            HaveYourSayPage haveYourSay = new HaveYourSayPage(_driver);
            home.GoToBBCPage();
            NewsPage news = home.goToNewsPage();
            news.ClickMore();
            news.goToHaveYourSayPage();
            haveYourSay.ClickQuestionLink();
            haveYourSay._fieldForQuestion = _driver.FindElement(By.XPath(haveYourSay.GetFormXpath("What questions would you like us to investigate?")));
            haveYourSay._nameField = _driver.FindElement(By.XPath(haveYourSay.GetFormXpath("Name")));
            haveYourSay._emailField = _driver.FindElement(By.XPath(haveYourSay.GetFormXpath("Email address")));
            haveYourSay._ageField = _driver.FindElement(By.XPath(haveYourSay.GetFormXpath("Age")));
            haveYourSay._postCodeField = _driver.FindElement(By.XPath(haveYourSay.GetFormXpath("Postcode")));

            haveYourSay._fieldForQuestion.SendKeys(fields["What questions would you like us to investigate?"]);
            haveYourSay._nameField.SendKeys(fields["Name"]);
            haveYourSay._emailField.SendKeys(fields["Email address"]);
            haveYourSay._ageField.SendKeys(fields["Age"]);
            haveYourSay._postCodeField.SendKeys(fields["Postcode"]);
            haveYourSay.ClickDailyNewsSubscribe();  
        }
    }
}
