using OpenQA.Selenium;
using SauceDemo.Locator;
using System.Collections.ObjectModel;

namespace SauceDemo.Screen
{
    public class CartScreen
    {
        private IWebDriver chromeDriver;
        private CartLocator cartLocator;

        public CartScreen(IWebDriver chromeDriver, CartLocator cartLocator)
        {
            this.chromeDriver = chromeDriver;
            this.cartLocator = cartLocator;
        }

        // GET CART TITLE IS DISPLAYED
        public bool YourCartDisplayed()
        {
            return cartLocator.YourCart.Displayed;
        }

        // GET QTY LABEL IS DISPLAYED
        public bool QTYLabelDisplayed()
        {
            return cartLocator.QTYLabel.Displayed;
        }

        // GET ITEM QTY 
        public List<string> ItemQTY()
        {
            List<string> itemQTY = new List<string>();

            foreach (IWebElement item in cartLocator.CartItem)
            {
                string itemqty = item.FindElement(By.CssSelector(Selector.CartSelector.div_cartquantity)).Text;
                itemQTY.Add(itemqty);
            }

            return itemQTY;
        }

        // GET DESCRIPTION LABEL IS DISPLAYED
        public bool DescriptionLabelDisplayed()
        {
            return cartLocator.DescriptionLabel.Displayed;
        }

        // GET ITEM NAME DISPLAYED
        public List<bool> ItemNameDisplayed()
        {
            IList<IWebElement> itemName = cartLocator.CartItem;

            List<bool> nameDisplayed = new List<bool>();

            foreach(IWebElement item in itemName)
            {
                bool namedisplayed = item.FindElement(By.CssSelector(Selector.CartSelector.div_itemname)).Displayed;
                nameDisplayed.Add(namedisplayed);
            }

            return nameDisplayed;
        }

        // GET ITEM TAG NAME
        public List<string> ItemNameTag()
        {
            IList<IWebElement> itemName = cartLocator.CartItem;

            List<string> itemNameTag = new List<string>();

            foreach (IWebElement item in itemName)
            {
                string itemnameTag = item.FindElement(By.XPath(Selector.CartSelector.a_itemname)).TagName;
                itemNameTag.Add(itemnameTag);
            }

            return itemNameTag;
        }

        // GET ITEM DESCRIPTION IS DISPLAYED
        public List<bool> ItemDescriptionDisplayed()
        {
            IList<IWebElement> itemName = cartLocator.CartItem;

            List<bool> itemDescriptionDisplayed = new List<bool>();

            foreach (IWebElement item in itemName)
            {
                bool itemdescriptionDisplayed = item.FindElement(By.CssSelector(Selector.CartSelector.div_itemdescription)).Displayed;
                itemDescriptionDisplayed.Add(itemdescriptionDisplayed);
            }

            return itemDescriptionDisplayed;
        }

        // GET ITEM PRICE IS DISPLAYED
        public List<bool> ItemPriceDisplayed()
        {
            IList<IWebElement> itemName = cartLocator.CartItem;

            List<bool> itemPriceDisplayed = new List<bool>();

            foreach (IWebElement item in itemName)
            {
                bool itempriceDisplayed = item.FindElement(By.CssSelector(Selector.CartSelector.div_itemprice)).Displayed;
                itemPriceDisplayed.Add(itempriceDisplayed);
            }

            return itemPriceDisplayed;
        }

        // GET CART PRODUCT LIST
        public List<string> ItemList(IList<IWebElement> webElements)
        {
            List<string> productsList = new List<string>();

            foreach (var webElement in webElements)
            {
                string itemName = webElement.FindElement(By.CssSelector(Selector.CartSelector.div_itemname)).Text;
                string itemDescription = webElement.FindElement(By.CssSelector(Selector.CartSelector.div_itemdescription)).Text;
                string itemPrice = webElement.FindElement(By.CssSelector(Selector.CartSelector.div_itemprice)).Text;
                string itemButton = webElement.FindElement(By.CssSelector(Selector.CartSelector.btn_removefromcart)).Text;

                productsList.Add(itemName);
                productsList.Add(itemDescription);
                productsList.Add(itemPrice);
                productsList.Add(itemButton);
            }

            return productsList;
        }

        // REMOVE ALL PRODUCTS FROM CART 
        public void RemoveAllItemsFromCart()
        {
            foreach (IWebElement item in cartLocator.CartItem)
            {
                cartLocator.RemoveFromCartButton.Click();
            }
        }

        // GET CART IS EMPTY 
        public bool CarIsEmpty()
        {
            bool cartisempty;

            try
            {
                IWebElement CartItem = chromeDriver!.FindElement(By.CssSelector(Selector.CartSelector.div_cartitem));
                cartisempty = false;
            }

            catch (NoSuchElementException)
            {
                cartisempty = true;
            }

            return cartisempty;
        }

        // NAVIGATE TO INVENTORY SCREEN 
        public void NavigateToInventoryScreen()
        {
            cartLocator.ContinueShoppingButton.Click();
        }

        // NAVIGATE TO CHECKOUT SCREEN 
        public void NavigateToCheckoutOneScreen()
        {
            cartLocator.CheckoutButton.Click();
        }

        // GET CONTINUE SHOPPING BUTTON IS DISPLAYED
        public bool ContinueShoppingButtonDisplayed()
        {
            return cartLocator.ContinueShoppingButton.Displayed;
        }

        // GET CHECKOUT BUTTON IS DISPLAYED
        public bool CheckoutButtonDisplayed()
        {
            return cartLocator.CheckoutButton.Displayed;
        }
    }
}