using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;

namespace Swag_Labs
{
    [TestFixture]
    public class Scenario_23
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
        [Category("Checkout 2 Screen | Description label is displayed")]
        public void TestCase_2301()
        {
            /* TEST CASE */
            string testcase = "2301 | Checkout 2 Screen | Description label is displayed";

            /* GET DESCRIPTION LABEL DISPLAYED */
            Boolean descriptionlabelDisplayed = checkout2screen!.GetElementDisplayed(By.CssSelector(checkout2screen!.div_descriptionlabel));

            /* EXPECTED RESULT */
            Boolean descriptionlabeldisplayed = true;
            Boolean expectedresult = descriptionlabeldisplayed;

            /* ACTUAL RESULT */
            Boolean actualresult = descriptionlabelDisplayed;

            /* PRINT EXPECTED RESULT VS ACTUAL RESULT */
            Console.WriteLine(testcase);
            Console.WriteLine();

            Console.WriteLine("Expected result: " + expectedresult);
            Console.WriteLine("Actual result: " + actualresult);

            /* ASSERTION EXPECTED RESULT VS ACTUAL RESULT */
            Assert.That(actualresult, Is.EqualTo(expectedresult));
        }

        [Test, Order(2)]
        [Category("Checkout 2 Screen | Description contains item name")]
        public void TestCase_2302()
        {
            /* TEST CASE */
            string testcase = "2302 | Checkout 2 Screen | Description contains item name";

            /* GET ITEM NAME DISPLAYED */
            List<string> itemnameDisplayed = checkout2screen!.GetItemNameDisplayed();

            /* EXPECTED RESULT */
            List<string> itemnamedisplayed = new List<string>();
            List<string> expectedresult = itemnamedisplayed;

            itemnamedisplayed.Add("Item name: Sauce Labs Backpack");
            itemnamedisplayed.Add("Is item name displayed?: True");
            itemnamedisplayed.Add("");

            itemnamedisplayed.Add("Item name: Sauce Labs Bike Light");
            itemnamedisplayed.Add("Is item name displayed?: True");
            itemnamedisplayed.Add("");

            itemnamedisplayed.Add("Item name: Sauce Labs Bolt T-Shirt");
            itemnamedisplayed.Add("Is item name displayed?: True");
            itemnamedisplayed.Add("");

            itemnamedisplayed.Add("Item name: Sauce Labs Fleece Jacket");
            itemnamedisplayed.Add("Is item name displayed?: True");
            itemnamedisplayed.Add("");

            itemnamedisplayed.Add("Item name: Sauce Labs Onesie");
            itemnamedisplayed.Add("Is item name displayed?: True");
            itemnamedisplayed.Add("");

            itemnamedisplayed.Add("Item name: Test.allTheThings() T-Shirt (Red)");
            itemnamedisplayed.Add("Is item name displayed?: True");
            itemnamedisplayed.Add("");

            /* ACTUAL RESULT */
            List<string> actualresult = itemnameDisplayed;

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

            /* ASSERTION EXPECTED RESULT VS ACTUAL RESULT */
            Assert.That(actualresult, Is.EqualTo(expectedresult));
        }

        [Test, Order(3)]
        [Category("Checkout 2 Screen | Description contains item name as link")]
        public void TestCase_2303()
        {
            /* TEST CASE */
            string testcase = "2303 | Checkout 2 Screen | Description contains item name as link";

            /* GET ITEM TAG NAME */
            List<string> itemTagname = checkout2screen!.GetItemTagName();

            /* EXPECTED RESULT */
            List<string> itemtagname = new List<string>();
            List<string> expectedresult = itemtagname;

            itemtagname.Add("Item name: Sauce Labs Backpack");
            itemtagname.Add("Item element tag: a");
            itemtagname.Add("");

            itemtagname.Add("Item name: Sauce Labs Bike Light");
            itemtagname.Add("Item element tag: a");
            itemtagname.Add("");

            itemtagname.Add("Item name: Sauce Labs Bolt T-Shirt");
            itemtagname.Add("Item element tag: a");
            itemtagname.Add("");

            itemtagname.Add("Item name: Sauce Labs Fleece Jacket");
            itemtagname.Add("Item element tag: a");
            itemtagname.Add("");

            itemtagname.Add("Item name: Sauce Labs Onesie");
            itemtagname.Add("Item element tag: a");
            itemtagname.Add("");

            itemtagname.Add("Item name: Test.allTheThings() T-Shirt (Red)");
            itemtagname.Add("Item element tag: a");
            itemtagname.Add("");

            /* ACTUAL RESULT */
            List<string> actualresult = itemTagname;

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

            /* ASSERTION EXPECTED RESULT VS ACTUAL RESULT */
            Assert.That(actualresult, Is.EqualTo(expectedresult));
        }

