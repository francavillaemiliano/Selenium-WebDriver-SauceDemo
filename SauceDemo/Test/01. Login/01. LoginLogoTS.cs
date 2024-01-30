using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SauceDemo.Locator;
using SauceDemo.Screen;

namespace SauceDemo.Tests.Login
{
    [TestFixture]
    public class Scenario_01
    {
        IWebDriver chromeDriver;

        LoginScreen loginScreen;
        LoginLocator loginLocator;

        [OneTimeSetUp]
        public void Setup()
        {
            // DRIVER SETUP
            chromeDriver = new ChromeDriver();
            SetUp.Driver driver = new SetUp.Driver(chromeDriver);
            driver.DriverSetup();

            loginLocator = new LoginLocator(chromeDriver);
            loginScreen = new LoginScreen(loginLocator);
        }

        [Test, Order(1)]
        [Category("Login Screen | Login logo is displayed")]
        public void TestCase_0101()
        {
            // GET TITLE IS DISPLAYED
            bool titleDisplayed = loginScreen.LoginLogoDisplayed();

            // ASSERTION TITLE IS DISPLAYED
            Assert.IsTrue(titleDisplayed);
        }

        [Test, Order(2)]
        [Category("Login Screen | Login logo text is Swag Labs")]
        public void TestCase_0102()
        {
            // GET TITLE TEXT
            string titleText = loginScreen.LoginLogoText();

            // EXPECTED RESULT
            string expectedresult = Expected.LoginExpected.logoLogin;

            // ACTUAL RESULT
            string actualresult = titleText;

            // ASSERTION TITLE TEXT
            Assert.That(actualresult, Is.EqualTo(expectedresult));
        }

        [OneTimeTearDown]
        public void Teardown()
        {
            chromeDriver?.Dispose();
        }
    }
}