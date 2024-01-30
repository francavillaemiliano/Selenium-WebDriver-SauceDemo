using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using SauceDemo.Component;
using SauceDemo.Locator;

namespace SauceDemo.Tests.CheckoutTwo
{
    [TestFixture]
    public class Scenario_26
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
        [Category("Checkout Step Two Screen | Price Total label is displayed")]
        public void TestCase_2601() 
        {
            // GET PRICE TOTAL IS DISPLAYED 
            bool pricetotalDisplayed = checkoutTwoScreen.PriceTotalDisplayed();

            // ASSERTION RICE TOTAL IS DISPLAYED 
            Assert.IsTrue(pricetotalDisplayed);
        }

        [Test, Order(2)]
        [Category("Checkout Step Two Screen | Price Total label text is Price Total")]
        public void TestCase_2602()
        {
            // GET PRICE TOTAL TEXT
            string pricetotalText = checkoutTwoScreen.PriceTotalText();

            // EXPECTED RESULT
            string expectedresult = Expected.CheckoutTwoExpected.pricetotalLabel;

            // ASSERTION PRICE TOTAL TEXT
            Assert.That(pricetotalText, Is.EqualTo(expectedresult));
        }

        [Test, Order(3)]
        [Category("Checkout Step Two Screen | Price Total contains Item Total label")]
        public void TestCase_2603()
        {
            // GET PRICE TOTAL ITEM TOTAL IS DISPLAYED 
            bool subtotallabelDisplayed = checkoutTwoScreen.SauceCardDisplayed();

            // ASSERTION PRICE TOTAL ITEM TOTAL IS DISPLAYED 
            Assert.IsTrue(subtotallabelDisplayed);
        }

        [Test, Order(4)]
        [Category("Checkout Step Two Screen | Item Total label text is Item Total: $")]
        public void TestCase_2604()
        {
            // GET ITEM TOTAL LABEL TEXT
            string itemtotalLabelText = checkoutTwoScreen.SubtotalLabelText();

            // EXPECTED RESULT
            string expectedresult = Expected.CheckoutTwoExpected.subtotalLabel;

            // ASSERTION ITEM TOTAL LABEL TEXT
            Assert.That(itemtotalLabelText, Is.EqualTo(expectedresult));
        }

        [Test, Order(5)]
        [Category("Checkout Step Two Screen | Price Total contains the total of the selected items")]
        public void TestCase_2605()
        {
            // GET SUBTOTAL LABEL TEXT 
            string subtotallabelText = checkoutTwoScreen.SubtotalLabelText();

            // EXPECTED RESULT 
            string expectedresult = Expected.CheckoutTwoExpected.subtotalLabel;

            // ASSERTION SUBTOTAL LABEL TEXT 
            Assert.That(subtotallabelText, Is.EqualTo(expectedresult));
        }

        [Test, Order(6)]
        [Category("Checkout Step Two Screen | Price Total contains Tax label")]
        public void TestCase_2606()
        {
            // GET TAX LABEL IS DISPLAYED 
            bool taxlabelDisplayed = checkoutTwoScreen.TaxLabelDisplayed();

            // ASSERTION TAX LABEL IS DISPLAYED 
            Assert.IsTrue(taxlabelDisplayed);
        }

        [Test, Order(7)]
        [Category("Checkout Step Two Screen | Tax label text is Tax: $")]
        public void TestCase_2607()
        {
            // GET TAX LABEL TEXT
            string taxlabelText = checkoutTwoScreen.TaxLabelText();

            // EXPECTED RESULT
            string expectedresult = Expected.CheckoutTwoExpected.taxLabel;

            // ASSERTION TAX LABEL TEXT
            Assert.That(taxlabelText, Is.EqualTo(expectedresult));
        }

        [OneTimeTearDown]
        public void Teardown()
        {
            chromeDriver?.Dispose();
        }
    }
}