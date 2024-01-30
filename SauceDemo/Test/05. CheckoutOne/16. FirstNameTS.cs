using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using SauceDemo.Component;
using SauceDemo.Locator;

namespace SauceDemo.Tests.CheckoutOne
{
    [TestFixture]
    public class Scenario_16
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
        [Category("Checkout Step One Screen | First Name field is displayed")]
        public void TestCase_1601()
        {
            // GET FIRST NAME IS DISPLAYED 
            bool firstnameDisplayed = checkoutOneScreen.FirstNameDisplayed();

            // ASSERTION FIRST NAME IS DISPLAYED 
            Assert.IsTrue(firstnameDisplayed);
        }

        [Test, Order(2)]
        [Category("Checkout Step One Screen | First Name field text is First Name")]
        public void TestCase_1602()
        {
            // GET FIRST NAME FIELD TEXT 
            string firstnameText = checkoutOneScreen.FirstNameAttribute();

            // EXPECTED RESULT 
            string expectedresult = Expected.CheckoutOneExpected.firstName;

            // ASSERTION FIRST NAME FIELD TEXT 
            Assert.That(firstnameText, Is.EqualTo(expectedresult));
        }

        [Test, Order(3)]
        [Category("Checkout Step One Screen | First Name field tag name is Input")]
        public void TestCase_1603()
        {
            // GET FIRST NAME FIELD TAG NAME 
            string firstnameTagname = checkoutOneScreen.FirstNameTagName();

            // EXPECTED RESULT  
            string expectedresult = Expected.CheckoutOneExpected.inputTag;

            // ASSERTION FIRST NAME FIELD TAG NAME 
            Assert.That(firstnameTagname, Is.EqualTo(expectedresult));
        }

        [Test, Order(4)]
        [Category("Checkout Step One Screen | First Name field is editable")]
        public void TestCase_1604()
        {
            // GET FIRST NAME IS ENABLED 
            bool firstnameEnabled = checkoutOneScreen.FirstNameEnabled();

            // ASSERTION FIRST NAME IS ENABLED 
            Assert.IsTrue(firstnameEnabled);
        }

        [Test, Order(5)]
        [Category("Checkout Step One Screen | First Name field is required | Last Name empty | Zip/Postal Code empty")]
        public void TestCase_1605()
        {
            // CLICK CONTINUE BUTTON 
            checkoutOneLocator.ContinueButton.Click();

            // GET ERROR MESSAGE 
            string errorMessage = checkoutOneScreen.RequiredFieldError();

            // EXPECTED RESULT 
            string expectedresult = Expected.CheckoutOneExpected.firstNameRequired;

            // ASSERTION ERROR MESSAGE 
            Assert.That(errorMessage, Is.EqualTo(expectedresult));
        }

        [Test, Order(6)]
        [Category("Checkout Step One Screen | First Name field is required | Last Name filled | Zip/Postal Code empty")]
        public void TestCase_1606()
        {
            // FILL IN LAST NAME 
            checkoutOneScreen.FillInLastName();

            // CLICK CONTINUE BUTTON 
            checkoutOneLocator.ContinueButton.Click();

            // GET ERROR MESSAGE 
            string errorMessage = checkoutOneScreen.RequiredFieldError();

            // EXPECTED RESULT 
            string expectedresult = Expected.CheckoutOneExpected.firstNameRequired;

            // ASSERTION ERROR MESSAGE 
            Assert.That(errorMessage, Is.EqualTo(expectedresult));

            // CLEAN LAST NAME 
            checkoutOneScreen.CleanLastName();
        }

        [Test, Order(7)]
        [Category("Checkout Step One Screen | First Name field is required | Last Name empty | Zip/Postal Code filled")]
        public void TestCase_1607()
        {
            // FILL IN ZIP/POSTAL CODE FIELD 
            checkoutOneScreen.FillInZipPostalCode();

            // CLICK CONTINUE BUTTON 
            checkoutOneLocator.ContinueButton.Click();

            // GET ERROR MESSAGE 
            string errorMessage = checkoutOneScreen.RequiredFieldError();

            // EXPECTED RESULT 
            string expectedresult = Expected.CheckoutOneExpected.firstNameRequired;

            // ASSERTION ERROR MESSAGE 
            Assert.That(errorMessage, Is.EqualTo(expectedresult));

            // CLEAN ZIP/POSTAL CODE FIELD 
            checkoutOneScreen.CleanZipPostalCode();
        }

        [Test, Order(8)]
        [Category("Checkout Step One Screen | First Name field is required | Last Name filled | Zip/Postal Code filled")]
        public void TestCase_1608()
        {
            // FILL IN LAST NAME FIELD 
            checkoutOneScreen.FillInLastName();

            // FILL IN ZIP/POSTAL CODE FIELD 
            checkoutOneScreen.FillInZipPostalCode();

            // CLICK CONTINUE BUTTON 
            checkoutOneLocator.ContinueButton.Click();

            // GET ERROR MESSAGE 
            string errorMessage = checkoutOneScreen.RequiredFieldError();

            // EXPECTED RESULT 
            string expectedresult = Expected.CheckoutOneExpected.firstNameRequired;

            // ASSERTION ERROR MESSAGE 
            Assert.That(errorMessage, Is.EqualTo(expectedresult));

            // CLEAN LAST NAME & ZIP/POSTAL CODE 
            checkoutOneScreen.CleanLastName();
            checkoutOneScreen.CleanZipPostalCode();
        }

        [Test, Order(9)]
        [Category("Checkout Step One Screen | First Name field is required | Last Name filled/cleaned | Zip/Postal Code filled/cleaned")]
        public void TestCase_1609()
        {
            // FILL IN/CLEAN LAST NAME FIELD 
            checkoutOneScreen.FillInLastName();
            checkoutOneScreen.CleanLastName();

            // FILL IN/CLEAN ZIP/POSTAL CODE FIELD 
            checkoutOneScreen.FillInZipPostalCode();
            checkoutOneScreen.CleanZipPostalCode();

            // CLICK CONTINUE BUTTON 
            checkoutOneLocator.ContinueButton.Click();

            // GET ERROR MESSAGE 
            string errorMessage = checkoutOneScreen.RequiredFieldError();

            // EXPECTED RESULT 
            string expectedresult = Expected.CheckoutOneExpected.firstNameRequired;

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