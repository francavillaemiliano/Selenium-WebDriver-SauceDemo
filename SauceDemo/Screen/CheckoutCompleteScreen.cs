using SauceDemo.Locator;

namespace SauceDemo.Screen
{
    public class CheckoutCompleteScreen
    {
        private CheckoutCompleteLocator checkoutCompleteLocator;

        public CheckoutCompleteScreen(CheckoutCompleteLocator checkoutCompleteLocator)
        {
            this.checkoutCompleteLocator = checkoutCompleteLocator;
        }

        // GET CHECKOUT: COMPLETE! IS DISPLAYED
        public bool CheckoutCompleteIsDisplayed()
        {
            return checkoutCompleteLocator.CheckoutComplete.Displayed;
        }

        // GET CHECKOUT: COMPLETE! TEXT
        public string CheckoutCompleteText()
        {
            return checkoutCompleteLocator.CheckoutComplete.Text;
        }

        // GET SUCCESSFUL IMAGE IS DISPLAYED
        public bool SuccessfulImgDisplayed()
        {
            return checkoutCompleteLocator.PonyExpressImg.Displayed;
        }

        // GET THANK YOU FOR YOUR ORDER! IS DISPLAYED
        public bool ThankForYourOrderDisplayed()
        {
            return checkoutCompleteLocator.ThankYou.Displayed;
        }

        // GET THANK YOU FOR YOUR ORDER! TEXT
        public string ThankYouForYourOrderText()
        {
            return checkoutCompleteLocator.ThankYou.Text;
        }

        // GET YOUR ORDER HAS BEEN DISPATCHED IS DISPLAYED
        public bool OrderDispatchedDisplayed()
        {
            return checkoutCompleteLocator.OrderDispatched.Displayed;
        }

        // GET YOUR ORDER HAS BEEN DISPATCHED TEXT
        public string OrderDispatchedText()
        {
            return checkoutCompleteLocator.OrderDispatched.Text;
        }

        // GET BACK HOME BUTTON IS DISPLAYED
        public bool BackHomeButtonDisplayed()
        {
            return checkoutCompleteLocator.BackHomeButton.Displayed;
        }

        // GET BACK HOME BUTTON TEXT
        public string BackHomeButtonText()
        {
            return checkoutCompleteLocator.BackHomeButton.Text;
        }
    }
}