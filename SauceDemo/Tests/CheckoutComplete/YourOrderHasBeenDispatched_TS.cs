using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using SauceDemo.POM;

namespace SauceDemo.Tests.CheckoutComplete
{
    [TestFixture]
    public class Scenario_33
    {
        IWebDriver? driver;
        Login_POM? loginscreen;
        Cart_POM? cartscreen;
        CheckoutOne_POM? checkout1screen;
        CheckoutTwo_POM? checkout2screen;
        CheckoutComplete_POM? checkoutcompletescreen;

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

            /* NAVIGATE TO CHECKOUT SCREEN */
            cartscreen.NavigateToCheckoutScreen();

            /* NAVIGATE TO CHECKOUT STEP TWO SCREEN */
            checkout1screen = new CheckoutOne_POM(driver);
            checkout1screen.NavigateToScreen();

            /* NAVIGATE TO CHECKOUT COMPLETE SCREEN */
            checkout2screen = new CheckoutTwo_POM(driver);
            checkout2screen.NavigateToCheckoutCompleteScreen();

            checkoutcompletescreen = new CheckoutComplete_POM(driver);
        }

        [Test, Order(1)]
        [Category("Checkout Complete Screen | Your order has been dispatched, and will arrive just as fast as the pony can get there! is displayed")]
        public void TestCase_3301()
        {
            /* TEST CASE */
            string testcase = "3301 | Checkout Complete Screen | Your order has been dispatched, and will arrive just as fast as the pony can get there! is displayed";

            /* GET YOUR ORDER HAS BEEN DISPATCHED, AND WILL ARRIVE JUST AS FAST AS THE PONY CAN GET THERE! DISPLAYED */
            Boolean yourordertextDisplayed = checkoutcompletescreen!.GetElementDisplayed(By.CssSelector(checkoutcompletescreen!.div_completetext));

            /* EXPECTED RESULT */
            Boolean yourordertextdisplayed = true;
            Boolean expectedresult = yourordertextdisplayed;

            /* ACTUAL RESULT */
            Boolean actualresult = yourordertextDisplayed;

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