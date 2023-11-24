using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using SauceDemo.POM;

namespace SauceDemo.Tests.CheckoutTwo
{
    [TestFixture]
    public class Scenario_26
    {
        IWebDriver? driver;
        Login_POM? loginscreen;
        Inventory_POM? inventoryscreen;
        Cart_POM? cartscreen;
        CheckoutOne_POM? checkout1screen;
        CheckoutTwo_POM? checkout2screen;

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

            /* NAVIGATE TO CHECKOUT SCREEN */
            cartscreen.NavigateToCheckoutScreen();

            /* NAVIGATE TO CHECKOUT STEP TWO SCREEN */
            checkout1screen = new CheckoutOne_POM(driver);
            checkout1screen.NavigateToScreen();

            checkout2screen = new CheckoutTwo_POM(driver);
        }

        [Test, Order(1)]
        [Category("Checkout 2 Screen | Price Total label is displayed")]
        public void TestCase_2601() 
        {
            /* TEST CASE */
            string testcase = "2601 | Checkout 2 Screen | Price Total label is displayed!";

            /* GET PRICE TOTAL DISPLAYED */
            Boolean pricetotalDisplayed = checkout2screen!.GetElementDisplayed(By.XPath(checkout2screen!.text_pricetotal));

            /* EXPECTED RESULT */
            Boolean pricetotaldisplayed = true;
            Boolean expectedresult = pricetotaldisplayed;

            /* ACTUAL RESULT */
            Boolean actualresult = pricetotalDisplayed;

            /* PRINT EXPECTED RESULT VS ACTUAL RESULT */
            Console.WriteLine(testcase);
            Console.WriteLine();

            Console.WriteLine("Expected result: " + expectedresult);
            Console.WriteLine("Actual result: " + actualresult);

            /* ASSERTION EXPECTED RESULT VS ACTUAL RESULT */
            Assert.That(actualresult, Is.EqualTo(expectedresult));
        }

        [Test, Order(2)]
        [Category("Checkout 2 Screen | Price Total contains Item Total label")]
        public void TestCase_2602()
        {
            /* TEST CASE */
            string testcase = "2602 | Checkout 2 Screen | Price Total contains Item Total label";

            /* GET PRICE TOTAL ITEM TOTAL IS VISIBLE */
            Boolean subtotallabelDisplayed = checkout2screen!.GetElementDisplayed(By.CssSelector(checkout2screen!.div_subtotallabel));

            /* EXPECTED RESULT */
            Boolean subtotallabeldisplayed = true;
            Boolean expectedresult = subtotallabeldisplayed;

            /* ACTUAL RESULT */
            Boolean actualresult = subtotallabelDisplayed;

            /* PRINT EXPECTED RESULT VS ACTUAL RESULT */
            Console.WriteLine(testcase);
            Console.WriteLine();

            Console.WriteLine("Expected result: " + expectedresult);
            Console.WriteLine("Actual result: " + actualresult);

            /* ASSERTION EXPECTED RESULT VS ACTUAL RESULT */
            Assert.That(actualresult, Is.EqualTo(expectedresult));
        }

        [Test, Order(3)]
        [Category("Checkout 2 Screen | Price Total contains the total of the selected items")]
        public void TestCase_2603()
        {
            /* TEST CASE */
            string testcase = "2603 | Checkout 2 Screen | Price Total contains the total of the selected items";

            /* GET ITEMS SUM */
            string itemsTotal = checkout2screen!.GetItemsSum();

            /* GET SUBTOTAL LABEL TEXT */
            string subtotallabelText = checkout2screen!.GetElementText(By.CssSelector(checkout2screen!.div_subtotallabel)); 

            /* EXPECTED RESULT */
            string subtotallabeltext = "Item total: $" + itemsTotal;

            /* ACTUAL RESULT */
            string actualresult = subtotallabelText;

            /* PRINT EXPECTED RESULT VS ACTUAL RESULT */
            Console.WriteLine(testcase);
            Console.WriteLine();

            Console.WriteLine("Expected result: " + subtotallabeltext);
            Console.WriteLine("Actual result: " + actualresult);

            /* ASSERTION EXPECTED RESULT VS ACTUAL RESULT */
            Assert.That(actualresult, Is.EqualTo(subtotallabeltext));
        }

        [Test, Order(4)]
        [Category("Checkout 2 Screen | Price Total contains Tax label")]
        public void TestCase_2604()
        {
            /* TEST CASE */
            string testcase = "2604 | Checkout 2 Screen | Price Total contains Tax label";

            /* GET TAX LABEL DISPLAYED */
            Boolean taxlabelDisplayed = checkout2screen!.GetElementDisplayed(By.CssSelector(checkout2screen!.div_taxlabel));

            /* EXPECTED RESULT */
            Boolean taxlabeldisplayed = true;
            Boolean expectedresult = taxlabeldisplayed;

            /* ACTUAL RESULT */
            Boolean actualresult = taxlabelDisplayed;

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