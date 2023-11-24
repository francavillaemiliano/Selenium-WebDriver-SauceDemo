using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;

namespace Swag_Labs
{
    [TestFixture]
    public class Scenario_22
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
        [Category("Checkout 2 Screen | QTY label is displayed")]
        public void TestCase_2201()
        {
            /* TEST CASE */
            string testcase = "2201 | Checkout 2 Screen | QTY label is displayed";

            /* GET QTY LABEL DISPLAYED */
            Boolean qtylabelDisplayed = checkout2screen!.GetElementDisplayed(By.CssSelector(checkout2screen!.div_cartquantity));

            /* EXPECTED RESULT */
            Boolean qtylabeldisplayed = true;
            Boolean expectedresult = qtylabeldisplayed;

            /* ACTUAL RESULT */
            Boolean actualresult = qtylabelDisplayed;

            /* PRINT EXPECTED RESULT VS ACTUAL RESULT */
            Console.WriteLine(testcase);
            Console.WriteLine();

            Console.WriteLine("Expected result: " + expectedresult);
            Console.WriteLine("Actual result: " + actualresult);

            /* ASSERTION EXPECTED RESULT VS ACTUAL RESULT */
            Assert.That(actualresult, Is.EqualTo(expectedresult));
        }

        [Test, Order(2)]
        [Category("Checkout 2 Screen | QTY contains the quantity of the item")]
        public void TestCase_2202()
        {
            /* TEST CASE */
            string testcase = "2202 | Checkout 2 Screen | QTY contains the quantity of the item";

            /* GET ITEM QTY */
            List<string> itemQTY = checkout2screen!.GetItemQTY();

            /* EXPECTED RESULT */
            List<string> itemqty = new List<string>();
            List<string> expectedresult = itemqty;

            itemqty.Add("Item name: Sauce Labs Backpack");
            itemqty.Add("Item quantity: 1");
            itemqty.Add("");

            itemqty.Add("Item name: Sauce Labs Bike Light");
            itemqty.Add("Item quantity: 1");
            itemqty.Add("");

            itemqty.Add("Item name: Sauce Labs Bolt T-Shirt");
            itemqty.Add("Item quantity: 1");
            itemqty.Add("");

            itemqty.Add("Item name: Sauce Labs Fleece Jacket");
            itemqty.Add("Item quantity: 1");
            itemqty.Add("");

            itemqty.Add("Item name: Sauce Labs Onesie");
            itemqty.Add("Item quantity: 1");
            itemqty.Add("");

            itemqty.Add("Item name: Test.allTheThings() T-Shirt (Red)");
            itemqty.Add("Item quantity: 1");
            itemqty.Add("");

            /* ACTUAL RESULT */
            List<string> actualresult = itemQTY;

            /* PRINT EXPECTED RESULT VS ACTUAL RESULT */
            Console.WriteLine(testcase);
            Console.WriteLine();

            Console.WriteLine("Expected result:");
            foreach (string item in expectedresult)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("Actual result:");
            foreach (string item in actualresult)
            {
                Console.WriteLine(item);
            }

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