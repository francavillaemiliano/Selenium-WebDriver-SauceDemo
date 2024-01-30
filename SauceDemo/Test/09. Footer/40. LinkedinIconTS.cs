using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;

namespace SauceDemo.Tests.Footer
{
    [TestFixture]
    public class Scenario_40
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
        [Category("Footer | Linkedin Icon is displayed")]
        public void TestCase_4001()
        {
            // GET LINKEDIN ICON IS DISPLAYED 
            bool linkediniconDisplayed = footerComponent.LinkedinIconDisplayed();

            // ASSERTION LINKEDIN ICON IS DISPLAYED 
            Assert.IsTrue(linkediniconDisplayed);
        }

        [Test, Order(2)]
        [Category("Footer | Linkedin Icon is a link")]
        public void TestCase_4002()
        {
            // GET LINKEDIN ICON TAG NAME 
            string linkediniconTagname = footerComponent.LinkedinIconTagName();

            // EXPECTED RESULT 
            string expectedresult = Expected.FooterExpected.socialIconTagName;

            // ASSERTION LINKEDIN ICON TAG NAME 
            Assert.That(linkediniconTagname, Is.EqualTo(expectedresult));
        }

        [Test, Order(3)]
        [Category("Footer | Linkedin icon redirects to https://www.linkedin.com/company/sauce-labs/")]
        public void TestCase_4003()
        {
            // CLICK LINKEDIN ICON 
            footerLocator.LinkedinIcon.Click();

            // SET BROWSER TABS 
            string maintab = chromeDriver!.WindowHandles[0];
            string newtab = chromeDriver!.WindowHandles[1];

            // CHANGE TO LINKEDIN TAB 
            chromeDriver.SwitchTo().Window(newtab);

            // GET SCREEN URL 
            string screenUrl = chromeDriver!.Url;

            // EXPECTED RESULT 
            string expectedresult = Expected.FooterExpected.linkedinUrl;

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