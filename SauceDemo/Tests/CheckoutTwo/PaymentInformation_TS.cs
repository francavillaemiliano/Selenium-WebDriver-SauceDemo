using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using SauceDemo.POM;

namespace SauceDemo.Tests.CheckoutTwo
{
    [TestFixture]
    public class Scenario_24
    {
        IWebDriver? driver;
        Login_POM? loginscreen;
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
        [Category("Checkout 2 Screen | Payment Information label is displayed")]
        public void TestCase_2401()
        {
            /* TEST CASE */
            string testcase = "2401 | Checkout 2 Screen | Payment Information label is displayed";

            /* GET PAYMENT INFORMATION DISPLAYED */
            Boolean paymentinformationDisplayed = checkout2screen!.GetElementDisplayed(By.XPath(checkout2screen!.text_paymentinformation));

            /* EXPECTED RESULT */
            Boolean paymentinformationdisplayed = true;
            Boolean expectedresult = paymentinformationdisplayed;

            /* ACTUAL RESULT */
            Boolean actualresult = paymentinformationDisplayed;

            /* PRINT EXPECTED RESULT VS ACTUAL RESULT */
            Console.WriteLine(testcase);
            Console.WriteLine();

            Console.WriteLine("Expected result: " + expectedresult);
            Console.WriteLine("Actual result: " + actualresult);

            /* ASSERTION EXPECTED RESULT VS ACTUAL RESULT */
            Assert.That(actualresult, Is.EqualTo(expectedresult));
        }

        [Test, Order(2)]
        [Category("Checkout 2 Screen | Payment Information shows SauceCard #31337 as payment method")]
        public void TestCase_2402()
        {
            /* TEST CASE */
            string testcase = "2402 | Checkout 2 Screen | Payment Information shows SauceCard #31337 as payment method";

            /* GET SAUCE CARD TEXT */
            string saucecardText = checkout2screen!.GetElementText(By.XPath(checkout2screen!.text_saucecard));

            /* EXPECTED RESULT */
            string saucecardtext = "SauceCard #31337";
            string expectedresult = saucecardtext;
            
            /* ACTUAL RESULT */
            string actualresult = saucecardText;            

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