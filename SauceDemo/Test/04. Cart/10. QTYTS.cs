using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;

namespace SauceDemo.Tests.Cart
{
    [TestFixture]
    public class Scenario_10
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
        [Category("Cart Screen | QTY label is displayed")]
        public void TestCase_1001()
        {
            // GET QTY LABEL IS DISPLAYED 
            bool qtylabelDisplayed = cartScreen.QTYLabelDisplayed();

            // ASSERTION QTY LABEL DISPLAYED
            Assert.IsTrue(qtylabelDisplayed);
        }

        [Test, Order(2)]
        [Category("Cart Screen | QTY contains item quantity")]
        public void TestCase_1002()
        {
            // GET ITEM QTY 
            List<string> itemQty = cartScreen.ItemQTY();

            // EXPECTED RESULT
            string expectedresult = Expected.CartExpected.itemQTY;

            // ACTUAL RESULT
            List<string> actualresult = itemQty;

            // ASSERTION ITEM QTY
            Assert.IsTrue(actualresult.All(item => item == expectedresult));
        }
        
        [OneTimeTearDown]
        public void Teardown()
        {
            chromeDriver?.Dispose();
        }
    }
}