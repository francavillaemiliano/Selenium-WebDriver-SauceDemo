using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SauceDemo.Tests.Login
{
    [TestFixture]
    public class Scenario_02
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
        [Category("Login Screen | Username is displayed")]
        public void TestCase_0201()
        {
            // GET USERNAME IS DISPLAYED 
            bool usernameDisplayed = loginScreen.UsernameDisplayed();

            // ASSERTION USERNAME IS DISPLAYED
            Assert.IsTrue(usernameDisplayed);
        }

        [Test, Order(2)]
        [Category("Login Screen | Username text is Username")]
        public void TestCase_0202()
        {
            // GET USERNAME TEXT 
            string usernameText = loginScreen.UsernameAttribute();

            // EXPECTED RESULT 
            string expectedresult = Expected.LoginExpected.placeholderUsername;

            // ASSERTION USERNAME TEXT 
            Assert.That(usernameText, Is.EqualTo(expectedresult));
        }

        [Test, Order(3)]
        [Category("Login Screen | Username tag name is Input")]
        public void TestCase_0203()
        {
            // GET USERNAME TAG NAME 
            string usernameTagName = loginScreen.UsernameTagName();

            // EXPECTED RESULT  
            string expectedresult = Expected.LoginExpected.tagNameInput;

            // ASSERTION USERNAME TAG NAME 
            Assert.That(usernameTagName, Is.EqualTo(expectedresult));
        }

        [Test, Order(4)]
        [Category("Login Screen | Username is editable")]
        public void TestCase_0204()
        {
            // GET USERNAME IS ENABLED 
            bool usernameEnabled = loginScreen.UsernameEnabled();

            // ASSERTION USERNAME IS ENABLED 
            Assert.IsTrue(usernameEnabled);
        }

        [Test, Order(5)]
        [Category("Login Screen | Username is required | Username empty | Password empty")]
        public void TestCase_0205()
        {
            // CLICK LOGIN BUTTON 
            loginScreen.ClickLoginButton();

            // GET ERROR MESSAGE 
            string errormessageText = loginScreen.LoginErrorMessage();

            // EXPECTED RESULT 
            string expectedresult = Expected.LoginExpected.RequiredErrorUsername;

            // ASSERTION ERROR MESSAGE 
            Assert.That(errormessageText, Is.EqualTo(expectedresult));
        }

        [Test, Order(6)]
        [Category("Login Screen | Username is required | Username filled/cleaned")]
        public void TestCase_0206()
        {
            // FILL IN/CLEAN USERNAME 
            loginScreen.FillInUsername();
            loginScreen.CleanUsername();

            // CLICK LOGIN BUTTON 
            loginScreen.ClickLoginButton();

            // GET ERROR MESSAGE 
            string errormessageText = loginScreen.LoginErrorMessage();

            // EXPECTED RESULT 
            string expectedresult = Expected.LoginExpected.RequiredErrorUsername;

            // ASSERTION ERROR MESSAGE 
            Assert.That(errormessageText, Is.EqualTo(expectedresult));
        }

        [Test, Order(7)]
        [Category("Login Screen | Username is required | Password filled/cleaned")]
        public void TestCase_0207()
        {
            // FILL IN/CLEAN PASSWORD 
            loginScreen.FillInPassword();
            loginScreen.CleanPassword();

            // CLICK LOGIN BUTTON 
            loginScreen.ClickLoginButton();

            // GET ERROR MESSAGE 
            string errormessageText = loginScreen.LoginErrorMessage();

            // EXPECTED RESULT  
            string expectedresult = Expected.LoginExpected.RequiredErrorUsername;

            // ASSERTION ERROR MESSAGE 
            Assert.That(errormessageText, Is.EqualTo(expectedresult));
        }

        [Test, Order(8)]
        [Category("Login Screen | Username is required | Username filled/cleaned | Password filled/cleaned")]
        public void TestCase_0208()
        {
            // FILL IN/CLEAN USERNAME 
            loginScreen.FillInUsername();
            loginScreen.CleanUsername();

            // FILL IN/CLEAN PASSWORD 
            loginScreen.FillInPassword();
            loginScreen.CleanPassword();

            // CLICK LOGIN BUTTON 
            loginScreen.ClickLoginButton();

            // GET ERROR MESSAGE 
            string errormessageText = loginScreen.LoginErrorMessage();

            // EXPECTED RESULT 
            string expectedresult = Expected.LoginExpected.RequiredErrorUsername;

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