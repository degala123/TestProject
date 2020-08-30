using System;
using System.Threading;
using FirstDemoProject.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using TechTalk.SpecFlow;

namespace FirstDemoProject.Steps
{
    [Binding]
    public class OrangeHrmDemoSteps
    {
        private IWebDriver driver;
        private string _userName;
        private LoginPage _loginPage;

        public OrangeHrmDemoSteps()
        {
            driver = new ChromeDriver();
            _loginPage = new LoginPage();
        }

        [Given(@"I am on login page")]
        public void GivenIAmOnLoginPage()
        {
            driver.Navigate().GoToUrl("https://opensource-demo.orangehrmlive.com/");
            driver.Manage().Window.Maximize();
        }
        
        [When(@"I enter username as '(.*)'")]
        public void WhenIEnterUsernameAs(string username)
        {
            
            driver.FindElement(_loginPage.UsernameInput).SendKeys(username);
            
        }
        
        [When(@"I enter the password as '(.*)'")]
        public void WhenIEnterThePasswordAs(string password)
        {
            driver.FindElement(_loginPage.PasswordInput).SendKeys(password);
        }
        
        [When(@"I click on login button")]
        public void WhenIClickOnLoginButton()
        {
            driver.FindElement(_loginPage.LoginButton).Click();
        }
        
        [Then(@"I should see the '(.*)' page")]
        public void ThenIShouldSeeThePage(string p0)
        {
           string pageHeaderText = driver.FindElement(By.XPath("//h1[text()='Dashboard']")).Text;

           Assert.IsTrue(pageHeaderText != null);
           Assert.AreEqual(p0, pageHeaderText);
           
        }

        [When(@"I click on admin")]
        public void WhenIClickOnAdmin()
        {
            driver.FindElement(By.XPath("//b[text()='Admin']")).Click();
        }

        [When(@"I click on Add button")]
        public void WhenIClickOnAddButton()
        {
            driver.FindElement(By.Id("btnAdd")).Click();
        }

        [When(@"I select user role as '(.*)'")]
        public void WhenISelectUserRoleAs(string p0)
        {
            SelectElement select = new SelectElement(driver.FindElement(By.Id("systemUser_userType")));
            select.SelectByText(p0);
        }

        [When(@"I enter employee name as'(.*)'")]
        public void WhenIEnterEmployeeNameAs(string p0)
        {
            driver.FindElement(By.Id("systemUser_employeeName_empName")).SendKeys(p0);
        }

        [When(@"I enter admin username as '(.*)'")]
        public void WhenIEnterAdminUsernameAs(string username)
        {
            _userName = username;
            driver.FindElement(By.Id("systemUser_userName")).SendKeys(username);
        }

        [When(@"I select status as '(.*)'")]
        public void WhenISelectStatusAs(string p0)
        {
          SelectElement select = new SelectElement(driver.FindElement(By.Id("systemUser_status")));
          select.SelectByText(p0);
        }

        [When(@"I enter admin password as '(.*)'")]
        public void WhenIEnterAdminPasswordAs(string password)
        {
            driver.FindElement(By.Id("systemUser_password")).SendKeys(password);
        }

        [When(@"I enter confirm password as '(.*)'")]
        public void WhenIEnterConfirmPasswordAs(string p0)
        {
            driver.FindElement(By.Id("systemUser_confirmPassword")).SendKeys(p0);
        }

        [When(@"I click on save button")]
        public void WhenIClickOnSaveButton()
        {
            Thread.Sleep(3000);
            driver.FindElement(By.Id("btnSave")).Click();
        }

        [Then(@"the new system user should be added")]
        public void ThenTheNewSystemUserShouldBeAdded()
        {
            string systemUsertable = driver.FindElement(By.Id("tableWrapper")).Text;

            Assert.IsTrue(systemUsertable.Contains(_userName));

            Thread.Sleep(5000);
        }

    }
}
