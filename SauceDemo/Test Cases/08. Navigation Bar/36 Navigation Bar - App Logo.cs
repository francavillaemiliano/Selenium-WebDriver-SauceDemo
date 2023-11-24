using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;

namespace Swag_Labs
{
    [TestFixture]
    public class Scenario_36
    {
        IWebDriver? driver;
        LoginScreen? loginscreen;
        NavigationBar? navigationbar;

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

            navigationbar = new NavigationBar(driver);
        }

        [Test, Order(1)]
        [Category("Navigation Bar | App Logo is displayed")]
        public void TestCase_3601()
        {
            /* TEST CASE */
            string testcase = "3601 | Navigation Bar | App Logo is displayed";

            /* GET APP LOGO DISPLAYED */
            Boolean applogoDisplayed = navigationbar!.GetElementDisplayed(By.CssSelector(navigationbar!.div_applogo));

            /* EXPECTED RESULT */
            Boolean applogodisplayed = true;
            Boolean expectedresult = applogodisplayed;

            /* ACTUAL RESULT */
            Boolean actualresult = applogoDisplayed;

            /* PRINT EXPECTED RESULT VS ACTUAL RESULT */
            Console.WriteLine(testcase);
            Console.WriteLine();

            Console.WriteLine("Expected result: " + expectedresult);
            Console.WriteLine("Actual result: " + actualresult);

            /* ASSERT EXPECTED RESULT VS ACTUAL RESULT */
            Assert.That(actualresult, Is.EqualTo(expectedresult));
        }
        [Test, Order(1)]
        [Category("Navigation Bar | App Logo text is Swag Labs")]
        public void TestCase_3602()
        {
            /* TEST CASE */
            string testcase = "3602 | Navigation Bar | App Logo text is Swag Labs";

            /* GET APP LOGO TEXT */
            string applogoText = navigationbar!.GetElementText(By.CssSelector(navigationbar!.div_applogo));

            /* EXPECTED RESULT */
            string applogotext = "Swag Labs";
            string expectedresult = applogotext;

            /* ACTUAL RESULT */
            string actualresult = applogoText;

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