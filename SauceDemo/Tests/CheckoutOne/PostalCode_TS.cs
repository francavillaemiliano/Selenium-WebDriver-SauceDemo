using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using SauceDemo.POM;

namespace SauceDemo.Tests.CheckoutOne
{
    [TestFixture]
    public class Scenario_18
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
        [Category("Checkout Screen | Zip/Postal Code field is displayed")]
        public void TestCase_1801()
        {
            /* TEST CASE */
            string testcase = "1801 | Checkout Screen | Zip/Postal Code field is displayed";

            /* GET ZIP/POSTAL CODE DISPLAYED */
            Boolean postalcodeDisplayed = checkout1screen!.GetElementDisplayed(By.CssSelector(checkout1screen!.input_postalcode));

            /* EXPECTED RESULT */
            Boolean postalcodedisplayed = true;
            Boolean expectedresult = postalcodedisplayed;

            /* ACTUAL RESULT */
            Boolean actualresult = postalcodeDisplayed;

            /* PRINT EXPECTED RESULT VS ACTUAL RESULT */
            Console.WriteLine(testcase);
            Console.WriteLine();

            Console.WriteLine("Expected result: " + expectedresult);
            Console.WriteLine("Actual result: " + actualresult);

            /* ASSERTION EXPECTED RESULT VS ACTUAL RESULT */
            Assert.That(actualresult, Is.EqualTo(expectedresult));
        }

        [Test, Order(2)]
        [Category("Checkout Screen | Zip/Postal Code text is Zip/Postal Code")]
        public void TestCase_1802()
        {
            /* TEST CASE */
            string testcase = "1802 | Checkout Screen | Zip/Postal Code text is Zip/Postal Code";

            /* GET ZIP/POSTAL CODE TEXT */
            string postalcodeText = checkout1screen!.GetElementAttribute(By.CssSelector(checkout1screen!.input_postalcode));

            /* EXPECTED RESULT */
            string postalcodetext = "Zip/Postal Code";
            string expectedresult = postalcodetext;

            /* ACTUAL RESULT */
            string actualresult = postalcodeText;

            /* PRINT EXPECTED RESULT VS ACTUAL RESULT */
            Console.WriteLine(testcase);
            Console.WriteLine();

            Console.WriteLine("Expected result: " + expectedresult);
            Console.WriteLine("Actual result: " + actualresult);

            /* ASSERTION EXPECTED RESULT VS ACTUAL RESULT */
            Assert.That(actualresult, Is.EqualTo(expectedresult));
        }

        [Test, Order(3)]
        [Category("Checkout Screen | Zip/Postal Code field tag name is Input")]
        public void TestCase_1803()
        {
            /* TEST CASE */
            string testcase = "1803 | Checkout Screen | Zip/Postal Code field tag name is Input";

            /* GET ZIP/POSTAL CODE TAG NAME */
            string postalcodeTagname = checkout1screen!.GetElementTagName(By.CssSelector(checkout1screen!.input_postalcode));

            /* EXPECTED RESULT  */
            string postalcodetagname = "input";
            string expectedresult = postalcodetagname;

            /* ACTUAL RESULT */
            string actualresult = postalcodeTagname;

            /* PRINT EXPECTED RESULT VS ACTUAL RESULT */
            Console.WriteLine(testcase);
            Console.WriteLine();

            Console.WriteLine("Expected result: " + expectedresult);
            Console.WriteLine("Actual result: " + actualresult);

            /* ASSERTION EXPECTED RESULT VS ACTUAL RESULT */
            Assert.That(actualresult, Is.EqualTo(expectedresult));
        }

