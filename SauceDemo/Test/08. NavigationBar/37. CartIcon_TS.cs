using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;

namespace SauceDemo.Tests.NavigationBar
{
    [TestFixture]
    public class Scenario_37
    {
        IWebDriver? chromeDriver;

        Locator.LoginLocator loginLocator;
        Locator.InventoryItemLocator? inventoryLocator;
        Locator.ItemDetailsLocator? itemDetailsLocator;
        Locator.NavigationBarLocator navigationBarLocator;

        Screen.LoginScreen loginScreen;
        Screen.InventoryItemScreen? inventoryScreen;
        Component.NavigationBarComponent navigationBar;

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

            navigationBarLocator = new Locator.NavigationBarLocator(chromeDriver);
            navigationBar = new Component.NavigationBarComponent(chromeDriver, navigationBarLocator);
        }

        [Test, Order(1)]
        [Category("Navigation Bar | Cart Icon is displayed")]
        public void TestCase_3701()
        {
            // GET CART ICON IS DISPLAYED 
            bool carticonDisplayed = navigationBar.CartIconDisplayed();

            // ASSERTIONION CART ICON IS DISPLAYED 
            Assert.IsTrue(carticonDisplayed);
        }

        [Test, Order(2)]
        [Category("Navigation Bar | Cart Icon shows quantity of selected products")]
        public void TestCase_3702()
        {
            // ADD ALL ITEMS TO CART 
            inventoryLocator = new Locator.InventoryItemLocator(chromeDriver!);
            itemDetailsLocator = new Locator.ItemDetailsLocator(chromeDriver!);
            inventoryScreen = new Screen.InventoryItemScreen(chromeDriver!, inventoryLocator, itemDetailsLocator);
            inventoryScreen.AddAllItemsToCart();

            // GET CART ITEMS 
            int cartItems = navigationBar.GetCartItems();

            // EXPECTED RESULT 
            int expectedresult = Expected.NavigationBarExpected.cartItemsFull;

            // ASSERTION CART ITEMS 
            Assert.That(cartItems, Is.EqualTo(expectedresult));
        }

        [Test, Order(3)]
        [Category("Navigation Bar | Cart Icon redirects to cart screen")]
        public void TestCase_3703()
        {
            // CLICK ON CART ICON 
            navigationBarLocator.CartIcon.Click();

            // GET SCREEN URL 
            string screenUrl = chromeDriver!.Url;

            // EXPECTED RESULT 
            string expectedresult = Expected.UrlExpected.cart;

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