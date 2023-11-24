using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using SauceDemo.POM;

namespace SauceDemo.Tests.Footer
{
    [TestFixture]
    public class Scenario_41
    {
        IWebDriver? driver;
        Login_POM? loginscreen;
        Footer_POM? footer;

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

            footer = new Footer_POM(driver);
        }

        [Test, Order(1)]
        [Category("Footer | Copyright is displayed")]
        public void TestCase_4101()
        {
            /* TEST CASE */
            string testcase = "4101 | Footer | Copyright is displayed ";

            /* GET COPYRIGHT IS DISPLAYED */
            Boolean copyrightDisplayed = footer!.GetElementDisplayed(By.CssSelector(footer!.div_copyright));

            /* EXPECTED RESULT */
            Boolean copyrightdisplayed = true;
            Boolean expectedresult = copyrightdisplayed;

            /* ACTUAL RESULT */
            Boolean actualresult = copyrightDisplayed;

            /* PRINT EXPECTED RESULT VS ACTUAL RESULT */
            Console.WriteLine(testcase);
            Console.WriteLine();

            Console.WriteLine("Expected result: " + expectedresult);
            Console.WriteLine("Actual result: " + actualresult);

            /* ASSERT EXPECTED RESULT VS ACTUAL RESULT */
            Assert.That(actualresult, Is.EqualTo(expectedresult));
        }

        [Test, Order(2)]
        [Category("Footer | Copyright text is © 2023 Sauce Labs. All Rights Reserved. Terms of Service | Privacy Policy")]
        public void TestCase_4102()
        {
            /* TEST CASE */
            string testcase = "4102 | Footer | Copyright text is © 2023 Sauce Labs. All Rights Reserved. Terms of Service | Privacy Policy";

            /* GET COPYRIGHT TEXT */
            string copyrightText = footer!.GetElementText(By.CssSelector(footer!.div_copyright));

            /* EXPECTED RESULT */
            string copyrighttext = "© 2023 Sauce Labs. All Rights Reserved. Terms of Service | Privacy Policy";
            string expectedresult = copyrighttext;

            /* ACTUAL RESULT */
            string actualresult = copyrightText;

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