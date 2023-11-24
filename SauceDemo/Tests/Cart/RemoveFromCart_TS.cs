using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using SauceDemo.POM;

namespace SauceDemo.Tests.Cart
{
    [TestFixture]
    public class Scenario_12
    {
        IWebDriver? driver;
        Login_POM? loginscreen;
        Inventory_POM? inventoryscreen;
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

            /* ADD TO CART ALL PRODUCTS */
            inventoryscreen = new Inventory_POM(driver);
            inventoryscreen.AddAllItemsToCart();

            /* NAVIGATE TO CART SCREEN */
            cartscreen = new Cart_POM(driver);
            cartscreen.NavigateToCartScreen();
        }

        [Test, Order(1)]
        [Category("Cart Screen | Remove from cart button is displayed")]
        public void TestCase_1201()
        {
            string testcase = "1201 | Cart Screen | Remove from cart button is displayed";

            /* GET REMOVE FROM CART BUTTON DISPLAYED */
            List<string> removefromcartbuttonDisplayed = cartscreen!.GetRemoveFromCartButtonDisplayed();     

            /* EXPECTED RESULT */
            List<string> removefromcartbuttondisplayed = new List<string>();
            List<string> expectedresult = removefromcartbuttondisplayed;

            removefromcartbuttondisplayed.Add("Item name: Sauce Labs Backpack");
            removefromcartbuttondisplayed.Add("Item button: Remove");
            removefromcartbuttondisplayed.Add("Is Remove button displayed?: True");
            removefromcartbuttondisplayed.Add("");

            removefromcartbuttondisplayed.Add("Item name: Sauce Labs Bike Light");
            removefromcartbuttondisplayed.Add("Item button: Remove");
            removefromcartbuttondisplayed.Add("Is Remove button displayed?: True");
            removefromcartbuttondisplayed.Add("");

            removefromcartbuttondisplayed.Add("Item name: Sauce Labs Bolt T-Shirt");
            removefromcartbuttondisplayed.Add("Item button: Remove");
            removefromcartbuttondisplayed.Add("Is Remove button displayed?: True");
            removefromcartbuttondisplayed.Add("");

            removefromcartbuttondisplayed.Add("Item name: Sauce Labs Fleece Jacket");
            removefromcartbuttondisplayed.Add("Item button: Remove");
            removefromcartbuttondisplayed.Add("Is Remove button displayed?: True");
            removefromcartbuttondisplayed.Add("");

            removefromcartbuttondisplayed.Add("Item name: Sauce Labs Onesie");
            removefromcartbuttondisplayed.Add("Item button: Remove");
            removefromcartbuttondisplayed.Add("Is Remove button displayed?: True");
            removefromcartbuttondisplayed.Add("");

            removefromcartbuttondisplayed.Add("Item name: Test.allTheThings() T-Shirt (Red)");
            removefromcartbuttondisplayed.Add("Item button: Remove");
            removefromcartbuttondisplayed.Add("Is Remove button displayed?: True");
            removefromcartbuttondisplayed.Add("");

            /* ACTUAL RESULT */
            List<string> actualresult = removefromcartbuttondisplayed;

            /* PRINT EXPECTED RESULT VS ACTUAL RESULT */
            Console.WriteLine(testcase);
            Console.WriteLine();

            Console.WriteLine("Expected result:");
            foreach (string item in removefromcartbuttonDisplayed)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("Actual result:");
            foreach (string item in removefromcartbuttondisplayed)
            {
                Console.WriteLine(item);
            }

            /* ASSERTION EXPECTED RESULT VS ACTUAL RESULT */
            Assert.That(actualresult, Is.EqualTo(expectedresult));
        }

        [Test, Order(2)]
        [Category("Cart Screen | Remove from cart button removes the product from the cart")]
        public void TestCase_1202()
        {
            /* TEST CASE */
            string testcase = "1202 | Cart Screen | Remove from cart button removes the product from the cart";

            /* REMOVE ALL PRODUCTS FROM CART */
            cartscreen!.RemoveAllItemsFromCart();

            /* GET CART IS EMPTY */
            Boolean cartIsempty = cartscreen!.GetCarIsEmpty();

            /* EXPECTED RESULT */
            Boolean cartisempty = true;
            Boolean expectedresult = cartisempty;

            /* ACTUAL RESULT */
            Boolean actualresult = cartIsempty;

            /* PRINT EXPECTED RESULT VS ACTUAL RESULT */
            Console.WriteLine(testcase);
            Console.WriteLine();

            Console.WriteLine("Expected result: Cart is empty: " + expectedresult);
            Console.WriteLine("Actual result: Cart is empty: " + actualresult);
            Console.WriteLine("");

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