using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;

namespace Swag_Labs
{
    [TestFixture]
    public class Scenario_35
    {
        IWebDriver? driver;
        LoginScreen? loginscreen;
        InventoryScreen? inventoryscreen;
        NavigationBar? navigationbar;

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

            navigationbar = new NavigationBar(driver);
        }

        [Test, Order(1)]
        [Category("Navigation Bar | Burguer Menu is displayed")]
        public void TestCase_3501()
        {
            /* TEST CASE */
            string testcase = "3501 | Navigation Bar | Burguer Menu is displayed";

            /* GET BURGUER MENU DISPLAYED */
            Boolean burguermenuDisplayed = navigationbar!.GetElementDisplayed(By.CssSelector(navigationbar!.btn_burguermenu));

            /* EXPECTED RESULT */
            Boolean burguermenudisplayed = true;
            Boolean expectedresult = burguermenudisplayed;

            /* ACTUAL RESULT */
            Boolean actualresult = burguermenuDisplayed;

            /* PRINT EXPECTED RESULT VS ACTUAL RESULT */
            Console.WriteLine(testcase);
            Console.WriteLine();

            Console.WriteLine("Expected result: " + expectedresult);
            Console.WriteLine("Actual result: " + actualresult);

            /* ASSERT EXPECTED RESULT VS ACTUAL RESULT */
            Assert.That(actualresult, Is.EqualTo(expectedresult));
        }

        [Test, Order(2)]
        [Category("Navigation Bar | Burguer Menu contains All items, about, Logout and Reset App State options")]
        public void TestCase_3502()
        {
            /* TEST CASE */
            string testcase = "3502 | Navigation Bar | Burguer Menu contains All items, about, Logout and Reset App State options";

            /* CLICK BURGUER MENU */
            navigationbar!.ClickElement(By.CssSelector(navigationbar!.btn_burguermenu));

            /* GET BURGUER MENU OPTIONS */
            List<string> burguermenuOptions = navigationbar!.GetBurguerMenuOptions();

            /* EXPECTED RESULT */
            List<string> burguermenuoptions = new List<string>();
            List<string> expectedresult = burguermenuoptions;

            burguermenuoptions.Add("All Items");
            burguermenuoptions.Add("About");
            burguermenuoptions.Add("Logout");
            burguermenuoptions.Add("Reset App State");

            /* ACTUAL RESULT */
            List<string> actualresult = burguermenuOptions;

            /* PRINT EXPECTED RESULT VS ACTUAL RESULT */
            Console.WriteLine(testcase);
            Console.WriteLine();

            Console.WriteLine("Expected result:");
            foreach (string option in expectedresult)
            {
                Console.WriteLine(option);
            }

            Console.WriteLine();

            Console.WriteLine("Actual result:");
            foreach (string option in actualresult)
            {
                Console.WriteLine(option);
            }

            /* ASSERT EXPECTED RESULT VS ACTUAL RESULT */
            Assert.That(actualresult, Is.EqualTo(expectedresult));
        }

        [Test, Order(3)]
        [Category("Navigation Bar | Burguer menu All items option redirect to inventory screen")]
        public void TestCase_3503()
        {
            /* TEST CASE */
            string testcase = "3503 | Navigation Bar | Burguer menu All items option redirect to inventory screen";

            /* CLICK BURGUER MENU ALL ITEMS OPTION */
            navigationbar!.ClickElement(By.LinkText(navigationbar!.a_allitems));

            /* GET SCREEN URL */
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
        }

        [Test, Order(4)]
        [Category("Navigation Bar | Burguer menu About option redirects to saucelabs.com")]
        public void TestCase_3504()
        {
            /* TEST CASE */
            string testcase = "3504 | Navigation Bar | Burguer menu About option redirects to saucelabs.com";

            /* CLICK BURGUER MENU ABOUT OPTION */
            navigationbar!.ClickElement(By.LinkText(navigationbar!.a_about));

            /* GET SCREEN URL */
            string screenUrl = driver!.Url;

            /* EXPECTED RESULT */
            string screenurl = "https://saucelabs.com/";
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

            /* NAVIGATE BACK */
            driver!.Navigate().Back();
        }

