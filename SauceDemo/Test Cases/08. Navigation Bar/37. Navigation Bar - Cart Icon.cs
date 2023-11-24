using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;

namespace Swag_Labs
{
    [TestFixture]
    public class Scenario_37
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
        [Category("Navigation Bar | Cart Icon is displayed")]
        public void TestCase_3701()
        {
            /* TEST CASE */
            string testcase = "3701 | Navigation Bar | Cart Icon is displayed";

            /* GET CART ICON DISPLAYED */
            Boolean carticonDisplayed = navigationbar!.GetElementDisplayed(By.CssSelector(navigationbar!.a_carticon));

            /* EXPECTED RESULT */
            Boolean carticondisplayed = true;
            Boolean expectedresult = carticondisplayed;

            /* ACTUAL RESULT */
            Boolean actualresult = carticonDisplayed;

            /* PRINT EXPECTED RESULT VS ACTUAL RESULT */
            Console.WriteLine(testcase);
            Console.WriteLine();

            Console.WriteLine("Expected result: " + expectedresult);
            Console.WriteLine("Actual result: " + actualresult);

            /* ASSERT EXPECTED RESULT VS ACTUAL RESULT */
            Assert.That(actualresult, Is.EqualTo(expectedresult));
        }

        [Test, Order(2)]
        [Category("Navigation Bar | Cart Icon shows quantity of selected products")]
        public void TestCase_3702()
        {
            /* TEST CASE */
            string testcase = "3702 | Navigation Bar | Cart Icon shows quantity of selected products";

            /* ADD ALL ITEMS TO CART */
            InventoryScreen inventoryscreen = new InventoryScreen(driver!);
            inventoryscreen!.AddAllItemsToCart();

            /* GET CART ITEMS */
            int cartItems = navigationbar!.GetCartItems();

            /* EXPECTED RESULT */
            int cartitems = 6;
            int expectedresult = cartitems;

            /* ACTUAL RESULT */
            int actualresult = cartItems;

            /* PRINT EXPECTED RESULT VS ACTUAL RESULT */
            Console.WriteLine(testcase);
            Console.WriteLine();

            Console.WriteLine("Expected result: " + expectedresult);
            Console.WriteLine("Actual result: " + actualresult);

            /* ASSERT EXPECTED RESULT VS ACTUAL RESULT */
            Assert.That(actualresult, Is.EqualTo(expectedresult));
        }

        [Test, Order(2)]
        [Category("Navigation Bar | Cart Icon redirects to cart screen")]
        public void TestCase_3703()
        {
            /* TEST CASE */
            string testcase = "3703 | Navigation Bar | Cart Icon redirects to cart screen";

            /* CLICK ON CART ICON */
            CartScreen cartscreen = new CartScreen(driver!);
            cartscreen.NavigateToCartScreen();

            /* GET SCREEN URL */
            string screenUrl = driver!.Url;

            /* EXPECTED RESULT */
            string expectedresult = "https://www.saucedemo.com/cart.html";

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