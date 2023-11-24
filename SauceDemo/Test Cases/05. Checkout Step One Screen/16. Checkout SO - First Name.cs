using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;

namespace Swag_Labs
{
    [TestFixture]
    public class Scenario_16
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
        [Category("Checkout Screen | First Name field is displayed")]
        public void TestCase_1601()
        {
            /* TEST CASE */
            string testcase = "1601 | Checkout Screen | First Name field is displayed";

            /* GET FIRST NAME DISPLAYED */
            Boolean firstnameDisplayed = checkout1screen!.GetElementDisplayed(By.CssSelector(checkout1screen!.input_firstname));

            /* EXPECTED RESULT */
            Boolean firstnamedisplayed = true;
            Boolean expectedresult = firstnamedisplayed;

            /* ACTUAL RESULT */
            Boolean actualresult = firstnameDisplayed;

            /* PRINT EXPECTED RESULT VS ACTUAL RESULT */
            Console.WriteLine(testcase);
            Console.WriteLine();

            Console.WriteLine("Expected result: " + expectedresult);
            Console.WriteLine("Actual result: " + actualresult);

            /* ASSERTION EXPECTED RESULT VS ACTUAL RESULT */
            Assert.That(actualresult, Is.EqualTo(expectedresult));
        }

        [Test, Order(2)]
        [Category("Checkout Screen | First Name field text is First Name")]
        public void TestCase_1602()
        {
            /* TEST CASE */
            string testcase = "1602 | Checkout Screen | First Name field text is First Name";

            /* GET FIRST NAME TEXT */
            string firstnameText = checkout1screen!.GetElementAttribute(By.CssSelector(checkout1screen!.input_firstname));

            /* EXPECTED RESULT */
            string firstnametext = "First Name";
            string expectedresult = firstnametext;

            /* ACTUAL RESULT */
            string actualresult = firstnameText;

            /* PRINT EXPECTED RESULT VS ACTUAL RESULT */
            Console.WriteLine(testcase);
            Console.WriteLine();

            Console.WriteLine("Expected result: " + expectedresult);
            Console.WriteLine("Actual result: " + actualresult);

            /* ASSERTION EXPECTED RESULT VS ACTUAL RESULT */
            Assert.That(actualresult, Is.EqualTo(expectedresult));
        }

        [Test, Order(3)]
        [Category("Checkout Screen | First Name field tag name is Input")]
        public void TestCase_1603()
        {
            /* TEST CASE */
            string testcase = "1603 | Checkout Screen | First Name field tag name is Input";

            /* GET FIRST NAME TAG NAME */
            string firstnameTagname = checkout1screen!.GetElementTagName(By.CssSelector(checkout1screen!.input_firstname));

            /* EXPECTED RESULT  */
            string firstnametagname = "input";
            string expectedresult = firstnametagname;

            /* ACTUAL RESULT */
            string actualresult = firstnameTagname;

            /* PRINT EXPECTED RESULT VS ACTUAL RESULT */
            Console.WriteLine(testcase);
            Console.WriteLine();

            Console.WriteLine("Expected result: " + expectedresult);
            Console.WriteLine("Actual result: " + actualresult);

            /* ASSERTION EXPECTED RESULT VS ACTUAL RESULT */
            Assert.That(actualresult, Is.EqualTo(expectedresult));
        }

        [Test, Order(4)]
        [Category("Checkout Screen | First Name field is editable")]
        public void TestCase_1604()
        {
            /* TEST CASE */
            string testcase = "1604 | Checkout Screen | First Name field is editable";

            /* GET FIRST NAME ENABLED */
            Boolean firstnameEnabled = checkout1screen!.GetElementEnabled(By.CssSelector(checkout1screen!.input_firstname));

            /* EXPECTED RESULT */
            Boolean firstnameenabled = true;
            Boolean expectedresult = firstnameenabled;

            /* ACTUAL RESULT */
            Boolean actualresult = firstnameEnabled;

            /* PRINT EXPECTED RESULT VS ACTUAL RESULT */
            Console.WriteLine(testcase);
            Console.WriteLine();

            Console.WriteLine("Expected result: " + expectedresult);
            Console.WriteLine("Actual result: " + actualresult);

            /* ASSERTION EXPECTED RESULT VS ACTUAL RESULT */
            Assert.That(actualresult, Is.EqualTo(expectedresult));
        }

