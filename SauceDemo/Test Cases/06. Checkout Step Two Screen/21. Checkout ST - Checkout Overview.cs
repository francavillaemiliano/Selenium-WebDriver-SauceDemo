using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;

namespace Swag_Labs
{
    [TestFixture]
    public class Scenario_21
    {
        IWebDriver? driver;
        LoginScreen? loginscreen;
        CartScreen? cartscreen;
        Checkout1Screen? checkout1screen;
        Checkout2Screen? checkout2screen;

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

            /* NAVIGATE TO CART SCREEN */
            cartscreen = new CartScreen(driver);
            cartscreen.NavigateToCartScreen();

            /* NAVIGATE TO CHECKOUT SCREEN */
            cartscreen.NavigateToCheckoutScreen();

            /* NAVIGATE TO CHECKOUT STEP TWO SCREEN */
            checkout1screen = new Checkout1Screen(driver);
            checkout1screen.NavigateToScreen();

            checkout2screen = new Checkout2Screen(driver);
        }

        [Test, Order(1)]
        [Category("Checkout 2 Screen | Title is displayed")]
        public void TestCase_2101()
        {
            /* TEST CASE */
            string testcase = "2101 | Checkout 2 Screen | Checkout: Overview is displayed";

            /* GET TITLE DISPLAYED */
            Boolean titleDisplayed = checkout2screen!.GetElementDisplayed(By.CssSelector(checkout2screen!.span_title));

            /* EXPECTED RESULT */
            Boolean titledisplayed = true;
            Boolean expectedresult = titledisplayed;

            /* ACTUAL RESULT */
            Boolean actualresult = titleDisplayed;

            /* PRINT EXPECTED RESULT VS ACTUAL RESULT */
            Console.WriteLine(testcase);
            Console.WriteLine();

            Console.WriteLine("Expected result: " + expectedresult);
            Console.WriteLine("Actual result: " + actualresult);

            /* ASSERTION EXPECTED RESULT VS ACTUAL RESULT */
            Assert.That(actualresult, Is.EqualTo(expectedresult));
        }

        [OneTimeTearDown]
        public void Teardown()
        {
            driver?.Dispose();
        }
    }
}