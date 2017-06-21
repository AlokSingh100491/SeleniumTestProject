using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SeleniumTestProject.SeleniumBasics
{
    class ExperimentalCodes
    {
        IWebDriver driver = new FirefoxDriver();

        public void Test()
        {
            // Find the checkbox or radio button element by Name
            IList<IWebElement> oCheckBox = driver.FindElements(By.Name("tool"));

            // This will tell you the number of checkboxes are present
            int Size = oCheckBox.Count;

            // Start the loop from first checkbox to last checkboxe
            for (int i = 0; i < Size; i++)
            {
                // Store the checkbox name to the string variable, using 'Value' attribute
                String Value = oCheckBox.ElementAt(i).GetAttribute("value");

                // Select the checkbox it the value of the checkbox is same what you are looking for
                if (Value.Equals("toolsqa"))
                {
                    oCheckBox.ElementAt(i).Click();
                    // This will take the execution out of for loop
                    break;
                }
            }
        }

        public void Wait()
        {
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));
        }

        public void SelectDropDown()
        {

            SelectElement oSelect = new SelectElement(driver.FindElement(By.Id("yy_date_8")));

            oSelect.selectByText("2010");


            //Alternate Way *****************************

            //oSelect = new SelectElement(driver.FindElement(By.Id("yy_date_8")));

            //oSelect.selectByText("2010");

            

            SelectElement oSelect1 = new SelectElement(driver.FindElement(By.Id("yy_date_8")));
            IList<IWebElement> elementCount = oSelect1.Options;
            Console.Write(elementCount.Count);


            SelectElement oSelect2 = new SelectElement(driver.FindElement(By.Id("yy_date_8")));
            IList<IWebElement> elementCount1 = oSelect2.Options;
            Console.Write(elementCount1.Count);

        }


        public void Test1()
        {

            // Create a new instance of the Firefox driver
            IWebDriver driver = new FirefoxDriver();

            // Put an Implicit wait, this means that any search for elements on the page could take the time the implicit wait is set for before throwing exception
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));

            // Launch the URL
            driver.Url = "http://toolsqa.wpengine.com/automation-practice-form";

            // Step 3: Select 'Continents' Drop down ( Use Id to identify the element )
            // Find Select element of "Single selection" using ID locator.
            SelectElement oSelection = new SelectElement(driver.FindElement(By.Id("continents")));

            // Step 4:) Select option 'Europe' (Use selectByIndex)
            oSelection.SelectByText("Europe");

            // Using sleep command so that changes can be notice
            Thread.Sleep(2000);

            // Step 5: Select option 'Africa' now (Use selectByVisibleText)
            oSelection.SelectByIndex(2);
            Thread.Sleep(2000);

            // Step 6: Print all the options for the selected drop down and select one option of your choice
            // Get the size of the Select element
            IList<IWebElement> oSize = oSelection.Options;

            int iListSize = oSize.Count;
            // Setting up the loop to print all the options
            for (int i = 0; i < iListSize; i++)
            {
                // Storing the value of the option	
                String sValue = oSelection.Options.ElementAt(i).Text;
                // Printing the stored value
                Console.WriteLine("Value of the Select item is : " + sValue);

                // Putting a check on each option that if any of the option is equal to 'Africa" then select it 
                if (sValue.Equals("Africa"))
                {
                    oSelection.SelectByIndex(i);
                    break;
                }

            }

            // Kill the browser
            driver.Close();
        }
        public void tableCode()
        {
            // Open the browser for Automation
            IWebDriver driver = new FirefoxDriver();
            driver.Manage().Window.Maximize();

            // WebPage which contains a WebTable
            driver.Navigate().GoToUrl("https://en.wikipedia.org/wiki/Programming_languages_used_in_most_popular_websites");
            driver.Manage().Timeouts().SetPageLoadTimeout(TimeSpan.FromSeconds(30));

            // xpath of html table
            var elemTable = driver.FindElement(By.XPath("//div[@id='mw-content-text']//table[1]"));

            // Fetch all Row of the table
            List<IWebElement> lstTrElem = new List<IWebElement>(elemTable.FindElements(By.TagName("tr")));
            String strRowData = "";

            // Traverse each row
            foreach (var elemTr in lstTrElem)
            {
                // Fetch the columns from a particuler row
                List<IWebElement> lstTdElem = new List<IWebElement>(elemTr.FindElements(By.TagName("td")));
                if (lstTdElem.Count > 0)
                {
                    // Traverse each column
                    foreach (var elemTd in lstTdElem)
                    {
                        // "\t\t" is used for Tab Space between two Text
                        strRowData = strRowData + elemTd.Text + "\t\t";
                    }
                }
                else
                {
                    // To print the data into the console
                    Console.WriteLine("This is Header Row");
                    Console.WriteLine(lstTrElem[0].Text.Replace(" ", "\t\t"));
                }
                Console.WriteLine(strRowData);
                strRowData = String.Empty;
            }
            Console.WriteLine("");
            driver.Quit();
        }
    }

 
}





    internal class SelectElement
    {
        private IWebElement webElement;

        public SelectElement(IWebElement webElement)
        {
            this.webElement = webElement;
        }

        public IList<IWebElement> Options { get; internal set; }

    internal void SelectByIndex(int v)
    {
        throw new NotImplementedException();
    }

    internal void SelectByText(string v)
    {
        throw new NotImplementedException();
    }

    internal void selectByText(string v)
        {
            throw new NotImplementedException();
        }
    }


