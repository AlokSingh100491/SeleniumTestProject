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
    class DriverCommands
    {
        IWebDriver driver;

        [Test]
        public void Test()
        {
            driver = new FirefoxDriver();

            driver.Url = "http://www.flipkart.com";

            string Title = driver.Title;

            Console.WriteLine("Title is : "+Title);

            Console.WriteLine("Length of Title is : "+Title.Length);

            string PageUrl = driver.Url;

            Console.WriteLine("URL is : " + PageUrl);

            Console.WriteLine("Length of URL is : " + PageUrl.Length);

        }
    }
}
