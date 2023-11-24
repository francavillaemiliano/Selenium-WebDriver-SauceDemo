using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;

namespace Swag_Labs
{
    [TestFixture]
    public class Scenario_32
    {
        IWebDriver? driver;
        LoginScreen? loginscreen;
        CartScreen? cartscreen;
        Checkout1Screen? checkout1screen;
        Checkout2Screen? checkout2screen;
        CheckoutCompleteScreen? checkoutcompletescreen;

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

            /* NAVIGATE TO CHECKOUT COMPLETE SCREEN */
            checkout2screen = new Checkout2Screen(driver);
            checkout2screen.NavigateToCheckoutCompleteScreen();

            checkoutcompletescreen = new CheckoutCompleteScreen(driver);
        }

        [Test, Order(1)]
        [Category("Checkout Complete Screen | Thank you for your order! is displayed")]
        public void TestCase_3201()
        {
            /* TEST CASE */
            string testcase = "3201 | Checkout Complete Screen | Thank you for your order! is displayed";

            /* GET THANK YOU FOR YOUR ORDER! DISPLAYED */
            Boolean thankyouheaderDisplayed = checkoutcompletescreen!.GetElementDisplayed(By.CssSelector(checkoutcompletescreen!.h2_completeheader));

            /* EXPECTED RESULT */
            Boolean thankyouheaderdisplayed = true;
            Boolean expectedresult = thankyouheaderdisplayed;

            /* ACTUAL RESULT */
            Boolean actualresult = thankyouheaderDisplayed;

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