using OpenQA.Selenium;

namespace SauceDemo.Locator
{
    public class LoginLocator
    {
        private IWebDriver chromeDriver;

        public LoginLocator(IWebDriver chromeDriver)
        {
            this.chromeDriver = chromeDriver;
        }

        public IWebElement LoginLogo => chromeDriver.FindElement(By.CssSelector(Selector.LoginSelector.div_logoLogin));
        public IWebElement LoginButton => chromeDriver.FindElement(By.CssSelector(Selector.LoginSelector.input_buttonLogin));
        public IWebElement Password => chromeDriver.FindElement(By.CssSelector(Selector.LoginSelector.input_password));
        public IWebElement Username => chromeDriver.FindElement(By.CssSelector(Selector.LoginSelector.input_username));
        public IWebElement LoginErrorMessage => chromeDriver.FindElement(By.CssSelector(Selector.LoginSelector.h3_errorMessage));
    }
}
