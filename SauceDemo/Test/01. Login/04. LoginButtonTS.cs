using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SauceDemo.Locator;
using SauceDemo.Screen;

namespace SauceDemo.Tests.Login
{
    [TestFixture]
    public class Scenario_04
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
        [Category("Login Screen | Login Button is displayed")]
        public void TestCase_0401()
        {
            // GET LOGIN BUTTON IS DISPLAYED
            bool loginbuttonDisplayed = loginScreen.LoginButtonDisplayed();

            // ASSERTION LOGIN BUTTON IS DISPLAYED
            Assert.IsTrue(loginbuttonDisplayed);
        }

        [Test, Order(2)]
        [Category("Login Screen | Login Button text is Login")]
        public void TestCase_0402()
        {
            // GET LOGIN BUTTON TEXT
            string loginbuttonText = loginScreen.LoginButtonAttribute();

            // EXPECTED RESULT
            string expectedresult = Expected.LoginExpected.buttonLogin;

            // ASSERTION LOGIN BUTTON TEXT
            Assert.That(loginbuttonText, Is.EqualTo(expectedresult));
        }

        [OneTimeTearDown]
        public void Teardown()
        {
            chromeDriver?.Dispose();
        }
    }
}