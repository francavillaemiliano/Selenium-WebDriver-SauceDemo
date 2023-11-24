using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

public class InventoryScreen
{
    private IWebDriver driver;

    public InventoryScreen (IWebDriver driver)
    {
        this.driver = driver;
    }

    /* SORTING VALUES */
    public string nameAtoZ = "az";
    public string nameZtoA = "za";
    
    public string priceLowtoHigh = "lohi";
    public string priceHightoLow = "hilo";

    /* ELEMENTS SELECTORS */
    public string btn_addtocart = "button[class=\"btn btn_primary btn_small btn_inventory \"]";
    public string btn_removefromcart = "button[class=\"btn btn_secondary btn_small btn_inventory \"]";    

    public string div_itemname = "div[class=\"inventory_item_name \"]";

    public string span_title = "span[class=\"title\"]";

    public string select_sorting = "select[class=\"product_sort_container\"]";    

    string a_itemname = "//div[@class=\"inventory_item_name \"]/ancestor::a";

    string btn_backtoproducts = "button[id=\"back-to-products\"]";    

    string div_item = "div[class=\"inventory_item\"]";
    string div_itemdescription = "div[class=\"inventory_item_desc\"]";
    string div_itemprice = "div[class=\"inventory_item_price\"]";

    string img_itemimage = "img[class=\"inventory_item_img\"]";

    /* ELEMENTS LOCATORS */
    private IWebElement BackToProductsButton => driver!.FindElement(By.CssSelector(btn_backtoproducts));
    private IList<IWebElement> InventoryItem => driver!.FindElements(By.CssSelector(div_item));
    private IWebElement Sorting => driver!.FindElement(By.CssSelector(select_sorting));

    /* GET ELEMENT DISPLAYED */
    public Boolean GetElementDisplayed(By selector)
    {
        return driver.FindElement(selector).Displayed;
    }

    /* GET ALL OPTIONS FROM SORTING */
    public List<string> GetAllSortingOptions()
    {
        SelectElement sorting = new SelectElement(Sorting);
        IList<IWebElement> SortingOptions = sorting.Options;

        List<string> sortingOptions = new List<string>();

        foreach (IWebElement option in SortingOptions)
        {
            sortingOptions.Add(option.Text);
        }

        return sortingOptions;
    }

    /* GET SORTING TAG NAME */
    public string GetSortingTagName()
    {
        return Sorting.TagName;
    }

    /* GET SORTING SELECTED OPTION */
    public string GetSortingSelectedOption()
    {
        SelectElement sorting = new SelectElement(Sorting);
        return sorting.SelectedOption.Text;
    }

    /* SELECT SORTING OPTION */
    public void SelectSortingOption(string value)
    {
        SelectElement sorting = new SelectElement(Sorting);
        sorting.SelectByValue(value);
    }

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

    /* GET ITEM PRICE ORDER */
    public List<string> GetItemPriceOrder()
    {
        List<string> itempriceOrder = new List<string>();

        foreach (IWebElement item in InventoryItem)
        {
            string itemName = item.FindElement(By.CssSelector(div_itemname)).Text;
            string itemPrice = item.FindElement(By.CssSelector(div_itemprice)).Text;
            string freespace = "";

            itempriceOrder.Add("Item name: " + itemName);
            itempriceOrder.Add("Item price: " + itemPrice);
            itempriceOrder.Add(freespace);
        }

        return itempriceOrder;
    }

    /* GET ITEM IMAGE DISPLAYED */
    public List<string> GetItemImageDisplayed()
    {
        List<string> itemimageDisplayed = new List<string>();
        
        foreach (IWebElement item in InventoryItem)
        {
            string itemName = item.FindElement(By.CssSelector(div_itemname)).Text;
            string imageSrc = item.FindElement(By.CssSelector(img_itemimage)).GetAttribute("src");
            string imageDisplayed = item.FindElement(By.CssSelector(img_itemimage)).Displayed.ToString();
            string freespace = "";

            itemimageDisplayed.Add("Item name: " + itemName);
            itemimageDisplayed.Add("Item image: " + imageSrc);
            itemimageDisplayed.Add("Is item image displayed?: " + imageDisplayed);
            itemimageDisplayed.Add(freespace);
        }

        return itemimageDisplayed;
    }

