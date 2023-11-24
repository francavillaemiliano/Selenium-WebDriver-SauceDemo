using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;

namespace Swag_Labs
{
    [TestFixture]
    public class Scenario_17
    {
        IWebDriver? driver;
        LoginScreen? loginscreen;
        CartScreen? cartscreen;
        Checkout1Screen? checkout1screen;

        string baseurl = "https://www.saucedemo.com/";

        [OneTimeSetUp]
        public void Setup()
        {
            /* DRIVER INITIALIZATION */
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl(baseurl);
            driver.Manage().Window.FullScreen();

            /* LOGIN USER */
            loginscreen = new LoginScreen(driver);
            loginscreen.LoginUser(loginscreen!.standarduser, loginscreen!.secretsauce);

            /* NAVIGATE TO CART SCREEN */
            cartscreen = new CartScreen(driver);
            cartscreen.NavigateToCartScreen();

            /* NAVIGATE TO CHECKOUT SCREEN */
            cartscreen.NavigateToCheckoutScreen();

            checkout1screen = new Checkout1Screen(driver);
        }

        [Test, Order(1)]
        [Category("Checkout Screen | Last Name field is displayed")]
        public void TestCase_1701()
        {
            /* TEST CASE */
            string testcase = "1701 | Checkout Screen | Last Name field is displayed";

            /* GET LAST NAME DISPLAYED */
            Boolean lastnameDisplayed = checkout1screen!.GetElementDisplayed(By.CssSelector(checkout1screen!.input_lastname));

            /* EXPECTED RESULT */
            Boolean lastnamedisplayed = true;
            Boolean expectedresult = lastnamedisplayed;

            /* ACTUAL RESULT */
            Boolean actualresult = lastnameDisplayed;

            /* PRINT EXPECTED RESULT VS ACTUAL RESULT */
            Console.WriteLine(testcase);
            Console.WriteLine();

            Console.WriteLine("Expected result: " + expectedresult);
            Console.WriteLine("Actual result: " + actualresult);

            /* ASSERTION EXPECTED RESULT VS ACTUAL RESULT */
            Assert.That(actualresult, Is.EqualTo(expectedresult));
        }

        [Test, Order(2)]
        [Category("Checkout Screen | Last Name field text is Last Name")]
        public void TestCase_1702()
        {
            /* TEST CASE */
            string testcase = "1702 | Checkout Screen | Last Name field text is Last Name";

            /* GET LAST NAME TEXT */
            string lastnameText = checkout1screen!.GetElementAttribute(By.CssSelector(checkout1screen!.input_lastname));

            /* EXPECTED RESULT */
            string lastnametext = "Last Name";
            string expectedresult = lastnametext;

            /* ACTUAL RESULT */
            string actualresult = lastnameText;

            /* PRINT EXPECTED RESULT VS ACTUAL RESULT */
            Console.WriteLine(testcase);
            Console.WriteLine();

            Console.WriteLine("Expected result: " + expectedresult);
            Console.WriteLine("Actual result: " + actualresult);

            /* ASSERTION EXPECTED RESULT VS ACTUAL RESULT */
            Assert.That(actualresult, Is.EqualTo(expectedresult));
        }

        [Test, Order(3)]
        [Category("Checkout Screen | Last Name field tag element is Input")]
        public void TestCase_1703()
        {
            /* TEST CASE */
            string testcase = "1703 | Checkout Screen | Last Name field tag element is Input";

            /* GET LAST NAME TAG NAME */
            string lastnameTagname = checkout1screen!.GetElementTagName(By.CssSelector(checkout1screen!.input_lastname));

            /* EXPECTED RESULT  */
            string lastnametagname = "input";
            string expectedresult = lastnametagname;

            /* ACTUAL RESULT */
            string actualresult = lastnameTagname;

            /* PRINT EXPECTED RESULT VS ACTUAL RESULT */
            Console.WriteLine(testcase);
            Console.WriteLine();

            Console.WriteLine("Expected result: " + expectedresult);
            Console.WriteLine("Actual result: " + actualresult);

            /* ASSERTION EXPECTED RESULT VS ACTUAL RESULT */
            Assert.That(actualresult, Is.EqualTo(expectedresult));
        }

