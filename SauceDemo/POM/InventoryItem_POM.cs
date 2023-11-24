using OpenQA.Selenium;

namespace SauceDemo.POM
{
    public class InventoryItem_POM
    {
        private IWebDriver? driver;

        public InventoryItem_POM(IWebDriver driver)
        {
            this.driver = driver;
        }

        /* ELEMENTS SELECTORS */
        public string btn_backtoproducts = "button[id=\"back-to-products\"]";
        public string btn_addtocart = "button[class=\"btn btn_primary btn_small btn_inventory\"]";
        public string btn_removefromcart = "button[class=\"btn btn_secondary btn_small btn_inventory\"]";

        string div_detailsdescription = "div[class=\"inventory_details_desc large_size\"]";
        string div_detailsname = "div[class=\"inventory_details_name large_size\"]";
        string div_detailsprice = "div[class=\"inventory_details_price\"]";
        string div_item = "div[class=\"inventory_item\"]";
        string div_itemname = "div[class=\"inventory_item_name \"]";

        string img_detailsimage = "img[class=\"inventory_details_img\"]";

        /* ELEMENTS LOCATORS */
        private IWebElement AddToCartButton => driver!.FindElement(By.CssSelector(btn_addtocart));
        private IWebElement RemoveFromCartButton => driver!.FindElement(By.CssSelector(btn_removefromcart));
        private IWebElement BackToProductsButton => driver!.FindElement(By.CssSelector(btn_backtoproducts));
        private IList<IWebElement> InventoryItem => driver!.FindElements(By.CssSelector(div_item));
        private IWebElement InventoryDetailsDescription => driver!.FindElement(By.CssSelector(div_detailsdescription));
        private IWebElement InventoryDetailsImage => driver!.FindElement(By.CssSelector(img_detailsimage));
        private IWebElement InventoryDetailsName => driver!.FindElement(By.CssSelector(div_detailsname));
        private IWebElement InventoryDetailsPrice => driver!.FindElement(By.CssSelector(div_detailsprice));

        /* GET ITEM NAME */
        public List<string> GetItemName()
        {
            List<string> itemName = new List<string>();

            foreach (IWebElement item in InventoryItem)
            {
                string itemname = item.FindElement(By.CssSelector(div_itemname)).Text;
                itemName.Add(itemname);
            }

            return itemName;
        }

        /* GET BUTTON IS DISPLAYED */
        public List<string> GetButtonDisplayed(List<string> itemName, By selector)
        {
            List<string> buttonDisplayed = new List<string>();

            foreach (string item in itemName)
            {
                /* NAVIGATE TO ITEM DETAILS SCREEN */
                IWebElement Itemname = driver!.FindElement(By.LinkText(item));
                Itemname.Click();

                /* GET BACK TO PRODUCTS BUTTON DISPLAYED ON EACH PRODUCT DETAILS SCREEN */
                string itemname = InventoryDetailsName.Text;
                string buttonname = driver.FindElement(selector).Text;
                string buttondisplayed = driver.FindElement(selector).Displayed.ToString();

                /* RESULTS */
                buttonDisplayed.Add("Item details screen: " + itemname);
                buttonDisplayed.Add("Button text: " + buttonname);
                buttonDisplayed.Add("Is button displayed?: " + buttondisplayed);
                buttonDisplayed.Add("");

                /* GO BACK TO PRODUCTS */
                BackToProductsButton.Click();
            }

            return buttonDisplayed;
        }

        /* GET ITEM URL REDIRECTION */
        public List<string> GetItemUrlRedirection(List<string> itemName)
        {
            List<string> itemUrl = new List<string>();

            foreach (string item in itemName)
            {
                IWebElement Itemname = driver!.FindElement(By.LinkText(item));
                Itemname.Click();

                BackToProductsButton.Click();
                string screenUrl = driver!.Url;

                itemUrl.Add("Item details screen: " + item);
                itemUrl.Add("Back to products link redirects to: " + screenUrl);
                itemUrl.Add("");
            }

            return itemUrl;
        }

