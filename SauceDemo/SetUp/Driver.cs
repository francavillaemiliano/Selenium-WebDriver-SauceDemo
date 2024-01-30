using OpenQA.Selenium;

namespace SauceDemo.SetUp
{
    public class Driver
    {
        IWebDriver? ChromeDriver;

        public Driver (IWebDriver chromeDriver)
        {
            this.ChromeDriver = chromeDriver;
        }

        public void DriverSetup()
        {
            ChromeDriver!.Navigate().GoToUrl(Data.Url.baseUrl);
            ChromeDriver!.Manage().Window.FullScreen();
        }
    }
}
