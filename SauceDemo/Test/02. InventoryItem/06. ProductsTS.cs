using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SauceDemo.Tests.Inventory
{
    [TestFixture]
    public class Scenario_06
    {
        IWebDriver chromeDriver;

        Locator.InventoryItemLocator inventoryItemLocator;
        Locator.ItemDetailsLocator itemDetailsLocator;
        Locator.LoginLocator loginLocator;

        Screen.InventoryItemScreen inventoryItemScreen;
        Screen.LoginScreen loginScreen;


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

            inventoryItemLocator = new Locator.InventoryItemLocator(chromeDriver);
            itemDetailsLocator = new Locator.ItemDetailsLocator(chromeDriver);
            inventoryItemScreen = new Screen.InventoryItemScreen(chromeDriver, inventoryItemLocator, itemDetailsLocator);
        }

        [Test, Order(1)]
        [Category("Inventory Item Screen | Title is displayed")]
        public void TestCase_0601()
        {
            // GET TITLE IS DISPLAYED 
            bool titleDisplayed = inventoryItemScreen.titleDisplayed();

            // ASSERTION TITLE IS DISPLAYED
            Assert.IsTrue(titleDisplayed);
        }

        [Test, Order(2)]
        [Category("Inventory Item Screen | Product image is displayed")]
        public void TestCase_0602()
        {
            // GET ITEM IMAGE IS DISPLAYED 
            List<bool> itemimageDisplayed = inventoryItemScreen.ProductImageDisplayed();

            // ASSERTION ITEM IMAGE IS DISPLAYED 
            Assert.IsTrue(itemimageDisplayed.All(Product => Product));
        }

        [Test, Order(3)]
        [Category("Inventory Item Screen | Product name is displayed")]
        public void TestCase_0603()
        {
            // GET ITEM NAME IS DISPLAYED 
            List<bool> itemnameDisplayed = inventoryItemScreen.ProductNameDisplayed();

            // ASSERTION ITEM NAME IS DISPLAYED 
            Assert.IsTrue(itemnameDisplayed.All(Product => Product));
        }


        [Test, Order(4)]
        [Category("Inventory Item Screen | Product tag name is a")]
        public void TestCase_0604()
        {
            // GET ITEM TAG NAME
            List<string> itemsTagName = inventoryItemScreen.ProductNameTagName();

            // EXPECTED RESULT 
            string expectedresult = Expected.InventoryItemExpected.tagNameLink;

            // ASSERTION ITEM TAG NAME
            Assert.IsTrue(itemsTagName.All(Product => Product == expectedresult));
        }


        [Test, Order(5)]
        [Category("Inventory Item Screen | Product name redirects to Product description screen")]
        public void TestCase_0605()
        {
            // GET ITEM NAME
            List<string> itemsName = inventoryItemScreen.ItemName();

            // GET ITEM URL
            List<string> itemsUrl = inventoryItemScreen.ItemDetailsUrl(itemsName);

            // EXPECTED RESULT 
            List<string> expectedresult = Expected.InventoryItemExpected.itemsUrl();

            // ASSERTION ITEM URL
            CollectionAssert.AreEqual(expectedresult, itemsUrl);
        }


        [Test, Order(6)]
        [Category("Inventory Item Screen | Product description is displayed")]
        public void TestCase_0606()
        {
            // GET ITEM DESCRIPTION IS DISPLAYED 
            List<bool> itemdescriptionDisplayed = inventoryItemScreen.ProductDescriptionDisplayed();

            // ASSERTION ITEM DESCRIPTION IS DISPLAYED 
            Assert.IsTrue(itemdescriptionDisplayed.All(Product => Product));
        }

        [Test, Order(7)]
        [Category("Inventory Item Screen | Product price is displayed")]
        public void TestCase_0607()
        {
            // GET ITEM PRICE IS DISPLAYED 
            List<bool> itempriceDisplayed = inventoryItemScreen.ProductPriceDisplayed();

            // ASSERTION ITEM PRICE IS DISPLAYED
            Assert.IsTrue(itempriceDisplayed.All(Product => Product));
        }

        [Test, Order(8)]
        [Category("Inventory Item Screen | Add To Cart button is displayed")]
        public void TestCase_0608()
        {
            // GET ITEM ADD TO CART BUTTON IS DISPLAYED 
            List<bool> addtocartDisplayed = inventoryItemScreen.AddToCartButtonDisplayed();

            // ASSERTION ITEM ADD TO CART BUTTON IS DISPLAYED
            Assert.IsTrue(addtocartDisplayed.All(Product => Product));
        }

        
        [Test, Order(9)]
        [Category("Inventory Item Screen | Remove from cart button is displayed")]
        public void TestCase_0609()
        {
            // ADD ALL ITEMS TO CART 
            inventoryItemScreen.AddAllItemsToCart();

            // GET REMOVE FROM CART BUTTON IS DISPLAYED 
            List<bool> removefromcartDisplayed = inventoryItemScreen.RemoveFromCartButtonDisplayed();

            // ASSERTION REMOVE FROM CART BUTTON IS DISPLAYED  
            Assert.IsTrue(removefromcartDisplayed.All(Product => Product));
        }

        [OneTimeTearDown]
        public void Teardown()
        {
            chromeDriver?.Dispose();
        }
    }
}