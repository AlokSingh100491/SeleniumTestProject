using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumTestProject.ObjectRepo
{
   public  class AppObjRepo
    {

        //public static string hiFlipkart = "//a[text()='Hi Flipkart!']";
        public static By hiFlipkart = By.XPath("//a[text()='Hi Flipkart!']");
        public static By LoginBtn = By.XPath(".//a[text() = 'Log In']");
        public static By MoreBtn = By.XPath(".//a[@class='_1AHrFc _2k0gmP']");
        public static By LogoutBtn = By.XPath(".//a[text()='Log Out']");
        public static By UserNameField = By.XPath(".//input[@class='_2zrpKA']");
        public static By PasswordField = By.XPath(".//input[@type='password']");
        public static By SubmitBtn = By.XPath(".//button[@type='submit' and @class='_2AkmmA _1LctnI _7UHT_c']");
        public static By ElectronicsBtn = By.XPath(".//a[@title='Electronics']");
        public static By AppleOption = By.XPath(".//a[@title='Apple']");
        public static By iPhoneOption = By.XPath(".//*[@class='yHn1qE' and text() = 'iPhone']");
        public static By LowToHighRangeBtn = By.XPath(".//li[text()='Price -- Low to High']");
        public static By NextBtn = By.XPath("//span[text()='Next']");
        public static By TotalPages = By.XPath(".//*[@class='_3v8VuN']//span[1]//span[4]");
        public static By ParentDiv = By.XPath(".//*[@class='_3T_wwx']/div");
        public static By NetworkTypeFilter = By.XPath(".//*[text()='Network Type']");
        public static By FourGNetworktypeChkBox = By.XPath(".//*[@class='_1GEhLw' and text()='4G']/../div[@class='_1p7h2j']");

    }
}
