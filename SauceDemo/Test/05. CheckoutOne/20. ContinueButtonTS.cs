using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using SauceDemo.Component;
using SauceDemo.Locator;

namespace SauceDemo.Tests.CheckoutOne
{
    [TestFixture]
    public class Scenario_20
    {
        IWebDriver chromeDriver;

        Locator.LoginLocator loginLocator;
        Locator.CartLocator cartLocator;
        Locator.CheckoutOneLocator checkoutOneLocator;
        Locator.NavigationBarLocator navigationBarLocator;

        Screen.LoginScreen loginScreen;
        Screen.CartScreen cartScreen;
        Screen.CheckoutOneScreen checkoutOneScreen;
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

            checkoutOneLocator = new Locator.CheckoutOneLocator(chromeDriver);
            checkoutOneScreen = new Screen.CheckoutOneScreen(checkoutOneLocator);
        }

        [Test, Order(1)]
        [Category("Checkout Step One Screen | Continue button is displayed")]
        public void TestCase_2001()
        {
            // GET CONTINUE BUTTON DISPLAYED 
            bool continuebuttonDisplayed = checkoutOneScreen.ContinueButtonDisplayed();

            // ASSERTION CONTINUE BUTTON DISPLAYED 
            Assert.IsTrue(continuebuttonDisplayed);
        }

        [Test, Order(2)]
        [Category("Checkout Step One Screen | Continue button redirects to checkout 2 screen")]
        public void TestCase_2002()
        {
            // FILL IN FIRST NAME FIELD 
            checkoutOneScreen.FillInFirstName();

            // FILL IN LAST NAME FIELD 
            checkoutOneScreen.FillInLastName();

            // FILL IN ZIP/POSTAL CODE FIELD 
            checkoutOneScreen.FillInZipPostalCode();

            // NAVIGATE TO CHECKOUT STEP TWO SCREEN 
            checkoutOneLocator.ContinueButton.Click();

            // GET SCREEN URL 
            string screenUrl = chromeDriver.Url;

            // EXPECTED RESULT 
            string expectedresult = Expected.UrlExpected.checkoutStepTwo;

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