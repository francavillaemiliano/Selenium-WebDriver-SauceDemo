using OpenQA.Selenium;
using SauceDemo.Locator;

namespace SauceDemo.Component
{
    public class NavigationBarComponent
    {
        private IWebDriver? chromeDriver;
        private NavigationBarLocator navigationBarLocator;

        public NavigationBarComponent(IWebDriver chromeDriver, NavigationBarLocator navigationBarLocator)
        {
            this.chromeDriver = chromeDriver;
            this.navigationBarLocator = navigationBarLocator;
        }

        // GET BURGUER MENU IS DISPLAYED
        public bool BurguerMenuDisplayed()
        {
            return navigationBarLocator.BurguerMenuButton.Displayed;
        }

        // GET BURGUER MENU OPTIONS 
        public List<string> GetBurguerMenuOptions()
        {
            IList<IWebElement> BurguerMenuOptions = navigationBarLocator.BurguerMenuOptions;
            List<string> burgueroptionsDisplayed = new List<string>();

            foreach (IWebElement option in BurguerMenuOptions)
            {
                burgueroptionsDisplayed.Add(option.Text);
            }

            return burgueroptionsDisplayed;
        }

        // GET CART ITEMS 
        public int GetCartItems()
        {
            string cartitems = chromeDriver!.FindElement(By.CssSelector(Selector.NavigationBarSelector.a_carticon)).Text;

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

        // GET BURGUER MENU X BUTTON IS DISPLAYED
        public bool BurguerMenuXButtonDisplayed()
        {
            return navigationBarLocator.BurguerMenuXButton.Displayed;
        }

        // GET BURGUER MENU IS HIDDEN
        public bool BurguerMenuHidden()
        {
            string burguerMenuHidden = navigationBarLocator.BurguerMenu.GetAttribute(Data.Attribute.ariahidden);
            return bool.Parse(burguerMenuHidden);
        }

        // CLICK ON BURGUER MENU
        public void ClickOnBurguerMenu()
        {
            navigationBarLocator.BurguerMenuButton.Click();
            Thread.Sleep(1000);
        }

        // GET APP LOGO IS DISPLAYED
        public bool AppLogoDisplayed()
        {
            return navigationBarLocator.AppLogo.Displayed;
        }

        // GET APP LOGO TEXT
        public string AppLogoText()
        {
            return navigationBarLocator.AppLogo.Text;
        }

        // GET CART ICON IS DISPLAYED
        public bool CartIconDisplayed()
        {
            return navigationBarLocator.CartIcon.Displayed;
        }

        // LOGOUT USER
        public void LogoutUser()
        {
            ClickOnBurguerMenu();
            navigationBarLocator.Logout.Click();
        }

        // NAVIGATE TO CART SCREEN 
        public void NavigateToCartScreen()
        {
            navigationBarLocator.CartIcon.Click();
        }
    }
}