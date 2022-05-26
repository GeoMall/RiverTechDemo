using OpenQA.Selenium;
using System;


namespace RiverTechDemo
{
    public class PageFunctions
    {
        private IWebDriver ChromeDriver { get; set; }
        public PageFunctions(IWebDriver driver) {
            this.ChromeDriver = driver;
        }

        /// <summary>
        /// Finds the username, password fields and inputs the passed data. It locates the login button and clicks it.
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        public void Login(String username, String password)
        {
            
            IWebElement UsernameFld = ChromeDriver.FindElement(By.Id("user-name"));
            UsernameFld.SendKeys(username);

            IWebElement PasswordFld = ChromeDriver.FindElement(By.Id("password"));
            PasswordFld.SendKeys(password);

            IWebElement LoginBtn = ChromeDriver.FindElement(By.Id("login-button"));
            LoginBtn.Click();
        }

        /// <summary>
        /// Locates the Item to add to the cart and clicks add to cart.
        /// </summary>
        public void AddItemToCart()
        {
            IWebElement ItemToClick = ChromeDriver.FindElement(By.Id("add-to-cart-sauce-labs-fleece-jacket"));
            ItemToClick.Click();
        }

        /// <summary>
        ///  locates the Cart button and clicks it
        /// </summary>
        public void OpenCart()
        {
            IWebElement CartButton = ChromeDriver.FindElement(By.Id("shopping_cart_container"));
            CartButton.Click();
        }

        /// <summary>
        /// locates the checkout button and clicks it
        /// </summary>
        public void Checkout()
        {
            IWebElement CheckoutButton = ChromeDriver.FindElement(By.Id("checkout"));
            CheckoutButton.Click();
        }

        /// <summary>
        /// locates the name, last name and zipcode fields and enters dummy data. locates the continue button and clicks it.
        /// </summary>
        public void FillCheckOutDetails()
        {
            IWebElement NameFld = ChromeDriver.FindElement(By.Id("first-name"));
            NameFld.SendKeys("TestName");

            IWebElement LastNameFld = ChromeDriver.FindElement(By.Id("last-name"));
            LastNameFld.SendKeys("TestLastName");

            IWebElement ZipCodeFld = ChromeDriver.FindElement(By.Id("postal-code"));
            ZipCodeFld.SendKeys("TestZipCode");

            IWebElement ContinueButton = ChromeDriver.FindElement(By.Id("continue"));
            ContinueButton.Click();
        }

        /// <summary>
        /// locates the finish button and clicks it to complete the order.
        /// </summary>
        public void ProceedCheckout()
        {
            IWebElement FinishButton = ChromeDriver.FindElement(By.Id("finish"));
            FinishButton.Click();
        }

    }
}
