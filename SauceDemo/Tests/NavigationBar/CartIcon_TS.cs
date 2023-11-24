using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using SauceDemo.POM;

namespace SauceDemo.Tests.NavigationBar
{
    [TestFixture]
    public class Scenario_37
    {
        IWebDriver? driver;
        Login_POM? loginscreen;
        NavigationBar_POM? navigationbar;

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

            navigationbar = new NavigationBar_POM(driver);
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
            Inventory_POM inventoryscreen = new Inventory_POM(driver!);
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
            Cart_POM cartscreen = new Cart_POM(driver!);
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