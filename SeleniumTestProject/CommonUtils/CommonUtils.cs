using log4net;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumTestProject.ObjectRepo;
using SeleniumTestProject.TestScripts;
using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SeleniumTestProject
{
    class CommonUtils
    {
        public IJavaScriptExecutor js;
        IWebDriver dr = null;
        public CommonUtils(IWebDriver driver)
        {
            dr = driver;
            js = (IJavaScriptExecutor)dr;
        }
        private readonly ILog log = LogManager.GetLogger("CommonUtils");

        //Actions action = new Actions(dr);

        public bool VerifyElementExistence(By Element)
        {
            
            bool status = false;
            WaitUntilElementIsPresent(Element);
            if (FirstFlipkartTC.dr.FindElement(Element) != null)
            {
                status = true;
            }
            return status;
        }

        //public void screenshot(string FilePath,string Message)
        //{
        //    Console.WriteLine("Hello 5");
        //    try
        //    {
        //        Console.WriteLine("Hello 6");
        //        DateTime dt = DateTime.Now;
        //        Screenshot scr = ((ITakesScreenshot)FirstFlipkartTC.dr).GetScreenshot(); 
        //        scr.SaveAsFile(FilePath + dt.ToString() +"_" + Message, ScreenshotImageFormat.Jpeg);
        //    }
        //    catch(Exception e)
        //    {
        //        Console.WriteLine(e.StackTrace);
        //    }
        //}

        public void Click(By Element)
        {
            try
            {
                WaitUntilElementIsPresent(Element);
                FirstFlipkartTC.dr.FindElement(Element).Click();
                //screenshot(@"C:\Screenshot", "Clicked");
            }
            catch(Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
        }
       
        public void Entertext(By Element, String TextToBeEntered)
        {
            try
            {
                WaitUntilElementIsPresent(Element);
                FirstFlipkartTC.dr.FindElement(Element).SendKeys(TextToBeEntered);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
        }

        public string ReturnObjectText(By Element)
        {
            string Text=null;
            try
            {
                WaitUntilElementIsPresent(Element);
                Text = FirstFlipkartTC.dr.FindElement(Element).Text;

                return Text;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                return Text;
            }
        }

        //public static IWebElement ReturnWebElement(By Element)
        //{
        //    return dr.FindElement(Element);
        //}

        public void MouseHoverToElement(By Element, IWebDriver dr)
        {
            //WaitUntilElementIsPresent(Element);
            Actions action = new Actions(dr); 
            action.MoveToElement(dr.FindElement(Element)).Click().Build().Perform();

        }

        public void ScrollToElement(By Element)
        {
            int counter = 0;
            int x = 0;
            int y = 250;
            while (!dr.FindElement(Element).Displayed && counter<10)
            {

                js.ExecuteScript("scroll(x, y);");
                counter++;
                Thread.Sleep(2000);
                x = x + 250;
                y = y + 250;
            }
        }

        public IList<String> ReturnSplittedValue(String FullString, char ToBeSplitByValue)
        {
            IList<String> lsSplittedvalue = FullString.Split(ToBeSplitByValue);

            return lsSplittedvalue;
        }

        public void WaitForElement(By Element)
        {
            //var wait = new IWebDriverWait(dr, TimeSpan.FromSeconds(60));
            
        }

        public void WaitUntilElementIsPresent( By by, int timeout = 10)
        {

            WebDriverWait wait = new WebDriverWait(dr, TimeSpan.FromSeconds(60));
            wait.Until(ExpectedConditions.ElementExists(by));

        }

    }
}
