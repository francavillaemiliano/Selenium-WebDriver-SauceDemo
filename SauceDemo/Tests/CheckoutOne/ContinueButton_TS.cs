using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using SauceDemo.POM;

namespace SauceDemo.Tests.CheckoutOne
{
    [TestFixture]
    public class Scenario_20
    {
        IWebDriver? driver;
        Login_POM? loginscreen;
        Cart_POM? cartscreen;
        CheckoutOne_POM? checkout1screen;

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

            /* NAVIGATE TO CART SCREEN */
            cartscreen = new Cart_POM(driver);
            cartscreen.NavigateToCartScreen();

            /* NAVIGATE TO CHECKOUT SCREEN */
            cartscreen.NavigateToCheckoutScreen();

            checkout1screen = new CheckoutOne_POM(driver);
        }

        [Test, Order(1)]
        [Category("Checkout Screen | Continue button is displayed")]
        public void TestCase_2001()
        {
            /* TEST CASE */
            string testcase = "2001 | Checkout Screen | Continue button is displayed";

            /* GET CONTINUE BUTTON DISPLAYED */
            Boolean continuebuttonDisplayed = checkout1screen!.GetElementDisplayed(By.CssSelector(checkout1screen!.btn_continue));

            /* EXPECTED RESULT */
            Boolean continuebuttondisplayed = true;
            Boolean expectedresult = continuebuttondisplayed;

            /* ACTUAL RESULT */
            Boolean actualresult = continuebuttonDisplayed;

            /* PRINT EXPECTED RESULT VS ACTUAL RESULT */
            Console.WriteLine(testcase);
            Console.WriteLine();

            Console.WriteLine("Expected result: " + expectedresult);
            Console.WriteLine("Actual result: " + actualresult);

            /* ASSERTION EXPECTED RESULT VS ACTUAL RESULT */
            Assert.That(actualresult, Is.EqualTo(expectedresult));
        }

        [Test, Order(2)]
        [Category("Checkout Screen | Continue button redirects to checkout 2 screen")]
        public void TestCase_2002()
        {
            /* TEST CASE */
            string testcase = "2002 | Checkout Screen | Continue button redirects to checkout 2 screen";

            /* FILL IN FIRST NAME FIELD */
            checkout1screen!.FillInInputElement(By.CssSelector(checkout1screen!.input_firstname), checkout1screen!.firstname);

            /* FILL IN LAST NAME FIELD */
            checkout1screen!.FillInInputElement(By.CssSelector(checkout1screen!.input_lastname), checkout1screen!.lastname);

            /* FILL IN ZIP/POSTAL CODE FIELD */
            checkout1screen!.FillInInputElement(By.CssSelector(checkout1screen!.input_postalcode), checkout1screen!.postalcode);

            /* NAVIGATE TO CHECKOUT 2 SCREEN */
            checkout1screen!.ClickElement(By.CssSelector(checkout1screen!.btn_continue));

            /* GET URL */
            string screenUrl = driver!.Url;

            /* EXPECTED RESULT */
            string screenurl = "https://www.saucedemo.com/checkout-step-two.html";
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