using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SauceDemo.POM;

namespace SauceDemo.Tests.Inventory
{
    [TestFixture]
    public class Scenario_06
    {
        IWebDriver? driver;
        Login_POM? loginscreen;
        Inventory_POM? inventoryscreen;

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

            inventoryscreen = new Inventory_POM(driver);
        }

        [Test, Order(1)]
        [Category("Inventory Screen | Title is displayed")]
        public void TestCase_0601()
        {
            /* TEST CASE */
            string testcase = "0601 | Inventory Screen | Title is displayed";

            /* GET TITLE DISPLAYED */
            Boolean titleDisplayed = inventoryscreen!.GetElementDisplayed(By.CssSelector(inventoryscreen!.span_title));

            /* EXPECTED RESULT */
            Boolean titledisplayed = true;
            Boolean expectedresult = titledisplayed;

            /* ACTUAL RESULT */
            Boolean actualresult = titleDisplayed;

            /* PRINT EXPECTED VS ACTUAL RESULT */
            Console.WriteLine(testcase);
            Console.WriteLine();

            Console.WriteLine("Expected result: " + expectedresult);
            Console.WriteLine("Actual result: " + actualresult);

            /* ASSERTION EXPECTED RESULT VS ACTUAL RESULT */
            Assert.That(actualresult, Is.EqualTo(expectedresult));
        }

