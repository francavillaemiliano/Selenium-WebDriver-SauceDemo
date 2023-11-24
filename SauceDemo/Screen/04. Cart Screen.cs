using OpenQA.Selenium;

public class CartScreen
{
    private IWebDriver? driver;

    public CartScreen (IWebDriver driver)
    {
        this.driver = driver;
    }

    /* ELEMENTS SELECTORS */
    public string btn_checkout = "button[class=\"btn btn_action btn_medium checkout_button \"]";
    public string btn_continueshopping = "button[class=\"btn btn_secondary back btn_medium\"]";
    
    public string div_descriptionlabel = "div[class=\"cart_desc_label\"]";
    public string div_quantitylabel = "div[class=\"cart_quantity_label\"]";
    
    public string span_title = "span[class=\"title\"]";

    string a_itemname = "//div[@class=\"inventory_item_name\"]/ancestor::a";
    string a_shoppingcart = "a[class=\"shopping_cart_link\"]";

    string btn_removefromcart = "button[class=\"btn btn_secondary btn_small cart_button\"]";
    
    string div_cartitem = "div[class=\"cart_item\"]";
    string div_cartquantity = "div[class=\"cart_quantity\"]";

    string div_itemdescription = "div[class=\"inventory_item_desc\"]";
    string div_itemname = "div[class=\"inventory_item_name\"]";
    string div_itemprice = "div[class=\"inventory_item_price\"]";    

    /* ELEMENTS LOCATORS */
    private IList<IWebElement> CartItem => driver!.FindElements(By.CssSelector(div_cartitem));
    private IWebElement CartLink => driver!.FindElement(By.CssSelector(a_shoppingcart));
    private IWebElement CheckoutButton => driver!.FindElement(By.CssSelector(btn_checkout));
    private IWebElement ContinueShoppingButton => driver!.FindElement(By.CssSelector(btn_continueshopping));
    private IWebElement RemoveFromCartButton => driver!.FindElement(By.CssSelector(btn_removefromcart));

    /* NAVIGATE TO CART SCREEN */
    public void NavigateToCartScreen()
    {
        CartLink.Click();
    }

    /* GET ELEMENT DISPLAYED */
    public Boolean GetElementDisplayed(By selector)
    {
        return driver!.FindElement(selector).Displayed;
    }

    /* GET ITEM QTY */
    public List<string> GetItemQTY()
    {
        List<string> itemQTY = new List<string>();

        foreach (IWebElement item in CartItem)
        {
            string itemName = item.FindElement(By.CssSelector(div_itemname)).Text;
            string itemqty = item.FindElement(By.CssSelector(div_cartquantity)).Text;

            itemQTY.Add("Item name: " + itemName);
            itemQTY.Add("Item quantity: " + itemqty);
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

    /* GET ITEM DESCRIPTION DISPLAYED */
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

    /* GET REMOVE FROM CART BUTTON DISPLAYED */
    public List<string> GetRemoveFromCartButtonDisplayed()
    {
        List<string> removefromcartbuttonDisplayed = new List<string>();

        foreach (IWebElement item in CartItem)
        {
            string itemName = item.FindElement(By.CssSelector(div_itemname)).Text;
            string buttonText = item.FindElement(By.CssSelector(btn_removefromcart)).Text;
            string buttonDisplayed = item.FindElement(By.CssSelector(btn_removefromcart)).Displayed.ToString();

            removefromcartbuttonDisplayed.Add("Item name: " + itemName);
            removefromcartbuttonDisplayed.Add("Item button: " + buttonText);
            removefromcartbuttonDisplayed.Add("Is Remove button displayed?: " + buttonDisplayed);
            removefromcartbuttonDisplayed.Add("");
        }

        return removefromcartbuttonDisplayed;
    }

    /* REMOVE ALL PRODUCTS FROM CART */
    public void RemoveAllItemsFromCart()
    {
        foreach (IWebElement item in CartItem)
        {
            RemoveFromCartButton.Click();
        }
    }

    /* GET CART IS EMPTY */
    public Boolean GetCarIsEmpty()
    {
        bool cartisempty;

        try
        {
            IWebElement CartItem = driver!.FindElement(By.CssSelector(div_cartitem));
            cartisempty = false;
        }

        catch (NoSuchElementException)
        {
            cartisempty = true;
        }

        return cartisempty;
    }

    /* NAVIGATE TO INVENTORY SCREEN */
    public void NavigateToInventoryScreen()
    {
        ContinueShoppingButton.Click();
    }

    /* NAVIGATE TO CHECKOUT SCREEN */
    public void NavigateToCheckoutScreen()
    {
        CheckoutButton.Click();
    }
}