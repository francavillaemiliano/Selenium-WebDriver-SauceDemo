using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using SauceDemo.Component;
using SauceDemo.Locator;

namespace SauceDemo.Tests.CheckoutTwo
{
    [TestFixture]
    public class Scenario_23
    {
        IWebDriver chromeDriver;

        Locator.LoginLocator loginLocator;
        Locator.CartLocator cartLocator;
        Locator.CheckoutOneLocator checkoutOneLocator;
        Locator.CheckoutTwoLocator checkoutTwoLocator;
        Locator.InventoryItemLocator inventoryItemLocator;
        Locator.ItemDetailsLocator itemDetailsLocator;
        Locator.NavigationBarLocator navigationBarLocator;

        Screen.LoginScreen loginScreen;
        Screen.CartScreen cartScreen;
        Screen.CheckoutOneScreen checkoutOneScreen;
        Screen.CheckoutTwoScreen checkoutTwoScreen;
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
            inventoryItemLocator = new Locator.InventoryItemLocator(chromeDriver);
            itemDetailsLocator = new Locator.ItemDetailsLocator(chromeDriver);
            inventoryItemScreen = new Screen.InventoryItemScreen(chromeDriver, inventoryItemLocator, itemDetailsLocator);
            inventoryItemScreen.AddAllItemsToCart();

            // NAVIGATE TO CART SCREEN 
            navigationBarLocator = new Locator.NavigationBarLocator(chromeDriver);
            navigationBarComponent = new Component.NavigationBarComponent(chromeDriver, navigationBarLocator);
            navigationBarComponent.NavigateToCartScreen();

            // NAVIGATE TO CHECKOUT SCREEN 
            cartLocator = new Locator.CartLocator(chromeDriver);
            cartScreen = new Screen.CartScreen(chromeDriver, cartLocator);
            cartScreen.NavigateToCheckoutOneScreen();

            // NAVIGATE TO CHECKOUT STEP TWO SCREEN 
            checkoutOneLocator = new Locator.CheckoutOneLocator(chromeDriver);
            checkoutOneScreen = new Screen.CheckoutOneScreen(checkoutOneLocator);
            checkoutOneScreen.NavigateToCheckoutTwoScreen();

            checkoutTwoLocator = new Locator.CheckoutTwoLocator(chromeDriver);
            checkoutTwoScreen = new Screen.CheckoutTwoScreen(checkoutTwoLocator);
        }

        [Test, Order(1)]
        [Category("Checkout Step Two Screen | Description label is displayed")]
        public void TestCase_2301()
        {
            // GET DESCRIPTION LABEL IS DISPLAYED 
            bool descriptionlabelDisplayed = checkoutTwoScreen.DescriptionLabelDisplayed();

            // ASSERTION DESCRIPTION LABEL IS DISPLAYED 
            Assert.IsTrue(descriptionlabelDisplayed);
        }

        [Test, Order(2)]
        [Category("Checkout Step Two Screen | Description contains item name")]
        public void TestCase_2302()
        {
            // GET ITEM NAME IS DISPLAYED 
            List<bool> itemnameDisplayed = checkoutTwoScreen.ItemNameDisplayed();

            // ASSERTION ITEM NAME IS DISPLAYED 
            Assert.IsTrue(itemnameDisplayed.All(item => item));
        }

        [Test, Order(3)]
        [Category("Checkout Step Two Screen | Description contains item name as link")]
        public void TestCase_2303()
        {
            // GET ITEM TAG NAME 
            List<string> itemTagname = checkoutTwoScreen.ItemTagName();

            // EXPECTED RESULT 
            string expectedresult = Expected.CheckoutTwoExpected.itemNameTagName;

            // ASSERTION ITEM TAG NAME 
            Assert.IsTrue(itemTagname.All(item => item == expectedresult));
        }

        [Test, Order(4)]
        [Category("Checkout Step Two Screen | Description contains item description")]
        public void TestCase_2304()
        {
            // GET ITEM DESCRTIPTION IS DISPLAYED 
            List<bool> itemdescriptionDisplayed = checkoutTwoScreen.ItemDescriptionDisplayed();

            // ASSERTION ITEM DESCRTIPTION IS DISPLAYED 
            Assert.IsTrue(itemdescriptionDisplayed.All(item => item));
        }

        [Test, Order(5)]
        [Category("Checkout Step Two Screen | Description contains item price")]
        public void TestCase_2305()
        {
            // GET ITEM PRICE IS DISPLAYED 
            List<bool> itempriceDisplayed = checkoutTwoScreen.ItemPriceDisplayed();

            // ASSERTION ITEM PRICE IS DISPLAYED 
            Assert.IsTrue(itempriceDisplayed.All(item => item));
        }

        [Test, Order(6)]
        [Category("Checkout Step Two Screen | Description shows item name, description and price")]
        public void TestCase_2306()
        {
            // GET ITEM NAME, DESCRIPTION AND PRICE
            List<string> itemList = checkoutTwoScreen.ItemList(checkoutTwoLocator.CartItem);

            // EXPECTED RESULT 
            List<string> expectedresult = Expected.CheckoutTwoExpected.ItemList();

            // ASSERTION ITEM NAME, DESCRIPTION AND PRICE
            CollectionAssert.AreEqual(expectedresult, itemList);
        }

        [OneTimeTearDown]
        public void Teardown()
        {
            chromeDriver?.Dispose();
        }
    }
}