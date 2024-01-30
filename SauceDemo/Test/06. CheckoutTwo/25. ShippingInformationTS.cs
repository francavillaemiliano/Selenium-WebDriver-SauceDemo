using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using SauceDemo.Component;
using SauceDemo.Locator;

namespace SauceDemo.Tests.CheckoutTwo
{
    [TestFixture]
    public class Scenario_25
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
        [Category("Checkout Step Two Screen | Shipping Information label is displayed")]
        public void TestCase_2501()
        {
            // GET SHIPPING INFORMATION DISPLAYED 
            bool shippinginformationDisplayed = checkoutTwoScreen.ShippingInformationDisplayed();

            // ASSERTION SHIPPING INFORMATION DISPLAYED 
            Assert.IsTrue(shippinginformationDisplayed);
        }

        [Test, Order(2)]
        [Category("Checkout Step Two Screen | Shipping Information text is Shipping Information")]
        public void TestCase_2502()
        {
            // GET SHIPPING INFORMATION TEXT
            string shippingInformationtext = checkoutTwoScreen.ShippingInformationText();

            // EXPECTED RESULT
            string expectedresult = Expected.CheckoutTwoExpected.shippingInformationLabel;

            // ASSERTION SHIPPING INFORMATION TEXT
            Assert.That(shippingInformationtext, Is.EqualTo(expectedresult));
        }

        [Test, Order(3)]
        [Category("Checkout Step Two Screen | Shipping Information contains Free Pony Express Delivery!")]
        public void TestCase_2503()
        {
            // GET FREE PONY EXPRESS DELIVERY LABEL IS DISPLAYED 
            bool freeponylabelDisplayed = checkoutTwoScreen.FreePonyExpressDeliveryDisplayed();

            // ASSERTION FREE PONY EXPRESS DELIVERY LABEL IS DISPLAYED 
            Assert.IsTrue(freeponylabelDisplayed);
        }

        [Test, Order(4)]
        [Category("Checkout Step Two Screen | Free Pony Express Delivery text is Free Pony Express Delivery!")]
        public void TestCase_2504()
        {
            // GET FREE PONY EXPRESS DELIVERY TEXT
            string freeponylabelText = checkoutTwoScreen.FreePonyExpressDeliveryText();

            // EXPECTED RESULT
            string expectedresult = Expected.CheckoutTwoExpected.freePonyExpressDeliveryLabel;

            // ASSERTION FREE PONY EXPRESS DELIVERY TEXT
            Assert.That(freeponylabelText, Is.EqualTo(expectedresult));
        }

        [OneTimeTearDown]
        public void Teardown()
        {
            chromeDriver?.Dispose();
        }
    }
}