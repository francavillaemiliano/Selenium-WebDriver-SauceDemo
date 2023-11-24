using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;

namespace Swag_Labs
{
    [TestFixture]
    public class Scenario_27
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
        [Category("Checkout 2 Screen | Total label is displayed")]
        public void TestCase_2701()
        {
            /* TEST CASE */
            string testcase = "2701 | Checkout 2 Screen | Total label is displayed";

            /* GET TOTAL LABEL DISPLAYED */
            Boolean totallabelDisplayed = checkout2screen!.GetElementDisplayed(By.CssSelector(checkout2screen!.div_totallabel));

            /* EXPECTED RESULT */
            Boolean totallabeldisplayed = true;
            Boolean expectedresult = totallabeldisplayed;

            /* ACTUAL RESULT */
            Boolean actualresult = totallabelDisplayed;

            /* PRINT EXPECTED RESULT VS ACTUAL RESULT */
            Console.WriteLine(testcase);
            Console.WriteLine();

            Console.WriteLine("Expected result: " + expectedresult);
            Console.WriteLine("Actual result: " + actualresult);

            /* ASSERT EXPECTED RESULT VS ACTUAL RESULT */
            Assert.That(actualresult, Is.EqualTo(expectedresult));
        }

        [Test, Order(2)]
        [Category("Checkout 2 screen | Total contains the sum of Item Total & Tax")]
        public void TestCase_2702()
        {
            /* TEST CASE */
            string testcase = "2702 | Checkout 2 screen | Total contains the sum of Item Total & Tax";

            /* GET TOTAL LABEL TEXT */
            string totallabelText = checkout2screen!.GetElementText(By.CssSelector(checkout2screen!.div_totallabel));

            /* EXPECTED RESULT */
            string totallabeltext = checkout2screen!.GetItemTotalAndTaxSum();
            string expectedresult = totallabeltext;

            /* ACTUAL RESULT */
            string actualresult = totallabelText;

            /* PRINT EXPECTED RESULT VS ACTUAL RESULT */
            Console.WriteLine(testcase);
            Console.WriteLine();

            Console.WriteLine("Expected result: " + expectedresult);
            Console.WriteLine("Actual result: " + actualresult);

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