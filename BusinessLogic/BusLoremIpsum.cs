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
    class BusLoremIpsum
    {
        private IWebDriver _driver;

        public BusLoremIpsum(IWebDriver driver)
        {
            this._driver = driver;
        }

        public string GrabSampleLoremIpsum(int amount)
        {
            LoremIpsumPage lorem = new LoremIpsumPage(_driver);
            lorem.GoToLoremPage();
            lorem.ClickBytes();
            lorem.ClearInputField();
            lorem.InputData(amount);
            lorem.ClickGenerate();
            lorem.GetLoremText();
            return lorem.GetLoremText();
        }
    }
}