        /* GET ITEM IMG DISPLAYED */
        public List<string> GetItemImgDisplayed(List<string> itemName)
        {
            List<string> itemimageDisplayed = new List<string>();

            foreach (string item in itemName)
            {
                IWebElement Itemname = driver!.FindElement(By.LinkText(item));
                Itemname.Click();

                string itemname = InventoryDetailsName.Text;
                string imageDisplayed = InventoryDetailsImage.Displayed.ToString();
                string imageSrc = InventoryDetailsImage.GetAttribute("src");

                itemimageDisplayed.Add("Item details screen: " + itemname);
                itemimageDisplayed.Add("src: " + imageSrc);
                itemimageDisplayed.Add("Is item image displayed?: " + imageDisplayed);
                itemimageDisplayed.Add("");

                BackToProductsButton.Click();
            }

            return itemimageDisplayed;
        }

        /* GET ITEM NAME DISPLAYED */
        public List<string> GetItemNameDisplayed(List<string> itemName)
        {
            List<string> itemnameDisplayed = new List<string>();

            foreach (string item in itemName)
            {
                IWebElement Itemname = driver!.FindElement(By.LinkText(item));
                Itemname.Click();

                string itemname = InventoryDetailsName.Text;
                string nameDisplayed = InventoryDetailsName.Displayed.ToString();

                itemnameDisplayed.Add("Item details screen: " + itemname);
                itemnameDisplayed.Add("Is item name displayed?: " + nameDisplayed);
                itemnameDisplayed.Add("");

                BackToProductsButton.Click();
            }

            return itemnameDisplayed;
        }

        /* GET ITEM DESCRIPTION DISPLAYED */
        public List<string> GetItemDescriptionDisplayed(List<string> itemName)
        {
            List<string> itemdescriptionDisplayed = new List<string>();

            foreach (string item in itemName)
            {
                IWebElement Itemname = driver!.FindElement(By.LinkText(item));
                Itemname.Click();

                string itemname = InventoryDetailsName.Text;
                string itemDescription = InventoryDetailsDescription.Text;
                string descriptionDisplayed = InventoryDetailsDescription.Displayed.ToString();

                itemdescriptionDisplayed.Add("Item details screen: " + itemname);
                itemdescriptionDisplayed.Add("Item description: " + itemDescription);
                itemdescriptionDisplayed.Add("Is item description displayed?: " + descriptionDisplayed);
                itemdescriptionDisplayed.Add("");

                BackToProductsButton.Click();
            }

            return itemdescriptionDisplayed;
        }

        /* GET ITEM PRICE DISPLAYED */
        public List<string> GetItemPriceDisplayed(List<string> itemName)
        {
            List<string> itempriceDisplayed = new List<string>();

            foreach (string item in itemName)
            {
                IWebElement Itemname = driver!.FindElement(By.LinkText(item));
                Itemname.Click();

                string itemname = InventoryDetailsName.Text;
                string itemDescription = InventoryDetailsPrice.Text;
                string priceDisplayed = InventoryDetailsPrice.Displayed.ToString();

                itempriceDisplayed.Add("Item details screen: " + itemname);
                itempriceDisplayed.Add("Item price: " + itemDescription);
                itempriceDisplayed.Add("Is item price displayed?: " + priceDisplayed);
                itempriceDisplayed.Add("");

                BackToProductsButton.Click();
            }

            return itempriceDisplayed;
        }

        /* ADD ITEM TO CART */
        public void AddItemToCart(List<string> itemName)
        {
            foreach (string item in itemName)
            {
                driver!.FindElement(By.LinkText(item)).Click();
                AddToCartButton.Click();
                BackToProductsButton.Click();
            }
        }

        /* REMOVE ITEM FROM CART */
        public void RemoveItemFromCart(List<string> itemName)
        {
            foreach (string item in itemName)
            {
                driver!.FindElement(By.LinkText(item)).Click();
                RemoveFromCartButton.Click();
                BackToProductsButton.Click();
            }
        }
    }
}