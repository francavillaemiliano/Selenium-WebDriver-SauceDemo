using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using SauceDemo.POM;

namespace SauceDemo.Tests.FunctionalTests
{
    [TestFixture]
    public class Scenario_42
    {
        IWebDriver? driver;
        Login_POM? loginscreen;
        NavigationBar_POM? navigationbar;

        string baseurl = "https://www.saucedemo.com/";

        [OneTimeSetUp]
        public void Setup()
        {
            /* DRIVER INITIALIZATION */
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl(baseurl);
            driver.Manage().Window.FullScreen();
        }

        [Test, Order(1)]
        [Category("Login | Standard User is able to access to website")]
        public void TestCase_4201()
        {
            /* TEST CASE */
            string testcase = "4201 | Footer | Standard User is able to access to website";

            /* LOGIN STANDARD USER */
            loginscreen = new Login_POM(driver!);
            loginscreen.LoginUser(loginscreen!.standarduser, loginscreen!.secretsauce);

            /* SCREEN URL */
            string screenUrl = driver!.Url;

            /* EXPECTED RESULT */
            string screenurl = "https://www.saucedemo.com/inventory.html";
            string expectedresult = screenurl;

            /* ACTUAL RESULT */
            string actualresult = screenUrl;

            /* PRINT EXPECTED RESULT VS ACTUAL RESULT */
            Console.WriteLine(testcase);
            Console.WriteLine();

            Console.WriteLine("Expected result: " + expectedresult);
            Console.WriteLine("Actual result: " + actualresult);

            /* ASSERT EXPECTED RESULT VS ACTUAL RESULT */
            Assert.That(actualresult, Is.EqualTo(expectedresult));

            /* LOGOUT USER */
            navigationbar = new NavigationBar_POM(driver!);
            navigationbar!.ClickElement(By.CssSelector(navigationbar!.btn_burguermenu));
            navigationbar!.ClickElement(By.LinkText(navigationbar!.a_Logout));
        }

        [Test, Order(2)]
        [Category("Login | Locked user is not able to access to website")]
        public void TestCase_4202()
        {
            /* TEST CASE */
            string testcase = "4202 | Footer | Locked user is not able to access to website";

            /* LOGIN STANDARD USER */
            loginscreen = new Login_POM(driver!);
            loginscreen.LoginUser(loginscreen!.lockedoutuser, loginscreen!.secretsauce);

            /* GET ERROR MESSAGE */
            string errorMessage = loginscreen!.GetElementText(By.CssSelector(loginscreen!.h3_errormessage));

            /* EXPECTED RESULT */
            string errormessage = "Epic sadface: Sorry, this user has been locked out.";
            string expectedresult = errormessage;

            /* ACTUAL RESULT */
            string actualresult = errorMessage;

            /* PRINT EXPECTED RESULT VS ACTUAL RESULT */
            Console.WriteLine(testcase);
            Console.WriteLine();

            Console.WriteLine("Expected result: " + expectedresult);
            Console.WriteLine("Actual result: " + actualresult);

            /* ASSERT EXPECTED RESULT VS ACTUAL RESULT */
            Assert.That(actualresult, Is.EqualTo(expectedresult));
        }

        [OneTimeTearDown]
        public void Teardown()
        {
            driver?.Dispose();
        }
    }
}