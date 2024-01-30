using SauceDemo.Locator;

namespace SauceDemo.Component
{
    public class FooterComponent
    {
        private FooterLocator footerLocator;

        public FooterComponent(FooterLocator footerLocator)
        {
            this.footerLocator = footerLocator;
        }

        // GET TWITTER ICON IS DISPLAYED
        public bool TwitterIconDisplayed()
        {
            return footerLocator.TwitterIcon.Displayed;
        }

        // GET TWITTER ICON TAG NAME
        public string TwitterIconTagName()
        {
            return footerLocator.TwitterIcon.TagName;
        }

        // GET FACEBOOK ICON IS DISPLAYED
        public bool FacebookIconDisplayed()
        {
            return footerLocator.FacebookIcon.Displayed;
        }

        // GET FACEBOOK ICON TAG NAME
        public string FacebookIconTagName()
        {
            return footerLocator.FacebookIcon.TagName;
        }

        // GET LINKEDIN ICON IS DISPLAYED
        public bool LinkedinIconDisplayed()
        {
            return footerLocator.LinkedinIcon.Displayed;
        }

        // GET LINKEDIN ICON TAG NAME
        public string LinkedinIconTagName()
        {
            return footerLocator.LinkedinIcon.TagName;
        }

        // GET COPYRIGHT IS DISPLAYED
        public bool CopyrightDisplayed()
        {
            return footerLocator.Copyright.Displayed;
        }

        // GET COPYRIGHT TEXT
        public string CopyrightText()
        {
            return footerLocator.Copyright.Text;
        }
    }
}