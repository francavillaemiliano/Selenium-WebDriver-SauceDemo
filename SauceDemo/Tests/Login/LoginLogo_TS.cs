using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SauceDemo.POM;

namespace SauceDemo.Tests.Login
{
    [TestFixture]
    public class Scenario_01
    {
        IWebDriver? driver;
        Login_POM? loginscreen;
        const string baseurl = "https://www.saucedemo.com/";

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
        [Category("Login Screen | Title is displayed")]
        public void TestCase_0101()
        {
            /* TEST CASE */
            const string testcase = "0101 | Login Screen | Title is displayed";

            /* GET TITLE DISPLAYED */
            Boolean titleDisplayed = loginscreen!.GetElementDisplayed(By.CssSelector(loginscreen!.div_loginlogo));

            /* EXPECTED RESULT */
            Boolean titledisplayed = true;
            Boolean expectedresult = titledisplayed;

            /* ACTUAL RESULT */
            Boolean actualresult = titleDisplayed;

            /* PRINT EXPECTED RESULT VS ACTUAL RESULT */
            Console.WriteLine(testcase);
            Console.WriteLine();

            Console.WriteLine("Expected result: " + expectedresult);
            Console.WriteLine("Actual result: " + actualresult);

            /* ASSERTION EXPECTED RESULT VS ACTUAL RESULT */
            Assert.That(actualresult, Is.EqualTo(expectedresult));
        }

        [Test, Order(2)]
        [Category("Login Screen | Title text is Swag Labs")]
        public void TestCase_0102()
        {
            /* TEST CASE */
            string testcase = "0102 | Login Screen | Title text is Swag Labs";

            /* GET TITLE TEXT */
            string titleText = loginscreen!.GetElementText(By.CssSelector(loginscreen!.div_loginlogo));

            /* EXPECTED RESULT */
            string titletext = "Swag Labs";
            string expectedresult = titletext;

            /* ACTUAL RESULT */
            string actualresult = titleText;

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