        [Test, Order(4)]
        [Category("Checkout 2 Screen | Description contains item description")]
        public void TestCase_2304()
        {
            /* TEST CASE */
            string testcase = "2304 | Checkout 2 Screen | Description contains item description";

            /* GET ITEM DESCRTIPTION DISPLAYED */
            List<string> itemdescriptionDisplayed = checkout2screen!.GetItemDescriptionDisplayed();

            /* EXPECTED RESULT */
            List<string> itemdescriptiondisplayed = new List<string>();
            List<string> expectedresult = itemdescriptiondisplayed;

            itemdescriptiondisplayed.Add("Item name: Sauce Labs Backpack");
            itemdescriptiondisplayed.Add("Item description: carry.allTheThings() with the sleek, streamlined Sly Pack that melds uncompromising style with unequaled laptop and tablet protection.");
            itemdescriptiondisplayed.Add("Is item description displayed?: True");
            itemdescriptiondisplayed.Add("");

            itemdescriptiondisplayed.Add("Item name: Sauce Labs Bike Light");
            itemdescriptiondisplayed.Add("Item description: A red light isn't the desired state in testing but it sure helps when riding your bike at night. Water-resistant with 3 lighting modes, 1 AAA battery included.");
            itemdescriptiondisplayed.Add("Is item description displayed?: True");
            itemdescriptiondisplayed.Add("");

            itemdescriptiondisplayed.Add("Item name: Sauce Labs Bolt T-Shirt");
            itemdescriptiondisplayed.Add("Item description: Get your testing superhero on with the Sauce Labs bolt T-shirt. From American Apparel, 100% ringspun combed cotton, heather gray with red bolt.");
            itemdescriptiondisplayed.Add("Is item description displayed?: True");
            itemdescriptiondisplayed.Add("");

            itemdescriptiondisplayed.Add("Item name: Sauce Labs Fleece Jacket");
            itemdescriptiondisplayed.Add("Item description: It's not every day that you come across a midweight quarter-zip fleece jacket capable of handling everything from a relaxing day outdoors to a busy day at the office.");
            itemdescriptiondisplayed.Add("Is item description displayed?: True");
            itemdescriptiondisplayed.Add("");

            itemdescriptiondisplayed.Add("Item name: Sauce Labs Onesie");
            itemdescriptiondisplayed.Add("Item description: Rib snap infant onesie for the junior automation engineer in development. Reinforced 3-snap bottom closure, two-needle hemmed sleeved and bottom won't unravel.");
            itemdescriptiondisplayed.Add("Is item description displayed?: True");
            itemdescriptiondisplayed.Add("");

            itemdescriptiondisplayed.Add("Item name: Test.allTheThings() T-Shirt (Red)");
            itemdescriptiondisplayed.Add("Item description: This classic Sauce Labs t-shirt is perfect to wear when cozying up to your keyboard to automate a few tests. Super-soft and comfy ringspun combed cotton.");
            itemdescriptiondisplayed.Add("Is item description displayed?: True");
            itemdescriptiondisplayed.Add("");

            /* ACTUAL RESULT */
            List<string> actualresult = itemdescriptionDisplayed;

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

            /* ASSERTION EXPECTED RESULT VS ACTUAL RESULT */
            Assert.That(actualresult, Is.EqualTo(expectedresult));
        }

        [Test, Order(5)]
        [Category("Checkout 2 Screen | Description contains item price")]
        public void TestCase_2305()
        {
            /* TEST CASE */
            string testcase = "2305 | Checkout 2 Screen | Description contains item price";

            /* GET ITEM PRICE DISPLAYED */
            List<string> itempriceDisplayed = checkout2screen!.GetItemPriceDisplayed();

            /* EXPECTED RESULT */
            List<string> itempricedisplayed = new List<string>();
            List<string> expectedresult = itempricedisplayed;

            itempricedisplayed.Add("Item name: Sauce Labs Backpack");
            itempricedisplayed.Add("Item price: $29.99");
            itempricedisplayed.Add("Is item price displayed?: True");
            itempricedisplayed.Add("");

            itempricedisplayed.Add("Item name: Sauce Labs Bike Light");
            itempricedisplayed.Add("Item price: $9.99");
            itempricedisplayed.Add("Is item price displayed?: True");
            itempricedisplayed.Add("");

            itempricedisplayed.Add("Item name: Sauce Labs Bolt T-Shirt");
            itempricedisplayed.Add("Item price: $15.99");
            itempricedisplayed.Add("Is item price displayed?: True");
            itempricedisplayed.Add("");

            itempricedisplayed.Add("Item name: Sauce Labs Fleece Jacket");
            itempricedisplayed.Add("Item price: $49.99");
            itempricedisplayed.Add("Is item price displayed?: True");
            itempricedisplayed.Add("");

            itempricedisplayed.Add("Item name: Sauce Labs Onesie");
            itempricedisplayed.Add("Item price: $7.99");
            itempricedisplayed.Add("Is item price displayed?: True");
            itempricedisplayed.Add("");

            itempricedisplayed.Add("Item name: Test.allTheThings() T-Shirt (Red)");
            itempricedisplayed.Add("Item price: $15.99");
            itempricedisplayed.Add("Is item price displayed?: True");
            itempricedisplayed.Add("");

            /* ACTUAL RESULT */
            List<string> actualresult = itempriceDisplayed;

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