using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SauceDemo.Locator
{
    public class FooterLocator
    {
        private IWebDriver chromeDriver;

        public FooterLocator(IWebDriver chromeDriver)
        {
            this.chromeDriver = chromeDriver;
        }

        public IWebElement FacebookIcon => chromeDriver.FindElement(By.CssSelector(Selector.FooterSelector.icon_facebook));
        public IWebElement LinkedinIcon => chromeDriver.FindElement(By.CssSelector(Selector.FooterSelector.icon_linkedin));
        public IWebElement TwitterIcon => chromeDriver.FindElement(By.CssSelector(Selector.FooterSelector.icon_twitter));
        public IWebElement Copyright => chromeDriver.FindElement(By.CssSelector(Selector.FooterSelector.div_copyright));
    }
}
