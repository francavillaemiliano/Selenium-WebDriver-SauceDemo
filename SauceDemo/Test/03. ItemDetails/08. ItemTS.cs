using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;

namespace SauceDemo.Tests.InventoryItem
{
    [TestFixture]
    public class Scenario_08
    {
        IWebDriver chromeDriver;

        Locator.InventoryItemLocator inventoryItemLocator;
        Locator.ItemDetailsLocator itemDetailsLocator;
        Locator.LoginLocator loginLocator;

        Screen.InventoryItemScreen inventoryItemScreen;
        Screen.ItemDetailsScreen itemDetailsScreen;
        Screen.LoginScreen loginScreen;

        List<string> itemName;

        [OneTimeSetUp]
        public void Setup()
        {
            // DRIVER SETUP
            chromeDriver = new ChromeDriver();

            SetUp.Driver driver = new SetUp.Driver(chromeDriver);
            driver.DriverSetup();

            // LOGIN USER
            loginLocator = new Locator.LoginLocator(chromeDriver);
            loginScreen = new Screen.LoginScreen(loginLocator);
            loginScreen.LoginStandardUser();

            // GET PRODUCT NAME
            inventoryItemLocator = new Locator.InventoryItemLocator(chromeDriver);
            itemDetailsLocator = new Locator.ItemDetailsLocator(chromeDriver);
            inventoryItemScreen = new Screen.InventoryItemScreen(chromeDriver, inventoryItemLocator, itemDetailsLocator);
            itemName = inventoryItemScreen.ItemName();

            itemDetailsScreen = new Screen.ItemDetailsScreen(chromeDriver, itemDetailsLocator);
        }

        [Test, Order(1)]
        [Category("Item Details Screen | Item image is displayed")]
        public void TestCase_0801()
        {
            // GET INVENTORY ITEM IMG IS DISPLAYED
            List<bool> itemimgDisplayed = itemDetailsScreen.ItemImgDisplayed(itemName);

            // ASSERTION INVENTORY ITEM IMG IS DISPLAYED
            Assert.IsTrue(itemimgDisplayed.All(item => item));
        }

        [Test, Order(2)]
        [Category("Item Details Screen | Item name is displayed")]
        public void TestCase_0802()
        {
            // GET ITEM NAME IS DISPLAYED 
            List<bool> itemnameDisplayed = itemDetailsScreen.ItemNameDisplayed(itemName);

            // ASSERTION ITEM NAME IS DISPLAYED
            Assert.IsTrue(itemnameDisplayed.All(item => item));
        }

        [Test, Order(3)]
        [Category("Item Details Screen | Item description is displayed")]
        public void TestCase_0803()
        {
            // GET ITEM DESCRIPTION IS DISPLAYED 
            List<bool> itemdescriptionDisplayed = itemDetailsScreen.ItemDescriptionDisplayed(itemName);

            // ASSERTION ITEM DESCRIPTION IS DISPLAYED
            Assert.IsTrue(itemdescriptionDisplayed.All(item => item));
        }


        [Test, Order(4)]
        [Category("Item Details Screen | Item price is displayed")]
        public void TestCase_0804()
        {
            // GET ITEM PRICE IS DISPLAYED 
            List<bool> itempriceDisplayed = itemDetailsScreen.ItemPriceDisplayed(itemName);

            // ASSERTION ITEM PRICE IS DISPLAYED
            Assert.IsTrue(itempriceDisplayed.All(item => item));
        }

        [Test, Order(5)]
        [Category("Item Details Screen | Add to cart button is displayed")]
        public void TestCase_0805()
        {
            // GET ADD TO CART BUTTON IS DISPLAYED 
            List<bool> addtocartDisplayed = itemDetailsScreen.AddToCartButtonDisplayed(itemName);

            // ASSERTION ADD TO CART BUTTON IS DISPLAYED
            Assert.IsTrue(addtocartDisplayed.All(item => item));
        }

        [Test, Order(6)]
        [Category("Item Details Screen | Remove from cart button is displayed")]
        public void TestCase_0806()
        {
            // ADD ITEMS TO CART 
            inventoryItemScreen.AddAllItemsToCart();

            // GET REMOVE FROM CART BUTTON IS DISPLAYED 
            List<bool> removefromcartDisplayed = itemDetailsScreen.RemoveFromCartButtonDisplayed(itemName);

            // ASSERTION REMOVE FROM CART BUTTON IS DISPLAYED 
            Assert.IsTrue(removefromcartDisplayed.All(item => item));
        }

        [OneTimeTearDown]
        public void Teardown()
        {
            chromeDriver?.Dispose();
        }
    }
}