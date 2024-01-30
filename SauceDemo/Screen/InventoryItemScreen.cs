using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SauceDemo.Locator;

namespace SauceDemo.Screen
{
    public class InventoryItemScreen
    {
        private IWebDriver chromeDriver;
        private InventoryItemLocator inventoryItemLocator;
        private ItemDetailsLocator itemDetailsLocator;

        public InventoryItemScreen(IWebDriver chromeDriver, InventoryItemLocator inventoryItemLocator, ItemDetailsLocator itemDetailsLocator)
        {
            this.chromeDriver = chromeDriver;
            this.inventoryItemLocator = inventoryItemLocator;
            this.itemDetailsLocator = itemDetailsLocator;
        }      
        
        // GET SORTING IS DISPLAYED
        public bool SortingDisplayed()
        {
            return inventoryItemLocator.Sorting.Displayed;
        }

        // GET SORTING OPTIONS
        public List<string> SortingOptions()
        {
            SelectElement dropdown = new SelectElement(inventoryItemLocator.Sorting);
            IList<IWebElement> dropdownOptions = dropdown.Options;

            List<string> GetSortingOptions = new List<string>();

            foreach (IWebElement option in dropdownOptions)
            {
                GetSortingOptions.Add(option.Text);
            }

            return GetSortingOptions;
        }

        // GET SORTING TAG NAME
        public string SortingTagName()
        {
            return inventoryItemLocator.Sorting.TagName;
        }

        // SELECT NAME (Z to A) SORTING OPTION
        public void SortByNameZtoA()
        {
            SelectElement sorting = new SelectElement(inventoryItemLocator.Sorting);
            sorting.SelectByValue(Data.Value.nameZtoA);
        }

        // SELECT NAME (A to Z) SORTING OPTION
        public void SortByNameAtoZ()
        {
            SelectElement sorting = new SelectElement(inventoryItemLocator.Sorting);
            sorting.SelectByValue(Data.Value.nameAtoZ);
        }

        // SELECT PRICE (low to high) SORTING OPTION
        public void SortByPriceLowToHigh()
        {
            SelectElement sorting = new SelectElement(inventoryItemLocator.Sorting);
            sorting.SelectByValue(Data.Value.priceLowtoHigh);
        }

        // SELECT PRICE (high to low) SORTING OPTION
        public void SortByPriceHighToLow()
        {
            SelectElement sorting = new SelectElement(inventoryItemLocator.Sorting);
            sorting.SelectByValue(Data.Value.priceHightoLow);
        }

        // GET TITLE IS DISPLAYED
        public bool titleDisplayed()
        {
            return inventoryItemLocator.ProductsTitle.Displayed;
        }

        // GET PRODUCT IMAGE IS DISPLAYED
        public List<bool> ProductImageDisplayed()
        {
            IList<IWebElement> webElements = inventoryItemLocator.InventoryItem;

            List<bool> elementsDisplayed = new List<bool>();

            foreach (var webElement in webElements)
            {
                bool displayed;

                try
                {
                    displayed = webElement.FindElement(By.CssSelector(Selector.InventoryItemSelector.img_itemimage)).Displayed;
                }
                catch (NoSuchElementException)
                {
                    displayed = false;
                }

                elementsDisplayed.Add(displayed);
            }

            return elementsDisplayed;
        }

        // GET PRODUCT NAME IS DISPLAYED
        public List<bool> ProductNameDisplayed()
        {
            IList<IWebElement> webElements = inventoryItemLocator.InventoryItem;

            List<bool> elementsDisplayed = new List<bool>();

            foreach (var webElement in webElements)
            {
                bool displayed;

                try
                {
                    displayed = webElement.FindElement(By.CssSelector(Selector.InventoryItemSelector.div_itemname)).Displayed;
                }
                catch (NoSuchElementException)
                {
                    displayed = false;
                }

                elementsDisplayed.Add(displayed);
            }

            return elementsDisplayed;
        }

        // GET PRODUCT DESCRIPTION IS DISPLAYED
        public List<bool> ProductDescriptionDisplayed()
        {
            IList<IWebElement> webElements = inventoryItemLocator.InventoryItem;

            List<bool> elementsDisplayed = new List<bool>();

            foreach (var webElement in webElements)
            {
                bool displayed;

                try
                {
                    displayed = webElement.FindElement(By.CssSelector(Selector.InventoryItemSelector.div_itemdescription)).Displayed;
                }
                catch (NoSuchElementException)
                {
                    displayed = false;
                }

                elementsDisplayed.Add(displayed);
            }

            return elementsDisplayed;
        }

        // GET PRODUCT PRICE IS DISPLAYED
        public List<bool> ProductPriceDisplayed()
        {
            IList<IWebElement> webElements = inventoryItemLocator.InventoryItem;

            List<bool> elementsDisplayed = new List<bool>();

            foreach (var webElement in webElements)
            {
                bool displayed;

                try
                {
                    displayed = webElement.FindElement(By.CssSelector(Selector.InventoryItemSelector.div_itemprice)).Displayed;
                }
                catch (NoSuchElementException)
                {
                    displayed = false;
                }

                elementsDisplayed.Add(displayed);
            }

            return elementsDisplayed;
        }

