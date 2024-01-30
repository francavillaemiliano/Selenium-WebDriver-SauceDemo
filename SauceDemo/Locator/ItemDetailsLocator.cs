using OpenQA.Selenium;

namespace SauceDemo.Locator
{
    public class ItemDetailsLocator
    {
        private IWebDriver chromeDriver;

        public ItemDetailsLocator (IWebDriver chromeDriver)
        {
            this.chromeDriver = chromeDriver;
        }

        public IWebElement BackToProductsButton => chromeDriver.FindElement(By.CssSelector(Selector.ItemDetailsSelector.btn_detailsbacktoproducts));
        public IWebElement ItemImage => chromeDriver.FindElement(By.CssSelector(Selector.ItemDetailsSelector.img_detailsimage));
        public IWebElement ItemName => chromeDriver.FindElement(By.CssSelector(Selector.ItemDetailsSelector.div_detailsname));
        public IWebElement ItemDescription => chromeDriver.FindElement(By.CssSelector(Selector.ItemDetailsSelector.div_detailsdescription));
        public IWebElement ItemPrice => chromeDriver.FindElement(By.CssSelector(Selector.ItemDetailsSelector.div_detailsprice));
        public IWebElement AddToCartButton => chromeDriver.FindElement(By.CssSelector(Selector.ItemDetailsSelector.btn_detailsaddtocart));
        public IWebElement RemoveFromCartButton => chromeDriver.FindElement(By.CssSelector(Selector.ItemDetailsSelector.btn_detailsremovefromcart));
    }
}
