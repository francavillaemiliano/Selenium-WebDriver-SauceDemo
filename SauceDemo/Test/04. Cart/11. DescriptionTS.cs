using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using SauceDemo.Locator;
using SauceDemo.Screen;

namespace SauceDemo.Tests.Cart
{
    [TestFixture]
    public class Scenario_11
    {
        IWebDriver chromeDriver;

        Locator.LoginLocator loginLocator;
        Locator.CartLocator cartLocator;
        Locator.InventoryItemLocator inventoryItemLocator;
        Locator.ItemDetailsLocator itemDetailsLocator;
        Locator.NavigationBarLocator navigationBarLocator;

        Screen.LoginScreen loginScreen;
        Screen.CartScreen cartScreen;
        Screen.InventoryItemScreen inventoryItemScreen;
        Component.NavigationBarComponent navigationBarComponent;

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

            // ADD TO CART ALL PRODUCTS 
            inventoryItemLocator = new InventoryItemLocator(chromeDriver);
            itemDetailsLocator = new ItemDetailsLocator(chromeDriver);
            inventoryItemScreen = new InventoryItemScreen(chromeDriver, inventoryItemLocator, itemDetailsLocator);
            inventoryItemScreen.AddAllItemsToCart();

            // NAVIGATE TO CART SCREEN 
            navigationBarLocator = new Locator.NavigationBarLocator(chromeDriver);
            navigationBarComponent = new Component.NavigationBarComponent(chromeDriver, navigationBarLocator);
            navigationBarComponent.NavigateToCartScreen();

            cartLocator = new Locator.CartLocator(chromeDriver);
            cartScreen = new Screen.CartScreen(chromeDriver, cartLocator);
        }

        [Test, Order(1)]
        [Category("Cart Screen | Description label is displayed")]
        public void TestCase_1101()
        {
            // GET DESCRIPTION LABEL IS DISPLAYED 
            bool descriptionlabelDisplayed = cartScreen.DescriptionLabelDisplayed();

            // ASSERTION DESCRIPTION LABEL IS DISPLAYED 
            Assert.IsTrue(descriptionlabelDisplayed);
        }
        
        [Test, Order(2)]
        [Category("CartScreen Screen | Description contains item name")]
        public void TestCase_1102()
        {
            // GET ITEM NAME IS DISPLAYED 
            List<bool> itemnameDisplayed = cartScreen.ItemNameDisplayed();

            // ASSERTION ITEM NAME IS DISPLAYED
            Assert.IsTrue(itemnameDisplayed.All(item => item));
        }

        [Test, Order(3)]
        [Category("CartScreen Screen | Description contains item name as link")]
        public void TestCase_1103()
        {
            // GET ITEM TAG NAME 
            List<string> itemNameTag = cartScreen.ItemNameTag();

            // EXPECTED RESULT
            string expectedresult = Expected.CartExpected.itemNameTag;

            // ASSERTION ITEM TAG NAME
            Assert.IsTrue(itemNameTag.All(item => item == expectedresult));
        }

        [Test, Order(4)]
        [Category("CartScreen Screen | Description contains item description")]
        public void TestCase_1104()
        {
            // GET ITEM DESCRIPTION IS DISPLAYED 
            List<bool> itemdescriptionDisplayed = cartScreen.ItemDescriptionDisplayed();

            // ASSERTION ITEM DESCRIPTION IS DISPLAYED 
            Assert.IsTrue(itemdescriptionDisplayed.All(item => item));
        }

        [Test, Order(5)]
        [Category("CartScreen Screen | Description contains item price")]
        public void TestCase_1105()
        {
            // GET ITEM PRICE IS DISPLAYED 
            List<bool> itempriceDisplayed = cartScreen.ItemPriceDisplayed();

            // ASSERTION ITEM PRICE IS DISPLAYED
            Assert.IsTrue(itempriceDisplayed.All(item => item));
        }

        [Test, Order(6)]
        [Category("CartScreen Screen | Description shows items name, description and price")]
        public void TestCase_1106()
        {
            // GET ITEM NAME, DESCRIPTION AND PRICE
            List<string> cartItem = cartScreen.ItemList(cartLocator.CartItem);

            // EXPECTED RESULT
            List<string> expectedresult = Expected.CartExpected.ItemList();

            // ASSERTION ITEM NAME, DESCRIPTION AND PRICE
            CollectionAssert.AreEqual(expectedresult, cartItem);
        }

        [OneTimeTearDown]
        public void Teardown()
        {
            chromeDriver?.Dispose();
        }
    }
}