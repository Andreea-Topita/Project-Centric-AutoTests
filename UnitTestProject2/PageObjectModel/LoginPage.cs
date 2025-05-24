using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test1Centric.PageObjectModel
{
    public class LoginPage
    {
        IWebDriver driver;

        public LoginPage(IWebDriver browser)
        {
            driver = browser;
        }

        public IWebElement txtEmail => driver.FindElement(By.Id("Email"));

        public IWebElement txtPassword => driver.FindElement(By.Id("Password"));

        public IWebElement btnLogin => driver.FindElement(By.XPath("//input[@class='button-1 login-button' and @type='submit']"));
        public void SignInAccount(string email, string password)
        {
            txtEmail.Clear();
            txtEmail.SendKeys(email);
            txtPassword.Clear();
            txtPassword.SendKeys(password);
            btnLogin.Click();
        }


    }
}
