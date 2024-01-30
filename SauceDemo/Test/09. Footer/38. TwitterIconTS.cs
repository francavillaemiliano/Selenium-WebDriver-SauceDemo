using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;

namespace SauceDemo.Tests.Footer
{
    [TestFixture]
    public class Scenario_38
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
        [Category("Footer | Twitter Icon is displayed")]
        public void TestCase_3801()
        {
            // GET TWITTER ICON IS DISPLAYED 
            bool twittericonDisplayed = footerComponent.TwitterIconDisplayed();

            // ASSERTION TWITTER ICON IS DISPLAYED 
            Assert.IsTrue(twittericonDisplayed);
        }

        [Test, Order(2)]
        [Category("Footer | Twitter Icon is a link")]
        public void TestCase_3802()
        {
            // GET TWITTER ICON TAG NAME 
            string twittericonTagname = footerComponent.TwitterIconTagName();

            // EXPECTED RESULT 
            string expectedresult = Expected.FooterExpected.socialIconTagName;

            // ASSERTION TWITTER ICON TAG NAME 
            Assert.That(twittericonTagname, Is.EqualTo(expectedresult));
        }

        [Test, Order(3)]
        [Category("Footer | Twitter icon redirects to https://twitter.com/saucelabs")]
        public void TestCase_3803()
        {
            // CLICK TWITTER ICON 
            footerLocator.TwitterIcon.Click();

            // SET BROWSER TABS 
            string maintab = chromeDriver!.WindowHandles[0];
            string newtab = chromeDriver.WindowHandles[1];

            // CHANGE TO TWITTER TAB 
            chromeDriver.SwitchTo().Window(newtab);

            // GET SCREEN URL 
            string screenUrl = chromeDriver.Url;

            // EXPECTED RESULT 
            string expectedresult = Expected.FooterExpected.twitterUrl;

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