using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using SauceDemo.Component;
using SauceDemo.Locator;

namespace SauceDemo.Tests.CheckoutComplete
{
    [TestFixture]
    public class Scenario_31
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
        [Category("Checkout Complete Screen | Successful image is displayed")]
        public void TestCase_3101()
        {
            // GET SUCCESSFUL IMAGE IS DISPLAYED 
            bool succefulimageDisplayed = checkoutCompleteScreen.SuccessfulImgDisplayed();

            // ASSERT SUCCESSFUL IMAGE IS DISPLAYED 
            Assert.IsTrue(succefulimageDisplayed);
        }

        [OneTimeTearDown]
        public void Teardown()
        {
            chromeDriver?.Dispose();
        }
    }
}