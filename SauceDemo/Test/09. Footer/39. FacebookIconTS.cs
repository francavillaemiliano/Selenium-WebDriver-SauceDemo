using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;

namespace SauceDemo.Tests.Footer
{
    [TestFixture]
    public class Scenario_39
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
        [Category("Footer | Facebook Icon is displayed")]
        public void TestCase_3901()
        {
            // GET FACEBOOK ICON IS DISPLAYED 
            bool facebookiconDisplayed = footerComponent.FacebookIconDisplayed();

            // ASSERTION FACEBOOK ICON IS DISPLAYED 
            Assert.IsTrue(facebookiconDisplayed);
        }

        [Test, Order(2)]
        [Category("Footer | Facebook Icon is a link")]
        public void TestCase_3902()
        {
            // GET FACEBOOK ICON TAG NAME 
            string facebookiconTagname = footerComponent.FacebookIconTagName();

            // EXPECTED RESULT 
            string expectedresult = Expected.FooterExpected.socialIconTagName;

            // ASSERTION FACEBOOK ICON TAG NAME 
            Assert.That(facebookiconTagname, Is.EqualTo(expectedresult));
        }

        [Test, Order(3)]
        [Category("Footer | Facebook icon redirects to https://www.facebook.com/saucelabs")]
        public void TestCase_3903()
        {
            // CLICK FACEBOOK ICON 
            footerLocator.FacebookIcon.Click();

            // SET BROWSER TABS 
            string maintab = chromeDriver!.WindowHandles[0];
            string newtab = chromeDriver!.WindowHandles[1];

            // CHANGE TO FACEBOOK TAB 
            chromeDriver.SwitchTo().Window(newtab);

            // GET SCREEN URL 
            string screenUrl = chromeDriver!.Url;

            // EXPECTED RESULT 
            string expectedresult = Expected.FooterExpected.facebookUrl;

            // ASSERTION SCREEN URL 
            Assert.That(screenUrl, Is.EqualTo(expectedresult));
        }

        [OneTimeTearDown]
        public void Teardown()
        {
            chromeDriver?.Dispose();
        }
    }
}