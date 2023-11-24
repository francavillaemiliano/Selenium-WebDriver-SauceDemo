using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;

namespace Swag_Labs
{
    [TestFixture]
    public class Scenario_43
    {
        IWebDriver? driver;
        LoginScreen? loginscreen;
        InventoryScreen? inventoryscreen;
        CartScreen? cartscreen;
        Checkout1Screen? checkout1;
        Checkout2Screen? checkout2;

        string baseurl = "https://www.saucedemo.com/";

        [OneTimeSetUp]
        public void Setup()
        {
            /* DRIVER INITIALIZATION */
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl(baseurl);
            driver.Manage().Window.FullScreen();

            loginscreen = new LoginScreen(driver!);
            inventoryscreen = new InventoryScreen(driver!);
            cartscreen = new CartScreen(driver!);
            checkout1 = new Checkout1Screen(driver!);
            checkout2 = new Checkout2Screen(driver!);
        }

        [Test, Order(1)]
        [Category("Checkout Complete | Standard user is able to complete an order")]
        public void TestCase_4301()
        {
            /* TEST CASE */
            string testcase = "4301 | Checkout Complete | Standard user is able to complete an order";

            /* LOGIN STANDARD USER */
            loginscreen!.LoginUser(loginscreen!.standarduser, loginscreen!.secretsauce);

            /* ADD ALL ITEMS TO CART */
            inventoryscreen!.AddAllItemsToCart();

            /* NAVIGATE TO CART SCREEN */
            cartscreen!.NavigateToCartScreen();

            /* NAVIGATE TO CHECKOUT STEP ONE SCREEN */
            cartscreen!.NavigateToCheckoutScreen();

            /* FILL CHECKOUT FORM */
            checkout1!.FillInInputElement(By.CssSelector(checkout1!.input_firstname), checkout1!.firstname);
            checkout1!.FillInInputElement(By.CssSelector(checkout1!.input_lastname), checkout1!.lastname);
            checkout1!.FillInInputElement(By.CssSelector(checkout1!.input_postalcode), checkout1!.postalcode);

            /* NAVIGATE TO CHECKOUT STEP 2 */
            checkout1!.ClickElement(By.CssSelector(checkout1!.btn_continue));

            /* FINISH ORDER */
            checkout2!.ClickElement(By.CssSelector(checkout2!.btn_finish));

            /* GET SCREEN URL */
            string screenUrl = driver!.Url;

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

            /* ASSERT EXPECTED RESULT VS ACTUAL RESULT */
            Assert.That(actualresult, Is.EqualTo(expectedresult));
        }

        [OneTimeTearDown]
        public void Teardown()
        {
            driver?.Dispose();
        }
    }
}