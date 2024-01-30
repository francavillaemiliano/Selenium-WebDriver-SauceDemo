using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using SauceDemo.Component;
using SauceDemo.Locator;

namespace SauceDemo.Tests.Cart
{
    [TestFixture]
    public class Scenario_14
    {
        IWebDriver chromeDriver;

        Locator.LoginLocator loginLocator;
        Locator.CartLocator cartLocator;
        Locator.NavigationBarLocator navigationBarLocator;

        Screen.LoginScreen loginScreen;
        Screen.CartScreen cartScreen;
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

            cartLocator = new Locator.CartLocator(chromeDriver);
            cartScreen = new Screen.CartScreen(chromeDriver, cartLocator);
        }

        [Test, Order(1)]
        [Category("Cart Screen | Checkout button is displayed")]
        public void TestCase_1401()
        {
            // GET CHECKOUT BUTTON IS DISPLAYED 
            bool checkoutbuttonDisplayed = cartScreen.CheckoutButtonDisplayed();

            // ASSERTION CHECKOUT BUTTON IS DISPLAYED
            Assert.IsTrue(checkoutbuttonDisplayed);
        }

        [Test, Order(2)]
        [Category("Cart Screen | Checkout button redirects to checkout screen")]
        public void TestCase_1402()
        {
            // NAVIGATE TO CHECKOUT SCREEN 
            cartScreen.NavigateToCheckoutOneScreen();

            // GET SCREEN URL 
            string screenUrl = chromeDriver.Url;

            // EXPECTED RESULT 
            string expectedresult = Expected.UrlExpected.checkoutStepOne;

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