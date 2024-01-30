using OpenQA.Selenium;

namespace SauceDemo.Locator
{
    public class CheckoutOneLocator
    {
        private IWebDriver chromeDriver;

        public CheckoutOneLocator (IWebDriver chromeDriver)
        {
            this.chromeDriver = chromeDriver;
        }

        public IWebElement ContinueButton => chromeDriver.FindElement(By.CssSelector(Selector.CheckoutOneSelector.btn_continue));
        public IWebElement RequiredError => chromeDriver.FindElement(By.CssSelector(Selector.CheckoutOneSelector.h3_error));
        public IWebElement FirstName => chromeDriver.FindElement(By.CssSelector(Selector.CheckoutOneSelector.input_firstname));
        public IWebElement LastName => chromeDriver.FindElement(By.CssSelector(Selector.CheckoutOneSelector.input_lastname));
        public IWebElement ZipPostalCode => chromeDriver.FindElement(By.CssSelector(Selector.CheckoutOneSelector.input_postalcode));
        public IWebElement YourInformation => chromeDriver.FindElement(By.CssSelector(Selector.CheckoutOneSelector.span_title));
        public IWebElement CancelButton => chromeDriver.FindElement(By.CssSelector(Selector.CheckoutOneSelector.btn_cancel));
    }
}
