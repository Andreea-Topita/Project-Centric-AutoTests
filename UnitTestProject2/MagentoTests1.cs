
namespace Test1Centric
{
    using System;
    using System.Threading;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Chrome;
    using OpenQA.Selenium.Support.UI;
    using SeleniumExtras.WaitHelpers;
    using Test1Centric.PageObjectModel;
    using Test1Centric.TestData;
    using Test1Centric.PageObjectModel;
    using Test1Centric.TestData;

    [TestClass]
    public class MagentoTests1
    {

        private IWebDriver driver;
        private LoginPage loginPage;
        private HomePage homePage;
        private ApparelAndShoes apparelAndShoes;
        private BlueJeansItem blueJeansItem;
        private ShoppingCart shoppingCart;



        [TestInitialize]
        public void Setup()
        {
            // Code to run before each test
            driver = new ChromeDriver();
            loginPage = new LoginPage(driver);
            homePage = new HomePage(driver);
            apparelAndShoes = new ApparelAndShoes(driver);
            blueJeansItem = new BlueJeansItem(driver);
            shoppingCart = new ShoppingCart(driver);
            driver.Navigate().GoToUrl("https://demowebshop.tricentis.com/");
            driver.Manage().Window.Maximize();

        }



        [TestMethod]
        public void LoginSuccesfull()
        {
            homePage.ClickSignIn();
            loginPage.SignInAccount(Resource1.email, Resource1.password);

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            wait.Until(ExpectedConditions.ElementIsVisible(By.LinkText("Log out")));
            var logOutMessage = driver.FindElement(By.LinkText("Log out")).Text;
            Assert.AreEqual("Log out", logOutMessage);

        }

        [TestMethod]
        public void LogOut()
        {
            //LoginSuccesfull();
            homePage.ClickLogout();

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            wait.Until(ExpectedConditions.ElementIsVisible(By.LinkText("Log in")));
            var signInMessage = driver.FindElement(By.LinkText("Log in")).Text;
            Assert.AreEqual("Log in", signInMessage);

        }



        [TestMethod]
        public void AddToCart()
        {
            //LoginSuccesfull();
            homePage.ClickApparel_Shoes();
            apparelAndShoes.ClickSortPriceLowToHigh();
            apparelAndShoes.ClickBlueJeans();
            blueJeansItem.AddProduct();


            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[@id='bar-notification' and contains(@class,'success')]//p[@class='content']")));
            var notification = driver.FindElement(By.XPath("//div[@id='bar-notification' and contains(@class,'success')]//p[@class='content']"));
            string message = notification.Text;
            Assert.AreEqual("The product has been added to your shopping cart", message);
        }

        [TestMethod]
        public void EmptyCart()
        {
            //LoginSuccesfull();
            homePage.clickShoppingCart();
            shoppingCart.emptyCart();

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[@class=\"order-summary-content\"]")));
            var succesMessage = driver.FindElement(By.XPath("//div[@class=\"order-summary-content\"]")).Text;
            Assert.AreEqual("Your Shopping Cart is empty!", succesMessage);
        }

        [TestMethod]
        public void test()
        {
            LoginSuccesfull();
            AddToCart();
            EmptyCart();
            LogOut();
        }
        [TestCleanup]
        public void Cleanup()
        {
            // Code to run after each test
            driver.Quit();
        }


    }
}
