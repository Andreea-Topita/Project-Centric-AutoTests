using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test1Centric.PageObjectModel
{
    class HomePage
    {
        IWebDriver driver;

        public HomePage(IWebDriver browser)
        {
            driver = browser;
        }

        public IWebElement linkSignIn => driver.FindElement(By.LinkText("Log in"));

        public IWebElement shoppingCart => driver.FindElement(By.XPath("//li[@id=\"topcartlink\"]/a/span[@class=\"cart-label\"]"));

        public IWebElement bttApparel_Shoes => driver.FindElement(By.XPath("//a[@href='/apparel-shoes']"));

        public IWebElement logOut => driver.FindElement(By.XPath("//a[@class=\"ico-logout\"]"));


        public void ClickSignIn()
        {
            linkSignIn.Click();
        }

        public void clickShoppingCart()
        {
            shoppingCart.Click();
        }

        public void ClickApparel_Shoes()
        {
            bttApparel_Shoes.Click();
        }

        public void ClickLogout()
        {
            logOut.Click();
        }
    }
}
