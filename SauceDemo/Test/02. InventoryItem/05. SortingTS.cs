using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SauceDemo.Tests.Inventory
{
    [TestFixture]
    public class Scenario_05
    {
        IWebDriver chromeDriver;

        Locator.InventoryItemLocator inventoryItemLocator;
        Locator.ItemDetailsLocator itemDetailsLocator;
        Locator.LoginLocator loginLocator;

        Screen.InventoryItemScreen inventoryItemScreen;
        Screen.LoginScreen loginScreen;

        [OneTimeSetUp]
        public void Setup()
        {
            // DRIVER SETUP
            chromeDriver = new ChromeDriver();
            SetUp.Driver driver = new SetUp.Driver(chromeDriver);
            driver.DriverSetup();

            // LOGIN USER
            loginLocator = new Locator.LoginLocator(chromeDriver);
            loginScreen = new Screen.LoginScreen(loginLocator);
            loginScreen.LoginStandardUser();

            inventoryItemLocator = new Locator.InventoryItemLocator(chromeDriver);
            itemDetailsLocator = new Locator.ItemDetailsLocator(chromeDriver);
            inventoryItemScreen = new Screen.InventoryItemScreen(chromeDriver, inventoryItemLocator, itemDetailsLocator);
        }

        [Test, Order(1)]
        [Category("Inventory Item Screen | Sorting is displayed")]
        public void TestCase_0501()
        {
            // GET SORTING IS DISPLAYED 
            bool sortingDisplayed = inventoryItemScreen.SortingDisplayed();

            // ASSERTION SORTING IS DISPLAYED 
            Assert.IsTrue(sortingDisplayed);
        }

        [Test, Order(2)]
        [Category("Inventory Item Screen | Sorting contains Name (A to Z), Name (Z to A), Price (low to high), Price (high to low)")]
        public void TestCase_0502()
        {
            // GET ALL OPTIONS FROM SORTING 
            List<string> sortingOptions = inventoryItemScreen.SortingOptions();

            // EXPECTED RESULT 
            List<string> expectedresult = Expected.InventoryItemExpected.SortingOptions();

            // ASSERTION ALL OPTIONS FROM SORTING 
            CollectionAssert.AreEqual(expectedresult, sortingOptions);
        }

        [Test, Order(3)]
        [Category("Inventory Item Screen | Sorting tag name is Select")]
        public void TestCase_0503()
        {
            // GET SORTING TAG NAME 
            string sortingTagname = inventoryItemScreen.SortingTagName();

            // EXPECTED RESULT 
            string expectedresult = Expected.InventoryItemExpected.tagNameSelect;

            // ASSERTION SORTING TAG NAME 
            Assert.That(sortingTagname, Is.EqualTo(expectedresult));
        }

        [Test, Order(4)]
        [Category("Inventory Item Screen | Sorting default value is Name (A to Z)")]
        public void TestCase_0504()
        {
            // GET SORTING SELECTED OPTION 
            string sortingSelectedoption = inventoryItemScreen.SelectedSortingOption();

            // EXPECTED RESULT 
            string expectedresult = Expected.InventoryItemExpected.defaultSortingOption;

            // ASSERTION SORTING SELECTED OPTION 
            Assert.That(sortingSelectedoption, Is.EqualTo(expectedresult));
        }

        [Test, Order(5)]
        [Category("Inventory Item Screen | Sorting sorts by Name (Z to A)")]
        public void TestCase_0505()
        {
            // SELECT SORTING OPTION NAME (Z TO A) 
            inventoryItemScreen.SortByNameZtoA();

            // GET INVENTORY PRODUCT LIST ORDER
            List<string> productList = inventoryItemScreen.InventoryItemList();

            // EXPECTED RESULT 
            List<string> expectedresult = Expected.InventoryItemExpected.itemsOrderNameZtoA();

            // ASSERTION INVENTORY PRODUCT LIST ORDER
            CollectionAssert.AreEqual(expectedresult, productList);
        }

        [Test, Order(6)]
        [Category("Inventory Item Screen | Sorting sorts by Name (A to Z)")]
        public void TestCase_0506()
        {
            // SELECT SORTING OPTION NAME (A TO Z) 
            inventoryItemScreen.SortByNameAtoZ();

            // GET INVENTORY PRODUCT LIST ORDER
            List<string> productList = inventoryItemScreen.InventoryItemList();

            // EXPECTED RESULT 
            List<string> expectedresult = Expected.InventoryItemExpected.itemsOrderNameAtoZ();

            // ASSERTION INVENTORY PRODUCT LIST ORDER
            CollectionAssert.AreEqual(expectedresult, productList);
        }

        
        [Test, Order(7)]
        [Category("Inventory Item Screen | Sorting sorts by Price (Low to High)")]
        public void TestCase_0507()
        {
            // SELECT SORTING OPTION PRICE (LOW TO HIGH) 
            inventoryItemScreen.SortByPriceLowToHigh();

            // GET INVENTORY PRODUCT LIST ORDER
            List<string> productList = inventoryItemScreen.InventoryItemList();

            // EXPECTED RESULT 
            List<string> expectedresult = Expected.InventoryItemExpected.itemsOrderPriceLowToHigh();

            // ASSERTION INVENTORY PRODUCT LIST ORDER
            CollectionAssert.AreEqual(expectedresult, productList);
        }

        
        [Test, Order(8)]
        [Category("Inventory Item Screen | Sorting sorts by Price (High to Low)")]
        public void TestCase_0508()
        {
            // SELECT SORTING OPTION PRICE (LOW TO HIGH) 
            inventoryItemScreen.SortByPriceHighToLow();

            // GET INVENTORY PRODUCT LIST ORDER
            List<string> productList = inventoryItemScreen.InventoryItemList();

            // EXPECTED RESULT 
            List<string> expectedresult = Expected.InventoryItemExpected.itemsOrderPriceHighToLow();

            // ASSERTION INVENTORY PRODUCT LIST ORDER
            CollectionAssert.AreEqual(expectedresult, productList);
        }

        [OneTimeTearDown]
        public void Teardown()
        {
            chromeDriver?.Dispose();
        }
    }
}