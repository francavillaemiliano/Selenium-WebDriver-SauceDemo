using OpenQA.Selenium;

namespace SauceDemo.POM
{
    public class Footer_POM
    {
        private IWebDriver? driver;

        public Footer_POM(IWebDriver driver)
        {
            this.driver = driver;
        }

        /* ELEMENT SELECTORS */
        public string div_copyright = "div[class=\"footer_copy\"]";

        public string icon_facebook = "//a[text()=\"Facebook\"]";
        public string icon_linkedin = "//a[text()=\"LinkedIn\"]";
        public string icon_twitter = "//a[text()=\"Twitter\"]";

        /* GET ELEMENT DISPLAYED */
        public Boolean GetElementDisplayed(By selector)
        {
            return driver!.FindElement(selector).Displayed;
        }

        /* GET ELEMENT TAG NAME */
        public string GetElementTagName(By selector)
        {
            return driver!.FindElement(selector).TagName;
        }

        /* CLICK ELEMENT */
        public void ClickElement(By selector)
        {
            driver!.FindElement(selector).Click();
        }

        /* GET ELEMENT TEXT */
        public string GetElementText(By selector)
        {
            return driver!.FindElement(selector).Text;
        }
    }
}