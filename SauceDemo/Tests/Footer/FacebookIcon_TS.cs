using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using SauceDemo.POM;

namespace SauceDemo.Tests.Footer
{
    [TestFixture]
    public class Scenario_39
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
        [Category("Footer | Facebook Icon is displayed")]
        public void TestCase_3901()
        {
            /* TEST CASE */
            string testcase = "3901 | Footer | Facebook Icon is displayed";

            /* GET FACEBOOK ICON IS DISPLAYED */
            Boolean facebookiconDisplayed = footer!.GetElementDisplayed(By.XPath(footer!.icon_facebook));

            /* EXPECTED RESULT */
            Boolean facebookicondisplayed = true;
            Boolean expectedresult = facebookicondisplayed;

            /* ACTUAL RESULT */
            Boolean actualresult = facebookiconDisplayed;

            /* PRINT EXPECTED RESULT VS ACTUAL RESULT */
            Console.WriteLine(testcase);
            Console.WriteLine();

            Console.WriteLine("Expected result: " + expectedresult);
            Console.WriteLine("Actual result: " + actualresult);

            /* ASSERT EXPECTED RESULT VS ACTUAL RESULT */
            Assert.That(actualresult, Is.EqualTo(expectedresult));
        }

        [Test, Order(2)]
        [Category("Footer | Facebook Icon is a link")]
        public void TestCase_3902()
        {
            /* TEST CASE */
            string testcase = "3902 | Footer | Facebook Icon is a link";

            /* GET FACEBOOK ICON TAG NAME */
            string facebookiconTagname = footer!.GetElementTagName(By.XPath(footer!.icon_facebook));

            /* EXPECTED RESULT */
            string facebookicontagname = "a";
            string expectedresult = facebookicontagname;

            /* ACTUAL RESULT */
            string actualresult = facebookiconTagname;

            /* PRINT EXPECTED RESULT VS ACTUAL RESULT */
            Console.WriteLine(testcase);
            Console.WriteLine();

            Console.WriteLine("Expected result: " + expectedresult);
            Console.WriteLine("Actual result: " + actualresult);

            /* ASSERT EXPECTED RESULT VS ACTUAL RESULT */
            Assert.That(actualresult, Is.EqualTo(expectedresult));
        }

        [Test, Order(3)]
        [Category("Footer | Facebook icon redirects to https://www.facebook.com/saucelabs")]
        public void TestCase_3903()
        {
            /* TEST CASE */
            string testcase = "3903 | Footer | Facebook icon redirects to https://www.facebook.com/saucelabs";

            /* CLICK FACEBOOK ICON */
            footer!.ClickElement(By.XPath(footer!.icon_facebook));

            /* SET BROWSER TABS */
            string maintab = driver!.WindowHandles[0];
            string newtab = driver!.WindowHandles[1];

            /* CHANGE TO FACEBOOK TAB */
            driver.SwitchTo().Window(newtab);

            /* GET SCREEN URL */
            string screenUrl = driver!.Url;

            /* EXPECTED RESULT */
            string screenurl = "https://www.facebook.com/saucelabs";
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