        [Test, Order(5)]
        [Category("Checkout Screen | First Name field is required | Last Name empty | Zip/Postal Code empty")]
        public void TestCase_1605()
        {
            /* TEST CASE */
            string testcase = "1605 | Checkout Screen | First Name field is required | Last Name empty | Zip/Postal Code empty";

            /* CLICK CONTINUE BUTTON */
            checkout1screen!.ClickElement(By.CssSelector(checkout1screen!.btn_continue));

            /* GET ERROR MESSAGE */
            string errorMessage = checkout1screen!.GetErrorMessage();

            /* EXPECTED RESULT */
            string errormessage = "Error: First Name is required";
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

        [Test, Order(6)]
        [Category("Checkout Screen | First Name field is required | Last Name filled | Zip/Postal Code empty")]
        public void TestCase_1606()
        {
            /* TEST CASE */
            string testcase = "1606 | Checkout Screen | First Name field is required | Last Name filled | Zip/Postal Code empty";

            /* FILL IN LAST NAME */
            checkout1screen!.FillInInputElement(By.CssSelector(checkout1screen!.input_lastname), checkout1screen!.lastname);

            /* CLICK CONTINUE BUTTON */
            checkout1screen!.ClickElement(By.CssSelector(checkout1screen!.btn_continue));

            /* GET ERROR MESSAGE */
            string errorMessage = checkout1screen!.GetErrorMessage();

            /* EXPECTED RESULT */
            string errormessage = "Error: First Name is required";
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

        [Test, Order(7)]
        [Category("Checkout Screen | First Name field is required | Last Name empty | Zip/Postal Code filled")]
        public void TestCase_1607()
        {
            /* TEST CASE */
            string testcase = "1607 | Checkout Screen | First Name field is required | Last Name empty | Zip/Postal Code filled";

            /* FILL IN ZIP/POSTAL CODE FIELD */
            checkout1screen!.FillInInputElement(By.CssSelector(checkout1screen!.input_postalcode), checkout1screen!.postalcode);

            /* CLICK CONTINUE BUTTON */
            checkout1screen!.ClickElement(By.CssSelector(checkout1screen!.btn_continue));

            /* GET ERROR MESSAGE */
            string errorMessage = checkout1screen!.GetErrorMessage();

            /* EXPECTED RESULT */
            string errormessage = "Error: First Name is required";
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

            /* CLEAN ZIP/POSTAL CODE FIELD */
            checkout1screen!.CleanInputElement(By.CssSelector(checkout1screen!.input_postalcode));
        }

        [Test, Order(8)]
        [Category("Checkout Screen | First Name field is required | Last Name filled | Zip/Postal Code filled")]
        public void TestCase_1608()
        {
            /* TEST CASE */
            string testcase = "1608 | Checkout Screen | First Name field is required | Last Name filled | Zip/Postal Code filled";

            /* FILL IN LAST NAME FIELD */
            checkout1screen!.FillInInputElement(By.CssSelector(checkout1screen!.input_lastname), checkout1screen!.lastname);

            /* FILL IN ZIP/POSTAL CODE FIELD */
            checkout1screen!.FillInInputElement(By.CssSelector(checkout1screen!.input_postalcode), checkout1screen!.postalcode);

            /* CLICK CONTINUE BUTTON */
            checkout1screen!.ClickElement(By.CssSelector(checkout1screen!.btn_continue));

            /* GET ERROR MESSAGE */
            string errorMessage = checkout1screen!.GetErrorMessage();

            /* EXPECTED RESULT */
            string errormessage = "Error: First Name is required";
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

            /* CLEAN LAST NAME & ZIP/POSTAL CODE */
            checkout1screen!.CleanInputElement(By.CssSelector(checkout1screen!.input_lastname));
            checkout1screen!.CleanInputElement(By.CssSelector(checkout1screen!.input_postalcode));
        }

        [Test, Order(9)]
        [Category("Checkout Screen | First Name field is required | Last Name filled/cleaned | Zip/Postal Code filled/cleaned")]
        public void TestCase_1609()
        {
            /* TEST CASE */
            string testcase = "1609 | Checkout Screen | First Name field is required | Last Name filled | Zip/Postal Code filled";

            /* FILL IN/CLEAN LAST NAME FIELD */
            checkout1screen!.FillInInputElement(By.CssSelector(checkout1screen!.input_lastname), checkout1screen!.lastname);
            checkout1screen!.CleanInputElement(By.CssSelector(checkout1screen!.input_lastname));

            /* FILL IN/CLEAN ZIP/POSTAL CODE FIELD */
            checkout1screen!.FillInInputElement(By.CssSelector(checkout1screen!.input_postalcode), checkout1screen!.postalcode);
            checkout1screen!.CleanInputElement(By.CssSelector(checkout1screen!.input_postalcode));

            /* CLICK CONTINUE BUTTON */
            checkout1screen!.ClickElement(By.CssSelector(checkout1screen!.btn_continue));

            /* GET ERROR MESSAGE */
            string errorMessage = checkout1screen!.GetErrorMessage();

            /* EXPECTED RESULT */
            string errormessage = "Error: First Name is required";
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