using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using SauceDemo.POM;

namespace SauceDemo.Tests.InventoryItem
{
    [TestFixture]
    public class Scenario_07
    {
        IWebDriver? driver;
        Login_POM? loginscreen;
        InventoryItem_POM? inventoryitemscreen;

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

            inventoryitemscreen = new InventoryItem_POM(driver);
        }

        [Test, Order(1)]
        [Category("Inventory Item Screen | Back to products button is displayed")]
        public void TestCase_0701()
        {
            /* TEST CASE */
            string testcase = "0701 | Inventory Item Screen | Back to products button is displayed";

            /* GET ITEM NAME */
            List<string> itemName = inventoryitemscreen!.GetItemName();

            /* GET BACK TO PRODUCTS BUTTON DISPLAYED */
            List<string> backtoproductsDisplayed = inventoryitemscreen!.GetButtonDisplayed(itemName, By.CssSelector(inventoryitemscreen!.btn_backtoproducts));

            /* EXPECTED RESULT */
            List<string> backtoproductsdisplayed = new List<string>();
            List<string> expectedresult = backtoproductsdisplayed;

            backtoproductsdisplayed.Add("Item details screen: Sauce Labs Backpack");
            backtoproductsdisplayed.Add("Button text: Back to products");
            backtoproductsdisplayed.Add("Is button displayed?: True");
            backtoproductsdisplayed.Add("");

            backtoproductsdisplayed.Add("Item details screen: Sauce Labs Bike Light");
            backtoproductsdisplayed.Add("Button text: Back to products");
            backtoproductsdisplayed.Add("Is button displayed?: True");
            backtoproductsdisplayed.Add("");

            backtoproductsdisplayed.Add("Item details screen: Sauce Labs Bolt T-Shirt");
            backtoproductsdisplayed.Add("Button text: Back to products");
            backtoproductsdisplayed.Add("Is button displayed?: True");
            backtoproductsdisplayed.Add("");

            backtoproductsdisplayed.Add("Item details screen: Sauce Labs Fleece Jacket");
            backtoproductsdisplayed.Add("Button text: Back to products");
            backtoproductsdisplayed.Add("Is button displayed?: True");
            backtoproductsdisplayed.Add("");

            backtoproductsdisplayed.Add("Item details screen: Sauce Labs Onesie");
            backtoproductsdisplayed.Add("Button text: Back to products");
            backtoproductsdisplayed.Add("Is button displayed?: True");
            backtoproductsdisplayed.Add("");

            backtoproductsdisplayed.Add("Item details screen: Test.allTheThings() T-Shirt (Red)");
            backtoproductsdisplayed.Add("Button text: Back to products");
            backtoproductsdisplayed.Add("Is button displayed?: True");
            backtoproductsdisplayed.Add("");

            /* ACTUAL RESULT */
            List<string> actualresult = backtoproductsDisplayed;

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
        [Category("Inventory Item Screen | Back to products button redirects to inventory screen")]
        public void TestCase_0702()
        {
            /* TEST CASE */
            string testcase = "0702 | Inventory Item Screen | Back to products button redirects to inventory screen";

            /* GET ITEM NAME */
            List<string> itemName = inventoryitemscreen!.GetItemName();

            /* GET ITEM URL REDIRECTION */
            List<string> itemUrl = inventoryitemscreen!.GetItemUrlRedirection(itemName);

            /* EXPECTED RESULT */
            List<string> itemurl = new List<string>();
            List<string> expectedresult = itemurl;

            itemurl.Add("Item details screen: Sauce Labs Backpack");
            itemurl.Add("Back to products link redirects to: https://www.saucedemo.com/inventory.html");
            itemurl.Add("");

            itemurl.Add("Item details screen: Sauce Labs Bike Light");
            itemurl.Add("Back to products link redirects to: https://www.saucedemo.com/inventory.html");
            itemurl.Add("");

            itemurl.Add("Item details screen: Sauce Labs Bolt T-Shirt");
            itemurl.Add("Back to products link redirects to: https://www.saucedemo.com/inventory.html");
            itemurl.Add("");

            itemurl.Add("Item details screen: Sauce Labs Fleece Jacket");
            itemurl.Add("Back to products link redirects to: https://www.saucedemo.com/inventory.html");
            itemurl.Add("");

            itemurl.Add("Item details screen: Sauce Labs Onesie");
            itemurl.Add("Back to products link redirects to: https://www.saucedemo.com/inventory.html");
            itemurl.Add("");

            itemurl.Add("Item details screen: Test.allTheThings() T-Shirt (Red)");
            itemurl.Add("Back to products link redirects to: https://www.saucedemo.com/inventory.html");
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

        [OneTimeTearDown]
        public void Teardown()
        {
            driver?.Dispose();
        }
    }
}