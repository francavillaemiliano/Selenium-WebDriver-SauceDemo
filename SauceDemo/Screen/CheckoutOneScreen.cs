using OpenQA.Selenium;
using SauceDemo.Locator;

namespace SauceDemo.Screen
{
    public class CheckoutOneScreen
    {
        private CheckoutOneLocator checkoutOneLocator;

        public CheckoutOneScreen(CheckoutOneLocator checkoutOneLocator)
        {
            this.checkoutOneLocator = checkoutOneLocator;
        }     

        // GET CHECKOUT:YOUR INFORMATION IS DISPLAYED
        public bool YourInformationDisplayed()
        {
            return checkoutOneLocator.YourInformation.Displayed;
        }

        // GET FIRST NAME IS DISPLAYED
        public bool FirstNameDisplayed()
        {
            return checkoutOneLocator.FirstName.Displayed;
        }

        // GET FIRST NAME ATTRIBUTE
        public string FirstNameAttribute()
        {
            return checkoutOneLocator.FirstName.GetAttribute(Data.Attribute.placeholder);
        }

        // GET FIRST NAME TAG NAME
        public string FirstNameTagName()
        {
            return checkoutOneLocator.FirstName.TagName;
        }

        // GET FIRST NAME IS ENABLED/EDITABLE
        public bool FirstNameEnabled()
        {
            return checkoutOneLocator.FirstName.Enabled;
        }

        // GET REQUIRED FIELD ERROR MESSAGE
        public string RequiredFieldError()
        {
            return checkoutOneLocator.RequiredError.Text;
        }

        // FILL IN FIRST NAME
        public void FillInFirstName()
        {
            checkoutOneLocator.FirstName.SendKeys(Data.User.firstName);
        }

        // CLEAN FIRST NAME
        public void CleanFirstName()
        {
            checkoutOneLocator.FirstName.SendKeys(Keys.Control + "a" + Keys.Delete);
        }

        // FILL IN LAST NAME
        public void FillInLastName()
        {
            checkoutOneLocator.LastName.SendKeys(Data.User.lastName);
        }

        // CLEAN LAST NAME
        public void CleanLastName()
        {
            checkoutOneLocator.LastName.SendKeys(Keys.Control + "a" + Keys.Delete);
        }

        // FILL IN ZIP/POSTAL CODE
        public void FillInZipPostalCode()
        {
            checkoutOneLocator.ZipPostalCode.SendKeys(Data.User.zipPostal);
        }

        // CLEAN ZIP/POSTAL CODE
        public void CleanZipPostalCode()
        {
            checkoutOneLocator.ZipPostalCode.SendKeys(Keys.Control + "a" + Keys.Delete);
        }

        // GET LAST NAME IS DISPLAYED
        public bool LastNameDisplayed()
        {
            return checkoutOneLocator.LastName.Displayed;
        }

        // GET LAST NAME ATTRIBUTE
        public string LastNameAttribute()
        {
            return checkoutOneLocator.LastName.GetAttribute(Data.Attribute.placeholder);
        }

        // GET LAST NAME TAG NAME
        public string LastNameTagName()
        {
            return checkoutOneLocator.LastName.TagName;
        }

        // GET LAST NAME EDITABLE/ENABLED
        public bool LastNameEnabled()
        {
            return checkoutOneLocator.LastName.Enabled;
        }

        // GET ZIP/POSTAL CODE IS DISPLAYED
        public bool ZipPostalCodeDisplayed()
        {
            return checkoutOneLocator.ZipPostalCode.Displayed;
        }

        // GET ZIP/POSTAL CODE ATTRIBUTE
        public string ZipPostalCodeAttribute()
        {
            return checkoutOneLocator.ZipPostalCode.GetAttribute(Data.Attribute.placeholder);
        }

        // GET ZIP/POSTAL CODE TAG NAME
        public string ZipPostalCodeTagName()
        {
            return checkoutOneLocator.ZipPostalCode.TagName;
        }

        // GET ZIP/POSTAL CODE EDITABLE/ENABLED
        public bool ZipPostalCodeEnabled()
        {
            return checkoutOneLocator.ZipPostalCode.Enabled;
        }

        // GET CANCEL BUTTON IS DISPLAYED
        public bool CancelButtonDisplayed()
        {
            return checkoutOneLocator.CancelButton.Displayed;
        }

        // GET CONTINUE BUTTON IS DISPLAYED
        public bool ContinueButtonDisplayed()
        {
            return checkoutOneLocator.ContinueButton.Displayed;
        }

        // NAVIGATE TO CHECKOUT STEP TWO SCREEN 
        public void NavigateToCheckoutTwoScreen()
        {
            checkoutOneLocator.FirstName.SendKeys(Data.User.firstName);
            checkoutOneLocator.LastName.SendKeys(Data.User.lastName);
            checkoutOneLocator.ZipPostalCode.SendKeys(Data.User.zipPostal);
            checkoutOneLocator.ContinueButton.Click();
        }

        // NAVIGATE TO CART SCREEN
        public void NavigateToCartScreen()
        {
            checkoutOneLocator.CancelButton.Click();
        }
    }
}