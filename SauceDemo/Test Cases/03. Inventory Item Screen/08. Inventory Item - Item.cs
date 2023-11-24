using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;

namespace Swag_Labs
{
    [TestFixture]
    public class Scenario_08
    {
        IWebDriver? driver;
        LoginScreen? loginscreen;
        InventoryItemScreen? inventoryitemscreen;

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

            inventoryitemscreen = new InventoryItemScreen(driver);
        }

        [Test, Order(1)]
        [Category("Inventory Item Screen | Item image is displayed")]
        public void TestCase_0801()
        {
            /* TEST CASE */
            string testcase = "0801 | Inventory Item Screen | Item image is displayed";

            /* GET ITEM NAME */
            List<string> itemName = inventoryitemscreen!.GetItemName();

            /* GET INVENTORY ITEMS IMG IS VISIBLE */
            List<string> itemimgDisplayed = inventoryitemscreen.GetItemImgDisplayed(itemName);

            /* EXPECTED RESULT */
            List<string> itemimgdisplayed = new List<string>();
            List<string> expectedresult = itemimgdisplayed;

            itemimgdisplayed.Add("Item details screen: Sauce Labs Backpack");
            itemimgdisplayed.Add("src: https://www.saucedemo.com/static/media/sauce-backpack-1200x1500.0a0b85a3.jpg");
            itemimgdisplayed.Add("Is item image displayed?: True");
            itemimgdisplayed.Add("");

            itemimgdisplayed.Add("Item details screen: Sauce Labs Bike Light");
            itemimgdisplayed.Add("src: https://www.saucedemo.com/static/media/bike-light-1200x1500.37c843b0.jpg");
            itemimgdisplayed.Add("Is item image displayed?: True");
            itemimgdisplayed.Add("");

            itemimgdisplayed.Add("Item details screen: Sauce Labs Bolt T-Shirt");
            itemimgdisplayed.Add("src: https://www.saucedemo.com/static/media/bolt-shirt-1200x1500.c2599ac5.jpg");
            itemimgdisplayed.Add("Is item image displayed?: True");
            itemimgdisplayed.Add("");

            itemimgdisplayed.Add("Item details screen: Sauce Labs Fleece Jacket");
            itemimgdisplayed.Add("src: https://www.saucedemo.com/static/media/sauce-pullover-1200x1500.51d7ffaf.jpg");
            itemimgdisplayed.Add("Is item image displayed?: True");
            itemimgdisplayed.Add("");

            itemimgdisplayed.Add("Item details screen: Sauce Labs Onesie");
            itemimgdisplayed.Add("src: https://www.saucedemo.com/static/media/red-onesie-1200x1500.2ec615b2.jpg");
            itemimgdisplayed.Add("Is item image displayed?: True");
            itemimgdisplayed.Add("");

            itemimgdisplayed.Add("Item details screen: Test.allTheThings() T-Shirt (Red)");
            itemimgdisplayed.Add("src: https://www.saucedemo.com/static/media/red-tatt-1200x1500.30dadef4.jpg");
            itemimgdisplayed.Add("Is item image displayed?: True");
            itemimgdisplayed.Add("");

            /* ACTUAL RESULT */
            List<string> actualresult = itemimgDisplayed;

            /* PRINT EXPECTED RESULT VS ACTUAL RESULT */
            Console.WriteLine(testcase);
            Console.WriteLine();

            Console.WriteLine("Expected result:");
            foreach (string item in expectedresult)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();
            Console.WriteLine("Actual result: ");
            foreach (string item in actualresult)
            {
                Console.WriteLine(item);
            }

            /* ASSERTION EXPECTED RESULT VS ACTUAL RESULT */
            Assert.That(actualresult, Is.EqualTo(expectedresult));
        }

