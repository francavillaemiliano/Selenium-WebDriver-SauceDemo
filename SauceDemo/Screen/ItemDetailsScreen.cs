using OpenQA.Selenium;
using SauceDemo.Locator;

namespace SauceDemo.Screen
{
    public class ItemDetailsScreen
    {
        private IWebDriver chromeDriver;
        private ItemDetailsLocator itemDetailsLocator;

        public ItemDetailsScreen(IWebDriver chromeDriver, ItemDetailsLocator itemDetailsLocator)
        {
            this.chromeDriver = chromeDriver;
            this.itemDetailsLocator = itemDetailsLocator;
        }

        // GET ITEM URL REDIRECTION 
        public List<string> InventoryItemUrls(List<string> itemName)
        {
            List<string> itemUrl = new List<string>();

            foreach (string item in itemName)
            {
                IWebElement Itemname = chromeDriver.FindElement(By.LinkText(item));
                Itemname.Click();

                itemDetailsLocator.BackToProductsButton.Click();

                string screenUrl = chromeDriver.Url;
                itemUrl.Add(screenUrl);
            }

            return itemUrl;
        }

        // GET BACK TO PRODUCTS BUTTON IS DISPLAYED
        public List<bool> BackToProductsButtonDisplayed(List<string> itemName)
        {
            List<bool> elementDisplayed = new List<bool>();

            foreach (string item in itemName)
            {
                IWebElement Itemname = chromeDriver!.FindElement(By.LinkText(item));
                Itemname.Click();

                bool buttonDisplayed = itemDetailsLocator.BackToProductsButton.Displayed;
                elementDisplayed.Add(buttonDisplayed);

                itemDetailsLocator.BackToProductsButton.Click();
            }
            return elementDisplayed;
        }

        // GET ITEM IMG IS DISPLAYED
        public List<bool> ItemImgDisplayed(List<string> itemName)
        {
            List<bool> elementDisplayed = new List<bool>();

            foreach (string item in itemName)
            {
                IWebElement Itemname = chromeDriver!.FindElement(By.LinkText(item));
                Itemname.Click();

                bool imageDisplayed = itemDetailsLocator.ItemImage.Displayed;
                elementDisplayed.Add(imageDisplayed);

                itemDetailsLocator.BackToProductsButton.Click();
            }
            return elementDisplayed;
        }

        // GET ITEM NAME IS DISPLAYED
        public List<bool> ItemNameDisplayed(List<string> itemName)
        {
            List<bool> elementDisplayed = new List<bool>();

            foreach (string item in itemName)
            {
                IWebElement Itemname = chromeDriver!.FindElement(By.LinkText(item));
                Itemname.Click();

                bool nameDisplayed = itemDetailsLocator.ItemName.Displayed;
                elementDisplayed.Add(nameDisplayed);

                itemDetailsLocator.BackToProductsButton.Click();
            }
            return elementDisplayed;
        }

        // GET ITEM DESCRIPTION IS DISPLAYED
        public List<bool> ItemDescriptionDisplayed(List<string> itemName)
        {
            List<bool> elementDisplayed = new List<bool>();

            foreach (string item in itemName)
            {
                IWebElement Itemname = chromeDriver!.FindElement(By.LinkText(item));
                Itemname.Click();

                bool desciptionDisplayed = itemDetailsLocator.ItemDescription.Displayed;
                elementDisplayed.Add(desciptionDisplayed);

                itemDetailsLocator.BackToProductsButton.Click();
            }
            return elementDisplayed;
        }

        // GET ITEM PRICE IS DISPLAYED
        public List<bool> ItemPriceDisplayed(List<string> itemName)
        {
            List<bool> elementDisplayed = new List<bool>();

            foreach (string item in itemName)
            {
                IWebElement Itemname = chromeDriver!.FindElement(By.LinkText(item));
                Itemname.Click();

                bool priceDisplayed = itemDetailsLocator.ItemPrice.Displayed;
                elementDisplayed.Add(priceDisplayed);

                itemDetailsLocator.BackToProductsButton.Click();
            }
            return elementDisplayed;
        }

        // GET ADD TO CART BUTTON IS DISPLAYED
        public List<bool> AddToCartButtonDisplayed(List<string> itemName)
        {
            List<bool> elementDisplayed = new List<bool>();

            foreach (string item in itemName)
            {
                IWebElement Itemname = chromeDriver!.FindElement(By.LinkText(item));
                Itemname.Click();

                bool buttonDisplayed = itemDetailsLocator.AddToCartButton.Displayed;
                elementDisplayed.Add(buttonDisplayed);

                itemDetailsLocator.BackToProductsButton.Click();
            }
            return elementDisplayed;
        }

        // GET REMOVE FROM CART BUTTON IS DISPLAYED
        public List<bool> RemoveFromCartButtonDisplayed(List<string> itemName)
        {
            List<bool> elementDisplayed = new List<bool>();

            foreach (string item in itemName)
            {
                IWebElement Itemname = chromeDriver!.FindElement(By.LinkText(item));
                Itemname.Click();

                bool buttonDisplayed = itemDetailsLocator.RemoveFromCartButton.Displayed;
                elementDisplayed.Add(buttonDisplayed);

                itemDetailsLocator.BackToProductsButton.Click();
            }
            return elementDisplayed;
        }

        // GET BACK TO PRODUCTS BUTTON TEXT
        public List<string> BackToProductsText(List<string> itemName)
        {
            List<string> itemUrl = new List<string>();

            foreach (string item in itemName)
            {
                IWebElement Itemname = chromeDriver.FindElement(By.LinkText(item));
                Itemname.Click();

                string backtoproductsText = itemDetailsLocator.BackToProductsButton.Text;
                itemUrl.Add(backtoproductsText);

                itemDetailsLocator.BackToProductsButton.Click();
            }

            return itemUrl;
        }
    }
}