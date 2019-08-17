using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;
using System.Threading.Tasks;

namespace final.Hooks
{
    [Binding]
    class GeneralHooks
    {
        private IWebDriver _driver;

        [BeforeScenario]
        public void RunBeforeScenario()
        {
            _driver = new ChromeDriver();
            _driver.Manage().Window.Maximize();
            ScenarioContext.Current.Add("currentDriver", _driver);
        }

        [AfterScenario]
        public void RunAfterScenario()
        {
            _driver?.Quit();
        }
    }
}
