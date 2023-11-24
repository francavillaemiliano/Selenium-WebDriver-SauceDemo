using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using SauceDemo.POM;

namespace SauceDemo.Tests.CheckoutOne
{
    [TestFixture]
    public class Scenario_19
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
        [Category("Checkout Screen | Cancel button is displayed")]
        public void TestCase_1901()
        {
            /* TEST CASE */
            string testcase = "1901 | Checkout Screen | Cancel button is displayed";

            /* GET CANCEL BUTTON DISPLAYED */
            Boolean cancelbuttonDisplayed = checkout1screen!.GetElementDisplayed(By.CssSelector(checkout1screen!.btn_cancel));

            /* EXPECTED RESULT */
            Boolean cancelbuttondisplayed = true;
            Boolean expectedresult = cancelbuttondisplayed;

            /* ACTUAL RESULT */
            Boolean actualresult = cancelbuttonDisplayed;

            /* PRINT EXPECTED RESULT VS ACTUAL RESULT */
            Console.WriteLine(testcase);
            Console.WriteLine();

            Console.WriteLine("Expected result: " + expectedresult);
            Console.WriteLine("Actual result: " + actualresult);

            /* ASSERTION EXPECTED RESULT VS ACTUAL RESULT */
            Assert.That(actualresult, Is.EqualTo(expectedresult));
        }

        [Test, Order(2)]
        [Category("Checkout Screen | Cancel button redirects to Your Cart screen")]
        public void TestCase_1902()
        {
            /* TEST CASE */
            string testcase = "1902 | Checkout Screen | Cancel button redirects to Your Cart screen";

            /* CLICK ON CANCEL BUTTON */
            checkout1screen!.ClickElement(By.CssSelector(checkout1screen!.btn_cancel));

            /* GET SCREEN URL */
            string screenUrl = driver!.Url;

            /* EXPECTED RESULT */
            string screenurl = "https://www.saucedemo.com/cart.html";
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