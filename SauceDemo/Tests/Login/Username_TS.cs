using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SauceDemo.POM;

namespace SauceDemo.Tests.Login
{
    [TestFixture]
    public class Scenario_02
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
        [Category("Login Screen | Username is displayed")]
        public void TestCase_0201()
        {
            /* TEST CASE */
            string testcase = "0201 | Login Screen | Username is displayed";

            /* GET USERNAME DISPLAYED */
            Boolean usernameDisplayed = loginscreen!.GetElementDisplayed(By.CssSelector(loginscreen!.input_username));

            /* EXPECTED RESULT */
            Boolean usernamedisplayed = true;
            Boolean expectedresult = usernamedisplayed;

            /* ACTUAL RESULT */
            Boolean actualresult = usernameDisplayed;

            /* PRINT EXPECTED RESULT VS ACTUAL RESULT */
            Console.WriteLine(testcase);
            Console.WriteLine();

            Console.WriteLine("Expected result: " + expectedresult);
            Console.WriteLine("Actual result: " + actualresult);

            /* ASSERTION EXPECTED RESULT VS ACTUAL RESULT */
            Assert.That(actualresult, Is.EqualTo(expectedresult));
        }

        [Test, Order(2)]
        [Category("Login Screen | Username text is Username")]
        public void TestCase_0202()
        {
            /* TEST CASE */
            string testcase = "0202 | Login Screen | Username text Username";

            /* GET USERNAME TEXT */
            string usernameText = loginscreen!.GetElementAttribute(By.CssSelector(loginscreen!.input_username), "placeholder");

            /* EXPECTED RESULT */
            string usernametext = "Username";
            string expectedresult = usernametext;

            /* ACTUAL RESULT */
            string actualresult = usernameText;

            /* PRINT EXPECTED RESULT VS ACTUAL RESULT */
            Console.WriteLine(testcase);
            Console.WriteLine();

            Console.WriteLine("Expected result: " + expectedresult);
            Console.WriteLine("Actual result: " + actualresult);

            /* ASSERTION EXPECTED RESULT VS ACTUAL RESULT */
            Assert.That(actualresult, Is.EqualTo(expectedresult));
        }

        [Test, Order(3)]
        [Category("Login Screen | Username tag name is Input")]
        public void TestCase_0203()
        {
            /* TEST CASE */
            string testcase = "0203 | Login Screen | Username tag name is Input";

            /* GET USERNAME TAG NAME */
            string usernameTagname = loginscreen!.GetElementTagName(By.CssSelector(loginscreen!.input_username));

            /* EXPECTED RESULT  */
            string usernametagname = "input";
            string expectedresult = usernametagname;

            /* ACTUAL RESULT */
            string actualresult = usernameTagname;

            /* PRINT EXPECTED RESULT VS ACTUAL RESULT */
            Console.WriteLine(testcase);
            Console.WriteLine();

            Console.WriteLine("Expected result: " + expectedresult);
            Console.WriteLine("Actual result: " + actualresult);

            /* ASSERTION EXPECTED RESULT VS ACTUAL RESULT */
            Assert.That(actualresult, Is.EqualTo(expectedresult));
        }

        [Test, Order(4)]
        [Category("Login Screen | Username is editable")]
        public void TestCase_0204()
        {
            /* TEST CASE */
            string testcase = "0204 | Login Screen | Username is editable";

            /* GET USERNAME ENABLED */
            Boolean usernameEnabled = loginscreen!.GetElementEnabled(By.CssSelector(loginscreen!.input_username));

            /* EXPECTED RESULT */
            Boolean usernameenabled = true;
            Boolean expectedresult = usernameenabled;

            /* ACTUAL RESULT */
            Boolean actualresult = usernameEnabled;

            /* PRINT EXPECTED RESULT VS ACTUAL RESULT */
            Console.WriteLine(testcase);
            Console.WriteLine();

            Console.WriteLine("Expected result: " + expectedresult);
            Console.WriteLine("Actual result: " + actualresult);

            /* ASSERTION EXPECTED RESULT VS ACTUAL RESULT */
            Assert.That(actualresult, Is.EqualTo(expectedresult));
        }

        [Test, Order(5)]
        [Category("Login Screen | Username is required | Username empty | Password empty")]
        public void TestCase_0205()
        {
            /* TEST CASE */
            string testcase = "0205 | Login Screen | Username is required | Username empty | Password empty";

            /* CLICK LOGIN BUTTON */
            loginscreen!.ClickElement(By.CssSelector(loginscreen!.input_loginbutton));

            /* GET ERROR MESSAGE */
            string errormessageText = loginscreen!.GetElementText(By.CssSelector(loginscreen!.h3_errormessage));

            /* EXPECTED RESULT */
            string errormessagetext = "Epic sadface: Username is required";
            string expectedresult = errormessagetext;

            /* ACTUAL RESULT */
            string actualresult = errormessageText;

            /* PRINT EXPECTED RESULT VS ACTUAL RESULT */
            Console.WriteLine(testcase);
            Console.WriteLine();

            Console.WriteLine("Expected result: " + expectedresult);
            Console.WriteLine("Actual result: " + actualresult);

            /* ASSERTION EXPECTED RESULT VS ACTUAL RESULT */
            Assert.That(actualresult, Is.EqualTo(expectedresult));
        }