        [Test, Order(4)]
        [Category("Checkout Screen | Zip/Postal Code field is editable")]
        public void TestCase_1804()
        {
            /* TEST CASE */
            string testcase = "1804 | Checkout Screen | Zip/Postal Code field is editable";

            /* GET ZIP/POSTAL CODE ENABLED */
            Boolean postalcodeEnabled = checkout1screen!.GetElementEnabled(By.CssSelector(checkout1screen!.input_postalcode));

            /* EXPECTED RESULT */
            Boolean postalcodeenabled = true;
            Boolean expectedresult = postalcodeenabled;

            /* ACTUAL RESULT */
            Boolean actualresult = postalcodeEnabled;

            /* PRINT EXPECTED RESULT VS ACTUAL RESULT */
            Console.WriteLine(testcase);
            Console.WriteLine();

            Console.WriteLine("Expected result: " + expectedresult);
            Console.WriteLine("Actual result: " + actualresult);

            /* ASSERTION EXPECTED RESULT VS ACTUAL RESULT */
            Assert.That(actualresult, Is.EqualTo(expectedresult));
        }

        [Test, Order(5)]
        [Category("Checkout Screen | Zip/Postal Code field is required | First Name filled | Last Name filled")]
        public void TestCase_1805()
        {
            /* TEST CASE */
            string testcase = "1805 | Checkout Screen | Zip/Postal Code field is required | First Name filled | Last Name filled";

            /* FILL IN FIRST NAME FIELD */
            checkout1screen!.FillInInputElement(By.CssSelector(checkout1screen!.input_firstname), checkout1screen!.firstname);

            /* FILL IN LAST NAME FIELD */
            checkout1screen!.FillInInputElement(By.CssSelector(checkout1screen!.input_lastname), checkout1screen!.lastname);

            /* CLICK CONTINUE BUTTON */
            checkout1screen!.ClickElement(By.CssSelector(checkout1screen!.btn_continue));

            /* GET ERROR MESSAGE */
            string errorMessage = checkout1screen!.GetErrorMessage();

            /* EXPECTED RESULT */
            string errormessage = "Error: Postal Code is required";
            string expectedresult = errormessage;

            /* ACTUAL RESULT */
            string actualresult = errorMessage;

            /* PRINT EXPECTED RESULT VS ACTUAL RESULT */
            Console.WriteLine(testcase);
            Console.WriteLine();

            Console.WriteLine("Expected result: " + expectedresult);
            Console.WriteLine("Actual result: " + actualresult);

            /* ASSERTION EXPECTED RESULT VS ACTUAL RESULT */
            Assert.That(actualresult, Is.EqualTo(expectedresult));

            /* CLEAN FIRST NAME & LAST NAME FIELDS */
            checkout1screen!.CleanInputElement(By.CssSelector(checkout1screen!.input_postalcode));
            checkout1screen!.CleanInputElement(By.CssSelector(checkout1screen!.input_lastname));
        }

        [Test, Order(6)]
        [Category("Checkout Screen | Zip/Postal Code field is required | First Name filled | Last Name filled | Zip/Postal Code filled/Cleaned")]
        public void TestCase_1806()
        {
            /* TEST CASE */
            string testcase = "1806 | Checkout Screen | Zip/Postal Code field is required | First Name filled | Last Name filled | Zip/Postal Code filled/Cleaned";

            /* FILL IN FIRST NAME FIELD */
            checkout1screen!.CleanInputElement(By.CssSelector(checkout1screen!.input_firstname));
            checkout1screen!.FillInInputElement(By.CssSelector(checkout1screen!.input_firstname), checkout1screen!.firstname);

            /* FILL IN LAST NAME FIELD */
            checkout1screen!.FillInInputElement(By.CssSelector(checkout1screen!.input_lastname), checkout1screen!.lastname);

            /* FILL IN/CLEAN ZIP7POSTAL CODE FIELD */
            checkout1screen!.FillInInputElement(By.CssSelector(checkout1screen!.input_postalcode), checkout1screen!.postalcode);
            checkout1screen!.CleanInputElement(By.CssSelector(checkout1screen!.input_postalcode));

            /* CLICK CONTINUE BUTTON */
            checkout1screen!.ClickElement(By.CssSelector(checkout1screen!.btn_continue));

            /* GET ERROR MESSAGE */
            string errorMessage = checkout1screen!.GetErrorMessage();

            /* EXPECTED RESULT */
            string errormessage = "Error: Postal Code is required";
            string expectedresult = errormessage;

            /* ACTUAL RESULT */
            string actualresult = errorMessage;

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