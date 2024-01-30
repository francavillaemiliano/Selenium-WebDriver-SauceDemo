using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using SauceDemo.Component;
using SauceDemo.Locator;

namespace SauceDemo.Tests.CheckoutOne
{
    [TestFixture]
    public class Scenario_17
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
        [Category("Checkout Step One Screen | Last Name field is displayed")]
        public void TestCase_1701()
        {
            // GET LAST NAME IS DISPLAYED 
            bool lastnameDisplayed = checkoutOneScreen.LastNameDisplayed();

            // ASSERTION LAST NAME IS DISPLAYED 
            Assert.IsTrue(lastnameDisplayed);
        }

        [Test, Order(2)]
        [Category("Checkout Step One Screen | Last Name field text is Last Name")]
        public void TestCase_1702()
        {
            // GET LAST NAME TEXT 
            string lastnameText = checkoutOneScreen.LastNameAttribute();

            // EXPECTED RESULT 
            string expectedresult = Expected.CheckoutOneExpected.lastName;

            // ASSERTION LAST NAME TEXT 
            Assert.That(lastnameText, Is.EqualTo(expectedresult));
        }

        [Test, Order(3)]
        [Category("Checkout Step One Screen | Last Name field tag element is Input")]
        public void TestCase_1703()
        {
            // GET LAST NAME TAG NAME 
            string lastnameTagname = checkoutOneScreen.LastNameTagName();

            // EXPECTED RESULT  
            string expectedresult = Expected.CheckoutOneExpected.inputTag;

            // ASSERTION LAST NAME TAG NAME 
            Assert.That(lastnameTagname, Is.EqualTo(expectedresult));
        }

        [Test, Order(4)]
        [Category("Checkout Step One Screen | Last Name field is editable")]
        public void TestCase_1704()
        {
            // GET LAST NAME IS ENABLED 
            bool lastnameEnabled = checkoutOneScreen.LastNameEnabled();

            // ASSERTION LAST NAME IS ENABLED 
            Assert.IsTrue(lastnameEnabled);
        }

        [Test, Order(5)]
        [Category("Checkout Step One Screen | Last Name field is required | First Name filled | Zip/Postal Code empty")]
        public void TestCase_1705()
        {
            // FILL IN FIRST NAME FIELD 
            checkoutOneScreen.FillInFirstName();

            // CLICK CONTINUE BUTTON 
            checkoutOneLocator.ContinueButton.Click();

            // GET ERROR MESSAGE 
            string errorMessage = checkoutOneScreen.RequiredFieldError();

            // EXPECTED RESULT 
            string expectedresult = Expected.CheckoutOneExpected.lastNameRequired;

            // ASSERTION ERROR MESSAGE 
            Assert.That(errorMessage, Is.EqualTo(expectedresult));
        }

        [Test, Order(6)]
        [Category("Checkout Step One Screen | Last Name field is required | First Name filled | Zip/Postal Code filled")]
        public void TestCase_1706()
        {
            // FILL IN FIRST NAME FIELD 
            checkoutOneScreen.CleanFirstName();
            checkoutOneScreen.FillInFirstName();

            // FILL IN ZIP/POSTAL CODE FIELD 
            checkoutOneScreen.FillInZipPostalCode();

            // CLICK CONTINUE BUTTON 
            checkoutOneLocator.ContinueButton.Click();

            // GET ERROR MESSAGE 
            string errorMessage = checkoutOneScreen.RequiredFieldError();

            // EXPECTED RESULT 
            string expectedresult = Expected.CheckoutOneExpected.lastNameRequired;

            // ASSERTION ERROR MESSAGE 
            Assert.That(errorMessage, Is.EqualTo(expectedresult));

            // CLEAN FIRST NAME & ZIP/POSTAL CODE 
            checkoutOneScreen.CleanFirstName();
            checkoutOneScreen.CleanZipPostalCode();
        }

        [Test, Order(7)]
        [Category("Checkout Step One Screen | Last Name field is required | First Name filled | Zip/Postal Code filled/cleaned")]
        public void TestCase_1707()
        {
            // FILL IN FIRST NAME FIELD 
            checkoutOneScreen.FillInFirstName();

            // FILL IN/CLEAN ZIP/POSTAL CODE FIELD 
            checkoutOneScreen.FillInZipPostalCode();
            checkoutOneScreen.CleanZipPostalCode();

            // CLICK CONTINUE BUTTON 
            checkoutOneLocator.ContinueButton.Click();

            // GET ERROR MESSAGE 
            string errorMessage = checkoutOneScreen.RequiredFieldError();

            // EXPECTED RESULT 
            string expectedresult = Expected.CheckoutOneExpected.lastNameRequired;

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