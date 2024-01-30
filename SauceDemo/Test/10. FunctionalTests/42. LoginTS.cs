using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;

namespace SauceDemo.Tests.FunctionalTests
{
    [TestFixture]
    public class Scenario_42
    {
        IWebDriver? chromeDriver;

        Locator.LoginLocator loginLocator;
        Locator.NavigationBarLocator? navigationBarLocator;

        Screen.LoginScreen loginScreen;
        Component.NavigationBarComponent? navigationBarComponent;
        
        [OneTimeSetUp]
        public void Setup()
        {
            /// DRIVER SETUP
            chromeDriver = new ChromeDriver();
            SetUp.Driver driver = new SetUp.Driver(chromeDriver);
            driver.DriverSetup();

            loginLocator = new Locator.LoginLocator(chromeDriver);
            loginScreen = new Screen.LoginScreen(loginLocator);            
        }

        [Test, Order(1)]
        [Category("Login | Standard User is able to access to website")]
        public void TestCase_4201()
        {
            // LOGIN STANDARD USER 
            loginScreen.LoginStandardUser();

            // SCREEN URL 
            string screenUrl = chromeDriver!.Url;

            // EXPECTED RESULT 
            string expectedresult = Expected.UrlExpected.inventory;

            // ASSERTION SCREEN URL 
            Assert.That(screenUrl, Is.EqualTo(expectedresult));

            // LOGOUT USER 
            navigationBarLocator = new Locator.NavigationBarLocator(chromeDriver);
            navigationBarComponent = new Component.NavigationBarComponent(chromeDriver, navigationBarLocator);
            navigationBarComponent.LogoutUser();
        }

        [Test, Order(2)]
        [Category("Login | Locked user is not able to access to website")]
        public void TestCase_4202()
        {
            // LOGIN LOCKED OUT USER
            loginScreen.LoginLockedoutUser();

            // GET ERROR MESSAGE 
            string errorMessage = loginScreen.LoginErrorMessage();

            // EXPECTED RESULT 
            string expectedresult = Expected.LoginExpected.lockedOutUserLoginError;

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