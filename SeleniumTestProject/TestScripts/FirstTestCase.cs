using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace SeleniumTestProject
{
    class FirstTestCase
    {

        static void Main(string[] args)
        {
            IWebDriver driver = new FirefoxDriver();
            driver.Url = "http://www.demoqa.com";


            //((//*[@class='srhres']//tr[@id])//td[contains(text(),'16:00')]/..//following-sibling::*)

            //driver.FindElement(By.XPath());
            //driver.Close();







        }
    }
}
