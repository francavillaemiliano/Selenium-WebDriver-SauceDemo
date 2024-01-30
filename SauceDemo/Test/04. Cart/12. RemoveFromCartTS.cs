using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using SauceDemo.Locator;
using SauceDemo.Screen;
using SauceDemo.Component;

namespace SauceDemo.Tests.Cart
{
    [TestFixture]
    public class Scenario_12
    {
        IWebDriver chromeDriver;

        Locator.LoginLocator loginLocator;
        Locator.CartLocator cartLocator;
        Locator.InventoryItemLocator inventoryItemLocator;
        Locator.ItemDetailsLocator itemDetailsLocator;
        Locator.NavigationBarLocator navigationBarLocator;

        Screen.LoginScreen loginScreen;
        Screen.CartScreen cartScreen;
        Screen.InventoryItemScreen inventoryitemScreen;
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
            inventoryitemScreen = new InventoryItemScreen(chromeDriver, inventoryItemLocator, itemDetailsLocator);
            inventoryitemScreen.AddAllItemsToCart();

            // NAVIGATE TO CART SCREEN 
            navigationBarLocator = new Locator.NavigationBarLocator(chromeDriver);
            navigationBarComponent = new Component.NavigationBarComponent(chromeDriver, navigationBarLocator);
            navigationBarComponent.NavigateToCartScreen();

            cartLocator = new Locator.CartLocator(chromeDriver);
            cartScreen = new Screen.CartScreen(chromeDriver, cartLocator);
        }

        [Test, Order(1)]        
        [Category("Cart Screen | Remove from cart button removes the product from the cart")]
        public void TestCase_1202()
        {
            // REMOVE ALL PRODUCTS FROM CART 
            cartScreen.RemoveAllItemsFromCart();

            // GET CART IS EMPTY 
            bool cartIsempty = cartScreen.CarIsEmpty();

            // ASSERTION CART IS EMPTY  
            Assert.IsTrue(cartIsempty);
        }

        [OneTimeTearDown]
        public void Teardown()
        {
            chromeDriver?.Dispose();
        }
    }
}