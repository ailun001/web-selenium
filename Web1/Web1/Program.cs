
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

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

            webDriver.Quit();
        }
    }
}