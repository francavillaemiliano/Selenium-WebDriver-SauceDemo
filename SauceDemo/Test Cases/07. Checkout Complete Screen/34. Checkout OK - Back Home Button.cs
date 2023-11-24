using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;

namespace Swag_Labs
{
    [TestFixture]
    public class Scenario_34
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
        [Category("Checkout Complete Screen | Back Home button is displayed")]
        public void TestCase_3401()
        {
            /* TEST CASE */
            string testcase = "3401 | Checkout Complete Screen | Back Home button is displayed";

            /* GET BACK HOME BUTTON DISPLAYED */
            Boolean backhomebuttonDisplayed = checkoutcompletescreen!.GetElementDisplayed(By.CssSelector(checkoutcompletescreen!.btn_back_home));

            /* EXPECTED RESULT */
            Boolean backhomebuttondisplayed = true;
            Boolean expectedresult = backhomebuttondisplayed;

            /* ACTUAL RESULT */
            Boolean actualresult = backhomebuttonDisplayed;

            /* PRINT EXPECTED RESULT VS ACTUAL RESULT */
            Console.WriteLine(testcase);
            Console.WriteLine();

            Console.WriteLine("Expected result: " + expectedresult);
            Console.WriteLine("Actual result: " + actualresult);

            /* ASSERT EXPECTED RESULT VS ACTUAL RESULT */
            Assert.That(actualresult, Is.EqualTo(expectedresult));
        }

        [Test, Order(2)]
        [Category("Checkout Complete screen | Back Home button redirects to Products screen")]
        public void TestCase_3402()
        {
            /* TEST CASE */
            string testcase = "3402 | Checkout Complete screen | Back Home button redirects to Inventory screen";

            /* CLICK BACK HOME BUTTON */
            checkoutcompletescreen!.ClickButton(By.CssSelector(checkoutcompletescreen!.btn_back_home));

            /* GET INVENTORY SCREEN URL */
            string screenUrl = driver!.Url;

            /* EXPECTED RESULT */
            string screenurl = "https://www.saucedemo.com/inventory.html";
            string expectedresult = screenurl;

            /* ACTUAL RESULT */
            string actualresult = screenUrl;

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