        [Test, Order(2)]
        [Category("Inventory Item Screen | Item name is displayed")]
        public void TestCase_0802()
        {
            /* TEST CASE */
            string testcase = "0802 | Inventory Item Screen | Item name is displayed";

            /* GET ITEM NAME */
            List<string> itemName = inventoryitemscreen!.GetItemName();

            /* GET ITEM NAME DISPLAYED */
            List<string> itemnameDisplayed = inventoryitemscreen.GetItemNameDisplayed(itemName);

            /* EXPECTED RESULT */
            List<string> itemNameisdisplayed = new List<string>();
            List<string> expectedresult = itemNameisdisplayed;

            itemNameisdisplayed.Add("Item details screen: Sauce Labs Backpack");
            itemNameisdisplayed.Add("Is item name displayed?: True");
            itemNameisdisplayed.Add("");

            itemNameisdisplayed.Add("Item details screen: Sauce Labs Bike Light");
            itemNameisdisplayed.Add("Is item name displayed?: True");
            itemNameisdisplayed.Add("");

            itemNameisdisplayed.Add("Item details screen: Sauce Labs Bolt T-Shirt");
            itemNameisdisplayed.Add("Is item name displayed?: True");
            itemNameisdisplayed.Add("");

            itemNameisdisplayed.Add("Item details screen: Sauce Labs Fleece Jacket");
            itemNameisdisplayed.Add("Is item name displayed?: True");
            itemNameisdisplayed.Add("");

            itemNameisdisplayed.Add("Item details screen: Sauce Labs Onesie");
            itemNameisdisplayed.Add("Is item name displayed?: True");
            itemNameisdisplayed.Add("");

            itemNameisdisplayed.Add("Item details screen: Test.allTheThings() T-Shirt (Red)");
            itemNameisdisplayed.Add("Is item name displayed?: True");
            itemNameisdisplayed.Add("");

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
            Console.WriteLine();
            Console.WriteLine("Actual result: ");
            foreach (string item in actualresult)
            {
                Console.WriteLine(item);
            }

            /* ASSERTION EXPECTED RESULT VS ACTUAL RESULT */
            Assert.That(actualresult, Is.EqualTo(expectedresult));
        }

        [Test, Order(3)]
        [Category("Inventory Item Screen | Item description is displayed")]
        public void TestCase_0803()
        {
            /* TEST CASE */
            string testcase = "0803 | Inventory Item Screen | Item description is displayed";

            /* GET ITEM NAME */
            List<string> itemName = inventoryitemscreen!.GetItemName();

            /* GET ITEM DESCRIPTION DISPLAYED */
            List<string> itemdescriptionDisplayed = inventoryitemscreen.GetItemDescriptionDisplayed(itemName);

            /* EXPECTED RESULT */
            List<string> itemdescriptiondisplayed = new List<string>();
            List<string> expectedresult = itemdescriptiondisplayed;

            itemdescriptiondisplayed.Add("Item details screen: Sauce Labs Backpack");
            itemdescriptiondisplayed.Add("Item description: carry.allTheThings() with the sleek, streamlined Sly Pack that melds uncompromising style with unequaled laptop and tablet protection.");
            itemdescriptiondisplayed.Add("Is item description displayed?: True");
            itemdescriptiondisplayed.Add("");

            itemdescriptiondisplayed.Add("Item details screen: Sauce Labs Bike Light");
            itemdescriptiondisplayed.Add("Item description: A red light isn't the desired state in testing but it sure helps when riding your bike at night. Water-resistant with 3 lighting modes, 1 AAA battery included.");
            itemdescriptiondisplayed.Add("Is item description displayed?: True");
            itemdescriptiondisplayed.Add("");

            itemdescriptiondisplayed.Add("Item details screen: Sauce Labs Bolt T-Shirt");
            itemdescriptiondisplayed.Add("Item description: Get your testing superhero on with the Sauce Labs bolt T-shirt. From American Apparel, 100% ringspun combed cotton, heather gray with red bolt.");
            itemdescriptiondisplayed.Add("Is item description displayed?: True");
            itemdescriptiondisplayed.Add("");

            itemdescriptiondisplayed.Add("Item details screen: Sauce Labs Fleece Jacket");
            itemdescriptiondisplayed.Add("Item description: It's not every day that you come across a midweight quarter-zip fleece jacket capable of handling everything from a relaxing day outdoors to a busy day at the office.");
            itemdescriptiondisplayed.Add("Is item description displayed?: True");
            itemdescriptiondisplayed.Add("");

            itemdescriptiondisplayed.Add("Item details screen: Sauce Labs Onesie");
            itemdescriptiondisplayed.Add("Item description: Rib snap infant onesie for the junior automation engineer in development. Reinforced 3-snap bottom closure, two-needle hemmed sleeved and bottom won't unravel.");
            itemdescriptiondisplayed.Add("Is item description displayed?: True");
            itemdescriptiondisplayed.Add("");

            itemdescriptiondisplayed.Add("Item details screen: Test.allTheThings() T-Shirt (Red)");
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
            Console.WriteLine();
            Console.WriteLine("Actual result: ");
            foreach (string item in actualresult)
            {
                Console.WriteLine(item);
            }

            /* ASSERTION EXPECTED RESULT VS ACTUAL RESULT */
            Assert.That(actualresult, Is.EqualTo(expectedresult));
        }

