using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using SauceDemo.Component;
using SauceDemo.Locator;

namespace SauceDemo.Tests.CheckoutOne
{
    [TestFixture]
    public class Scenario_18
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
        [Category("Checkout Step One Screen | Zip/Postal Code field is displayed")]
        public void TestCase_1801()
        {
            // GET ZIP/POSTAL CODE DISPLAYED 
            bool postalcodeDisplayed = checkoutOneScreen.ZipPostalCodeDisplayed();

            // ASSERTION ZIP/POSTAL CODE DISPLAYED 
            Assert.IsTrue(postalcodeDisplayed);
        }

        [Test, Order(2)]
        [Category("Checkout Step One Screen | Zip/Postal Code text is Zip/Postal Code")]
        public void TestCase_1802()
        {
            // GET ZIP/POSTAL CODE TEXT 
            string postalcodeText = checkoutOneScreen.ZipPostalCodeAttribute();

            // EXPECTED RESULT
            string expectedresult = Expected.CheckoutOneExpected.zipPostalCode;

            // ASSERTION ZIP/POSTAL CODE TEXT 
            Assert.That(postalcodeText, Is.EqualTo(expectedresult));
        }

        [Test, Order(3)]
        [Category("Checkout Step One Screen | Zip/Postal Code field tag name is Input")]
        public void TestCase_1803()
        {
            // GET ZIP/POSTAL CODE TAG NAME 
            string postalcodeTagname = checkoutOneScreen.ZipPostalCodeTagName();

            // EXPECTED RESULT  
            string expectedresult = Expected.CheckoutOneExpected.inputTag;

            // ASSERTION ZIP/POSTAL CODE TAG NAME 
            Assert.That(postalcodeTagname, Is.EqualTo(expectedresult));
        }

        [Test, Order(4)]
        [Category("Checkout Step One Screen | Zip/Postal Code field is editable")]
        public void TestCase_1804()
        {
            // GET ZIP/POSTAL CODE IS ENABLED 
            bool postalcodeEnabled = checkoutOneScreen.ZipPostalCodeEnabled();

            // ASSERTION ZIP/POSTAL CODE IS ENABLED 
            Assert.IsTrue(postalcodeEnabled);
        }

        [Test, Order(5)]
        [Category("Checkout Step One Screen | Zip/Postal Code field is required | First Name filled | Last Name filled")]
        public void TestCase_1805()
        {
            // FILL IN FIRST NAME FIELD 
            checkoutOneScreen.FillInFirstName();

            // FILL IN LAST NAME FIELD 
            checkoutOneScreen.FillInLastName();

            // CLICK CONTINUE BUTTON 
            checkoutOneLocator.ContinueButton.Click();

            // GET ERROR MESSAGE 
            string errorMessage = checkoutOneScreen.RequiredFieldError();

            // EXPECTED RESULT 
            string expectedresult = Expected.CheckoutOneExpected.zipPostalCodeRequired;

            // ASSERTION ERROR MESSAGE 
            Assert.That(errorMessage, Is.EqualTo(expectedresult));

            // CLEAN FIRST NAME & LAST NAME FIELDS 
            checkoutOneScreen.CleanFirstName();
            checkoutOneScreen.CleanLastName();
        }

        [Test, Order(6)]
        [Category("Checkout Step One Screen | Zip/Postal Code field is required | First Name filled | Last Name filled | Zip/Postal Code filled/Cleaned")]
        public void TestCase_1806()
        {
            // FILL IN FIRST NAME FIELD 
            checkoutOneScreen.FillInFirstName();

            // FILL IN LAST NAME FIELD 
            checkoutOneScreen.FillInLastName();

            // FILL IN/CLEAN ZIP7POSTAL CODE FIELD 
            checkoutOneScreen.FillInZipPostalCode();
            checkoutOneScreen.CleanZipPostalCode();

            // CLICK CONTINUE BUTTON 
            checkoutOneLocator.ContinueButton.Click();

            // GET ERROR MESSAGE 
            string errorMessage = checkoutOneScreen.RequiredFieldError();

            // EXPECTED RESULT 
            string expectedresult = Expected.CheckoutOneExpected.zipPostalCodeRequired;

            // ASSERTION ERROR MESSAGE 
            Assert.That(errorMessage, Is.EqualTo(expectedresult));
        }
        [OneTimeTearDown]
        public void Teardown()
        {
            chromeDriver?.Dispose();
        }
    }
}