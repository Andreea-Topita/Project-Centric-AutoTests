using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test1Centric.PageObjectModel
{
    class ShoppingCart
    {
        IWebDriver driver;

        public ShoppingCart(IWebDriver browser)
        {
            driver = browser;
        }

        public IWebElement checkBoxBlueJeansItem => driver.FindElement(By.XPath("//input[@name=\"removefromcart\"]"));
        public IWebElement updateShoppingCart => driver.FindElement(By.XPath("//input[@name=\"updatecart\"]"));
        public void emptyCart()
        {
            checkBoxBlueJeansItem.Click();
            updateShoppingCart.Click();

        }



    }
}
