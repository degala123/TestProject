using OpenQA.Selenium;

namespace FirstDemoProject.Pages
{
    public class LoginPage
    {
        public By UsernameInput => By.Id("txtUsername");
        public By PasswordInput => By.Id("txtPassword");
        public By LoginButton => By.Id("btnLogin");
    }
}
