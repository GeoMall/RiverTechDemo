using System;
using System.IO;
using LightBDD.Framework;
using LightBDD.Framework.Scenarios;
using LightBDD.MsTest2;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using RiverTechDemo;

namespace TestSuite
{
    [TestClass]
    [Label("UiLightBDDTests")]
    public partial class UiLightBDDTests
    {
        [Scenario]
        [Label("Login")]
        public void SuccessfulLogin() 
        {
            Runner.RunScenario(
                Given_the_user_is_about_to_login, 
                When_the_user_enteres_valid_login_and_password_and_logs_in,
                Then_the_login_operation_should_be_successful
                );
        }

        [Scenario]
        [Label("Add Item to Cart")]
        public void AddItemToCart()
        {
            Runner.RunScenario(
                Given_the_user_logged_in_successfully,
                Given_the_Item_is_added_to_Cart,
                Then_it_should_be_visible_in_icon,
                And_it_should_be_visible_in_cart
                );
        }

        [Scenario]
        [Label("Proceed to Checkout Details")]
        public void ProceedToCheckout()
        {
            Runner.RunScenario(
                Given_the_user_logged_in_successfully,
                Given_the_Item_is_added_to_Cart,
                Given_the_cart_is_opened,
                Given_checkout_button_is_clicked,
                When_Customer_details_are_inputted,
                Then_the_correct_checkout_details_are_displayed
                );
        }

        [Scenario]
        [Label("Order Item")]
        public void OrderItem()
        {
            Runner.RunScenario(
               Given_the_user_logged_in_successfully,
               Given_the_Item_is_added_to_Cart,
               Given_the_cart_is_opened,
               Given_checkout_button_is_clicked,
               When_Customer_details_are_inputted,
               When_the_user_proceeds,
               Then_the_order_should_be_dispatched
               );
        }

    }

    public partial class UiLightBDDTests : FeatureFixture
    {

        IWebDriver driver;
        PageFunctions PageFunctions;
        String test_url;

        [TestInitialize]
        public void Setup()
        {
            test_url = "https://www.saucedemo.com/";
            // Local Selenium WebDriver
            driver = new ChromeDriver(Directory.GetCurrentDirectory() + "/drivers/");

            driver.Manage().Window.Maximize();

            PageFunctions = new PageFunctions(driver);
        }

        [TestCleanup]
        public void TearDown()
        {
            driver.Close();
        }

      
        //Scenario Login

        public void Given_the_user_is_about_to_login()
        {
            driver.Navigate().GoToUrl(test_url);

            driver.Manage().Window.Maximize();
        }

        public void When_the_user_enteres_valid_login_and_password_and_logs_in()
        {
            PageFunctions.Login("standard_user", "secret_sauce");
        }

        public void Then_the_login_operation_should_be_successful()
        {
            IWebElement InventoryContainer = driver.FindElement(By.Id("inventory_container"));
            Assert.IsTrue(InventoryContainer.Displayed);
        }


        //Scenario Add Item to Cart
        public void Given_the_user_logged_in_successfully()
        {
            driver.Navigate().GoToUrl(test_url);

            driver.Manage().Window.Maximize();
            PageFunctions.Login("standard_user", "secret_sauce");
        }

        public void Given_the_Item_is_added_to_Cart()
        {
            PageFunctions.AddItemToCart();
        }

        public void Then_it_should_be_visible_in_icon()
        {
            IWebElement cartIcon = driver.FindElement(By.XPath("//*[@id=\"shopping_cart_container\"]/a/span"));
            Assert.IsTrue(cartIcon.Displayed);
        }

        public void And_it_should_be_visible_in_cart()
        {
            PageFunctions.OpenCart();

            IWebElement ItemInCart = driver.FindElement(By.Id("item_5_title_link"));
            Assert.IsTrue(ItemInCart.Displayed);
        }


        //Scenario Proceed to Checkout Details
        public void Given_the_cart_is_opened()
        {
            PageFunctions.OpenCart();
        }
        
        public void Given_checkout_button_is_clicked()
        {
            PageFunctions.Checkout();
        }
       
        public void  When_Customer_details_are_inputted()
        {
            PageFunctions.FillCheckOutDetails();
        }
        
        public void Then_the_correct_checkout_details_are_displayed()
        {

            IWebElement SubTotalLb = driver.FindElement(By.ClassName("summary_subtotal_label"));
            IWebElement TaxLb = driver.FindElement(By.ClassName("summary_tax_label"));
            IWebElement TotalLb = driver.FindElement(By.ClassName("summary_total_label"));

            Assert.AreEqual("Item total: $49.99", SubTotalLb.Text);
            Assert.AreEqual("Tax: $4.00", TaxLb.Text);
            Assert.AreEqual("Total: $53.99", TotalLb.Text);
        }


        //Scenario Order Item

        public void When_the_user_proceeds()
        {
            PageFunctions.ProceedCheckout();
        }

        public void Then_the_order_should_be_dispatched()
        {
            IWebElement ConfirmationMessage = driver.FindElement(By.XPath("//*[@id=\"checkout_complete_container\"]/div"));
            IWebElement CheckoutComplete = driver.FindElement(By.XPath("//*[@id=\"header_container\"]/div[2]/span"));

            Assert.AreEqual("Your order has been dispatched, and will arrive just as fast as the pony can get there!", ConfirmationMessage.Text);
            Assert.AreEqual("CHECKOUT: COMPLETE!", CheckoutComplete.Text);
        }

    }
}
