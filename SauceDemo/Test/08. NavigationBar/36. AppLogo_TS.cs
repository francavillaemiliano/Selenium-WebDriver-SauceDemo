using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;

namespace SauceDemo.Tests.NavigationBar
{
    [TestFixture]
    public class Scenario_36
    {
        IWebDriver? chromeDriver;

        Locator.LoginLocator loginLocator;
        Locator.NavigationBarLocator navigationBarLocator;

        Screen.LoginScreen loginScreen;
        Component.NavigationBarComponent navigationBar;

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

            navigationBarLocator = new Locator.NavigationBarLocator(chromeDriver);
            navigationBar = new Component.NavigationBarComponent(chromeDriver, navigationBarLocator);
        }

        [Test, Order(1)]
        [Category("Navigation Bar | App Logo is displayed")]
        public void TestCase_3601()
        {
            // GET APP LOGO IS DISPLAYED 
            bool applogoDisplayed = navigationBar.AppLogoDisplayed();

            // ASSERTION APP LOGO IS DISPLAYED 
            Assert.IsTrue(applogoDisplayed);
        }
        [Test, Order(2)]
        [Category("Navigation Bar | App Logo text is Swag Labs")]
        public void TestCase_3602()
        {
            // GET APP LOGO TEXT 
            string applogoText = navigationBar.AppLogoText();

            // EXPECTED RESULT 
            string expectedresult = Expected.NavigationBarExpected.appLogoText;

            // ASSERTION APP LOGO TEXT 
            Assert.That(applogoText, Is.EqualTo(expectedresult));
        }


        [OneTimeTearDown]
        public void Teardown()
        {
            chromeDriver?.Dispose();
        }
    }
}