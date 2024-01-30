using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using SauceDemo.Component;
using SauceDemo.Locator;

namespace SauceDemo.Tests.FunctionalTests
{
    [TestFixture]
    public class Scenario_43
    {
        IWebDriver? chromeDriver;

        Locator.LoginLocator loginLocator;
        Locator.InventoryItemLocator inventoryItemLocator;
        Locator.ItemDetailsLocator itemDetailsLocator;
        Locator.CartLocator cartLocator;
        Locator.CheckoutOneLocator checkoutOneLocator;
        Locator.CheckoutTwoLocator checkoutTwoLocator;
        Locator.NavigationBarLocator navigationBarLocator;

        Screen.LoginScreen loginScreen;
        Screen.InventoryItemScreen inventoryItemScreen;
        Screen.CartScreen cartScreen;
        Screen.CheckoutOneScreen checkoutOneScreen;
        Screen.CheckoutTwoScreen checkoutTwoScreen;
        Component.NavigationBarComponent navigationBarComponent;

        [OneTimeSetUp]
        public void Setup()
        {
            /// DRIVER SETUP
            chromeDriver = new ChromeDriver();
            SetUp.Driver driver = new SetUp.Driver(chromeDriver);
            driver.DriverSetup();

            loginLocator = new Locator.LoginLocator(chromeDriver);
            inventoryItemLocator = new Locator.InventoryItemLocator(chromeDriver);
            itemDetailsLocator = new Locator.ItemDetailsLocator(chromeDriver);
            cartLocator = new Locator.CartLocator(chromeDriver);
            checkoutOneLocator = new Locator.CheckoutOneLocator(chromeDriver);
            checkoutTwoLocator = new Locator.CheckoutTwoLocator(chromeDriver);

            loginScreen = new Screen.LoginScreen(loginLocator);
            inventoryItemScreen = new Screen.InventoryItemScreen(chromeDriver, inventoryItemLocator, itemDetailsLocator);
            cartScreen = new Screen.CartScreen(chromeDriver, cartLocator);
            checkoutOneScreen = new Screen.CheckoutOneScreen(checkoutOneLocator);
            checkoutTwoScreen = new Screen.CheckoutTwoScreen(checkoutTwoLocator);

            navigationBarLocator = new Locator.NavigationBarLocator(chromeDriver);
            navigationBarComponent = new Component.NavigationBarComponent(chromeDriver, navigationBarLocator);
        }

        [Test, Order(1)]
        [Category("Checkout Complete | Standard user is able to complete an order")]
        public void TestCase_4301()
        {
            // LOGIN STANDARD USER 
            loginScreen.LoginStandardUser();

            // ADD ALL ITEMS TO CART 
            inventoryItemScreen.AddAllItemsToCart();

            // NAVIGATE TO CART SCREEN 
            navigationBarComponent.NavigateToCartScreen();

            // NAVIGATE TO CHECKOUT STEP ONE SCREEN 
            cartScreen.NavigateToCheckoutOneScreen();

            // NAVIGATE TO CHECKOUT STEP TWO SCREEN
            checkoutOneScreen.NavigateToCheckoutTwoScreen();

            // FINISH ORDER 
            checkoutTwoScreen.NavigateToCheckoutCompleteScreen();

            // GET SCREEN URL 
            string screenUrl = chromeDriver!.Url;

            // EXPECTED RESULT 
            string expectedresult = Expected.UrlExpected.checkoutComplete;

            // ASSERTION SCREEN URL 
            Assert.That(screenUrl, Is.EqualTo(expectedresult));
        }

        [OneTimeTearDown]
        public void Teardown()
        {
            chromeDriver?.Dispose();
        }
    }
}