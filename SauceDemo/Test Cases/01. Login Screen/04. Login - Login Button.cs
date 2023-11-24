using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Swag_Labs
{
    [TestFixture]
    public class Scenario_04
    {
        IWebDriver? driver;
        LoginScreen? loginscreen;
        string baseurl = "https://www.saucedemo.com/";

        [OneTimeSetUp]
        public void Setup()
        {
            /* DRIVER INITIALIZATION */
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl(baseurl);
            driver.Manage().Window.FullScreen();

            loginscreen = new LoginScreen(driver);

        }

        [Test, Order(1)]
        [Category("Login Screen | Login Button is displayed")]
        public void TestCase_0401()
        {
            /* TEST CASE */
            string testcase = "0401 | Login Screen | Login Button is displayed";

            /* GET LOGIN BUTTON DISPLAYED */
            Boolean loginbuttonDisplayed = loginscreen!.GetElementDisplayed(By.CssSelector(loginscreen!.input_loginbutton));

            /* EXPECTED RESULT */
            Boolean loginbuttondisplayed = true;
            Boolean expectedresult = loginbuttondisplayed;

            /* ACTUAL RESULT */
            Boolean actualresult = loginbuttonDisplayed;

            /* PRINT EXPECTED RESULT VS ACTUAL RESULT */
            Console.WriteLine(testcase);
            Console.WriteLine();

            Console.WriteLine("Expected result: " + expectedresult);
            Console.WriteLine("Actual result: " + actualresult);

            /* ASSERTION EXPECTED RESULT VS ACTUAL RESULT */
            Assert.That(actualresult, Is.EqualTo(expectedresult));
        }

        [Test, Order(2)]
        [Category("Login Screen | Login Button text is Login")]
        public void TestCase_0402()
        {
            /* TEST CASE */
            string testcase = "0402 | Login Screen | Login Button text is Login";

            /* GET LOGIN BUTTON TEXT */
            string loginbuttonText = loginscreen!.GetElementAttribute(By.CssSelector(loginscreen!.input_loginbutton), "value");

            /* EXPECTED RESULT */
            string loginbuttontext = "Login";
            string expectedresult = loginbuttontext;

            /* ACTUAL RESULT */
            string actualresult = loginbuttonText;

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