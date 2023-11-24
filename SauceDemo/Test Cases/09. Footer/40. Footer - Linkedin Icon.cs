using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;

namespace Swag_Labs
{
    [TestFixture]
    public class Scenario_40
    {
        IWebDriver? driver;
        LoginScreen? loginscreen;
        Footer? footer;

        string baseurl = "https://www.saucedemo.com/";

        [OneTimeSetUp]
        public void Setup()
        {
            /* DRIVER INITIALIZATION */
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl(baseurl);
            driver.Manage().Window.FullScreen();

            /* LOGIN USER */
            loginscreen = new LoginScreen(driver);
            loginscreen.LoginUser(loginscreen!.standarduser, loginscreen!.secretsauce);

            footer = new Footer(driver);
        }

        [Test, Order(1)]
        [Category("Footer | Linkedin Icon is displayed")]
        public void TestCase_4001()
        {
            /* TEST CASE */
            string testcase = "4001 | Footer | Linkedin Icon ";

            /* GET LINKEDIN ICON IS DISPLAYED */
            Boolean linkediniconDisplayed = footer!.GetElementDisplayed(By.XPath(footer!.icon_linkedin));

            /* EXPECTED RESULT */
            Boolean linkedinicondisplayed = true;
            Boolean expectedresult = linkedinicondisplayed;

            /* ACTUAL RESULT */
            Boolean actualresult = linkediniconDisplayed;

            /* PRINT EXPECTED RESULT VS ACTUAL RESULT */
            Console.WriteLine(testcase);
            Console.WriteLine();

            Console.WriteLine("Expected result: " + expectedresult);
            Console.WriteLine("Actual result: " + actualresult);

            /* ASSERT EXPECTED RESULT VS ACTUAL RESULT */
            Assert.That(actualresult, Is.EqualTo(expectedresult));
        }

        [Test, Order(2)]
        [Category("Footer | Linkedin Icon is a link")]
        public void TestCase_4002()
        {
            /* TEST CASE */
            string testcase = "4002 | Footer | Linkedin Icon is a link";

            /* GET LINKEDIN ICON TAG NAME */
            string linkediniconTagname = footer!.GetElementTagName(By.XPath(footer!.icon_linkedin));

            /* EXPECTED RESULT */
            string linkedinicontagname = "a";
            string expectedresult = linkedinicontagname;

            /* ACTUAL RESULT */
            string actualresult = linkediniconTagname;

            /* PRINT EXPECTED RESULT VS ACTUAL RESULT */
            Console.WriteLine(testcase);
            Console.WriteLine();

            Console.WriteLine("Expected result: " + expectedresult);
            Console.WriteLine("Actual result: " + actualresult);

            /* ASSERT EXPECTED RESULT VS ACTUAL RESULT */
            Assert.That(actualresult, Is.EqualTo(expectedresult));
        }

        [Test, Order(3)]
        [Category("Footer | Linkedin icon redirects to https://www.linkedin.com/company/sauce-labs/")]
        public void TestCase_4003()
        {
            /* TEST CASE */
            string testcase = "4003 | Footer | Linkedin icon redirects to https://www.linkedin.com/company/sauce-labs/";

            /* CLICK LINKEDIN ICON */
            footer!.ClickElement(By.XPath(footer!.icon_linkedin));

            /* SET BROWSER TABS */
            string maintab = driver!.WindowHandles[0];
            string newtab = driver!.WindowHandles[1];

            /* CHANGE TO LINKEDIN TAB */
            driver.SwitchTo().Window(newtab);

            /* GET SCREEN URL */
            string screenUrl = driver!.Url;

            /* EXPECTED RESULT */
            string screenurl = "https://www.linkedin.com/company/sauce-labs/";
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