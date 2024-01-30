using OpenQA.Selenium;
using SauceDemo.Locator;

namespace SauceDemo.Screen
{
    public class LoginScreen
    {
        private LoginLocator loginLocator;

        public LoginScreen(LoginLocator loginLocator)
        {
            this.loginLocator = loginLocator;
        }

        // GET LOGIN LOGO IS DISPLAYED
        public bool LoginLogoDisplayed()
        {
            return loginLocator.LoginLogo.Displayed;
        }

        // GET LOGIN LOGO TEXT
        public string LoginLogoText()
        {
            return loginLocator.LoginLogo.Text;
        }

        // GET USERNAME FIELD IS DISPLAYED
        public bool UsernameDisplayed()
        {
            return loginLocator.Username.Displayed;
        }

        // GET USERNAME FIELD ATTRIBUTE
        public string UsernameAttribute()
        {
            return loginLocator.Username.GetAttribute(Data.Attribute.placeholder);
        }

        // GET USERNAME FIELD TAG NAME
        public string UsernameTagName()
        {
            return loginLocator.Username.TagName;
        }

        // GET USERNAME FIELD IS ENABLED
        public bool UsernameEnabled()
        {
            return loginLocator.Username.Enabled;
        }

        // GET LOGIN ERROR MESSAGE
        public string LoginErrorMessage()
        {
            return loginLocator.LoginErrorMessage.Text;
        }

        // GET PASSWORD FIELD IS DISPLAYED
        public bool PasswordDisplayed()
        {
            return loginLocator.Password.Displayed;
        }

        // GET PASSWORD FIELD ATTRIBUTE
        public string PasswordAttribute()
        {
            return loginLocator.Password.GetAttribute(Data.Attribute.placeholder);
        }

        // GET PASSWORD FIELD TAG NAME
        public string PasswordTagName()
        {
            return loginLocator.Password.TagName;
        }

        // GET PASSWORD FIELD IS ENABLED
        public bool PasswordEnabled()
        {
            return loginLocator.Password.Enabled;
        }

        // GET LOGIN BUTTON IS DISPLAYED
        public bool LoginButtonDisplayed()
        {
            return loginLocator.LoginButton.Displayed;
        }

        // GET LOGIN BUTTON ATTRIBUTE
        public string LoginButtonAttribute()
        {
            return loginLocator.LoginButton.GetAttribute(Data.Attribute.value);
        }

        // FILL IN USERNAME FIELD
        public void FillInUsername()
        {
            loginLocator.Username.SendKeys(Data.Credential.userStandard);
        }

        // FILL IN PASSWORD FIELD
        public void FillInPassword()
        {
            loginLocator.Password.SendKeys(Data.Credential.passwordSecretSauce);
        }

        // CLEAN USERNAME FIELD
        public void CleanUsername() 
        {
            loginLocator.Username.SendKeys(Keys.Control + "a" + Keys.Delete);
        }

        // CLEAN PASSWORD FIELD
        public void CleanPassword()
        {
            loginLocator.Password.SendKeys(Keys.Control + "a" + Keys.Delete);
        }

        // CLICK LOGIN BUTTON
        public void ClickLoginButton()
        {
            loginLocator.LoginButton.Click();                
        }

        // LOGIN STANDARD USER
        public void LoginStandardUser()
        {
            loginLocator.Username.SendKeys(Data.Credential.userStandard);
            loginLocator.Password.SendKeys(Data.Credential.passwordSecretSauce);
            loginLocator.LoginButton.Click();
        }

        // LOGIN LOCKED OUT USER
        public void LoginLockedoutUser()
        {
            loginLocator.Username.SendKeys(Data.Credential.userLockedout);
            loginLocator.Password.SendKeys(Data.Credential.passwordSecretSauce);
            loginLocator.LoginButton.Click();
        }
    }
}
