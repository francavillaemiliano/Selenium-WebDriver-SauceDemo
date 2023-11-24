using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;

namespace Swag_Labs
{
    [TestFixture]
    public class Scenario_25
    {
        IWebDriver? driver;
        LoginScreen? loginscreen;
        InventoryScreen? inventoryscreen;
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

            /* ADD TO CART ALL PRODUCTS */
            inventoryscreen = new InventoryScreen(driver);
            inventoryscreen.AddAllItemsToCart();

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
        [Category("Checkout 2 Screen | Shipping Information label is displayed")]
        public void TestCase_2501()
        {
            /* TEST CASE */
            string testcase = "2501 | Checkout 2 Screen | Shipping Information label is displayed";

            /* GET SHIPPING INFORMATION DISPLAYED */
            Boolean shippinginformationDisplayed = checkout2screen!.GetElementDisplayed(By.XPath(checkout2screen!.text_shippinginformation));

            /* EXPECTED RESULT */
            Boolean shippinginformationdisplayed = true;
            Boolean expectedresult = shippinginformationdisplayed;

            /* ACTUAL RESULT */
            Boolean actualresult = shippinginformationDisplayed;

            /* PRINT EXPECTED RESULT VS ACTUAL RESULT */
            Console.WriteLine(testcase);
            Console.WriteLine();

            Console.WriteLine("Expected result: " + expectedresult);
            Console.WriteLine("Actual result: " + actualresult);

            /* ASSERTION EXPECTED RESULT VS ACTUAL RESULT */
            Assert.That(actualresult, Is.EqualTo(expectedresult));
        }

        [Test, Order(2)]
        [Category("Checkout 2 Screen | Shipping Information contains Free Pony Express Delivery!")]
        public void TestCase_2502()
        {
            /* TEST CASE */
            string testcase = "2502 | Checkout 2 Screen | Shipping Information contains Free Pony Express Delivery!";

            /* GET FREE PONY EXPRESS DELIVERY LABEL TEXT */
            string freeponylabelText = checkout2screen!.GetElementText(By.XPath(checkout2screen!.text_freeponyexpress));

            /* EXPECTED RESULT */
            string freeponylabeltext = "Free Pony Express Delivery!";
            string expectedresult = freeponylabeltext;

            /* ACTUAL RESULT */
            string actualresult = freeponylabelText;

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