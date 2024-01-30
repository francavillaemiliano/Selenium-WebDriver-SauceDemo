using OpenQA.Selenium;

namespace SauceDemo.Locator
{
    public class InventoryItemLocator
    {
        private IWebDriver chromeDriver;

        public InventoryItemLocator(IWebDriver chromeDriver) 
        { 
            this.chromeDriver = chromeDriver;
        }

        public IWebElement Sorting => chromeDriver.FindElement(By.CssSelector(Selector.InventoryItemSelector.select_sorting));
        public IWebElement ProductsTitle => chromeDriver.FindElement(By.CssSelector(Selector.InventoryItemSelector.span_productstitle));
        public IList<IWebElement> InventoryItem => chromeDriver.FindElements(By.CssSelector(Selector.InventoryItemSelector.div_item));
    }
}
