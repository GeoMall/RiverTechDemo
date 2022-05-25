using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using RiverTechDemo;
using System;
using System.IO;


namespace TestSuite
{
    [TestClass]

    public class UITests
    {
        IWebDriver driver;
        PageFunctions PageFunctions;


        [TestInitialize]
        public void Setup()
        {
            String test_url = "https://www.saucedemo.com/";

            // Local Selenium WebDriver
            driver = new ChromeDriver(Directory.GetCurrentDirectory() + "/drivers/");

            driver.Manage().Window.Maximize();

            driver.Navigate().GoToUrl(test_url);

            driver.Manage().Window.Maximize();
            PageFunctions = new PageFunctions(driver);
        }

        [TestCleanup]
        public void Cleanup()
        {
            driver.Close();
        }

        [TestMethod]
        public void TestSuccessfulLogin()
        {
            PageFunctions.Login("standard_user", "secret_sauce");

            IWebElement InventoryContainer = driver.FindElement(By.Id("inventory_container"));
            //By.XPath("/html/body/div/div/div/div[1]/div[2]/span"));
            //String InvTest = InventoryContainer.Text;
            // Assert.AreEqual("PRODUCTS", InvTest);
            Assert.IsTrue(InventoryContainer.Displayed);

        }


        //Testing cart element in item list
        [TestMethod]
        public void TestAddToCartIcon()
        {
            PageFunctions.Login("standard_user", "secret_sauce");
            PageFunctions.AddItemToCart();

            IWebElement cartIcon = driver.FindElement(By.XPath("//*[@id=\"shopping_cart_container\"]/a/span"));
            Assert.IsTrue(cartIcon.Displayed);
        }


        //Testing cart content
        [TestMethod]
        public void TestItemAddedToCart()
        {
            PageFunctions.Login("standard_user", "secret_sauce");
            PageFunctions.AddItemToCart();
            PageFunctions.OpenCart();

            //Assert Cart page is open cart_contents_container
            IWebElement ItemInCart = driver.FindElement(By.Id("item_5_title_link"));
            Assert.IsTrue(ItemInCart.Displayed);
        }

        [TestMethod]
        public void TestCheckOutDetails()
        {
            PageFunctions.Login("standard_user", "secret_sauce");
            PageFunctions.AddItemToCart();
            PageFunctions.OpenCart();
            PageFunctions.Checkout();
            PageFunctions.FillCheckOutDetails();


            IWebElement SubTotalLb = driver.FindElement(By.ClassName("summary_subtotal_label"));
            IWebElement TaxLb = driver.FindElement(By.ClassName("summary_tax_label"));
            IWebElement TotalLb = driver.FindElement(By.ClassName("summary_total_label"));

            Assert.AreEqual("Item total: $49.99", SubTotalLb.Text);
            Assert.AreEqual("Tax: $4.00", TaxLb.Text);
            Assert.AreEqual("Total: $53.99", TotalLb.Text);
        }

        [TestMethod]
        public void TestCheckoutConfirmationMessage()
        {
            PageFunctions.Login("standard_user", "secret_sauce");
            PageFunctions.AddItemToCart();
            PageFunctions.OpenCart();
            PageFunctions.Checkout();
            PageFunctions.FillCheckOutDetails();
            PageFunctions.ProceedCheckout();

            IWebElement ConfirmationMessage = driver.FindElement(By.XPath("//*[@id=\"checkout_complete_container\"]/div"));
            IWebElement CheckoutComplete = driver.FindElement(By.XPath("//*[@id=\"header_container\"]/div[2]/span"));

            Assert.AreEqual("Your order has been dispatched, and will arrive just as fast as the pony can get there!", ConfirmationMessage.Text);
            Assert.AreEqual("CHECKOUT: COMPLETE!", CheckoutComplete.Text);
        }

        

    }
}
