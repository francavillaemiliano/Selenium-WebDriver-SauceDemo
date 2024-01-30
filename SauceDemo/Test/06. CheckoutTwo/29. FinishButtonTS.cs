using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using SauceDemo.Component;
using SauceDemo.Locator;

namespace SauceDemo.Tests.CheckoutTwo
{
    [TestFixture]
    public class Scenario_29
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
        [Category("Checkout Step Two Screen | Finish button is displayed")]
        public void TestCase_2901()
        {
            // GET FINISH BUTTON IS DISPLAYED 
            bool finishbuttonDisplayed = checkoutTwoScreen.FinishButtonDisplayed();

            // ASSERT FINISH BUTTON IS DISPLAYED 
            Assert.IsTrue(finishbuttonDisplayed);
        }

        [Test, Order(2)]
        [Category("Checkout Step Two Screen | Finish button text is Finish")]
        public void TestCase_2902()
        {
            // GET FINISH BUTTON TEXT
            string finishbuttonText = checkoutTwoScreen.FinishButtonText();

            // EXPECTED RESULT
            string expectedresult = Expected.CheckoutTwoExpected.finishButton;

            // ASSERTION FINISH BUTTON TEXT
            Assert.That(finishbuttonText, Is.EqualTo(expectedresult));
        }

        [Test, Order(3)]
        [Category("Checkout Step Two screen | Finish button redirects to Checkout Complete screen")]
        public void TestCase_2903()
        {
            // CLICK FINISH BUTTON
            checkoutTwoLocator.FinishButton.Click();

            // GET CHECKOUT COMPLETE SCREEN URL 
            string screenUrl = chromeDriver.Url;

            // EXPECTED RESULT 
            string expectedresult = Expected.UrlExpected.checkoutComplete;

            // ASSERTION CHECKOUT COMPLETE SCREEN URL 
            Assert.That(screenUrl, Is.EqualTo(expectedresult));
        }

        [OneTimeTearDown]
        public void Teardown()
        {
            chromeDriver?.Dispose();
        }
    }
}