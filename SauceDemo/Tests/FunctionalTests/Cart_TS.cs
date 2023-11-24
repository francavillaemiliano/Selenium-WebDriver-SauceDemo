using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using SauceDemo.POM;

namespace SauceDemo.Tests.FunctionalTests
{
    [TestFixture]
    public class Scenario_44
    {
        IWebDriver? driver;
        Login_POM? loginscreen;
        Inventory_POM? inventoryscreen;
        InventoryItem_POM? inventoryitemscreen;
        NavigationBar_POM? navigationbar;

        string baseurl = "https://www.saucedemo.com/";

        [OneTimeSetUp]
        public void Setup()
        {
            /* DRIVER INITIALIZATION */
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl(baseurl);
            driver.Manage().Window.FullScreen();

            /* LOGIN STANDARD USER */
            loginscreen = new Login_POM(driver!);
            loginscreen!.LoginUser(loginscreen!.standarduser, loginscreen!.secretsauce);
            
            inventoryscreen = new Inventory_POM(driver!);
            inventoryitemscreen = new InventoryItem_POM(driver!);
            navigationbar = new NavigationBar_POM(driver);
        }

        [Test, Order(1)]
        [Category("Cart | Cart item quantity doesn't reset when Standard user log out and log in")]
        public void TestCase_4401()
        {
            /* TEST CASE */
            string testcase = "4401 | Cart | Cart item quantity doesn't reset when Standard user log out and log in";

            /* ADD ALL ITEMS TO CART */
            inventoryscreen!.AddAllItemsToCart();

            /* LOGOUT USER */
            navigationbar!.ClickElement(By.CssSelector(navigationbar!.btn_burguermenu));
            navigationbar!.ClickElement(By.LinkText(navigationbar!.a_Logout));

            /* LOGIN STANDARD USER */
            loginscreen!.LoginUser(loginscreen!.standarduser, loginscreen!.secretsauce);

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
        [Category("Cart | Cart product quantity change when Standard user clicks remove button from Inventory screen")]
        public void TestCase_4402()
        {
            /* TEST CASE */
            string testcase = "4402 | Cart | Cart product quantity change when Standard user clicks remove button from Inventory screen";

            /* REMOVE ALL ITEMS FROM CART */
            inventoryscreen!.RemoveAllItemsFromCart();

            /* GET CART ITEMS */
            int cartItems = navigationbar!.GetCartItems();

            /* EXPECTED RESULT */
            int cartitems = 0;
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

        [Test, Order(3)]
        [Category("Cart | Cart product quantity change when Standard user clicks remove button from Inventory Item screen")]
        public void TestCase_4403()
        {
            /* TEST CASE */
            string testcase = "4403 | Cart | Cart product quantity change when Standard user clicks remove button from Inventory Item screen";

            /* ADD ALL ITEMS TO CART */
            inventoryscreen!.AddAllItemsToCart();

            /* GET ITEM NAME */
            List<string> itemName = inventoryscreen!.GetItemName();

            /* REMOVE ALL ITEMS FROM CART FROM INVENTORY ITEM SCREEN */
            inventoryitemscreen!.RemoveItemFromCart(itemName);

            /* GET CART ITEMS */
            int cartItems = navigationbar!.GetCartItems();

            /* EXPECTED RESULT */
            int cartitems = 0;
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
            [OneTimeTearDown]
        public void Teardown()
        {
            driver?.Dispose();
        }
    }
}