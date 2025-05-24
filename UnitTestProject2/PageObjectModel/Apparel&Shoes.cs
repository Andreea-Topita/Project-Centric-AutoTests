using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test1Centric.PageObjectModel
{
    class ApparelAndShoes
    {
        IWebDriver driver;
        public ApparelAndShoes(IWebDriver browser)
        {
            driver = browser;
        }
        public IWebElement btnSort => driver.FindElement(By.Id("products-orderby"));

        public IWebElement priceLowToHigh => driver.FindElement(By.XPath("//select[@id='products-orderby']/option[normalize-space(.)='Price: Low to High']"));

        public IWebElement blueJeans => driver.FindElement(By.XPath("//a[@href='/blue-jeans']"));

        public void ClickSortPriceLowToHigh()
        {
            btnSort.Click();
            priceLowToHigh.Click();
        }

        public void ClickBlueJeans()
        {
            blueJeans.Click();
        }
    }
}
