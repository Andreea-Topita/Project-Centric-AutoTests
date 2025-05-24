using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test1Centric.PageObjectModel
{
    class BlueJeansItem
    {
        IWebDriver driver;

        public BlueJeansItem(IWebDriver browser)
        {
            driver = browser;
        }

        public IWebElement quantity => driver.FindElement(By.Id("addtocart_36_EnteredQuantity"));

        public IWebElement addToCart => driver.FindElement(By.Id("add-to-cart-button-36"));

        public void AddProduct()
        {
            quantity.Clear();
            quantity.SendKeys("4");
            addToCart.Click();
        }




    }
}
