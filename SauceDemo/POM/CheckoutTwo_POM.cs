using OpenQA.Selenium;

namespace SauceDemo.POM
{
    public class CheckoutTwo_POM
    {
        private IWebDriver? driver;

        public CheckoutTwo_POM(IWebDriver driver)
        {
            this.driver = driver;
        }

        /* ELEMENTS SELECTORS */
        public string btn_cancel = "button[class=\"btn btn_secondary back btn_medium cart_cancel_link\"]";
        public string btn_finish = "button[class=\"btn btn_action btn_medium cart_button\"]";

        public string div_cartquantity = "div[class=\"cart_quantity\"]";
        public string div_descriptionlabel = "div[class=\"cart_desc_label\"]";
        public string div_subtotallabel = "div[class=\"summary_subtotal_label\"]";
        public string div_taxlabel = "div[class=\"summary_tax_label\"]";
        public string div_totallabel = "div[class=\"summary_info_label summary_total_label\"]";

        public string span_title = "span[class=\"title\"]";

        public string text_freeponyexpress = "//div[text()=\"Free Pony Express Delivery!\"]";
        public string text_paymentinformation = "//div[text()=\"Payment Information\"]";
        public string text_pricetotal = "//div[text()=\"Price Total\"]";
        public string text_saucecard = "//div[text()=\"SauceCard #31337\"]";
        public string text_shippinginformation = "//div[text()=\"Shipping Information\"]";

        string a_itemname = "//div[@class=\"inventory_item_name\"]/ancestor::a";

        string div_cartitem = "div[class=\"cart_item\"]";
        string div_itemdescription = "div[class=\"inventory_item_desc\"]";
        string div_itemname = "div[class=\"inventory_item_name\"]";
        string div_itemprice = "div[class=\"inventory_item_price\"]";



        /* ELEMENTS LOCATORS */
        private IList<IWebElement> CartItem => driver!.FindElements(By.CssSelector(div_cartitem));
        private IWebElement FinishButton => driver!.FindElement(By.CssSelector(btn_finish));

        /* PARAMETERS VALUES */
        double packPrice = 29.99;
        double bikelightPrice = 9.99;
        double bolttshirtPrice = 15.99;
        double fleecejacketPrice = 49.99;
        double onesiePrice = 7.99;
        double shirtredPrice = 15.99;

        double itemTotal = 129.94;
        double taxTotal = 10.40;

        /* GET ELEMENT DISPLAYED */
        public Boolean GetElementDisplayed(By selector)
        {
            return driver!.FindElement(selector).Displayed;
        }

        /* GET ELEMENT TEXT */
        public string GetElementText(By selector)
        {
            return driver!.FindElement(selector).Text;
        }

        /* GET ITEM QTY */
        public List<string> GetItemQTY()
        {
            List<string> itemQTY = new List<string>();

            foreach (IWebElement item in CartItem)
            {
                string itemName = item.FindElement(By.CssSelector(div_itemname)).Text;
                string qtyText = item.FindElement(By.CssSelector(div_cartquantity)).Text;

                itemQTY.Add("Item name: " + itemName);
                itemQTY.Add("Item quantity: " + qtyText);
                itemQTY.Add("");
            }

            return itemQTY;
        }

        /* GET ITEM NAME DISPLAYED */
        public List<string> GetItemNameDisplayed()
        {
            List<string> itemnameDisplayed = new List<string>();

            foreach (IWebElement item in CartItem)
            {
                string itemName = item.FindElement(By.CssSelector(div_itemname)).Text;
                string nameDisplayed = item.FindElement(By.CssSelector(div_itemname)).Displayed.ToString();

                itemnameDisplayed.Add("Item name: " + itemName);
                itemnameDisplayed.Add("Is item name displayed?: " + nameDisplayed);
                itemnameDisplayed.Add("");
            }

            return itemnameDisplayed;
        }

        /* GET ITEM TAG NAME */
        public List<string> GetItemTagName()
        {
            List<string> itemTagname = new List<string>();

            foreach (IWebElement item in CartItem)
            {
                string itemName = item.FindElement(By.CssSelector(div_itemname)).Text;
                string tagName = item.FindElement(By.XPath(a_itemname)).TagName;

                itemTagname.Add("Item name: " + itemName);
                itemTagname.Add("Item element tag: " + tagName);
                itemTagname.Add("");
            }

            return itemTagname;
        }

        /* GET ITEM DESCRTIPTION DISPLAYED */
        public List<string> GetItemDescriptionDisplayed()
        {
            List<string> itemdescriptionDisplayed = new List<string>();

            foreach (IWebElement item in CartItem)
            {
                string itemName = item.FindElement(By.CssSelector(div_itemname)).Text;
                string itemDescription = item.FindElement(By.CssSelector(div_itemdescription)).Text;
                string descriptionDisplayed = item.FindElement(By.CssSelector(div_itemdescription)).Displayed.ToString();

                itemdescriptionDisplayed.Add("Item name: " + itemName);
                itemdescriptionDisplayed.Add("Item description: " + itemDescription);
                itemdescriptionDisplayed.Add("Is item description displayed?: " + descriptionDisplayed);
                itemdescriptionDisplayed.Add("");
            }

            return itemdescriptionDisplayed;
        }

        /* GET ITEM PRICE DISPLAYED */
        public List<string> GetItemPriceDisplayed()
        {
            List<string> itempriceDisplayed = new List<string>();

            foreach (IWebElement item in CartItem)
            {
                string itemName = item.FindElement(By.CssSelector(div_itemname)).Text;
                string itemPrice = item.FindElement(By.CssSelector(div_itemprice)).Text;
                string priceDisplayed = item.FindElement(By.CssSelector(div_itemprice)).Displayed.ToString();

                itempriceDisplayed.Add("Item name: " + itemName);
                itempriceDisplayed.Add("Item price: " + itemPrice);
                itempriceDisplayed.Add("Is item price displayed?: " + priceDisplayed);
                itempriceDisplayed.Add("");
            }

            return itempriceDisplayed;
        }

        /* GET ITEMS SUM */
        public string GetItemsSum()
        {
            double sum = packPrice + bikelightPrice + bolttshirtPrice + fleecejacketPrice + onesiePrice + shirtredPrice;
            string result = sum.ToString();
            return result;
        }

        /* GET ITEM TOTAL & TAX SUM */
        public string GetItemTotalAndTaxSum()
        {
            double sum = itemTotal + taxTotal;
            string result = "Total: $" + sum.ToString();
            return result;
        }

        /* CLICK ELEMENT */
        public void ClickElement(By selector)
        {
            driver!.FindElement(selector).Click();
        }

        /* GET CHECKOUT COMPLETE SCREEN URL */
        public string GetCheckoutCompleteScreenUrl()
        {
            FinishButton.Click();
            string screenurl = driver!.Url;
            return screenurl;
        }

        /* NAVIGATE TO CHECKOUT COMPLETE SCREEN */
        public void NavigateToCheckoutCompleteScreen()
        {
            FinishButton.Click();
        }
    }
}