        [Test, Order(5)]
        [Category("Navigation Bar | Burguer menu Logout option redirects to login screen")]
        public void TestCase_3505()
        {
            /* TEST CASE */
            string testcase = "3505 | Navigation Bar | Burguer menu Logout option redirects to login screen";

            /* CLICK BURGUER MENU */
            navigationbar!.ClickElement(By.CssSelector(navigationbar!.btn_burguermenu));

            /* CLICK BURGUER MENU LOGOUT OPTION */
            navigationbar!.ClickElement(By.LinkText(navigationbar!.a_Logout));

            /* GET SCREEN URL */
            string screenUrl = driver!.Url;

            /* EXPECTED RESULT */
            string screenurl = "https://www.saucedemo.com/";
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
        }

        [Test, Order(6)]
        [Category("Navigation Bar | Burguer menu Reset App State removes products from the cart")]
        public void TestCase_3506()
        {
            /* TEST CASE */
            string testcase = "3506 | Navigation Bar | Burguer menu Reset App State removes products from the cart";

            /* LOGIN STANDARD USER */
            loginscreen!.LoginUser(loginscreen!.standarduser, loginscreen!.secretsauce);

            /* ADD ALL ITEMS TO CART */
            inventoryscreen = new InventoryScreen(driver!);
            inventoryscreen!.AddAllItemsToCart();

            /* CLICK BURGUER MENU ICON */
            navigationbar!.ClickElement(By.CssSelector(navigationbar!.btn_burguermenu));

            /* CLICK BURGUER MENU RESET APP STATE */
            navigationbar!.ClickElement(By.LinkText(navigationbar!.a_resetappstate));

            /* GET CART ITEMS */
            int cartItems = navigationbar!.GetCartItems();

            /* EXPECTED RESULT */
            int cartitems = 0;
            int expectedresult = cartitems;

            /* ACTUAL RESULT */
            int actualresult = cartItems;

            /* PRINT EXPECTED RESULT VS ACTUAL RESULT */
            Console.WriteLine(testcase);
            Console.WriteLine();

            Console.WriteLine("Expected result: " + expectedresult);
            Console.WriteLine("Actual result: " + actualresult);

            /* ASSERT EXPECTED RESULT VS ACTUAL RESULT */
            Assert.That(actualresult, Is.EqualTo(expectedresult));
        }

        [Test, Order(7)]
        [Category("Navigation Bar | Burguer menu contains X button")]
        public void TestCase_3507()
        {
            /* TEST CASE */
            string testcase = "3507 | Navigation Bar | Burguer menu contains X button";

            /* GET MENU BURGUER X BUTTON DISPLAYED */
            Boolean menuburguerxDisplayed = navigationbar!.GetElementDisplayed(By.CssSelector(navigationbar!.btn_burguermenux));

            /* EXPECTED RESULT */
            Boolean menuburguerxdisplayed = true;
            Boolean expectedresult = menuburguerxdisplayed;

            /* ACTUAL RESULT */
            Boolean actualresult = menuburguerxDisplayed;

            /* PRINT EXPECTED RESULT VS ACTUAL RESULT */
            Console.WriteLine(testcase);
            Console.WriteLine();

            Console.WriteLine("Expected result: " + expectedresult);
            Console.WriteLine("Actual result: " + actualresult);

            /* ASSERT EXPECTED RESULT VS ACTUAL RESULT */
            Assert.That(actualresult, Is.EqualTo(expectedresult));
        }

        [Test, Order(8)]
        [Category("Navigation Bar | Burguer menu X button closes the menu")]
        public void TestCase_3508()
        {
            /* TEST CASE */
            string testcase = "3508 | Navigation Bar | Burguer menu X button closes the menu";

            /* CLICK BURGUER MENU X */
            navigationbar!.ClickElement(By.CssSelector(navigationbar!.btn_burguermenux));

            /* GET BURGUER MENU DISPLAYED */
            string burguermenuHidden = navigationbar!.GetAttributeValue(By.CssSelector(navigationbar!.div_burguermenu));

            /* EXPECTED RESULT */
            string burguermenuhidden = "true";
            string expectedresult = burguermenuhidden;

            /* ACTUAL RESULT */
            string actualresult = burguermenuHidden;

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