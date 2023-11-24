using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using SauceDemo.POM;

namespace SauceDemo.Tests.Cart
{
    [TestFixture]
    public class Scenario_10
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
        [Category("Cart Screen | QTY label is displayed")]
        public void TestCase_1001()
        {
            /* TEST CASE */
            string testcase = "1001 | Cart Screen | QTY label is displayed";

            /* GET QTY LABEL DISPLAYED */
            Boolean qtylabelDisplayed = cartscreen!.GetElementDisplayed(By.CssSelector(cartscreen!.div_quantitylabel));            

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

            /* ASSERT EXPECTED RESULT VS ACTUAL RESULT */
            Assert.That(actualresult, Is.EqualTo(expectedresult));
        }

        [Test, Order(2)]
        [Category("Cart Screen | QTY contains item quantity")]
        public void TestCase_1002()
        {
            /* TEST CASE */
            string testcase = "1002 | Cart Screen | QTY contains item quantity";

            /* GET ITEM QTY */
            List<string> itemQty = cartscreen!.GetItemQTY();

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
            List<string> actualresult = itemQty;

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