using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;

namespace SauceDemo.Tests.NavigationBar
{
    [TestFixture]
    public class Scenario_35
    {
        IWebDriver? chromeDriver;

        Locator.LoginLocator loginLocator;
        Locator.InventoryItemLocator? inventoryItemLocator;
        Locator.ItemDetailsLocator? itemDetailsLocator;
        Locator.NavigationBarLocator navigationBarLocator;

        Screen.LoginScreen loginScreen;
        Screen.InventoryItemScreen? inventoryItemScreen;
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
        [Category("Navigation Bar | Burguer Menu is displayed")]
        public void TestCase_3501()
        {
            // GET BURGUER MENU IS DISPLAYED 
            bool burguermenuDisplayed = navigationBar.BurguerMenuDisplayed();

            // ASSERTION BURGUER MENU IS DISPLAYED 
            Assert.IsTrue(burguermenuDisplayed);
        }

        [Test, Order(2)]
        [Category("Navigation Bar | Burguer Menu contains All items, about, Logout and Reset App State options")]
        public void TestCase_3502()
        {
            // CLICK BURGUER MENU 
            navigationBar.ClickOnBurguerMenu();

            // GET BURGUER MENU OPTIONS 
            List<string> burguermenuOptions = navigationBar.GetBurguerMenuOptions();

            // EXPECTED RESULT 
            List<string> expectedresult = Expected.NavigationBarExpected.BurguerMenuOptions();

            // ASSERTION BURGUER MENU OPTIONS 
            CollectionAssert.AreEqual(expectedresult, burguermenuOptions);
        }

        [Test, Order(3)]
        [Category("Navigation Bar | Burguer menu All items option redirect to inventory screen")]
        public void TestCase_3503()
        {
            // CLICK BURGUER MENU ALL ITEMS OPTION 
            navigationBarLocator.AllItems.Click();

            // GET SCREEN URL 
            string screenUrl = chromeDriver!.Url;

            // EXPECTED RESULT 
            string expectedresult = Expected.UrlExpected.inventory;

            // ASSERTION SCREEN URL 
            Assert.That(screenUrl, Is.EqualTo(expectedresult));
        }

        [Test, Order(4)]
        [Category("Navigation Bar | Burguer menu About option redirects to saucelabs.com")]
        public void TestCase_3504()
        {
            // CLICK BURGUER MENU ABOUT OPTION 
            navigationBarLocator.About.Click();

            // GET SCREEN URL 
            string screenUrl = chromeDriver!.Url;

            // EXPECTED RESULT 
            string expectedresult = Expected.UrlExpected.saucelabs;

            // ASSERTION SCREEN URL 
            Assert.That(screenUrl, Is.EqualTo(expectedresult));

            // NAVIGATE BACK 
            chromeDriver.Navigate().Back();
        }

        [Test, Order(5)]
        [Category("Navigation Bar | Burguer menu Logout option redirects to login screen")]
        public void TestCase_3505()
        {
            // CLICK BURGUER MENU 
            navigationBar.ClickOnBurguerMenu();            

            // CLICK BURGUER MENU LOGOUT OPTION 
            navigationBarLocator.Logout.Click();

            // GET SCREEN URL 
            string screenUrl = chromeDriver!.Url;

            // EXPECTED RESULT 
            string expectedresult = Data.Url.baseUrl;

            // ASSERTION SCREEN URL 
            Assert.That(screenUrl, Is.EqualTo(expectedresult));
        }

        [Test, Order(6)]
        [Category("Navigation Bar | Burguer menu Reset App State removes products from the cart")]
        public void TestCase_3506()
        {
            // LOGIN STANDARD USER 
            loginScreen.LoginStandardUser();

            // ADD ALL ITEMS TO CART 
            inventoryItemLocator = new Locator.InventoryItemLocator(chromeDriver!);
            itemDetailsLocator = new Locator.ItemDetailsLocator(chromeDriver!);
            inventoryItemScreen = new Screen.InventoryItemScreen(chromeDriver!, inventoryItemLocator, itemDetailsLocator);
            inventoryItemScreen.AddAllItemsToCart();

            // CLICK BURGUER MENU ICON 
            navigationBar.ClickOnBurguerMenu();

            // CLICK BURGUER MENU RESET APP STATE 
            navigationBarLocator.ResetAppState.Click();

            // GET CART ITEMS 
            int cartItems = navigationBar.GetCartItems();

            // EXPECTED RESULT 
            int expectedresult = Expected.NavigationBarExpected.cartItemsEmpty;

            // ASSERTION CART ITEMS 
            Assert.That(cartItems, Is.EqualTo(expectedresult));
        }

        [Test, Order(7)]
        [Category("Navigation Bar | Burguer menu contains X button")]
        public void TestCase_3507()
        {
            // GET MENU BURGUER X BUTTON IS DISPLAYED 
            bool menuburguerxDisplayed = navigationBar.BurguerMenuXButtonDisplayed();

            // ASSERTION MENU BURGUER X BUTTON IS DISPLAYED 
            Assert.IsTrue(menuburguerxDisplayed);
        }

        [Test, Order(8)]
        [Category("Navigation Bar | Burguer menu X button closes the menu")]
        public void TestCase_3508()
        {
            // CLICK BURGUER MENU X 
            navigationBarLocator.BurguerMenuXButton.Click();

            // GET BURGUER MENU IS HIDDEN 
            bool burguermenuHidden = navigationBar.BurguerMenuHidden();

            // ASSERTION BURGUER MENU IS HIDDEN 
            Assert.IsTrue(burguermenuHidden);
        }

        [OneTimeTearDown]
        public void Teardown()
        {
            chromeDriver?.Dispose();
        }
    }
}