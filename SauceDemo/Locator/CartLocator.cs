using OpenQA.Selenium;

namespace SauceDemo.Locator
{
    public class CartLocator
    {
        private IWebDriver chromeDriver;

        public CartLocator (IWebDriver chromeDriver)
        {
            this.chromeDriver = chromeDriver;
        }

        public IList<IWebElement> CartItem => chromeDriver.FindElements(By.CssSelector(Selector.CartSelector.div_cartitem));
        public IWebElement CheckoutButton => chromeDriver.FindElement(By.CssSelector(Selector.CartSelector.btn_checkout));
        public IWebElement ContinueShoppingButton => chromeDriver.FindElement(By.CssSelector(Selector.CartSelector.btn_continueshopping));
        public IWebElement RemoveFromCartButton => chromeDriver.FindElement(By.CssSelector(Selector.CartSelector.btn_removefromcart));
        public IWebElement YourCart => chromeDriver.FindElement(By.CssSelector(Selector.CartSelector.span_title));
        public IWebElement QTYLabel => chromeDriver.FindElement(By.CssSelector(Selector.CartSelector.div_quantitylabel));
        public IWebElement DescriptionLabel => chromeDriver.FindElement(By.CssSelector(Selector.CartSelector.div_descriptionlabel));
    }
}
