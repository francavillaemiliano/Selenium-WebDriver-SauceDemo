using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SauceDemo.Tests.Login
{
    [TestFixture]
    public class Scenario_03
    {
        IWebDriver chromeDriver;

        Locator.LoginLocator loginLocator;
        Screen.LoginScreen loginScreen;

        [OneTimeSetUp]
        public void Setup()
        {
            // DRIVER SETUP
            chromeDriver = new ChromeDriver();
            SetUp.Driver driver = new SetUp.Driver(chromeDriver);
            driver.DriverSetup();

            loginLocator = new Locator.LoginLocator(chromeDriver);
            loginScreen = new Screen.LoginScreen(loginLocator);
        }

        [Test, Order(1)]
        [Category("Login Screen | Password is displayed")]
        public void TestCase_0301()
        {
            // GET PASSWORD IS DISPLAYED
            bool passwordDisplayed = loginScreen.PasswordDisplayed();

            // ASSERTION PASSWORD IS DISPLAYED
            Assert.IsTrue(passwordDisplayed);
        }

        [Test, Order(2)]
        [Category("Login Screen | Password text is Password")]
        public void TestCase_0302()
        {
            // GET PASSWORD TEXT 
            string passwordText = loginScreen.PasswordAttribute();

            // EXPECTED RESULT 
            string expectedresult = Expected.LoginExpected.placeholderPassword;

            // ASSERTION PASSWORD TEXT 
            Assert.That(passwordText, Is.EqualTo(expectedresult));
        }

        [Test, Order(3)]
        [Category("Login Screen | Password tag name is Input")]
        public void TestCase_0303()
        {
            // GET PASSWORD TAG NAME 
            string passwordTagname = loginScreen.PasswordTagName();

            // EXPECTED RESULT  
            string expectedresult = Expected.LoginExpected.tagNameInput;

            // ASSERTION PASSWORD TAG NAME 
            Assert.That(passwordTagname, Is.EqualTo(expectedresult));
        }

        [Test, Order(4)]
        [Category("Login Screen | Password is editable")]
        public void TestCase_0304()
        {
            // GET PASSWORD IS ENABLED 
            bool passwordEnabled = loginScreen.PasswordEnabled();

            // ASSERTION PASSWORD IS ENABLED
            Assert.IsTrue(passwordEnabled);
        }

        [Test, Order(5)]
        [Category("Login Screen | Password is required | Username filled | Password empty")]
        public void TestCase_0305()
        {
            // FILL IN USERNAME 
            loginScreen.FillInUsername();

            // CLICK LOGIN BUTTON 
            loginScreen.ClickLoginButton();

            // GET ERROR MESSAGE 
            string errormessageText = loginScreen.LoginErrorMessage();

            // EXPECTED RESULT 
            string expectedresult = Expected.LoginExpected.RequiredErrorPassword;

            // ASSERTION ERROR MESSAGE 
            Assert.That(errormessageText, Is.EqualTo(expectedresult));
        }

        [Test, Order(6)]
        [Category("Login Screen | Password is required | Password filled/cleaned")]
        public void TestCase_0306()
        {
            // FILL IN/CLEAN PASSWORD 
            loginScreen.FillInPassword();
            loginScreen.CleanPassword();

            // CLICK LOGIN BUTTON 
            loginScreen.ClickLoginButton();

            // GET ERROR MESSAGE 
            string errormessageText = loginScreen.LoginErrorMessage();

            // EXPECTED RESULT 
            string expectedresult = Expected.LoginExpected.RequiredErrorPassword;

            // ASSERTION ERROR MESSAGE
            Assert.That(errormessageText, Is.EqualTo(expectedresult));
        }

        [OneTimeTearDown]
        public void Teardown()
        {
            chromeDriver?.Dispose();
        }
    }
}