        [Test, Order(2)]
        [Category("Inventory Screen | Item image is displayed")]
        public void TestCase_0602()
        {
            /* TEST CASE */
            string testcase = "0602 | Inventory Screen | Item image is displayed";

            /* GET ITEM IMAGE DISPLAYED */
            List<string> itemimageDisplayed = inventoryscreen!.GetItemImageDisplayed();

            /* EXPECTED RESULT */
            List<string> itemimagedisplayed = new List<string>();
            List<string> expectedresult = itemimagedisplayed;

            itemimagedisplayed.Add("Item name: Sauce Labs Backpack");
            itemimagedisplayed.Add("Item image: https://www.saucedemo.com/static/media/sauce-backpack-1200x1500.0a0b85a3.jpg");
            itemimagedisplayed.Add("Is item image displayed?: True");
            itemimagedisplayed.Add("");

            itemimagedisplayed.Add("Item name: Sauce Labs Bike Light");
            itemimagedisplayed.Add("Item image: https://www.saucedemo.com/static/media/bike-light-1200x1500.37c843b0.jpg");
            itemimagedisplayed.Add("Is item image displayed?: True");
            itemimagedisplayed.Add("");

            itemimagedisplayed.Add("Item name: Sauce Labs Bolt T-Shirt");
            itemimagedisplayed.Add("Item image: https://www.saucedemo.com/static/media/bolt-shirt-1200x1500.c2599ac5.jpg");
            itemimagedisplayed.Add("Is item image displayed?: True");
            itemimagedisplayed.Add("");

            itemimagedisplayed.Add("Item name: Sauce Labs Fleece Jacket");
            itemimagedisplayed.Add("Item image: https://www.saucedemo.com/static/media/sauce-pullover-1200x1500.51d7ffaf.jpg");
            itemimagedisplayed.Add("Is item image displayed?: True");
            itemimagedisplayed.Add("");

            itemimagedisplayed.Add("Item name: Sauce Labs Onesie");
            itemimagedisplayed.Add("Item image: https://www.saucedemo.com/static/media/red-onesie-1200x1500.2ec615b2.jpg");
            itemimagedisplayed.Add("Is item image displayed?: True");
            itemimagedisplayed.Add("");

            itemimagedisplayed.Add("Item name: Test.allTheThings() T-Shirt (Red)");
            itemimagedisplayed.Add("Item image: https://www.saucedemo.com/static/media/red-tatt-1200x1500.30dadef4.jpg");
            itemimagedisplayed.Add("Is item image displayed?: True");
            itemimagedisplayed.Add("");

            /* ACTUAL RESULT */
            List<string> actualresult = itemimageDisplayed;            

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
        [Category("Inventory Screen | Item name is displayed")]
        public void TestCase_0603()
        {
            /* TEST CASE */
            string testcase = "0603 | Inventory Screen | Item name is displayed";

            /* GET ITEM NAME DISPLAYED */
            List<string> itemnameDisplayed = inventoryscreen!.GetItemNameDisplayed();

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
        [Category("Inventory Screen | Item tag name is a")]
        public void TestCase_0604()
        {
            /* TEST CASE */
            string testcase = "0604 | Inventory Screen | Item tag name is a";

            /* GET ITEM TAG NAME */
            List<string> itemTagname = inventoryscreen!.GetItemTagName();

            /* EXPECTED RESULT */
            List<string> itemtagname = new List<string>();
            List<string> expectedresult = itemtagname;

            itemtagname.Add("Item name: Sauce Labs Backpack");
            itemtagname.Add("Item tag name: a");
            itemtagname.Add("");

            itemtagname.Add("Item name: Sauce Labs Bike Light");
            itemtagname.Add("Item tag name: a");
            itemtagname.Add("");

            itemtagname.Add("Item name: Sauce Labs Bolt T-Shirt");
            itemtagname.Add("Item tag name: a");
            itemtagname.Add("");

            itemtagname.Add("Item name: Sauce Labs Fleece Jacket");
            itemtagname.Add("Item tag name: a");
            itemtagname.Add("");

            itemtagname.Add("Item name: Sauce Labs Onesie");
            itemtagname.Add("Item tag name: a");
            itemtagname.Add("");

            itemtagname.Add("Item name: Test.allTheThings() T-Shirt (Red)");
            itemtagname.Add("Item tag name: a");
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
        [Category("Inventory Screen | Item name redirects to item description screen")]
        public void TestCase_0605()
        {
            /* TEST CASE */
            string testcase = "0605 | Inventory Screen | Item name redirects to item description screen";

            /* GET ITEM NAME */
            List<string> itemName = inventoryscreen!.GetItemName();

            /* GET ITEM URL */
            List<string> itemUrl = inventoryscreen!.GetItemUrl(itemName);

            /* EXPECTED RESULT */
            List<string> itemurl = new List<string>();
            List<string> expectedresult = itemurl;

            itemurl.Add("Item name: Sauce Labs Backpack");
            itemurl.Add("Item url: https://www.saucedemo.com/inventory-item.html?id=4");
            itemurl.Add("");

            itemurl.Add("Item name: Sauce Labs Bike Light");
            itemurl.Add("Item url: https://www.saucedemo.com/inventory-item.html?id=0");
            itemurl.Add("");

            itemurl.Add("Item name: Sauce Labs Bolt T-Shirt");
            itemurl.Add("Item url: https://www.saucedemo.com/inventory-item.html?id=1");
            itemurl.Add("");

            itemurl.Add("Item name: Sauce Labs Fleece Jacket");
            itemurl.Add("Item url: https://www.saucedemo.com/inventory-item.html?id=5");
            itemurl.Add("");

            itemurl.Add("Item name: Sauce Labs Onesie");
            itemurl.Add("Item url: https://www.saucedemo.com/inventory-item.html?id=2");
            itemurl.Add("");

            itemurl.Add("Item name: Test.allTheThings() T-Shirt (Red)");
            itemurl.Add("Item url: https://www.saucedemo.com/inventory-item.html?id=3");
            itemurl.Add("");

            /* ACTUAL RESULT */
            List<string> actualresult = itemUrl;

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
        [Category("Inventory Screen | Item description is displayed")]
        public void TestCase_0606()
        {
            /* TEST CASE */
            string testcase = "0606 | Inventory Screen | Item description is displayed";

            /* GET ITEM DESCRIPTION DISPLAYED */
            List<string> itemdescriptionDisplayed = inventoryscreen!.GetItemDescriptionDisplayed();

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
            Console.WriteLine();
            Console.WriteLine("Actual result: ");
            foreach (string item in actualresult)
            {
                Console.WriteLine(item);
            }

            /* ASSERTION EXPECTED RESULT VS ACTUAL RESULT */
            Assert.That(actualresult, Is.EqualTo(expectedresult));
        }

        [Test, Order(7)]
        [Category("Inventory Screen | Item price is displayed")]
        public void TestCase_0607()
        {
            /* TEST CASE */
            string testcase = "0607 | Inventory Screen | Item price is displayed";

            /* GET ITEM PRICE DISPLAYED */
            List<string> itempriceDisplayed = inventoryscreen!.GetItemPriceDisplayed();

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
            Console.WriteLine();
            Console.WriteLine("Actual result: ");
            foreach (string item in actualresult)
            {
                Console.WriteLine(item);
            }

            /* ASSERTION EXPECTED RESULT VS ACTUAL RESULT */
            Assert.That(actualresult, Is.EqualTo(expectedresult));
        }

        [Test, Order(8)]
        [Category("Inventory Screen | Add To Cart button is displayed")]
        public void TestCase_0608()
        {
            /* TEST CASE */
            string testcase = "0608 | Inventory Screen | Add To Cart button is displayed";

            /* GET ITEM ADD TO CART BUTTON DISPLAYED */
            List<string> addtocartDisplayed = inventoryscreen!.GetButtonDisplayed(By.CssSelector(inventoryscreen!.div_itemname), By.CssSelector(inventoryscreen!.btn_addtocart));

            /* EXPECTED RESULT */
            List<string> addtocartdisplayed = new List<string>();
            List<string> expectedresult = addtocartdisplayed;

            addtocartdisplayed.Add("Item name: Sauce Labs Backpack");
            addtocartdisplayed.Add("Button text: Add to cart");
            addtocartdisplayed.Add("Is button displayed?: True");
            addtocartdisplayed.Add("");

            addtocartdisplayed.Add("Item name: Sauce Labs Bike Light");
            addtocartdisplayed.Add("Button text: Add to cart");
            addtocartdisplayed.Add("Is button displayed?: True");
            addtocartdisplayed.Add("");

            addtocartdisplayed.Add("Item name: Sauce Labs Bolt T-Shirt");
            addtocartdisplayed.Add("Button text: Add to cart");
            addtocartdisplayed.Add("Is button displayed?: True");
            addtocartdisplayed.Add("");

            addtocartdisplayed.Add("Item name: Sauce Labs Fleece Jacket");
            addtocartdisplayed.Add("Button text: Add to cart");
            addtocartdisplayed.Add("Is button displayed?: True");
            addtocartdisplayed.Add("");

            addtocartdisplayed.Add("Item name: Sauce Labs Onesie");
            addtocartdisplayed.Add("Button text: Add to cart");
            addtocartdisplayed.Add("Is button displayed?: True");
            addtocartdisplayed.Add("");

            addtocartdisplayed.Add("Item name: Test.allTheThings() T-Shirt (Red)");
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

        [Test, Order(9)]
        [Category("Inventory Screen | Remove from cart button is displayed")]
        public void TestCase_0609()
        {
            /* TEST CASE */
            string testcase = "0609 | Inventory Screen | Remove from cart button is displayed";

            /* ADD ALL ITEMS TO CART */
            inventoryscreen!.AddAllItemsToCart();

            /* GET REMOVE FROM CART BUTTON DISPLAYED */
            List<string> removefromcartDisplayed = inventoryscreen!.GetButtonDisplayed(By.CssSelector(inventoryscreen!.div_itemname), By.CssSelector(inventoryscreen!.btn_removefromcart));

            /* EXPECTED RESULT */
            List<string> removefromcartdisplayed = new List<string>();
            List<string> expectedresult = removefromcartdisplayed;

            removefromcartdisplayed.Add("Item name: Sauce Labs Backpack");
            removefromcartdisplayed.Add("Button text: Remove");
            removefromcartdisplayed.Add("Is button displayed?: True");
            removefromcartdisplayed.Add("");

            removefromcartdisplayed.Add("Item name: Sauce Labs Bike Light");
            removefromcartdisplayed.Add("Button text: Remove");
            removefromcartdisplayed.Add("Is button displayed?: True");
            removefromcartdisplayed.Add("");

            removefromcartdisplayed.Add("Item name: Sauce Labs Bolt T-Shirt");
            removefromcartdisplayed.Add("Button text: Remove");
            removefromcartdisplayed.Add("Is button displayed?: True");
            removefromcartdisplayed.Add("");

            removefromcartdisplayed.Add("Item name: Sauce Labs Fleece Jacket");
            removefromcartdisplayed.Add("Button text: Remove");
            removefromcartdisplayed.Add("Is button displayed?: True");
            removefromcartdisplayed.Add("");

            removefromcartdisplayed.Add("Item name: Sauce Labs Onesie");
            removefromcartdisplayed.Add("Button text: Remove");
            removefromcartdisplayed.Add("Is button displayed?: True");
            removefromcartdisplayed.Add("");

            removefromcartdisplayed.Add("Item name: Test.allTheThings() T-Shirt (Red)");
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