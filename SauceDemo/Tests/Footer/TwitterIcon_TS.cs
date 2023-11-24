using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using SauceDemo.POM;

namespace SauceDemo.Tests.Footer
{
    [TestFixture]
    public class Scenario_38
    {
        IWebDriver? driver;
        Login_POM? loginscreen;
        Footer_POM? footer;

        string baseurl = "https://www.saucedemo.com/";

        [OneTimeSetUp]
        public void Setup()
        {
            /* DRIVER INITIALIZATION */
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl(baseurl);
            driver.Manage().Window.FullScreen();

            /* LOGIN USER */
            loginscreen = new Login_POM(driver);
            loginscreen.LoginUser(loginscreen!.standarduser, loginscreen!.secretsauce);

            footer = new Footer_POM(driver);
        }

        [Test, Order(1)]
        [Category("Footer | Twitter Icon is displayed")]
        public void TestCase_3801()
        {
            /* TEST CASE */
            string testcase = "3801 | Footer | Twitter Icon is displayed";

            /* GET TWITTER ICON IS DISPLAYED */
            Boolean twittericonDisplayed = footer!.GetElementDisplayed(By.XPath(footer!.icon_twitter));

            /* EXPECTED RESULT */
            Boolean twittericondisplayed = true;
            Boolean expectedresult = twittericondisplayed;

            /* ACTUAL RESULT */
            Boolean actualresult = twittericonDisplayed;

            /* PRINT EXPECTED RESULT VS ACTUAL RESULT */
            Console.WriteLine(testcase);
            Console.WriteLine();

            Console.WriteLine("Expected result: " + expectedresult);
            Console.WriteLine("Actual result: " + actualresult);

            /* ASSERT EXPECTED RESULT VS ACTUAL RESULT */
            Assert.That(actualresult, Is.EqualTo(expectedresult));
        }

        [Test, Order(2)]
        [Category("Footer | Twitter Icon is a link")]
        public void TestCase_3802()
        {
            /* TEST CASE */
            string testcase = "3802 | Footer | Twitter Icon is a link";

            /* GET TWITTER ICON TAG NAME */
            string twittericonTagname = footer!.GetElementTagName(By.XPath(footer!.icon_twitter));

            /* EXPECTED RESULT */
            string twittericontagname = "a";
            string expectedresult = twittericontagname;

            /* ACTUAL RESULT */
            string actualresult = twittericonTagname;

            /* PRINT EXPECTED RESULT VS ACTUAL RESULT */
            Console.WriteLine(testcase);
            Console.WriteLine();

            Console.WriteLine("Expected result: " + expectedresult);
            Console.WriteLine("Actual result: " + actualresult);

            /* ASSERT EXPECTED RESULT VS ACTUAL RESULT */
            Assert.That(actualresult, Is.EqualTo(expectedresult));
        }

        [Test, Order(3)]
        [Category("Footer | Twitter icon redirects to https://twitter.com/saucelabs")]
        public void TestCase_3803()
        {
            /* TEST CASE */
            string testcase = "3803 | Footer | Twitter icon redirects to https://twitter.com/saucelabs";

            /* CLICK TWITTER ICON */
            footer!.ClickElement(By.XPath(footer!.icon_twitter));

            /* SET BROWSER TABS */
            string maintab = driver!.WindowHandles[0];
            string newtab = driver!.WindowHandles[1];

            /* CHANGE TO TWITTER TAB */
            driver.SwitchTo().Window(newtab);

            /* GET SCREEN URL */
            string screenUrl = driver!.Url;

            /* EXPECTED RESULT */
            string screenurl = "https://twitter.com/saucelabs";
            string expectedresult = screenurl;

            /* ACTUAL RESULT */
            string actualresult = screenUrl;

            /* PRINT EXPECTED RESULT VS ACTUAL RESULT */
            Console.WriteLine(testcase);
            Console.WriteLine();

            Console.WriteLine("Expected result: " + expectedresult);
            Console.WriteLine("Actual result: " + actualresult);

            /* ASSERT EXPECTED RESULT VS ACTUAL RESULT */
            Assert.That(actualresult, Is.EqualTo(expectedresult));
        }

            [OneTimeTearDown]
        public void Teardown()
        {
            driver?.Dispose();
        }
    }
}