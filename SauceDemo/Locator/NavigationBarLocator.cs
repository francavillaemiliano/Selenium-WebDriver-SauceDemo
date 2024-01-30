using OpenQA.Selenium;

namespace SauceDemo.Locator
{
    public class NavigationBarLocator
    {
        private IWebDriver chromeDriver;

        public NavigationBarLocator(IWebDriver chromeDriver)
        {
            this.chromeDriver = chromeDriver;
        }

        public IWebElement BurguerMenu => chromeDriver.FindElement(By.CssSelector(Selector.NavigationBarSelector.div_burguermenu));
        public IWebElement BurguerMenuButton => chromeDriver.FindElement(By.CssSelector(Selector.NavigationBarSelector.btn_burguermenu));
        public IWebElement BurguerMenuXButton => chromeDriver.FindElement(By.CssSelector(Selector.NavigationBarSelector.btn_burguermenux));
        public IList<IWebElement> BurguerMenuOptions => chromeDriver.FindElements(By.CssSelector(Selector.NavigationBarSelector.a_burguermenuoptions));
        public IWebElement AllItems => chromeDriver.FindElement(By.CssSelector(Selector.NavigationBarSelector.a_allItems));
        public IWebElement About => chromeDriver.FindElement(By.CssSelector(Selector.NavigationBarSelector.a_about));
        public IWebElement Logout => chromeDriver.FindElement(By.CssSelector(Selector.NavigationBarSelector.a_logout));
        public IWebElement ResetAppState => chromeDriver.FindElement(By.CssSelector(Selector.NavigationBarSelector.a_resetAppState));
        public IWebElement AppLogo => chromeDriver.FindElement(By.CssSelector(Selector.NavigationBarSelector.div_applogo));
        public IWebElement CartIcon => chromeDriver.FindElement(By.CssSelector(Selector.NavigationBarSelector.a_carticon));

    }
}