    /* GET ITEM NAME DISPLAYED */
    public List<string> GetItemNameDisplayed()
    {
        List<string> itemnameDisplayed = new List<string>();
        
        foreach (IWebElement item in InventoryItem)
        {
            string itemName = item.FindElement(By.CssSelector(div_itemname)).Text;
            string nameDisplayed = item.FindElement(By.CssSelector(div_itemname)).Displayed.ToString();
            string freespace = "";

            itemnameDisplayed.Add("Item name: " + itemName);
            itemnameDisplayed.Add("Is item name displayed?: " + nameDisplayed);
            itemnameDisplayed.Add(freespace);
        }

        return itemnameDisplayed;
    }

    /* GET ITEM TAG NAME */
    public List<string> GetItemTagName()
    {
        List<string> itemTagName = new List<string>();
        
        foreach (IWebElement item in InventoryItem)
        {
            string itemName = item.FindElement(By.CssSelector(div_itemname)).Text;
            string itemTagname = item.FindElement(By.XPath(a_itemname)).TagName;
            string freespace = "";

            itemTagName.Add("Item name: " + itemName);
            itemTagName.Add("Item tag name: " + itemTagname);
            itemTagName.Add(freespace);
        }

        return itemTagName;
    }

    /* GET ITEM URL */
    public List<string> GetItemUrl(List<string> itemName)
    {
        List<string> itemUrl = new List<string>();
        
        foreach (string item in itemName)
        {
            IWebElement Itemname = driver!.FindElement(By.LinkText(item));
            Itemname.Click();

            string itemurl = driver.Url;
            string freespace = "";

            itemUrl.Add("Item name: " + item);
            itemUrl.Add("Item url: " + itemurl);
            itemUrl.Add(freespace);

            BackToProductsButton.Click();
        }

        return itemUrl;
    }

    /* GET ITEM DESCRIPTION DISPLAYED */
    public List<string> GetItemDescriptionDisplayed()
    {
        List<string> itemdescriptionDisplayed = new List<string>();
        
        foreach (IWebElement item in InventoryItem)
        {
            string itemName = item.FindElement(By.CssSelector(div_itemname)).Text;
            string itemDescription = item.FindElement(By.CssSelector(div_itemdescription)).Text;
            string descriptionDisplayed = item.FindElement(By.CssSelector(div_itemdescription)).Displayed.ToString();
            string freespace = "";

            itemdescriptionDisplayed.Add("Item name: " + itemName);
            itemdescriptionDisplayed.Add("Item description: " + itemDescription);
            itemdescriptionDisplayed.Add("Is item description displayed?: " + descriptionDisplayed);
            itemdescriptionDisplayed.Add(freespace);
        }

        return itemdescriptionDisplayed;
    }

    /* GET ITEM PRICE DISPLAYED */
    public List<string> GetItemPriceDisplayed()
    {
        List<string> itempriceDisplayed = new List<string>();

        foreach (IWebElement item in InventoryItem)
        {
            string itemName = item.FindElement(By.CssSelector(div_itemname)).Text;
            string itemPrice = item.FindElement(By.CssSelector(div_itemprice)).Text;
            string priceDisplayed = item.FindElement(By.CssSelector(div_itemprice)).Displayed.ToString();
            string freespace = "";

            itempriceDisplayed.Add("Item name: " + itemName);
            itempriceDisplayed.Add("Item price: " + itemPrice);
            itempriceDisplayed.Add("Is item price displayed?: " + priceDisplayed);
            itempriceDisplayed.Add(freespace);
        }

        return itempriceDisplayed;
    }

    /* GET BUTTON DISPLAYED */
    public List<string> GetButtonDisplayed(By nameselector, By selector)
    {
        List<string> buttonDisplayed = new List<string>();

        foreach (IWebElement item in InventoryItem)
        {
            string itemName = item.FindElement(nameselector).Text;
            string btnText = item.FindElement(selector).Text;
            string btnDisplayed = item.FindElement(selector).Displayed.ToString();
            string freeSpace = "";

            buttonDisplayed.Add("Item name: " + itemName);
            buttonDisplayed.Add("Button text: " + btnText);
            buttonDisplayed.Add("Is button displayed?: " + btnDisplayed);
            buttonDisplayed.Add(freeSpace);
        }

        return buttonDisplayed;
    }

    /* ADD ALL ITEMS TO CART */
    public void AddAllItemsToCart()
    {
        foreach (IWebElement item in InventoryItem)
        {
            item.FindElement(By.CssSelector(btn_addtocart)).Click();            
        }
    }

    /* REMOVE ALL ITEMS FROM CART */
    public void RemoveAllItemsFromCart()
    {
        foreach (IWebElement item in InventoryItem)
        {
            item.FindElement(By.CssSelector(btn_removefromcart)).Click();
        }
    }
}