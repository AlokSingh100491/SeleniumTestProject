using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumTestProject
{
    class NUnitTest
    {
        IWebDriver driver;

        [SetUp]
        public void Initialize()
        {
            driver = new FirefoxDriver();
        }
        
        [Test]
        public void OpenAppTest()
        {
            driver.Url = "http://www.demoqa.com";
            //driver.Close();
        }

        [TearDown]
        public void EndTest()
        {
            driver.Close();
        }
    }
}
