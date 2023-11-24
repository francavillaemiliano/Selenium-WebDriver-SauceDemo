using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using SauceDemo.POM;

namespace SauceDemo.Tests.Cart
{
    [TestFixture]
    public class Scenario_14
    {
        IWebDriver? driver;
        Login_POM? loginscreen;
        Cart_POM? cartscreen;

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

            /* NAVIGATE TO CART SCREEN */
            cartscreen = new Cart_POM(driver);
            cartscreen.NavigateToCartScreen();
        }

        [Test, Order(1)]
        [Category("Cart Screen | Checkout button is displayed")]
        public void TestCase_1401()
        {
            /* TEST CASE */
            string testcase = "1401 | Cart Screen | Checkout button is displayed";

            /* GET CHECKOUT BUTTON DISPLAYED */
            Boolean checkoutbuttonDisplayed = cartscreen!.GetElementDisplayed(By.CssSelector(cartscreen!.btn_checkout)); 

            /* EXPECTED RESULT */
            Boolean checkoutbuttondisplayed = true;
            Boolean expectedresult = checkoutbuttondisplayed;

            /* ACTUAL RESULT */
            Boolean actualresult = checkoutbuttonDisplayed;

            /* PRINT EXPECTED RESULT VS ACTUAL RESULT */
            Console.WriteLine(testcase);
            Console.WriteLine();

            Console.WriteLine("Expected result: " + expectedresult);
            Console.WriteLine("Actual result: " + actualresult);

            /* ASSERTION EXPECTED RESULT VS ACTUAL RESULT */
            Assert.That(actualresult, Is.EqualTo(expectedresult));
        }

        [Test, Order(2)]
        [Category("Cart Screen | Checkout button redirects to checkout screen")]
        public void TestCase_1402()
        {
            /* TEST CASE */
            string testcase = "1402 | Cart Screen | Checkout button redirects to checkout screen";

            /* NAVIGATE TO CHECKOUT SCREEN */
            cartscreen!.NavigateToCheckoutScreen();

            /* GET SCREEN URL */
            string screenUrl = driver!.Url;

            /* EXPECTED RESULT */
            string screenurl = "https://www.saucedemo.com/checkout-step-one.html";
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