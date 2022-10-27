
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using OpenQA.Selenium.Support.UI.ExpectedConditions;
using static System.Net.WebRequestMethods;

namespace Web1
{
    class Program
    {
        static void Main(string[] args)
        {
            IWebDriver webDriver = new ChromeDriver();

            webDriver.Url = "http://www.google.co.nz";

            string title = webDriver.Title;
            Console.WriteLine("Title is "+ title);
            string pageSource = webDriver.PageSource;
            int pageSourceLength = pageSource.Length;
            Console.WriteLine("length of page source is "+ pageSourceLength);

            webDriver.FindElement(By.LinkText("Gmail")).Click();
            webDriver.Navigate().Back();
            webDriver.Navigate().Forward();
            webDriver.Navigate().Refresh();

            webDriver.Navigate().Back();
            IWebElement searchInput = webDriver.FindElement(By.Name("q"));
            searchInput.SendKeys("facebook");
            searchInput.Clear();


            //Web2

            webDriver.SwitchTo().NewWindow(WindowType.Tab);
            webDriver.Url = "http://106.15.238.71/testpage1.html";

            //name 
            webDriver.FindElement(By.Name("submit")).Submit();
            //tagname
            IWebElement elementSubmit = webDriver.FindElement(By.TagName("button"));
            elementSubmit.Submit();
            //linktext
            webDriver.FindElement(By.LinkText("Link Test")).Click();
            webDriver.Navigate().Back();
            //partial linktext
            webDriver.FindElement(By.PartialLinkText("Partial")).Click();
            webDriver.Navigate().Back();
            //XPath (copy full Xpath)
            webDriver.FindElement(By.XPath("/html/body/form/fieldset/div[14]/div/button")).Click();

            //mutiple (2 choose 1) 
            IList<IWebElement> elementsSex = webDriver.FindElements(By.Name("sex"));
            bool femaleSelected = elementsSex.ElementAt(1).Selected;
            if (femaleSelected)
            {
                elementsSex.ElementAt(0).Click();// male selected
                Console.WriteLine("male selected");
            }
            else 
            { 
                elementsSex.ElementAt(1).Click(); //female selected
            }
            //mutiple (++ choose 1)
            webDriver.FindElement(By.Id("exp-3")).Click(); // exp : 4 selected

            //mtiple (checkbox)
            IList<IWebElement> elementsPro = webDriver.FindElements(By.Name("profession"));
            for (int i = 0; i < elementsPro.Count; i++)
            {
                if(elementsPro.ElementAt(i).GetAttribute("value").Equals("Automation Tester"))
                {
                    elementsPro.ElementAt(i).Click();
                    Console.WriteLine("aut selected");
                    //break;
                    // aut selected
                }
            }

            //css selector
            webDriver.FindElement(By.CssSelector("#tool-1")).Click(); 
            Console.WriteLine("selenium ide selected");

            //select selector (dropdown)
            SelectElement selectElementContinents = new SelectElement(webDriver.FindElement(By.Id("continents")));
            selectElementContinents.SelectByText("Australia");
            Console.WriteLine("au selected");
            selectElementContinents.SelectByIndex(1);//europe 

            for (int i = 0; i < selectElementContinents.Options.Count; i++)
            {
                if (selectElementContinents.Options.ElementAt(i).Equals("Antartica"))
                {
                    selectElementContinents.SelectByIndex(i);// last (antartica)
                }
            }

            //select selector mutiple
            SelectElement selectElementCommand = new SelectElement(webDriver.FindElement(By.Name("selenium_commands"));
            selectElementCommand.SelectByIndex(0);
            selectElementCommand.DeselectByIndex(0);
            selectElementCommand.SelectByText("Switch Commands");
            selectElementCommand.DeselectByText("Switch Commands");
            for (int i = 0; i < selectElementCommand.Options.Count; i++)
            {
                selectElementCommand.SelectByIndex(i);
            }
            selectElementCommand.DeselectAll();


            /*Web 3
            <table>
                <tr>
                    <td>table role</td>
                    <td>
                        <table>
                            <tr><td>t2 r1</tr></td>
                            <tr><td>t2 r2</tr></td>
                        </table>
                    </td>
                </tr>
            </table>
            */

            //var table1 = webDriver.FindElement(By.TagName("table"));
            //var table2 = table1.FindElement(By.TagName("table"));
            //var row1 = table2.FindElements(By.TagName("td"))[0];

            //wait
            //隐
            webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            Thread.Sleep(10000);
            //显
            WebDriverWait wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(10));
            IWebElement result = wait.Until(element => element.FindElement(By.Id("")));
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("")));
            result.Click();




            webDriver.Quit();
        }
    }
}