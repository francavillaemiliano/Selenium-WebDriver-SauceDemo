using OpenQA.Selenium;

namespace SauceDemo.POM
{
    public class CheckoutComplete_POM
    {
        private IWebDriver? driver;

        public CheckoutComplete_POM(IWebDriver driver)
        {
            this.driver = driver;
        }

        /* ELEMENTS SELECTORS */
        public string btn_back_home = "button[class=\"btn btn_primary btn_small\"]";

        public string div_completetext = "div[class=\"complete-text\"]";

        public string h2_completeheader = "h2[class=\"complete-header\"]";

        public string img_ponyexpress = "img[class=\"pony_express\"]";

        public string span_title = "span[class=\"title\"]";

        /* GET ELEMENT DISPLAYED */
        public Boolean GetElementDisplayed(By selector)
        {
            return driver!.FindElement(selector).Displayed;
        }

        /* CLICK BUTTON */
        public void ClickButton(By selector)
        {
            driver!.FindElement(selector).Click();
        }
    }
}