        [Test, Order(4)]
        [Category("Inventory Item Screen | Item price is displayed")]
        public void TestCase_0804()
        {
            /* TEST CASE */
            string testcase = "0804 | Inventory Item Screen | Item price is displayed";

            /* GET ITEM NAME */
            List<string> itemName = inventoryitemscreen!.GetItemName();

            /* GET ITEM PRICE DISPLAYED */
            List<string> itempriceDisplayed = inventoryitemscreen!.GetItemPriceDisplayed(itemName);

            /* EXPECTED RESULT */
            List<string> itempricedisplayed = new List<string>();
            List<string> expectedresult = itempricedisplayed;

            itempricedisplayed.Add("Item details screen: Sauce Labs Backpack");
            itempricedisplayed.Add("Item price: $29.99");
            itempricedisplayed.Add("Is item price displayed?: True");
            itempricedisplayed.Add("");

            itempricedisplayed.Add("Item details screen: Sauce Labs Bike Light");
            itempricedisplayed.Add("Item price: $9.99");
            itempricedisplayed.Add("Is item price displayed?: True");
            itempricedisplayed.Add("");

            itempricedisplayed.Add("Item details screen: Sauce Labs Bolt T-Shirt");
            itempricedisplayed.Add("Item price: $15.99");
            itempricedisplayed.Add("Is item price displayed?: True");
            itempricedisplayed.Add("");

            itempricedisplayed.Add("Item details screen: Sauce Labs Fleece Jacket");
            itempricedisplayed.Add("Item price: $49.99");
            itempricedisplayed.Add("Is item price displayed?: True");
            itempricedisplayed.Add("");

            itempricedisplayed.Add("Item details screen: Sauce Labs Onesie");
            itempricedisplayed.Add("Item price: $7.99");
            itempricedisplayed.Add("Is item price displayed?: True");
            itempricedisplayed.Add("");

            itempricedisplayed.Add("Item details screen: Test.allTheThings() T-Shirt (Red)");
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
            Console.WriteLine();
            Console.WriteLine("Actual result: ");
            foreach (string item in actualresult)
            {
                Console.WriteLine(item);
            }

            /* ASSERTION EXPECTED RESULT VS ACTUAL RESULT */
            Assert.That(actualresult, Is.EqualTo(expectedresult));
        }

