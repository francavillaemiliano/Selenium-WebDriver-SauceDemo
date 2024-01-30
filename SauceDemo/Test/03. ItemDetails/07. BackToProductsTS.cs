using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;

namespace SauceDemo.Tests.InventoryItem
{
    [TestFixture]
    public class Scenario_07
    {
        IWebDriver chromeDriver;

        Locator.InventoryItemLocator inventoryItemLocator;
        Locator.ItemDetailsLocator itemDetailsLocator;
        Locator.LoginLocator loginLocator;

        Screen.InventoryItemScreen inventoryItemScreen;
        Screen.ItemDetailsScreen itemDetailsScreen;
        Screen.LoginScreen loginScreen;

        List<string> itemName;

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

            // GET PRODUCT NAME
            itemDetailsLocator = new Locator.ItemDetailsLocator(chromeDriver);
            inventoryItemLocator = new Locator.InventoryItemLocator(chromeDriver);
            inventoryItemScreen = new Screen.InventoryItemScreen(chromeDriver, inventoryItemLocator, itemDetailsLocator);
            itemName = inventoryItemScreen.ItemName();

            itemDetailsScreen = new Screen.ItemDetailsScreen(chromeDriver, itemDetailsLocator);
        }

        [Test, Order(1)]
        [Category("Item Details Screen | Back to products button is displayed")]
        public void TestCase_0701()
        {
            // GET BACK TO PRODUCTS BUTTON IS DISPLAYED 
            List<bool> backtoproductsDisplayed = itemDetailsScreen.BackToProductsButtonDisplayed(itemName);

            // ASSERTION BACK TO PRODUCTS BUTTON IS DISPLAYED 
            Assert.IsTrue(backtoproductsDisplayed.All(item => item));
        }

        [Test, Order(2)]
        [Category("Item Details Screen | Back to products button text is Back to products")]
        public void TestCase_0702()
        {
            // GET BACK TO PRODUCTS BUTTON TEXT
            List<string> backtoproductsbuttonText = itemDetailsScreen.BackToProductsText(itemName);

            // EXPECTED RESULT
            string expectedresult = Expected.ItemDetailsExpected.backtoproductsButton;

            // ASSERTION BACK TO PRODUCTS BUTTON TEXT
            Assert.IsTrue(backtoproductsbuttonText.All(item => item == expectedresult));
        }

        [Test, Order(3)]
        [Category("Item Details Screen | Back to products button redirects to inventory screen")]
        public void TestCase_0703()
        {
            // GET ITEM URL REDIRECTION 
            List<string> itemUrl = itemDetailsScreen.InventoryItemUrls(itemName);

            // EXPECTED RESULT
            string expectedresult = Expected.UrlExpected.inventory;

            // ASSERTION ITEM URL REDIRECTION 
            Assert.IsTrue(itemUrl.All(item => item == expectedresult));
        }

        [OneTimeTearDown]
        public void Teardown()
        {
            chromeDriver.Dispose();
        }
    }
}