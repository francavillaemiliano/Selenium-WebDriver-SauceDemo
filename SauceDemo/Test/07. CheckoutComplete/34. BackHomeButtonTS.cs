using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using SauceDemo.Component;
using SauceDemo.Locator;

namespace SauceDemo.Tests.CheckoutComplete
{
    [TestFixture]
    public class Scenario_34
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
        [Category("Checkout Complete Screen | Back Home button is displayed")]
        public void TestCase_3401()
        {
            // GET BACK HOME BUTTON DISPLAYED 
            bool backhomebuttonDisplayed = checkoutCompleteScreen.BackHomeButtonDisplayed();

            // ASSERTION BACK HOME BUTTON DISPLAYED 
            Assert.IsTrue(backhomebuttonDisplayed);
        }

        [Test, Order(2)]
        [Category("Checkout Complete Screen | Back Home button text is Back Home")]
        public void TestCase_3402()
        {
            // GET BACK HOME BUTTON TEXT
            string backHomeButtonText = checkoutCompleteScreen.BackHomeButtonText();

            // EXPECTED RESULT
            string expectedresult = Expected.CheckoutCompleteExpected.backHomeButton;

            // ASSERTION BACK HOME BUTTON TEXT
            Assert.That(backHomeButtonText, Is.EqualTo(expectedresult));
        }

        [Test, Order(3)]
        [Category("Checkout Complete Screen | Back Home button redirects to inventory screen")]
        public void TestCase_3403()
        {
            // CLICK BACK HOME BUTTON 
            checkoutCompleteLocator.BackHomeButton.Click();

            // GET INVENTORY SCREEN URL 
            string screenUrl = chromeDriver!.Url;

            // EXPECTED RESULT 
            string expectedresult = Expected.UrlExpected.inventory;

            // ASSERTION INVENTORY SCREEN URL 
            Assert.That(screenUrl, Is.EqualTo(expectedresult));
        }

        [OneTimeTearDown]
        public void Teardown()
        {
            chromeDriver?.Dispose();
        }
    }
}