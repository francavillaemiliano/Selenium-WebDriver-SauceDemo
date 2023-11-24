using OpenQA.Selenium;

namespace SauceDemo.POM
{
    public class CheckoutOne_POM
    {
        private IWebDriver? driver;

        public CheckoutOne_POM(IWebDriver driver)
        {
            this.driver = driver;
        }

        /* CLASSES ATTRIBUTES */
        string attribute = "placeholder";

        /* FORM VALUES */
        public string firstname = "First Name";
        public string lastname = "Last Name";
        public string postalcode = "1900";

        /* ELEMENTS SELECTORS */
        public string btn_cancel = "button[class=\"btn btn_secondary back btn_medium cart_cancel_link\"]";
        public string btn_continue = "input[class=\"submit-button btn btn_primary cart_button btn_action\"]";

        public string input_firstname = "input[name=\"firstName\"]";
        public string input_lastname = "input[name=\"lastName\"]";
        public string input_postalcode = "input[name=\"postalCode\"]";

        public string span_title = "span[class=\"title\"]";

        string h3_error = "h3[data-test=\"error\"]";

        /* ELEMENTS LOCATORS */
        private IWebElement ContinueButton => driver!.FindElement(By.CssSelector(btn_continue));
        private IWebElement ErrorMessage => driver!.FindElement(By.CssSelector(h3_error));
        private IWebElement FirstName => driver!.FindElement(By.CssSelector(input_firstname));
        private IWebElement LastName => driver!.FindElement(By.CssSelector(input_lastname));
        private IWebElement PostalCode => driver!.FindElement(By.CssSelector(input_postalcode));

        /* GET ELEMENT DISPLAYED */
        public Boolean GetElementDisplayed(By selector)
        {
            return driver!.FindElement(selector).Displayed;
        }

        /* GET ELEMENT ATTRIBUTE */
        public string GetElementAttribute(By selector)
        {
            return driver!.FindElement(selector).GetAttribute(attribute);
        }

        /* GET ELEMENT TAG NAME */
        public string GetElementTagName(By selector)
        {
            return driver!.FindElement(selector).TagName;
        }

        /* GET ELEMENT ENABLED */
        public Boolean GetElementEnabled(By selector)
        {
            return driver!.FindElement(selector).Enabled;
        }

        /* CLICK ELEMENT */
        public void ClickElement(By selector)
        {
            driver!.FindElement(selector).Click();
        }

        /* GET ERROR MESSAGE */
        public string GetErrorMessage()
        {
            return ErrorMessage.Text;
        }

        /* FILL IN INPUT ELEMENT */
        public void FillInInputElement(By selector, string input)
        {
            IWebElement WebElement = driver!.FindElement(selector);
            WebElement.SendKeys(input);
        }

        /* CLEAN INPUT ELEMENT */
        public void CleanInputElement(By selector)
        {
            IWebElement WebElement = driver!.FindElement(selector);
            WebElement.SendKeys(Keys.Control + "a" + Keys.Delete);
        }

        /* NAVIGATE TO CHECKOUT STEP TWO */
        public void NavigateToScreen()
        {
            FirstName.SendKeys(firstname);
            LastName.SendKeys(lastname);
            PostalCode.SendKeys(postalcode);
            ContinueButton.Click();
        }
    }
}