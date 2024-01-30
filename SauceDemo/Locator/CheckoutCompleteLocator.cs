using OpenQA.Selenium;

namespace SauceDemo.Locator
{
    public class CheckoutCompleteLocator
    {
        private IWebDriver chromeDriver;

        public CheckoutCompleteLocator(IWebDriver chromeDriver)
        {
            this.chromeDriver = chromeDriver;
        }

        public IWebElement BackHomeButton => chromeDriver.FindElement(By.CssSelector(Selector.CheckoutCompleteSelector.btn_backhome));
        public IWebElement OrderDispatched => chromeDriver.FindElement(By.CssSelector(Selector.CheckoutCompleteSelector.div_orderdispatched));
        public IWebElement ThankYou => chromeDriver.FindElement(By.CssSelector(Selector.CheckoutCompleteSelector.h2_thankyou));
        public IWebElement PonyExpressImg => chromeDriver.FindElement(By.CssSelector(Selector.CheckoutCompleteSelector.img_ponyexpress));
        public IWebElement CheckoutComplete => chromeDriver.FindElement(By.CssSelector(Selector.CheckoutCompleteSelector.span_checkoutcomplete));
    }
}
