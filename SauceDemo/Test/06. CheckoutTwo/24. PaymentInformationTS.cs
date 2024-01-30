using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using SauceDemo.Locator;
using SauceDemo.Screen;
using System.Dynamic;
using SauceDemo.Component;

namespace SauceDemo.Tests.CheckoutTwo
{
    [TestFixture]
    public class Scenario_24
    {
        IWebDriver chromeDriver;

        Locator.LoginLocator loginLocator;
        Locator.CartLocator cartLocator;
        Locator.CheckoutOneLocator checkoutOneLocator;
        Locator.CheckoutTwoLocator checkoutTwoLocator;
        Locator.NavigationBarLocator navigationBarLocator;

        Screen.LoginScreen loginScreen;
        Screen.CartScreen cartScreen;
        Screen.CheckoutOneScreen checkoutOneScreen;
        Screen.CheckoutTwoScreen checkoutTwoScreen;
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

            checkoutTwoLocator = new Locator.CheckoutTwoLocator(chromeDriver);
            checkoutTwoScreen = new Screen.CheckoutTwoScreen(checkoutTwoLocator);
        }

        [Test, Order(1)]
        [Category("Checkout Step Two Screen | Payment Information label is displayed")]
        public void TestCase_2401()
        {
            // GET PAYMENT INFORMATION DISPLAYED 
            bool paymentinformationDisplayed = checkoutTwoScreen.PaymentInformationDisplayed();

            // ASSERTION EXPECTED RESULT VS ACTUAL RESULT 
            Assert.IsTrue(paymentinformationDisplayed);
        }

        [Test, Order(2)]
        [Category("Checkout Step Two Screen | Payment Information label text is Payment Information")]
        public void TestCase_2402()
        {
            // GET PAYMENT INFORMATION TEXT
            string paymentInformationText = checkoutTwoScreen.PaymentInformationText();

            // EXPECTED RESULT
            string expectedresult = Expected.CheckoutTwoExpected.paymentInformationLabel;

            // ASSERTION PAYMENT INFORMATION TEXT
            Assert.That(paymentInformationText, Is.EqualTo(expectedresult));
        }

        [Test, Order(3)]
        [Category("Checkout Step Two Screen | SauceCard #31337 is displayed")]
        public void TestCase_2403()
        {
            // GET SAUCECARD #31337 IS DISPLAYED
            bool sauceCardDisplayed = checkoutTwoScreen.SauceCardDisplayed();

            // ASSERT SAUCECARD #31337 IS DISPLAYED
            Assert.IsTrue(sauceCardDisplayed);
        }

        [Test, Order(4)]
        [Category("Checkout Step Two Screen | Payment Information shows SauceCard #31337 as payment method")]
        public void TestCase_2404()
        {
            // GET SAUCE CARD TEXT 
            string saucecardText = checkoutTwoScreen.SauceCardText();

            // EXPECTED RESULT 
            string expectedresult = Expected.CheckoutTwoExpected.sauceCardLabel;

            // ASSERTION SAUCE CARD TEXT
            Assert.That(saucecardText, Is.EqualTo(expectedresult));
        }        

        [OneTimeTearDown]
        public void Teardown()
        {
            chromeDriver?.Dispose();
        }
    }
}