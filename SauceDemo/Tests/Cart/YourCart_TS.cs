using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SauceDemo.POM;

namespace SauceDemo.Tests.Cart
{
    [TestFixture]
    public class Scenario_09
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
        [Category("Cart Screen | Title is displayed")]
        public void TestCase_0901()
        {
            /* TEST CASE */
            string testcase = "0901 | Cart Screen | Your Cart title is displayed";

            /* GET YOUR CART TITLE IS VISIBLE */
            Boolean titleDisplayed = cartscreen!.GetElementDisplayed(By.CssSelector(cartscreen!.span_title));

            /* EXPECTED RESULT */
            Boolean titledisplayed = true;
            Boolean expectedresult = titledisplayed;

            /* ACTUAL RESULT */
            Boolean actualresult = titledisplayed;

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