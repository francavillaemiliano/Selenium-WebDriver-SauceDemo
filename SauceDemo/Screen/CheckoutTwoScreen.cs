using OpenQA.Selenium;
using SauceDemo.Locator;

namespace SauceDemo.Screen
{
    public class CheckoutTwoScreen
    {
        private CheckoutTwoLocator checkoutTwoLocator;

        public CheckoutTwoScreen(CheckoutTwoLocator checkoutTwoLocator)
        {
            this.checkoutTwoLocator = checkoutTwoLocator;
        }

        // GET CHECKOUT: OVERVIEW IS DISPLAYED 
        public bool CheckoutOverviewDisplayed()
        {
            return checkoutTwoLocator.CheckoutOverviewLabel.Displayed;
        }

        // GET QTY LABEL IS DISPLAYED
        public bool QTYLabelDisplayed()
        {
            return checkoutTwoLocator.QTYLabel.Displayed;
        }

        // GET ITEM QTY
        public List<string> ItemQTY()
        {
            List<string> itemQTY = new List<string>();

            foreach (IWebElement item in checkoutTwoLocator.CartItem)
            {
                string qtyText = item.FindElement(By.CssSelector(Selector.CheckoutTwoSelector.div_cartquantity)).Text;
                itemQTY.Add(qtyText);
            }

            return itemQTY;
        }

        // GET DESCRIPTION LABEL DISPLAYED
        public bool DescriptionLabelDisplayed()
        {
            return checkoutTwoLocator.DescriptionLabel.Displayed;
        }

        // GET ITEM NAME DISPLAYED 
        public List<bool> ItemNameDisplayed()
        {
            List<bool> itemnameDisplayed = new List<bool>();

            foreach (IWebElement item in checkoutTwoLocator.CartItem)
            {
                bool nameDisplayed = item.FindElement(By.CssSelector(Selector.CheckoutTwoSelector.div_itemname)).Displayed;
                itemnameDisplayed.Add(nameDisplayed);
            }

            return itemnameDisplayed;
        }

        // GET ITEM TAG NAME 
        public List<string> ItemTagName()
        {
            List<string> itemTagname = new List<string>();

            foreach (IWebElement item in checkoutTwoLocator.CartItem)
            {
                string tagName = item.FindElement(By.XPath(Selector.CheckoutTwoSelector.a_itemname)).TagName;
                itemTagname.Add(tagName);
            }

            return itemTagname;
        }

        // GET ITEM DESCRTIPTION DISPLAYED 
        public List<bool> ItemDescriptionDisplayed()
        {
            List<bool> itemdescriptionDisplayed = new List<bool>();

            foreach (IWebElement item in checkoutTwoLocator.CartItem)
            {
                bool descriptionDisplayed = item.FindElement(By.CssSelector(Selector.CheckoutTwoSelector.div_itemdescription)).Displayed;
                itemdescriptionDisplayed.Add(descriptionDisplayed);
            }

            return itemdescriptionDisplayed;
        }

        // GET ITEM PRICE DISPLAYED 
        public List<bool> ItemPriceDisplayed()
        {
            List<bool> itempriceDisplayed = new List<bool>();

            foreach (IWebElement item in checkoutTwoLocator.CartItem)
            {
                bool priceDisplayed = item.FindElement(By.CssSelector(Selector.CheckoutTwoSelector.div_itemprice)).Displayed;
                itempriceDisplayed.Add(priceDisplayed);
            }

            return itempriceDisplayed;
        }

        // GET ITEM NAME, DESCRIPTION AND PRICE
        public List<string> ItemList(IList<IWebElement> webElements)
        {
            List<string> productsList = new List<string>();

            foreach (var webElement in webElements)
            {
                string itemName = webElement.FindElement(By.CssSelector(Selector.CartSelector.div_itemname)).Text;
                string itemDescription = webElement.FindElement(By.CssSelector(Selector.CartSelector.div_itemdescription)).Text;
                string itemPrice = webElement.FindElement(By.CssSelector(Selector.CartSelector.div_itemprice)).Text;

                productsList.Add(itemName);
                productsList.Add(itemDescription);
                productsList.Add(itemPrice);
            }

            return productsList;
        }