        [Test, Order(5)]
        [Category("Inventory Item Screen | Add to cart button is displayed")]
        public void TestCase_0805()
        {
            /* TEST CASE */
            string testcase = "0805 | Inventory Item Screen | Add to cart button is displayed";

            /* GET INVENTORY ITEM NAME LIST */
            List<string> itemName = inventoryitemscreen!.GetItemName();

            /* GET ADD TO CART BUTTON IS DISPLAYED */
            List<string> addtocartDisplayed = inventoryitemscreen.GetButtonDisplayed(itemName, By.CssSelector(inventoryitemscreen!.btn_addtocart));

            /* EXPECTED RESULT */
            List<string> addtocartdisplayed = new List<string>();
            List<string> expectedresult = addtocartdisplayed;

            addtocartdisplayed.Add("Item details screen: Sauce Labs Backpack");
            addtocartdisplayed.Add("Button text: Add to cart");
            addtocartdisplayed.Add("Is button displayed?: True");
            addtocartdisplayed.Add("");

            addtocartdisplayed.Add("Item details screen: Sauce Labs Bike Light");
            addtocartdisplayed.Add("Button text: Add to cart");
            addtocartdisplayed.Add("Is button displayed?: True");
            addtocartdisplayed.Add("");

            addtocartdisplayed.Add("Item details screen: Sauce Labs Bolt T-Shirt");
            addtocartdisplayed.Add("Button text: Add to cart");
            addtocartdisplayed.Add("Is button displayed?: True");
            addtocartdisplayed.Add("");

            addtocartdisplayed.Add("Item details screen: Sauce Labs Fleece Jacket");
            addtocartdisplayed.Add("Button text: Add to cart");
            addtocartdisplayed.Add("Is button displayed?: True");
            addtocartdisplayed.Add("");

            addtocartdisplayed.Add("Item details screen: Sauce Labs Onesie");
            addtocartdisplayed.Add("Button text: Add to cart");
            addtocartdisplayed.Add("Is button displayed?: True");
            addtocartdisplayed.Add("");

            addtocartdisplayed.Add("Item details screen: Test.allTheThings() T-Shirt (Red)");
            addtocartdisplayed.Add("Button text: Add to cart");
            addtocartdisplayed.Add("Is button displayed?: True");
            addtocartdisplayed.Add("");

            /* ACTUAL RESULT */
            List<string> actualresult = addtocartDisplayed;

            /* PRINT EXPECTED RESULT VS ACTUAL RESULT */
            Console.WriteLine(testcase);
            Console.WriteLine();

            Console.WriteLine("Expected result:");
            foreach (string item in expectedresult)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();
            Console.WriteLine("Actual result: ");
            foreach (string item in actualresult)
            {
                Console.WriteLine(item);
            }

            /* ASSERTION EXPECTED RESULT VS ACTUAL RESULT */
            Assert.That(actualresult, Is.EqualTo(expectedresult));
        }

        [Test, Order(6)]
        [Category("Inventory Item Screen | Remove from cart button is displayed")]
        public void TestCase_0806()
        {
            /* TEST CASE */
            string testcase = "0806 | Inventory Item Screen | Remove from cart button is displayed";

            /* GET ITEM NAME */
            List<string> itemName = inventoryitemscreen!.GetItemName();

            /* ADD ITEM TO CART */
            inventoryitemscreen!.AddItemToCart(itemName);

            /* GET REMOVE FROM CART BUTTON DISPLAYED */
            List<string> removefromcartDisplayed = inventoryitemscreen!.GetButtonDisplayed(itemName, By.CssSelector(inventoryitemscreen!.btn_removefromcart));

            /* EXPECTED RESULT */
            List<string> removefromcartdisplayed = new List<string>();
            List<string> expectedresult = removefromcartdisplayed;

            removefromcartdisplayed.Add("Item details screen: Sauce Labs Backpack");
            removefromcartdisplayed.Add("Button text: Remove");
            removefromcartdisplayed.Add("Is button displayed?: True");
            removefromcartdisplayed.Add("");

            removefromcartdisplayed.Add("Item details screen: Sauce Labs Bike Light");
            removefromcartdisplayed.Add("Button text: Remove");
            removefromcartdisplayed.Add("Is button displayed?: True");
            removefromcartdisplayed.Add("");

            removefromcartdisplayed.Add("Item details screen: Sauce Labs Bolt T-Shirt");
            removefromcartdisplayed.Add("Button text: Remove");
            removefromcartdisplayed.Add("Is button displayed?: True");
            removefromcartdisplayed.Add("");

            removefromcartdisplayed.Add("Item details screen: Sauce Labs Fleece Jacket");
            removefromcartdisplayed.Add("Button text: Remove");
            removefromcartdisplayed.Add("Is button displayed?: True");
            removefromcartdisplayed.Add("");

            removefromcartdisplayed.Add("Item details screen: Sauce Labs Onesie");
            removefromcartdisplayed.Add("Button text: Remove");
            removefromcartdisplayed.Add("Is button displayed?: True");
            removefromcartdisplayed.Add("");

            removefromcartdisplayed.Add("Item details screen: Test.allTheThings() T-Shirt (Red)");
            removefromcartdisplayed.Add("Button text: Remove");
            removefromcartdisplayed.Add("Is button displayed?: True");
            removefromcartdisplayed.Add("");

            /* ACTUAL RESULT */
            List<string> actualresult = removefromcartDisplayed;

            /* PRINT EXPECTED RESULT VS ACTUAL RESULT */
            Console.WriteLine(testcase);
            Console.WriteLine();

            Console.WriteLine("Expected result:");
            foreach (string item in expectedresult)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();
            Console.WriteLine("Actual result: ");
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