using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using SauceDemo.Component;
using SauceDemo.Locator;

namespace SauceDemo.Tests.CheckoutComplete
{
    [TestFixture]
    public class Scenario_33
    {
        IWebDriver chromeDriver;

        Locator.LoginLocator loginLocator;
        Locator.CartLocator cartLocator;
        Locator.CheckoutOneLocator checkoutOneLocator;
        Locator.CheckoutTwoLocator checkoutTwoLocator;
        Locator.CheckoutCompleteLocator checkoutCompleteLocator;
        Locator.NavigationBarLocator navigationBarLocator;

        Screen.LoginScreen loginScreen;
        Screen.CartScreen cartScreen;
        Screen.CheckoutOneScreen checkoutOneScreen;
        Screen.CheckoutTwoScreen checkoutTwoScreen;
        Screen.CheckoutCompleteScreen checkoutCompleteScreen;
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

            // NAVIGATE TO CHECKOUT COMPLETE SCREEN 
            checkoutTwoLocator = new Locator.CheckoutTwoLocator(chromeDriver);
            checkoutTwoScreen = new Screen.CheckoutTwoScreen(checkoutTwoLocator);
            checkoutTwoScreen.NavigateToCheckoutCompleteScreen();

            checkoutCompleteLocator = new Locator.CheckoutCompleteLocator(chromeDriver);
            checkoutCompleteScreen = new Screen.CheckoutCompleteScreen(checkoutCompleteLocator);
        }

        [Test, Order(1)]
        [Category("Checkout Complete Screen | Your order has been dispatched, and will arrive just as fast as the pony can get there! is displayed")]
        public void TestCase_3301()
        {
            // GET YOUR ORDER HAS BEEN DISPATCHED, AND WILL ARRIVE JUST AS FAST AS THE PONY CAN GET THERE! IS DISPLAYED 
            bool orderDispatchedDisplayed = checkoutCompleteScreen.OrderDispatchedDisplayed();

            // ASSERTION YOUR ORDER HAS BEEN DISPATCHED, AND WILL ARRIVE JUST AS FAST AS THE PONY CAN GET THERE! IS DISPLAYED 
            Assert.IsTrue(orderDispatchedDisplayed);
        }

        [Test, Order(2)]
        [Category("Checkout Complete Screen | Your Order has been dispatched text is Your order has been dispatched, and will arrive just as fast as the pony can get there!")]
        public void TestCase_3302()
        {
            // GET YOUR ORDER HAS BEEN DISPATCHED TEXT
            string orderDispatchedText = checkoutCompleteScreen.OrderDispatchedText();

            // EXPECTED RESULT
            string expectedresult = Expected.CheckoutCompleteExpected.orderDispatched;

            // ASSERTION YOUR ORDER HAS BEEN DISPATCHED TEXT
            Assert.That(orderDispatchedText, Is.EqualTo(expectedresult));
        }

        [OneTimeTearDown]
        public void Teardown()
        {
            chromeDriver?.Dispose();
        }
    }
}