        [Test, Order(6)]
        [Category("Login Screen | Username is required | Username filled/cleaned")]
        public void TestCase_0206()
        {
            /* TEST CASE */
            string testcase = "0206 | Login Screen | Username is required | Username filled/cleaned";

            /* FILL IN/CLEAN USERNAME */
            loginscreen!.FillInInputElement(By.CssSelector(loginscreen!.input_username), loginscreen!.standarduser);
            loginscreen!.CleanInputElement(By.CssSelector(loginscreen!.input_username));

            /* CLICK LOGIN BUTTON */
            loginscreen!.ClickElement(By.CssSelector(loginscreen!.input_loginbutton));

            /* GET ERROR MESSAGE */
            string errormessageText = loginscreen!.GetElementText(By.CssSelector(loginscreen!.h3_errormessage));

            /* EXPECTED RESULT */
            string errormessagetext = "Epic sadface: Username is required";
            string expectedresult = errormessagetext;

            /* ACTUAL RESULT */
            string actualresult = errormessageText;

            /* PRINT EXPECTED RESULT VS ACTUAL RESULT */
            Console.WriteLine(testcase);
            Console.WriteLine();

            Console.WriteLine("Expected result: " + expectedresult);
            Console.WriteLine("Actual result: " + actualresult);

            /* ASSERTION EXPECTED RESULT VS ACTUAL RESULT */
            Assert.That(actualresult, Is.EqualTo(expectedresult));
        }

        [Test, Order(7)]
        [Category("Login Screen | Username is required | Password filled/cleaned")]
        public void TestCase_0207()
        {
            /* TEST CASE */
            string testcase = "0207 | Login Screen | Username is required | Password filled/cleaned";

            /* FILL IN/CLEAN PASSWORD */
            loginscreen!.FillInInputElement(By.CssSelector(loginscreen!.input_password), loginscreen!.secretsauce);
            loginscreen!.CleanInputElement(By.CssSelector(loginscreen!.input_password));

            /* CLICK LOGIN BUTTON */
            loginscreen!.ClickElement(By.CssSelector(loginscreen!.input_loginbutton));

            /* GET ERROR MESSAGE */
            string errormessageText = loginscreen!.GetElementText(By.CssSelector(loginscreen!.h3_errormessage));

            /* EXPECTED RESULT  */
            string errormessagetext = "Epic sadface: Username is required";
            string expectedresult = errormessagetext;

            /* ACTUAL RESULT */
            string actualresult = errormessageText;            

            /* PRINT EXPECTED RESULT VS ACTUAL RESULT */
            Console.WriteLine(testcase);
            Console.WriteLine();

            Console.WriteLine("Expected result: " + expectedresult);
            Console.WriteLine("Actual result: " + actualresult);

            /* ASSERTION EXPECTED RESULT VS ACTUAL RESULT */
            Assert.That(actualresult, Is.EqualTo(expectedresult));
        }

        [Test, Order(8)]
        [Category("Login Screen | Username is required | Username filled/cleaned | Password filled/cleaned")]
        public void TestCase_0208()
        {
            /* TEST CASE */
            string testcase = "0208 | Login Screen | Username is required | Username filled/cleaned | Password filled/cleaned";

            /* FILL IN/CLEAN USERNAME */
            loginscreen!.FillInInputElement(By.CssSelector(loginscreen!.input_username), loginscreen!.standarduser);           
            loginscreen!.CleanInputElement(By.CssSelector(loginscreen!.input_username));

            /* FILL IN/CLEAN PASSWORD */
            loginscreen!.FillInInputElement(By.CssSelector(loginscreen!.input_password), loginscreen!.secretsauce);
            loginscreen!.CleanInputElement(By.CssSelector(loginscreen!.input_password));

            /* CLICK LOGIN BUTTON */
            loginscreen!.ClickElement(By.CssSelector(loginscreen!.input_loginbutton));

            /* GET ERROR MESSAGE */
            string errormessageText = loginscreen!.GetElementText(By.CssSelector(loginscreen!.h3_errormessage));

            /* EXPECTED RESULT */
            string errormessagetext = "Epic sadface: Username is required";
            string expectedresult = errormessagetext;

            /* ACTUAL RESULT */
            string actualresult = errormessageText;

            /* PRINT EXPECTED RESULT VS ACTUAL RESULT */
            Console.WriteLine(testcase);
            Console.WriteLine();

            Console.WriteLine("Expected result: " + expectedresult);
            Console.WriteLine("Actual result: " + actualresult);

            /* ASSERTION EXPECTED RESULT VS ACTUAL RESULT */
            Assert.That(actualresult, Is.EqualTo(errormessageText));
        }

        [OneTimeTearDown]
        public void Teardown()
        {
            driver?.Dispose();
        }
    }
}