        // GET PAYMENT INFORMATION IS DISPLAYED
        public bool PaymentInformationDisplayed()
        {
            return checkoutTwoLocator.PaymentInformationLabel.Displayed;
        }

        // GET PAYMENT INFORMATION TEXT
        public string PaymentInformationText()
        {
            return checkoutTwoLocator.PaymentInformationLabel.Text;
        }

        // GET SAUCECARD #31337 IS DISPLAYED
        public bool SauceCardDisplayed()
        {
            return checkoutTwoLocator.SauceCardLabel.Displayed;
        }

        // GET SAUCECARD #31337 TEXT
        public string SauceCardText()
        {
            return checkoutTwoLocator.SauceCardLabel.Text;
        }

        // GET SHIPPING INFORMATION IS DISPLAYED
        public bool ShippingInformationDisplayed()
        {
            return checkoutTwoLocator.ShippingInformationLabel.Displayed;
        }

        // GET SHIPPING INFORMATION LABEL TEXT
        public string ShippingInformationText()
        {
            return checkoutTwoLocator.ShippingInformationLabel.Text;
        }

        // GET FREE PONY EXPRESS DELIVERY IS DISPLAYED
        public bool FreePonyExpressDeliveryDisplayed()
        {
            return checkoutTwoLocator.FreePonyExpressDeliveryLabel.Displayed;
        }

        // GET FREE PONY EXPRESS DELIVERY LABEL TEXT
        public string FreePonyExpressDeliveryText()
        {
            return checkoutTwoLocator.FreePonyExpressDeliveryLabel.Text;
        }

        // GET PRICE TOTAL IS DISPLAYED
        public bool PriceTotalDisplayed()
        {
            return checkoutTwoLocator.PriceTotalLabel.Displayed;
        }

        // GET PRICE TOTAL TEXT
        public string PriceTotalText()
        {
            return checkoutTwoLocator.PriceTotalLabel.Text;
        }

        // GET SUBTOTAL LABEL IS DISPLAYED
        public bool SubtotalLabelDisplayed()
        {
            return checkoutTwoLocator.SubtotalLabel.Displayed;
        }

        // GET SUBTOTAL LABEL TEXT
        public string SubtotalLabelText()
        {
            return checkoutTwoLocator.SubtotalLabel.Text;
        }

        // GET ITEMS SUM 
        public string ItemsSum()
        {
            double sum = Data.Value.packPrice + Data.Value.bikelightPrice + Data.Value.bolttshirtPrice + Data.Value.fleecejacketPrice + Data.Value.onesiePrice + Data.Value.shirtredPrice;
            string result = sum.ToString();
            return result;
        }

        // GET TAX LABEL IS DISPLAYED
        public bool TaxLabelDisplayed()
        {
            return checkoutTwoLocator.TaxLabel.Displayed;
        }

        // GET TAX LABEL TEXT
        public string TaxLabelText()
        {
            return checkoutTwoLocator.TaxLabel.Text;
        }

        // GET TOTAL LABEL IS DISPLAYED
        public bool TotalLabelDisplayed()
        {
            return checkoutTwoLocator.TotalLabel.Displayed;
        }

        // GET TOTAL LABEL TEXT
        public string TotalLabelText()
        {
            return checkoutTwoLocator.TotalLabel.Text;
        }

        // GET CANCEL BUTTON IS DISPLAYED
        public bool CancelButtonDisplayed()
        {
            return checkoutTwoLocator.CancelButton.Displayed;
        }

        // GET CANCEL BUTTON TEXT
        public string CancelButtonText()
        {
            return checkoutTwoLocator.CancelButton.Text;
        }

        // GET FINISH BUTTON IS DISPLAYED
        public bool FinishButtonDisplayed()
        {
            return checkoutTwoLocator.FinishButton.Displayed;
        }

        // GET FINISH BUTTON TEXT
        public string FinishButtonText()
        {
            return checkoutTwoLocator.FinishButton.Text;
        }        

        // NAVIGATE TO CHECKOUT COMPLETE SCREEN
        public void NavigateToCheckoutCompleteScreen()
        {
            checkoutTwoLocator.FinishButton.Click();
        }

        // NAVIGATE TO INVENTORY ITEM SCREEN
        public void NavigateToInventoryItemScreen()
        {
            checkoutTwoLocator.CancelButton.Click();
        }
    }
}