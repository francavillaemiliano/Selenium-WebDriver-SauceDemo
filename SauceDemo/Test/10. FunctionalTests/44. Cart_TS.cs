using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;

namespace SauceDemo.Tests.FunctionalTests
{
    [TestFixture]
    public class Scenario_44
    {
        IWebDriver? chromeDriver;

        Locator.LoginLocator loginLocator;
        Locator.InventoryItemLocator inventoryItemLocator;
        Locator.ItemDetailsLocator itemDetailsLocator;
        Locator.NavigationBarLocator navigationBarLocator;        

        Screen.LoginScreen loginScreen;
        Screen.InventoryItemScreen inventoryItemScreen;
        Component.NavigationBarComponent navigationBarComponent;

        [OneTimeSetUp]
        public void Setup()
        {
            /// DRIVER SETUP
            chromeDriver = new ChromeDriver();
            SetUp.Driver driver = new SetUp.Driver(chromeDriver);
            driver.DriverSetup();

            // LOGIN STANDARD USER 
            loginLocator = new Locator.LoginLocator(chromeDriver);
            loginScreen = new Screen.LoginScreen(loginLocator);
            loginScreen.LoginStandardUser();

            inventoryItemLocator = new Locator.InventoryItemLocator(chromeDriver);
            itemDetailsLocator = new Locator.ItemDetailsLocator(chromeDriver);
            inventoryItemScreen = new Screen.InventoryItemScreen(chromeDriver, inventoryItemLocator, itemDetailsLocator);
            navigationBarLocator = new Locator.NavigationBarLocator(chromeDriver);
            navigationBarComponent = new Component.NavigationBarComponent(chromeDriver, navigationBarLocator);
        }

        [Test, Order(1)]
        [Category("Cart | Cart item quantity doesn't reset when Standard user log out and log in")]
        public void TestCase_4401()
        {
            // ADD ALL ITEMS TO CART 
            inventoryItemScreen.AddAllItemsToCart();

            // LOGOUT USER 
            navigationBarComponent.LogoutUser();

            // LOGIN STANDARD USER 
            loginScreen.LoginStandardUser();

            // GET CART ITEMS 
            int cartItems = navigationBarComponent.GetCartItems();

            // EXPECTED RESULT 
            int expectedresult = Expected.CartExpected.cartitemsFull;

            // ASSERTION CART ITEMS 
            Assert.That(cartItems, Is.EqualTo(expectedresult));
        }

        [Test, Order(2)]
        [Category("Cart | Cart product quantity change when Standard user clicks remove button from Inventory screen")]
        public void TestCase_4402()
        {
            // REMOVE ALL ITEMS FROM CART 
            inventoryItemScreen.RemoveAllItemsFromCart();

            // GET CART ITEMS 
            int cartItems = navigationBarComponent.GetCartItems();

            // EXPECTED RESULT 
            int expectedresult = Expected.CartExpected.cartitemsEmpty;

            // ASSERTION CART ITEMS 
            Assert.That(cartItems, Is.EqualTo(expectedresult));
        }

        [Test, Order(3)]
        [Category("Cart | Cart product quantity change when Standard user clicks remove button from Inventory Item screen")]
        public void TestCase_4403()
        {
            // ADD ALL ITEMS TO CART 
            inventoryItemScreen.AddAllItemsToCart();

            // REMOVE ALL ITEMS FROM CART FROM INVENTORY ITEM SCREEN 
            inventoryItemScreen.RemoveAllItemsFromCart();

            // GET CART ITEMS 
            int cartItems = navigationBarComponent.GetCartItems();

            // EXPECTED RESULT 
            int expectedresult = Expected.CartExpected.cartitemsEmpty;

            // ASSERTION CART ITEMS 
            Assert.That(cartItems, Is.EqualTo(expectedresult));
        }
            [OneTimeTearDown]
        public void Teardown()
        {
            chromeDriver?.Dispose();
        }
    }
}