using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace FirstDemoProject.Utils
{
    public class BaseClass
    {
        private readonly IWebDriver _driver;
        public readonly WebDriverWait Wait;

        public BaseClass(IWebDriver driver)
        {
            _driver = driver;
            Wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(30));
        }

        public void NavigateToPage(string pageUrl)
        {
            _driver.Navigate().GoToUrl(pageUrl);
        }

        public void WaitForPageToLoad()
        {
            _driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(30);
        }

        public void ClickEvent(By locator)
        {
                Wait.Until(ExpectedConditions.ElementToBeClickable(locator));
                _driver.FindElement(locator).Click();
        }

        public void EnterText(By locator, string text)
        {
            Wait.Until(ExpectedConditions.ElementIsVisible(locator));
            _driver.FindElement(locator).Clear();
            _driver.FindElement(locator).SendKeys(text.Trim());
        }
    }
}
