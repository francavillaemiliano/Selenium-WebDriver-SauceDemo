using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using SauceDemo.POM;

namespace SauceDemo.Tests.FunctionalTests
{
    [TestFixture]
    public class Scenario_43
    {
        IWebDriver? driver;
        Login_POM? loginscreen;
        Inventory_POM? inventoryscreen;
        Cart_POM? cartscreen;
        CheckoutOne_POM? checkout1;
        CheckoutTwo_POM? checkout2;

        string baseurl = "https://www.saucedemo.com/";

        [OneTimeSetUp]
        public void Setup()
        {
            /* DRIVER INITIALIZATION */
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl(baseurl);
            driver.Manage().Window.FullScreen();

            loginscreen = new Login_POM(driver!);
            inventoryscreen = new Inventory_POM(driver!);
            cartscreen = new Cart_POM(driver!);
            checkout1 = new CheckoutOne_POM(driver!);
            checkout2 = new CheckoutTwo_POM(driver!);
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