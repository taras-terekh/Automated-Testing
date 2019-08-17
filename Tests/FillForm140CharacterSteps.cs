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
    public class FillForm140CharacterSteps
    {
        private readonly IWebDriver _driver;
        private string _loremText;
        public FillForm140CharacterSteps()
        {
            _driver = ScenarioContext.Current.Get<IWebDriver>("currentDriver");
        }

        [Given(@"I have Navigated to the Lorem and grab some text and redirected to the BBC Page")]
        public void GivenIHaveNavigatedToTheLoremAndGrabSomeTextAndRedirectedToTheBBCPage()
        {
            BusLoremIpsum lorem = new BusLoremIpsum(_driver);
            _loremText = lorem.GrabSampleLoremIpsum(140);
        }
        
        [When(@"I fill the form")]
        public void WhenIFillTheForm()
        {
            BusHaveYourSay haveYourSay = new BusHaveYourSay(_driver);
            Dictionary<string, string> fields = new Dictionary<string, string>();
            fields.Add("What questions would you like us to investigate?", _loremText);
            fields.Add("Name", "Taras");
            fields.Add("Email address", "maxim21@gmail.com");
            fields.Add("Age", "21");
            fields.Add("Postcode", "00000");
            haveYourSay.SubmitQuestion(fields);
        }
        
        [Then(@"take screenshot")]
        public void ThenTakeScreenshot()
        {
            HaveYourSayPage haveYourSay = new HaveYourSayPage(_driver);
            haveYourSay.TakeScreenshot();
        }
    }
}
