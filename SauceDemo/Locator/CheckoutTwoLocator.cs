using OpenQA.Selenium;
using SauceDemo.SetUp;

namespace SauceDemo.Locator
{
    public class CheckoutTwoLocator
    {
        private IWebDriver chromeDriver;
        public CheckoutTwoLocator(IWebDriver chromeDriver) 
        { 
            this.chromeDriver = chromeDriver;
        }

        public IList<IWebElement> CartItem => chromeDriver.FindElements(By.CssSelector(Selector.CheckoutTwoSelector.div_cartitem));
        public IWebElement FinishButton => chromeDriver.FindElement(By.CssSelector(Selector.CheckoutTwoSelector.btn_finish));
        public IWebElement CheckoutOverviewLabel => chromeDriver.FindElement(By.CssSelector(Selector.CheckoutTwoSelector.span_title));
        public IWebElement QTYLabel => chromeDriver.FindElement(By.CssSelector(Selector.CheckoutTwoSelector.div_cartquantitylabel));
        public IWebElement DescriptionLabel => chromeDriver.FindElement(By.CssSelector(Selector.CheckoutTwoSelector.div_descriptionlabel));
        public IWebElement PaymentInformationLabel => chromeDriver.FindElement(By.XPath(Selector.CheckoutTwoSelector.text_paymentinformation));
        public IWebElement SauceCardLabel => chromeDriver.FindElement(By.XPath(Selector.CheckoutTwoSelector.text_saucecard));
        public IWebElement ShippingInformationLabel => chromeDriver.FindElement(By.XPath(Selector.CheckoutTwoSelector.text_shippinginformation));
        public IWebElement FreePonyExpressDeliveryLabel => chromeDriver.FindElement(By.XPath(Selector.CheckoutTwoSelector.text_freeponyexpress));
        public IWebElement PriceTotalLabel => chromeDriver.FindElement(By.XPath(Selector.CheckoutTwoSelector.text_pricetotal));
        public IWebElement SubtotalLabel => chromeDriver.FindElement(By.CssSelector(Selector.CheckoutTwoSelector.div_subtotallabel));
        public IWebElement TaxLabel => chromeDriver.FindElement(By.CssSelector(Selector.CheckoutTwoSelector.div_taxlabel));
        public IWebElement TotalLabel => chromeDriver.FindElement(By.CssSelector(Selector.CheckoutTwoSelector.div_totallabel));
        public IWebElement CancelButton => chromeDriver.FindElement(By.CssSelector(Selector.CheckoutTwoSelector.btn_cancel));
    }
}
