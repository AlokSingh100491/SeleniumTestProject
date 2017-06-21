using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using NUnit.Framework;

namespace SeleniumTestProject.SeleniumBasics
{
    class DriverTestClass2
    {

        IWebDriver driver;
        [Test]
        public void Test2()
        {
            driver = new FirefoxDriver();
            driver.Url = "http://www.flipkart.com";

            IWebElement wb = driver.FindElement(By.XPath(".//input[@placeholder='Search for Products, Brands and More']"));

            wb.SendKeys("Galaxy J5");

            driver.FindElement(By.XPath(".//*[@class='vh79eNYfDXPHG5mI79OWE']")).Click();

            driver.Navigate().Back();

            string Title = driver.Title;
            if (Title == "Online Shopping Site for Mobiles, Fashion, Books, Electronics, Home Appliances and More")
            {
                Console.WriteLine("User navigated successfully to back home page.");
            }
            else
            {
                Console.WriteLine("Fails to navigate Back.");
            }
            
            driver.Navigate().Forward();

            Title = driver.Title;
            if (Title != "Online Shopping Site for Mobiles, Fashion, Books, Electronics, Home Appliances and More")
            {
                Console.WriteLine("User navigated successfully to forward page.");
            }
            else
            {
                Console.WriteLine("Fails to navigate forward.");
            }

            driver.Navigate().GoToUrl("http://www.flipkart.com");

            Title = driver.Title;
            if (Title == "Online Shopping Site for Mobiles, Fashion, Books, Electronics, Home Appliances and More")
            {
                Console.WriteLine("User navigated successfully to home page using GoToUrl.");
            }
            else
            {
                Console.WriteLine("Fails to navigate to Home.");
            }

            driver.Navigate().Refresh();


        }

    }
}