        [Test, Order(4)]
        [Category("Checkout Screen | Last Name field is editable")]
        public void TestCase_1704()
        {
            /* TEST CASE */
            string testcase = "1704 | Checkout Screen | Last Name field is editable";

            /* GET LAST NAME ENABLED */
            Boolean lastnameEnabled = checkout1screen!.GetElementEnabled(By.CssSelector(checkout1screen!.input_lastname));

            /* EXPECTED RESULT */
            Boolean lastnameenabled = true;
            Boolean expectedresult = lastnameenabled;

            /* ACTUAL RESULT */
            Boolean actualresult = lastnameEnabled;

            /* PRINT EXPECTED RESULT VS ACTUAL RESULT */
            Console.WriteLine(testcase);
            Console.WriteLine();

            Console.WriteLine("Expected result: " + expectedresult);
            Console.WriteLine("Actual result: " + actualresult);

            /* ASSERTION EXPECTED RESULT VS ACTUAL RESULT */
            Assert.That(actualresult, Is.EqualTo(expectedresult));
        }

        [Test, Order(5)]
        [Category("Checkout Screen | Last Name field is required | First Name filled | Zip/Postal Code empty")]
        public void TestCase_1705()
        {
            /* TEST CASE */
            string testcase = "1705 | Checkout Screen | Last Name field is required | First Name filled | Zip/Postal Code empty";

            /* FILL IN FIRST NAME FIELD */
            checkout1screen!.FillInInputElement(By.CssSelector(checkout1screen!.input_firstname), checkout1screen!.firstname);

            /* CLICK CONTINUE BUTTON */
            checkout1screen!.ClickElement(By.CssSelector(checkout1screen!.btn_continue));

            /* GET ERROR MESSAGE */
            string errorMessage = checkout1screen!.GetErrorMessage();

            /* EXPECTED RESULT */
            string errormessage = "Error: Last Name is required";
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

            /* CLEAN LAST NAME */
            checkout1screen!.CleanInputElement(By.CssSelector(checkout1screen!.input_lastname));
        }

        [Test, Order(6)]
        [Category("Checkout Screen | Last Name field is required | First Name filled | Zip/Postal Code filled")]
        public void TestCase_1706()
        {
            /* TEST CASE */
            string testcase = "1706 | Checkout Screen | Last Name field is required | First Name filled | Zip/Postal Code filled";

            /* FILL IN FIRST NAME FIELD */
            checkout1screen!.CleanInputElement(By.CssSelector(checkout1screen!.input_firstname));
            checkout1screen!.FillInInputElement(By.CssSelector(checkout1screen!.input_firstname), checkout1screen!.firstname);

            /* FILL IN ZIP/POSTAL CODE FIELD */
            checkout1screen!.FillInInputElement(By.CssSelector(checkout1screen!.input_postalcode), checkout1screen!.postalcode);

            /* CLICK CONTINUE BUTTON */
            checkout1screen!.ClickElement(By.CssSelector(checkout1screen!.btn_continue));

            /* GET ERROR MESSAGE */
            string errorMessage = checkout1screen!.GetErrorMessage();

            /* EXPECTED RESULT */
            string errormessage = "Error: Last Name is required";
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

            /* CLEAN FIRST NAME & ZIP/POSTAL CODE */
            checkout1screen!.CleanInputElement(By.CssSelector(checkout1screen!.input_postalcode));
            checkout1screen!.CleanInputElement(By.CssSelector(checkout1screen!.input_postalcode));
        }

        [Test, Order(7)]
        [Category("Checkout Screen | Last Name field is required | First Name filled | Zip/Postal Code filled/cleaned")]
        public void TestCase_1707()
        {
            /* TEST CASE */
            string testcase = "1707 | Checkout Screen | Last Name field is required | First Name filled | Zip/Postal Code filled/cleaned";

            /* FILL IN FIRST NAME FIELD */
            checkout1screen!.CleanInputElement(By.CssSelector(checkout1screen!.input_firstname));
            checkout1screen!.FillInInputElement(By.CssSelector(checkout1screen!.input_firstname), checkout1screen!.firstname);

            /* FILL IN/CLEAN ZIP/POSTAL CODE FIELD */
            checkout1screen!.FillInInputElement(By.CssSelector(checkout1screen!.input_postalcode), checkout1screen!.postalcode);
            checkout1screen!.CleanInputElement(By.CssSelector(checkout1screen!.input_postalcode));

            /* CLICK CONTINUE BUTTON */
            checkout1screen!.ClickElement(By.CssSelector(checkout1screen!.btn_continue));

            /* GET ERROR MESSAGE */
            string errorMessage = checkout1screen!.GetErrorMessage();

            /* EXPECTED RESULT */
            string errormessage = "Error: Last Name is required";
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