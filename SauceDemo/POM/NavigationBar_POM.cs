using OpenQA.Selenium;

namespace SauceDemo.POM
{
    public class NavigationBar_POM
    {
        private IWebDriver? driver;

        public NavigationBar_POM(IWebDriver driver)
        {
            this.driver = driver;
        }

        /* LINK TEXTS */
        public string a_allitems = "All Items";
        public string a_about = "About";
        public string a_Logout = "Logout";
        public string a_resetappstate = "Reset App State";

        /* ELEMENTS SELECTORS */
        public string a_carticon = "a[class=\"shopping_cart_link\"]";

        public string btn_burguermenu = "button[id=\"react-burger-menu-btn\"]";
        public string btn_burguermenux = "button[id=\"react-burger-cross-btn\"]";

        public string div_applogo = "div[class=\"app_logo\"]";
        public string div_burguermenu = "div[class=\"bm-menu-wrap\"]";

        public string nav_burguermenuoptions = "nav[class=\"bm-item-list\"]";

        /* GET ELEMENT DISPLAYED */
        public Boolean GetElementDisplayed(By selector)
        {
            return driver!.FindElement(selector).Displayed;
        }

        /* GET ELEMENT TEXT */
        public string GetElementText(By selector)
        {
            return driver!.FindElement(selector).Text;
        }

        /* CLICK ELEMENT */
        public void ClickElement(By selector)
        {
            driver!.FindElement(selector).Click();
            Thread.Sleep(500);
        }

        /* GET BURGUER MENU OPTIONS */
        public List<string> GetBurguerMenuOptions()
        {
            IWebElement navElement = driver!.FindElement(By.CssSelector(nav_burguermenuoptions));
            IList<IWebElement> options = navElement.FindElements(By.TagName("a"));

            List<string> burgueroptionsDisplayed = new List<string>();

            foreach (IWebElement option in options)
            {
                burgueroptionsDisplayed.Add(option.Text);
            }

            return burgueroptionsDisplayed;
        }

        /* GET CART ITEMS */
        public int GetCartItems()
        {
            string cartitems = driver!.FindElement(By.CssSelector(a_carticon)).Text;

            int cartItems;

            if (cartitems == "")
            {
                cartItems = 0;
            }

            else
            {
                cartItems = int.Parse(cartitems);
            }

            return cartItems;
        }

        /* GET ATTRIBUTE VALUE */
        public string GetAttributeValue(By selector)
        {
            return driver!.FindElement(selector).GetAttribute("aria-hidden");
        }
    }
}