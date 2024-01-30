using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;

namespace SauceDemo.Tests.Footer
{
    [TestFixture]
    public class Scenario_41
    {
        IWebDriver? chromeDriver;

        Locator.LoginLocator loginLocator;
        Locator.FooterLocator footerLocator;

        Screen.LoginScreen loginScreen;
        Component.FooterComponent footerComponent;

        [OneTimeSetUp]
        public void Setup()
        {
            /// DRIVER SETUP
            chromeDriver = new ChromeDriver();
            SetUp.Driver driver = new SetUp.Driver(chromeDriver);
            driver.DriverSetup();

            // LOGIN USER
            loginLocator = new Locator.LoginLocator(chromeDriver);
            loginScreen = new Screen.LoginScreen(loginLocator);
            loginScreen.LoginStandardUser();

            footerLocator = new Locator.FooterLocator(chromeDriver);
            footerComponent = new Component.FooterComponent(footerLocator);
        }

        [Test, Order(1)]
        [Category("Footer | Copyright is displayed")]
        public void TestCase_4101()
        {
            // GET COPYRIGHT IS DISPLAYED 
            bool copyrightDisplayed = footerComponent.CopyrightDisplayed();

            // ASSERTION COPYRIGHT IS DISPLAYED 
            Assert.IsTrue(copyrightDisplayed);
        }

        [Test, Order(2)]
        [Category("Footer | Copyright text is © 2024 Sauce Labs. All Rights Reserved. Terms of Service | Privacy Policy")]
        public void TestCase_4102()
        {
            // GET COPYRIGHT TEXT 
            string copyrightText = footerComponent.CopyrightText();

            // EXPECTED RESULT 
            string expectedresult = Expected.FooterExpected.copyrightText;

            // ASSERTION COPYRIGHT TEXT 
            Assert.That(copyrightText, Is.EqualTo(expectedresult));
        }
        [OneTimeTearDown]
        public void Teardown()
        {
            chromeDriver?.Dispose();
        }
    }
}