using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SauceDemo.POM;

namespace SauceDemo.Tests.Login
{
    [TestFixture]
    public class Scenario_03
    {
        IWebDriver? driver;
        Login_POM? loginscreen;
        string baseurl = "https://www.saucedemo.com/";

        [OneTimeSetUp]
        public void Setup()
        {
            /* DRIVER INITIALIZATION */
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl(baseurl);
            driver.Manage().Window.FullScreen();

            loginscreen = new Login_POM(driver);
        }

        [Test, Order(1)]
        [Category("Login Screen | Password is displayed")]
        public void TestCase_0301()
        {
            /* TEST CASE */
            string testcase = "0301 | Login Screen | Password is displayed";

            /* GET PASSWORD DISPLAYED */
            Boolean passwordDisplayed = loginscreen!.GetElementDisplayed(By.CssSelector(loginscreen!.input_password));

            /* EXPECTED RESULT */
            Boolean passworddisplayed = true;
            Boolean expectedresult = passworddisplayed;

            /* ACTUAL RESULT */
            Boolean actualresult = passwordDisplayed;

            /* PRINT EXPECTED RESULT VS ACTUAL RESULT */
            Console.WriteLine(testcase);
            Console.WriteLine();

            Console.WriteLine("Expected result: " + expectedresult);
            Console.WriteLine("Actual result: " + actualresult);

            /* ASSERTION EXPECTED RESULT VS ACTUAL RESULT */
            Assert.That(actualresult, Is.EqualTo(expectedresult));
        }

        [Test, Order(2)]
        [Category("Login Screen | Password text is Password")]
        public void TestCase_0302()
        {
            /* TEST CASE */
            string testcase = "0302 | Login Screen | Password text Password";

            /* GET PASSWORD TEXT */
            string passwordText = loginscreen!.GetElementAttribute(By.CssSelector(loginscreen!.input_password), "placeholder");

            /* EXPECTED RESULT */
            string passwordtext = "Password";
            string expectedresult = passwordtext;

            /* ACTUAL RESULT */
            string actualresult = passwordText;

            /* PRINT EXPECTED RESULT VS ACTUAL RESULT */
            Console.WriteLine(testcase);
            Console.WriteLine();

            Console.WriteLine("Expected result: " + expectedresult);
            Console.WriteLine("Actual result: " + actualresult);

            /* ASSERTION EXPECTED RESULT VS ACTUAL RESULT */
            Assert.That(actualresult, Is.EqualTo(expectedresult));
        }

        [Test, Order(3)]
        [Category("Login Screen | Password tag name is Input")]
        public void TestCase_0303()
        {
            /* TEST CASE */
            string testcase = "0303 | Login Screen | Password tag name is Input";

            /* GET PASSWORD TAG NAME */
            string passwordTagname = loginscreen!.GetElementTagName(By.CssSelector(loginscreen!.input_password));

            /* EXPECTED RESULT  */
            string passwordtagname = "input";
            string expectedresult = passwordtagname;

            /* ACTUAL RESULT */
            string actualresult = passwordTagname;

            /* PRINT EXPECTED RESULT VS ACTUAL RESULT */
            Console.WriteLine(testcase);
            Console.WriteLine();

            Console.WriteLine("Expected result: " + expectedresult);
            Console.WriteLine("Actual result: " + actualresult);

            /* ASSERTION EXPECTED RESULT VS ACTUAL RESULT */
            Assert.That(actualresult, Is.EqualTo(expectedresult));
        }

        [Test, Order(4)]
        [Category("Login Screen | Password is editable")]
        public void TestCase_0304()
        {
            /* TEST CASE */
            string testcase = "0304 | Login Screen | Password is editable";

            /* GET PASSWORD ENABLED */
            Boolean passwordEnabled = loginscreen!.GetElementEnabled(By.CssSelector(loginscreen!.input_password));

            /* EXPECTED RESULT */
            Boolean passwordenabled = true;
            Boolean expectedresult = passwordenabled;

            /* ACTUAL RESULT */
            Boolean actualresult = passwordEnabled;

            /* PRINT EXPECTED RESULT VS ACTUAL RESULT */
            Console.WriteLine(testcase);
            Console.WriteLine();

            Console.WriteLine("Expected result: " + expectedresult);
            Console.WriteLine("Actual result: " + actualresult);

            /* ASSERTION EXPECTED RESULT VS ACTUAL RESULT */
            Assert.That(actualresult, Is.EqualTo(expectedresult));

        }

        [Test, Order(5)]
        [Category("Login Screen | Password is required | Username filled | Password empty")]
        public void TestCase_0305()
        {
            /* TEST CASE */
            string testcase = "0305 | Login Screen | Password is required | Username filled | Password empty";

            /* FILL IN USERNAME */
            loginscreen!.FillInInputElement(By.CssSelector(loginscreen!.input_username), loginscreen!.standarduser);

            /* CLICK LOGIN BUTTON */
            loginscreen!.ClickElement(By.CssSelector(loginscreen!.input_loginbutton));

            /* GET ERROR MESSAGE */
            string errormessageText = loginscreen!.GetElementText(By.CssSelector(loginscreen!.h3_errormessage));

            /* EXPECTED RESULT */
            string errormessagetext = "Epic sadface: Password is required";
            string expectedresult = errormessagetext;

            /* ACTUAL RESULT */
            string actualresult = errormessageText;

            /* PRINT EXPECTED RESULT VS ACTUAL RESULT */
            Console.WriteLine(testcase);
            Console.WriteLine();

            Console.WriteLine("Expected result: " + expectedresult);
            Console.WriteLine("Actual result: " + actualresult);

            /* ASSERTION EXPECTED RESULT VS ACTUAL RESULT */
            Assert.That(actualresult, Is.EqualTo(errormessagetext));

            /* CLEAN USERNAME */
            loginscreen!.CleanInputElement(By.CssSelector(loginscreen!.input_username));
        }

        [Test, Order(6)]
        [Category("Login Screen | Password is required | Password filled/cleaned")]
        public void TestCase_0306()
        {
            /* TEST CASE */
            string testcase = "0306 | Login Screen | Password is required | Password filled/cleaned";

            /* FILL IN USERNAME */
            loginscreen!.FillInInputElement(By.CssSelector(loginscreen!.input_username), loginscreen!.standarduser);

            /* FILL IN/CLEAN PASSWORD */
            loginscreen!.FillInInputElement(By.CssSelector(loginscreen!.input_password), loginscreen!.secretsauce);
            loginscreen!.CleanInputElement(By.CssSelector(loginscreen!.input_password));

            /* GET ERROR MESSAGE */
            string errormessageText = loginscreen!.GetElementText(By.CssSelector(loginscreen!.h3_errormessage));

            /* EXPECTED RESULT */
            string errormessagetext = "Epic sadface: Password is required";
            string expectedresult = errormessagetext;

            /* ACTUAL RESULT */
            string actualresult = errormessageText;

            /* CLICK LOGIN BUTTON */
            loginscreen!.ClickElement(By.CssSelector(loginscreen!.input_loginbutton));

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