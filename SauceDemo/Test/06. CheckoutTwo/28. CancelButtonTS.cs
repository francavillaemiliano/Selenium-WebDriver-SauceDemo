using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using SauceDemo.Component;
using SauceDemo.Locator;

namespace SauceDemo.Tests.CheckoutTwo
{
    [TestFixture]
    public class Scenario_28
    {
        IWebDriver chromeDriver;

        Locator.LoginLocator loginLocator;
        Locator.CartLocator cartLocator;
        Locator.CheckoutOneLocator checkoutOneLocator;
        Locator.CheckoutTwoLocator checkoutTwoLocator;
        Locator.InventoryItemLocator inventoryLocator;
        Locator.ItemDetailsLocator itemDetailsLocator;
        Locator.NavigationBarLocator navigationBarLocator;

        Screen.LoginScreen loginScreen;
        Screen.CartScreen cartScreen;
        Screen.CheckoutOneScreen checkoutOneScreen;
        Screen.CheckoutTwoScreen checkoutTwoScreen;
        Screen.InventoryItemScreen inventoryScreen;
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
            inventoryLocator = new Locator.InventoryItemLocator(chromeDriver);
            itemDetailsLocator = new Locator.ItemDetailsLocator(chromeDriver);
            inventoryScreen = new Screen.InventoryItemScreen(chromeDriver, inventoryLocator, itemDetailsLocator);
            inventoryScreen.AddAllItemsToCart();

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
        [Category("Checkout Step Two Screen | Cancel button is displayed")]
        public void TestCase_2801()
        {
            // GET CANCEL BUTTON IS DISPLAYED
            bool cancelbuttonDisplayed = checkoutTwoScreen.CancelButtonDisplayed();

            // ASSERT CANCEL BUTTON IS DISPLAYED
            Assert.IsTrue(cancelbuttonDisplayed);
        }

        [Test,Order(2)]
        [Category("Checkout Step Two Screen | Cancel button text is Cancel")]
        public void TestCase_2802()
        {
            // GET CANCEL BUTTON TEXT
            string cancelbuttonText = checkoutTwoScreen.CancelButtonText();

            // EXPECTED RESULT
            string expectedresult = Expected.CheckoutTwoExpected.cancelButton;

            // ASSERTION CANCEL BUTTON TEXT
            Assert.That(cancelbuttonText, Is.EqualTo(expectedresult));
        }

        [Test, Order(3)]
        [Category("Checkout Step Two Screen | Cancel button redirects to Products screen")]
        public void TestCase_2803()
        {
            // CLICK CANCEL BUTTON 
            checkoutTwoScreen.NavigateToInventoryItemScreen();

            // GET SCREEN URL 
            string screenUrl = chromeDriver!.Url;

            // EXPECTED RESULT 
            string expectedresult = Expected.UrlExpected.inventory;

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