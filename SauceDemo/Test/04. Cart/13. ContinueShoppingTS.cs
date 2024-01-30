using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using SauceDemo.Component;
using SauceDemo.Locator;

namespace SauceDemo.Tests.Cart
{
    [TestFixture]
    public class Scenario_13
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
        [Category("Cart Screen | Continue Shopping button is displayed")]
        public void TestCase_1301()
        {
            // GET CONTINUE SHOPPING BUTTON IS DISPLAYED 
            bool continueshoppingbuttonDisplayed = cartScreen.ContinueShoppingButtonDisplayed();

            // ASSERTION CONTINUE SHOPPING BUTTON IS DISPLAYED
            Assert.IsTrue(continueshoppingbuttonDisplayed);
        }

        [Test, Order(2)]
        [Category("Cart Screen | Continue Shopping button redirects to checkout screen")]
        public void TestCase_1302()
        {
            // NAVIGATE TO PRODUCTS SCREEN 
            cartScreen.NavigateToInventoryScreen();

            // GET BROWSER URL 
            string browserUrl = chromeDriver!.Url;

            // EXPECTED RESULT 
            string expectedresult = Expected.UrlExpected.inventory;         

            // ASSERTION EXPECTED RESULT VS ACTUAL RESULT 
            Assert.That(browserUrl, Is.EqualTo(expectedresult));
        }

        [OneTimeTearDown]
        public void Teardown()
        {
            chromeDriver?.Dispose();
        }
    }
}