using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace RiverTechDemo
{
    public class PageFunctions
    {
        private IWebDriver ChromeDriver { get; set; }
        public PageFunctions(IWebDriver driver) {
            this.ChromeDriver = driver;
        }

        public void Login(String username, String password)
        {
            
            IWebElement UsernameFld = ChromeDriver.FindElement(By.Id("user-name"));
            UsernameFld.SendKeys(username);

            IWebElement PasswordFld = ChromeDriver.FindElement(By.Id("password"));
            PasswordFld.SendKeys(password);

            IWebElement LoginBtn = ChromeDriver.FindElement(By.Id("login-button"));
            LoginBtn.Click();
        }

        public void AddItemToCart()
        {
            IWebElement ItemToClick = ChromeDriver.FindElement(By.Id("add-to-cart-sauce-labs-fleece-jacket"));
            ItemToClick.Click();
        }

        public void OpenCart()
        {
            IWebElement CartButton = ChromeDriver.FindElement(By.Id("shopping_cart_container"));
            CartButton.Click();
        }
        
        public void Checkout()
        {
            IWebElement CheckoutButton = ChromeDriver.FindElement(By.Id("checkout"));
            CheckoutButton.Click();
        }

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

        public void ProceedCheckout()
        {
            IWebElement FinishButton = ChromeDriver.FindElement(By.Id("finish"));
            FinishButton.Click();
        }

      



    }
}