        // GET PRODUCT ADD TO CART BUTTON IS DISPLAYED
        public List<bool> AddToCartButtonDisplayed()
        {
            IList<IWebElement> webElements = inventoryItemLocator.InventoryItem;

            List<bool> elementsDisplayed = new List<bool>();

            foreach (var webElement in webElements)
            {
                bool displayed;

                try
                {
                    displayed = webElement.FindElement(By.CssSelector(Selector.InventoryItemSelector.btn_addtocart)).Displayed;
                }
                catch (NoSuchElementException)
                {
                    displayed = false;
                }

                elementsDisplayed.Add(displayed);
            }

            return elementsDisplayed;
        }

        // GET PRODUCT REMOVE FROM CART BUTTON IS DISPLAYED
        public List<bool> RemoveFromCartButtonDisplayed()
        {
            IList<IWebElement> webElements = inventoryItemLocator.InventoryItem;

            List<bool> elementsDisplayed = new List<bool>();

            foreach (var webElement in webElements)
            {
                bool displayed;

                try
                {
                    displayed = webElement.FindElement(By.CssSelector(Selector.InventoryItemSelector.btn_removefromcart)).Displayed;
                }
                catch (NoSuchElementException)
                {
                    displayed = false;
                }

                elementsDisplayed.Add(displayed);
            }

            return elementsDisplayed;
        }

        // GET PRODUCT NAME TAG NAME
        public List<string> ProductNameTagName()
        {
            IList<IWebElement> webElements = inventoryItemLocator.InventoryItem;

            List<string> tagNames = new List<string>();

            foreach (var webElement in webElements)
            {
                tagNames.Add(webElement.FindElement(By.XPath(Selector.InventoryItemSelector.a_itemname)).TagName);
            }

            return tagNames;
        }

        // GET PRODUCTS NAMES
        public List<string> ItemName()
        {
            IList<IWebElement> InventoryItems = inventoryItemLocator.InventoryItem;

            List<string> itemName = new List<string>();

            foreach (IWebElement item in InventoryItems)
            {
                itemName.Add(item.FindElement(By.CssSelector(Selector.InventoryItemSelector.div_itemname)).Text);
            }

            return itemName;
        }

        // ADD ALL ITEMS TO CART 
        public void AddAllItemsToCart()
        {
            IList<IWebElement> inventoryItem = inventoryItemLocator.InventoryItem;

            foreach (IWebElement item in inventoryItem)
            {
                item.FindElement(By.CssSelector(Selector.InventoryItemSelector.btn_addtocart)).Click();
            }
        }

        // REMOVE ALL ITEMS FROM CART 
        public void RemoveAllItemsFromCart()
        {
            IList<IWebElement> inventoryItem = inventoryItemLocator.InventoryItem;

            foreach (IWebElement item in inventoryItem)
            {
                item.FindElement(By.CssSelector(Selector.InventoryItemSelector.btn_removefromcart)).Click();
            }
        }

        // GET SELECTED SORTING OPTION
        public string SelectedSortingOption()
        {
            SelectElement sorting = new SelectElement(inventoryItemLocator.Sorting);
            return sorting.SelectedOption.Text;
        }

        // GET INVENTORY PRODUCT LIST
        public List<string> InventoryItemList()
        {
            IList<IWebElement> webElements = inventoryItemLocator.InventoryItem;

            List<string> productsList = new List<string>();

            foreach (var webElement in webElements)
            {
                string itemName = webElement.FindElement(By.CssSelector(Selector.InventoryItemSelector.div_itemname)).Text;
                string itemDescription = webElement.FindElement(By.CssSelector(Selector.InventoryItemSelector.div_itemdescription)).Text;
                string itemPrice = webElement.FindElement(By.CssSelector(Selector.InventoryItemSelector.div_itemprice)).Text;
                string itemButton;

                try
                {
                    itemButton = webElement.FindElement(By.CssSelector(Selector.InventoryItemSelector.btn_addtocart)).Text;
                }

                catch (NoSuchElementException)
                {
                    itemButton = webElement.FindElement(By.CssSelector(Selector.InventoryItemSelector.btn_removefromcart)).Text;
                }

                productsList.Add(itemName);
                productsList.Add(itemDescription);
                productsList.Add(itemPrice);
                productsList.Add(itemButton);
            }

            return productsList;
        }

        // GET ITEM DETAILS URL
        public List<string> ItemDetailsUrl(List<string> itemName)
        {
            List<string> itemsUrl = new List<string>();

            foreach (string item in itemName)
            {
                IWebElement Itemname = chromeDriver!.FindElement(By.LinkText(item));
                Itemname.Click();

                string itemurl = chromeDriver.Url;
                itemsUrl.Add(itemurl);
                                
                itemDetailsLocator.BackToProductsButton.Click();
            }
            return itemsUrl;
        }
    }
}