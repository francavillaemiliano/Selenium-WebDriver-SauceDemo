using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Swag_Labs
{
    [TestFixture]
    public class Scenario_05
    {
        IWebDriver? driver;
        LoginScreen? loginscreen;
        InventoryScreen? inventoryscreen;
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

            inventoryscreen = new InventoryScreen(driver);
        }

        [Test, Order(1)]
        [Category("Inventory Screen | Sorting is displayed")]
        public void TestCase_0501()
        {
            /* TEST CASE */
            string testcase = "0501 | Inventory Screen | Sorting is displayed";

            /* GET SORTING DISPLAYED */
            Boolean sortingDisplayed = inventoryscreen!.GetElementDisplayed(By.CssSelector(inventoryscreen!.select_sorting));

            /* EXPECTED RESULT */
            Boolean sortingdisplayed = true;
            Boolean expectedresult = sortingdisplayed;

            /* ACTUAL RESULT */
            Boolean actualresult = sortingDisplayed;

            /* PRINT EXPECTED RESULT VS ACTUAL RESULT */
            Console.WriteLine(testcase);
            Console.WriteLine();

            Console.WriteLine("Expected result: " + expectedresult);
            Console.WriteLine("Actual result: " + actualresult);

            /* ASSERTION EXPECTED RESULT VS ACTUAL RESULT */
            Assert.That(actualresult, Is.EqualTo(expectedresult));
        }

        [Test, Order(2)]
        [Category("Inventory Screen | Sorting contains Name (A to Z), Name (Z to A), Price (low to high), Price (high to low)")]
        public void TestCase_0502()
        {
            /* TEST CASE */
            string testcase = "0502 | Inventory Screen | Sorting contains Name (A to Z), Name (Z to A), Price (low to high), Price (high to low)";

            /* GET ALL OPTIONS FROM SORTING */
            List<string> sortingOptions = inventoryscreen!.GetAllSortingOptions();

            /* EXPECTED RESULT */
            List<string> sortingoptions = new List<string>();
            List<string> expectedresult = sortingoptions;

            expectedresult.Add("Name (A to Z)");
            expectedresult.Add("Name (Z to A)");
            expectedresult.Add("Price (low to high)");
            expectedresult.Add("Price (high to low)");

            /* ACTUAL RESULT */
            List<string> actualresult = sortingOptions;

            /* PRINT EXPECTED RESULT VS ACTUAL RESULT */
            Console.WriteLine(testcase);
            Console.WriteLine();

            Console.WriteLine("Expected result:");
            foreach (string option in expectedresult)
            {
                Console.WriteLine(option);
            }
            Console.WriteLine();
            Console.WriteLine("Actual result: ");
            foreach (string option in actualresult)
            {
                Console.WriteLine(option);
            }

            /* ASSERTION EXPECTED RESULT VS ACTUAL RESULT */
            Assert.That(actualresult, Is.EqualTo(expectedresult));
        }

        [Test, Order(3)]
        [Category("Inventory Screen | Sorting tag name is Select")]
        public void TestCase_0503()
        {
            /* TEST CASE */
            string testcase = "0503 | Inventory Screen | Sorting tag name is Select";

            /* GET SORTING TAG NAME */
            string sortingTagname = inventoryscreen!.GetSortingTagName();

            /* EXPECTED RESULT */
            string sortingtagname = "select";
            string expectedresult = sortingtagname;

            /* ACTUAL RESULT */
            string actualresult = sortingTagname;

            /* PRINT EXPECTED RESULT VS ACTUAL RESULT */
            Console.WriteLine(testcase);
            Console.WriteLine();

            Console.WriteLine("Expected result: " + expectedresult);
            Console.WriteLine("Actual result: " + actualresult);

            /* ASSERTION EXPECTED RESULT VS ACTUAL RESULT */
            Assert.That(actualresult, Is.EqualTo(expectedresult));
        }

        [Test, Order(4)]
        [Category("Inventory Screen | Sorting default value is Name (A to Z)")]
        public void TestCase_0504()
        {
            /* TEST CASE */
            string testcase = "0504 | Inventory Screen | Sorting default value is Name (A to Z)";

            /* GET SORTING SELECTED OPTION */
            string sortingSelectedoption = inventoryscreen!.GetSortingSelectedOption();

            /* EXPECTED RESULT */
            string sortingselectedoption = "Name (A to Z)";
            string expectedresult = sortingselectedoption;

            /* ACTUAL RESULT */
            string actualresult = sortingSelectedoption;

            /* PRINT EXPECTED RESULT VS ACTUAL RESULT */
            Console.WriteLine(testcase);
            Console.WriteLine();

            Console.WriteLine("Expected result: " + expectedresult);
            Console.WriteLine("Actual result: " + actualresult);

            /* ASSERTION EXPECTED RESULT VS ACTUAL RESULT */
            Assert.That(actualresult, Is.EqualTo(expectedresult));
        }

        [Test, Order(5)]
        [Category("Inventory Screen | Sorting sorts by Name (Z to A)")]
        public void TestCase_0505()
        {
            /* TEST CASE */
            string testcase = "0505 | Inventory Screen | Sorting sorts by Name (Z to A)";

            /* SELECT SORTING OPTION NAME (Z TO A) */
            inventoryscreen!.SelectSortingOption(inventoryscreen!.nameZtoA);

            /* GET INVENTORY ITEM NAME */
            List<string> inventoryItemname = inventoryscreen.GetItemName();

            /* EXPECTED RESULT */
            List<string> inventoryitemname = new List<string>();
            List<string> expectedresult = inventoryitemname;

            inventoryitemname.Add("Test.allTheThings() T-Shirt (Red)");
            inventoryitemname.Add("Sauce Labs Onesie");
            inventoryitemname.Add("Sauce Labs Fleece Jacket");
            inventoryitemname.Add("Sauce Labs Bolt T-Shirt");
            inventoryitemname.Add("Sauce Labs Bike Light");
            inventoryitemname.Add("Sauce Labs Backpack");

            /* ACTUAL RESULT */
            List<string> actualresult = inventoryItemname;

            /* PRINT EXPECTED RESULT VS ACTUAL RESULT */
            Console.WriteLine(testcase);
            Console.WriteLine();

            Console.WriteLine("Expected result:");
            foreach (string option in expectedresult)
            {
                Console.WriteLine(option);
            }
            Console.WriteLine();
            Console.WriteLine("Actual result: ");
            foreach (string option in actualresult)
            {
                Console.WriteLine(option);
            }

            /* ASSERTION EXPECTED RESULT VS ACTUAL RESULT */
            Assert.That(actualresult, Is.EqualTo(expectedresult));
        }

        [Test, Order(6)]
        [Category("Inventory Screen | Sorting sorts by Name (A to Z)")]
        public void TestCase_0506()
        {
            /* TEST CASE */
            string testcase = "0506 | Inventory Screen | Sorting sorts by Name (A to Z)";

            /* SELECT SORTING OPTION NAME (A TO Z) */
            inventoryscreen!.SelectSortingOption(inventoryscreen!.nameAtoZ);

            /* GET INVENTORY ITEM NAME */
            List<string> inventoryItemname = inventoryscreen!.GetItemName();

            /* EXPECTED RESULT */
            List<string> inventoryitemname = new List<string>();
            List<string> expectedresult = inventoryitemname;

            inventoryitemname.Add("Sauce Labs Backpack");
            inventoryitemname.Add("Sauce Labs Bike Light");
            inventoryitemname.Add("Sauce Labs Bolt T-Shirt");
            inventoryitemname.Add("Sauce Labs Fleece Jacket");
            inventoryitemname.Add("Sauce Labs Onesie");
            inventoryitemname.Add("Test.allTheThings() T-Shirt (Red)");

            /* ACTUAL RESULT */
            List<string> actualresult = inventoryItemname;

            /* PRINT EXPECTED RESULT VS ACTUAL RESULT */
            Console.WriteLine(testcase);
            Console.WriteLine();

            Console.WriteLine("Expected result:");
            foreach (string option in expectedresult)
            {
                Console.WriteLine(option);
            }
            Console.WriteLine();
            Console.WriteLine("Actual result: ");
            foreach (string option in actualresult)
            {
                Console.WriteLine(option);
            }

            /* ASSERTION EXPECTED RESULT VS ACTUAL RESULT */
            Assert.That(actualresult, Is.EqualTo(expectedresult));
        }

        [Test, Order(7)]
        [Category("Inventory Screen | Sorting sorts by Price (Low to High)")]
        public void TestCase_0507()
        {
            /* TEST CASE */
            string testcase = "0507 | Inventory Screen | Sorting sorts by Price (Low to High)";

            /* SELECT SORTING OPTION PRICE (LOW TO HIGH) */
            inventoryscreen!.SelectSortingOption(inventoryscreen!.priceLowtoHigh);

            /* GET ITEM PRICE ORDER */
            List<string> inventoryItemprice = inventoryscreen!.GetItemPriceOrder();

            /* EXPECTED RESULT */
            List<string> inventoryitemprice = new List<string>();
            List<string> expectedresult = inventoryitemprice;

            inventoryitemprice.Add("Item name: Sauce Labs Onesie");
            inventoryitemprice.Add("Item price: $7.99");
            inventoryitemprice.Add("");

            inventoryitemprice.Add("Item name: Sauce Labs Bike Light");
            inventoryitemprice.Add("Item price: $9.99");
            inventoryitemprice.Add("");

            inventoryitemprice.Add("Item name: Sauce Labs Bolt T-Shirt");
            inventoryitemprice.Add("Item price: $15.99");
            inventoryitemprice.Add("");

            inventoryitemprice.Add("Item name: Test.allTheThings() T-Shirt (Red)");
            inventoryitemprice.Add("Item price: $15.99");
            inventoryitemprice.Add("");

            inventoryitemprice.Add("Item name: Sauce Labs Backpack");
            inventoryitemprice.Add("Item price: $29.99");
            inventoryitemprice.Add("");

            inventoryitemprice.Add("Item name: Sauce Labs Fleece Jacket");
            inventoryitemprice.Add("Item price: $49.99");
            inventoryitemprice.Add("");

            /* ACTUAL RESULT */
            List<string> actualresult = inventoryItemprice;

            /* PRINT EXPECTED RESULT VS ACTUAL RESULT */
            Console.WriteLine(testcase);
            Console.WriteLine();

            Console.WriteLine("Expected result:");
            foreach (string option in expectedresult)
            {
                Console.WriteLine(option);
            }
            Console.WriteLine();
            Console.WriteLine("Actual result: ");
            foreach (string option in actualresult)
            {
                Console.WriteLine(option);
            }

            /* ASSERTION EXPECTED RESULT VS ACTUAL RESULT */
            Assert.That(actualresult, Is.EqualTo(expectedresult));
        }

        [Test, Order(8)]
        [Category("Inventory Screen | Sorting sorts by Price (High to Low)")]
        public void TestCase_0508()
        {
            /* TEST CASE */
            string testcase = "0508 | Inventory Screen | Sorting sorts by Price (High to Low)";

            /* SELECT SORTING OPTION PRICE (HIGH TO LOW) */
            inventoryscreen!.SelectSortingOption(inventoryscreen!.priceHightoLow);

            /* GET ITEM PRICE ORDER */
            List<string> inventoryItemprice = inventoryscreen!.GetItemPriceOrder();

            /* EXPECTED RESULT */
            List<string> inventoryitemprice = new List<string>();
            List<string> expectedresult = inventoryitemprice;

            inventoryitemprice.Add("Item name: Sauce Labs Fleece Jacket");
            inventoryitemprice.Add("Item price: $49.99");
            inventoryitemprice.Add("");

            inventoryitemprice.Add("Item name: Sauce Labs Backpack");
            inventoryitemprice.Add("Item price: $29.99");
            inventoryitemprice.Add("");

            inventoryitemprice.Add("Item name: Sauce Labs Bolt T-Shirt");
            inventoryitemprice.Add("Item price: $15.99");
            inventoryitemprice.Add("");

            inventoryitemprice.Add("Item name: Test.allTheThings() T-Shirt (Red)");
            inventoryitemprice.Add("Item price: $15.99");
            inventoryitemprice.Add("");

            inventoryitemprice.Add("Item name: Sauce Labs Bike Light");
            inventoryitemprice.Add("Item price: $9.99");
            inventoryitemprice.Add("");

            inventoryitemprice.Add("Item name: Sauce Labs Onesie");
            inventoryitemprice.Add("Item price: $7.99");
            inventoryitemprice.Add("");

            /* ACTUAL RESULT */
            List<string> actualresult = inventoryItemprice;

            /* PRINT EXPECTED RESULT VS ACTUAL RESULT */
            Console.WriteLine(testcase);
            Console.WriteLine();

            Console.WriteLine("Expected result:");
            foreach (string option in expectedresult)
            {
                Console.WriteLine(option);
            }
            Console.WriteLine();
            Console.WriteLine("Actual result: ");
            foreach (string option in actualresult)
            {
                Console.WriteLine(option);
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