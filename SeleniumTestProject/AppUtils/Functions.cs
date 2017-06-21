using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using SeleniumTestProject.TestScripts;
using SeleniumTestProject.ObjectRepo;
using System.Threading;

namespace SeleniumTestProject
{
    class Functions
    {
        //IWebDriver dr;
        CommonUtils CommonUtilObj;
        public Functions(IWebDriver dr)
        {
           
            CommonUtilObj = new CommonUtils(dr);
        }

        public void LaunchApp(string url)
        {
            
            FirstFlipkartTC.dr.Url = url;
            FirstFlipkartTC.dr.Manage().Window.Maximize();

        }

        public void LoginApp(string username, string password, string url=null)
        {
            
            if (CommonUtilObj.VerifyElementExistence(AppObjRepo.LoginBtn))
            {
                CommonUtilObj.Click(AppObjRepo.LoginBtn);
            }
            else if(CommonUtilObj.VerifyElementExistence(AppObjRepo.MoreBtn))
            {
                CommonUtilObj.Click(AppObjRepo.MoreBtn);
                CommonUtilObj.Click(AppObjRepo.LogoutBtn);
                CommonUtilObj.Click(AppObjRepo.LoginBtn);

            }
            else
            {
                Console.WriteLine("Fails to find Login Button.");
                FirstFlipkartTC.dr.Close();
                LaunchApp(url);
                CommonUtilObj.Click(AppObjRepo.LoginBtn);

            }

          
            if (CommonUtilObj.VerifyElementExistence(AppObjRepo.UserNameField))
            {
                Console.WriteLine("User successfully navigated to Login screen");

                CommonUtilObj.Entertext(AppObjRepo.UserNameField, "aloksingh100491@gmail.com");
                CommonUtilObj.Entertext(AppObjRepo.PasswordField, "alok@1991");
                CommonUtilObj.Click(AppObjRepo.SubmitBtn);
            }
            else
            {
                Console.WriteLine("Fails to navigate to LOGIN screen.");
            }

        }

        public List<string> ReturnMobilePriceList()
        {
            String TotalNoOfPages = FirstFlipkartTC.dr.FindElement(AppObjRepo.TotalPages).Text;

            List<string> NoOfRows = new List<String>();
            string RateText;
            IList<IWebElement> Elements;
            
            for (int i = 0; i < Convert.ToInt32(TotalNoOfPages); i++)
            {
                Elements = FirstFlipkartTC.dr.FindElements(AppObjRepo.ParentDiv);

                int NoOfElements = Elements.Count;

                Console.WriteLine("Page Number : " + i);

                for (int k = 1; k <= NoOfElements; k++)
                {
                    RateText = FirstFlipkartTC.dr.FindElement(By.XPath(".//*[@class='_3T_wwx']/div[" + k + "]//div[@class='_1vC4OE _2rQ-NK']")).Text;

                    NoOfRows.Add(RateText);
                }

                if (i != Convert.ToInt32(TotalNoOfPages) - 1)
                {

                    //NextBtn = dr.FindElement(By.XPath("//span[text()='Next']"));

                    //js.ExecuteScript("arguments[0].scrollIntoView(true);", NextBtn);
                    //js.ExecuteScript("scroll(0, 500);");
                    CommonUtilObj.Click(AppObjRepo.NextBtn);
                    //NextBtn.Click();

                    Thread.Sleep(8000);

                }

            }
            return NoOfRows;
        }
    }
}
