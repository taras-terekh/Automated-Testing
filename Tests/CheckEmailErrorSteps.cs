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
using final.BusinessLogic;

namespace final
{
    [Binding]
    public class CheckEmailErrorSteps
    {
        private readonly IWebDriver _driver;
        private string _loremText;
        public CheckEmailErrorSteps()
        {
            _driver = ScenarioContext.Current.Get<IWebDriver>("currentDriver");
        }

        [Given(@"I have navigated to the lorem and grab some text and redirected to the BBC page")]
        public void GivenIHaveNavigatedToTheLoremAndGrabSomeTextAndRedirectedToTheBBCPage()
        {
            BusLoremIpsum lorem = new BusLoremIpsum(_driver);
            _loremText = lorem.GrabSampleLoremIpsum(141);
        }
        
        [When(@"I fill the form and leave email field blank")]
        public void WhenIFillTheFormAndLeaveEmailFieldBlank()
        {
            BusHaveYourSay haveYourSay = new BusHaveYourSay(_driver);
            Dictionary<string, string> fields = new Dictionary<string, string>();
            fields.Add("What questions would you like us to investigate?", _loremText);
            fields.Add("Name", "Taras");
            fields.Add("Email address", "");
            fields.Add("Age", "21");
            fields.Add("Postcode", "00000");
            haveYourSay.SubmitQuestion(fields);
        }
        
        [Then(@"check error message")]
        public void ThenCheckErrorMessage()
        {
            HaveYourSayPage haveYourSay = new HaveYourSayPage(_driver);
            haveYourSay.ClickSubmit();
            haveYourSay.CheckErrorForEmail();
        }
    }
}
