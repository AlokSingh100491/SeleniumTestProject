using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using System.Threading;
using SeleniumTestProject.ObjectRepo;
using log4net.Repository.Hierarchy;
using OpenQA.Selenium.Interactions;

namespace SeleniumTestProject.TestScripts
{
    public class FirstFlipkartTC
    {

        public IJavaScriptExecutor js;
        public static IWebDriver dr = null;
        CommonUtils CommonUtilObj;
        Functions func;

        public FirstFlipkartTC()
        {
            dr = new FirefoxDriver();
           js  = (IJavaScriptExecutor)dr;
            CommonUtilObj = new CommonUtils(dr);
            func = new Functions(dr);
        }

        

        [Test]
        public void FirstTC()
        {
            func.LaunchApp("http://www.flipkart.com");
            Screenshot scr = ((ITakesScreenshot)FirstFlipkartTC.dr).GetScreenshot();
            scr.SaveAsFile("Temp", ScreenshotImageFormat.Jpeg);

            func.LoginApp("aloksingh100491@gmail.com", "alok@1991");

            Thread.Sleep(2000);
            
            if (CommonUtilObj.VerifyElementExistence(AppObjRepo.hiFlipkart))
            {
                Console.WriteLine("User successfully loggen in to flipkart.");
            }
            else
            {
                Console.WriteLine("Fails to login to flipkart.");
            }

            //dr.Close();

        }

        [Test]
        public void SortLowToHighIPhone()
        {
            func.LaunchApp("http://www.flipkart.com");

            func.LoginApp("aloksingh100491@gmail.com", "alok@1991");
            Thread.Sleep(10000);
            //CommonUtilObj.WaitUntilElementIsPresent(AppObjRepo.ElectronicsBtn);

            CommonUtilObj.MouseHoverToElement(AppObjRepo.ElectronicsBtn, dr);
            Thread.Sleep(2000);

            CommonUtilObj.MouseHoverToElement(AppObjRepo.AppleOption, dr);
            Thread.Sleep(3000);

            CommonUtilObj.Click(AppObjRepo.iPhoneOption);
            Thread.Sleep(3000);

            CommonUtilObj.Click(AppObjRepo.LowToHighRangeBtn);
            Thread.Sleep(5000);

           // String lowestRangePhone = dr.FindElement(By.XPath(".//*[@class='_3T_wwx']//div[1]/div[@class='_3wU53n']")).Text;
            
            //String NoOfPages = dr.FindElement(By.XPath(".//*[@class='_3v8VuN']//span[1]//span[4]")).Text;

            //List<string> NoOfRows = new List<String>();
            //string RateText;
            //IList<IWebElement> Elements;
            //IWebElement NextBtn;
            //for (int i = 0; i < Convert.ToInt32(NoOfPages); i++)
            //{
            //    Elements = dr.FindElements(By.XPath(".//*[@class='_3T_wwx']/div"));

            //    int NoOfElements = Elements.Count;

            //    Console.WriteLine("Page Number : "+i);

            //    for (int k = 1; k <= NoOfElements; k++)
            //    {
            //        RateText = dr.FindElement(By.XPath(".//*[@class='_3T_wwx']/div[" + k + "]//div[@class='_1vC4OE _2rQ-NK']")).Text;
                    
            //        NoOfRows.Add(RateText);
            //    }
                
            //    if (i != Convert.ToInt32(NoOfPages)-1)
            //    {
                   
            //        //NextBtn = dr.FindElement(By.XPath("//span[text()='Next']"));

            //        //js.ExecuteScript("arguments[0].scrollIntoView(true);", NextBtn);
            //        //js.ExecuteScript("scroll(0, 500);");
            //        CommonUtilObj.Click(AppObjRepo.NextBtn);
            //        //NextBtn.Click();
                    
            //        Thread.Sleep(5000);
                    
            //    }

            //}



            List<string> ActualRates = func.ReturnMobilePriceList();
            //NoOfRows;
            List<string> ExpectedRates = func.ReturnMobilePriceList();

            ExpectedRates.Sort();

            
            if(ActualRates == ExpectedRates)
            {
                Console.WriteLine("List is sorted in Low to High Order");
            }
            else
            {
                Console.WriteLine("List is not Sorted");
            }
        }

        [Test]
        public void SelectFilterAndverifyItem()
        {
            func.LaunchApp("http://www.flipkart.com");

            func.LoginApp("aloksingh100491@gmail.com", "alok@1991");
            Thread.Sleep(10000);
            //CommonUtilObj.WaitUntilElementIsPresent(AppObjRepo.ElectronicsBtn);

            CommonUtilObj.MouseHoverToElement(AppObjRepo.ElectronicsBtn, dr);
            Thread.Sleep(2000);

            CommonUtilObj.MouseHoverToElement(AppObjRepo.AppleOption, dr);
            Thread.Sleep(3000);

            CommonUtilObj.Click(AppObjRepo.iPhoneOption);
            Thread.Sleep(3000);

            CommonUtilObj.ScrollToElement(AppObjRepo.NetworkTypeFilter);

            CommonUtilObj.Click(AppObjRepo.NetworkTypeFilter);

            Thread.Sleep(2000);

            CommonUtilObj.Click(AppObjRepo.FourGNetworktypeChkBox);

            Thread.Sleep(4000);
            
            CommonUtilObj.Click(AppObjRepo.LowToHighRangeBtn);
            Thread.Sleep(8000);

            string LowestPhonePrice = dr.FindElement(By.XPath(".//*[@class='_3T_wwx']/div[1]//div[@class='_1vC4OE _2rQ-NK']")).Text;
                       

            Console.WriteLine("First Mobile with Lowest Range with 4G feature is : "+ LowestPhonePrice);
        }


        public static void Testing()
        {

            String NoOfPages = dr.FindElement(By.XPath(".//*[@class='_3v8VuN']//span[1]//span[4]")).Text;

            IList<String> NoOfRows = new List<String>();
            string RateText;
            IList<IWebElement> Elements;
            IWebElement NextBtn;
            for (int i=0;i< Convert.ToInt32(NoOfPages); i++)
            {
                Elements = dr.FindElements(By.XPath(".//*[@class='_3T_wwx']/div"));

                int NoOfElements = Elements.Count;

                for (int k=0;k< NoOfElements; k++)
                {
                    RateText = dr.FindElement(By.XPath(".//*[@class='_3T_wwx']/div[" + k + "]//div[@class='_1vC4OE _2rQ-NK']")).Text;
                    Console.WriteLine("Rate of Phone is " + RateText);
                    NoOfRows.Add(RateText);
                }

               NextBtn =  dr.FindElement(By.XPath(".//span[text()='Next']"));

               // js.ExecuteScript("arguments[0].scrollIntoView(true);", NextBtn);

                NextBtn.Click();

                Thread.Sleep(5000);
                //.//*[@class='_3T_wwx']//div[@class='_1vC4OE _2rQ-NK']

                
            }
        }

    }
}