using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using SauceDemo.POM;

namespace SauceDemo.Tests.Cart
{
    [TestFixture]
    public class Scenario_13
    {
        IWebDriver? driver;
        Login_POM? loginscreen;
        Cart_POM? cartscreen;

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
        }

        [Test, Order(1)]
        [Category("Cart Screen | Continue Shopping button is displayed")]
        public void TestCase_1301()
        {
            /* TEST CASE */
            string testcase = "1301 | Cart Screen | Continue Shopping button is displayed";

            /* GET CONTINUE SHOPPING BUTTON DISPLAYED */
            Boolean continueshoppingbuttonDisplayed = cartscreen!.GetElementDisplayed(By.CssSelector(cartscreen!.btn_continueshopping));

            /* EXPECTED RESULT */
            Boolean continueshoppingbuttondisplayed = true;
            Boolean expectedresult = continueshoppingbuttondisplayed;

            /* ACTUAL RESULT */
            Boolean actualresult = continueshoppingbuttonDisplayed;
            
            /* PRINT EXPECTED RESULT VS ACTUAL RESULT */
            Console.WriteLine(testcase);
            Console.WriteLine();

            Console.WriteLine("Expected result: " + expectedresult);
            Console.WriteLine("Actual result: " + actualresult);
            
            /* ASSERTION EXPECTED RESULT VS ACTUAL RESULT */
            Assert.That(actualresult, Is.EqualTo(expectedresult));
        }

        [Test, Order(2)]
        [Category("Cart Screen | Continue Shopping button redirects to checkout screen")]
        public void TestCase_1302()
        {
            /* TEST CASE */
            string testcase = "1302 | Cart Screen | Continue Shopping button redirects to checkout screen";

            /* NAVIGATE TO PRODUCTS SCREEN */
            cartscreen!.NavigateToInventoryScreen();

            /* GET BROWSER URL */
            string browserUrl = driver!.Url;

            /* EXPECTED RESULT */
            string browserurl = "https://www.saucedemo.com/inventory.html";
            string expectedresult = browserurl;

            /* ACTUAL RESULT */
            string actualresult = browserUrl;

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