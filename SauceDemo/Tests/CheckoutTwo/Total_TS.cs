using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using SauceDemo.POM;

namespace SauceDemo.Tests.CheckoutTwo
{
    [TestFixture]
    public class Scenario_27
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