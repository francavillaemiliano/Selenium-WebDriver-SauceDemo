using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using SauceDemo.POM;

namespace SauceDemo.Tests.CheckoutTwo
{
    [TestFixture]
    public class Scenario_29
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
        [Category("Checkout 2 Screen | Finish button is displayed")]
        public void TestCase_2901()
        {
            /* TEST CASE */
            string testcase = "2901 | Checkout 2 Screen | Finish button is displayed";

            /* GET FINISH BUTTON DISPLAYED */
            Boolean finishbuttonDisplayed = checkout2screen!.GetElementDisplayed(By.CssSelector(checkout2screen!.btn_finish));

            /* EXPECTED RESULT */
            Boolean finishbuttondisplayed = true;
            Boolean expectedresult = finishbuttondisplayed;

            /* ACTUAL RESULT */
            Boolean actualresult = finishbuttonDisplayed;

            /* PRINT EXPECTED RESULT VS ACTUAL RESULT */
            Console.WriteLine(testcase);
            Console.WriteLine();

            Console.WriteLine("Expected result: " + expectedresult);
            Console.WriteLine("Actual result: " + actualresult);

            /* ASSERT EXPECTED RESULT VS ACTUAL RESULT */
            Assert.That(actualresult, Is.EqualTo(expectedresult));
        }

        [Test, Order(2)]
        [Category("Checkout 2 screen | Finish button redirects to Checkout Complete screen")]
        public void TestCase_2902()
        {
            /* TEST CASE */
            string testcase = "2902 | Checkout 2 screen | Finish button redirects to Checkout Complete screen";

            /* GET CHECKOUT COMPLETE SCREEN URL */
            string screenUrl = checkout2screen!.GetCheckoutCompleteScreenUrl();

            /* EXPECTED RESULT */
            string screenurl = "https://www.saucedemo.com/checkout-complete.html";
            string expectedresult = screenurl;

            /* ACTUAL RESULT */
            string actualresult = screenUrl;

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