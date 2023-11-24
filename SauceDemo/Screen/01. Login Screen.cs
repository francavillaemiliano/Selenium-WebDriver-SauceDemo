using OpenQA.Selenium;
using System.Xml.Linq;

public class LoginScreen
{
    private IWebDriver driver;

    public LoginScreen (IWebDriver driver)
    {
        this.driver = driver;
    }

    /* CREDENTIALS */
    public string standarduser = "standard_user";
    public string lockedoutuser = "locked_out_user";
    public string secretsauce = "secret_sauce";

    /* ELEMENTS SELECTORS */
    public string div_loginlogo = "div[class=\"login_logo\"]";

    public string h3_errormessage = "h3[data-test=\"error\"]";

    public string input_loginbutton = "input[id=\"login-button\"]";
    public string input_password = "input[id=\"password\"]";
    public string input_username = "input[id=\"user-name\"]";

    /* ELEMENTS LOCATORS */
    private IWebElement Username => driver!.FindElement(By.CssSelector(input_username));
    private IWebElement Password => driver!.FindElement(By.CssSelector(input_password));
    private IWebElement LoginButton => driver!.FindElement(By.CssSelector(input_loginbutton));

    /* GET ELEMENT DISPLAYED */
    public Boolean GetElementDisplayed(By selector)
    {
        return driver.FindElement(selector).Displayed;
    }

    /* GET ELEMENT TEXT */
    public string GetElementText(By selector)
    {
        return driver.FindElement(selector).Text;
    }

    /* GET ELEMENT ATTRIBUTE */
    public string GetElementAttribute(By selector, string attribute)
    {
        return driver.FindElement(selector).GetAttribute(attribute);
    }

    /* GET ELEMENT TAG NAME */
    public string GetElementTagName(By selector)
    {
        return driver.FindElement(selector).TagName;
    }

    /* GET ELEMENT ENABLED */
    public Boolean GetElementEnabled(By selector)
    {
        return driver.FindElement(selector).Enabled;
    }

    /* CLICK ELEMENT */
    public void ClickElement(By selector)
    {
        driver!.FindElement(selector).Click();
    }

    /* FILL IN INPUT ELEMENT */
    public void FillInInputElement(By selector, string input)
    {
        driver.FindElement(selector).SendKeys(input);
    }

    /* CLEAN INPUT ELEMENT */
    public void CleanInputElement(By selector)
    {   
        driver.FindElement(selector).SendKeys(Keys.Control + "a" + Keys.Delete);
    }

    /* LOGIN STANDARD USER */
    public void LoginUser(string userName, string passWord)
    {
        Username.SendKeys(userName);
        Password.SendKeys(passWord);
        LoginButton.Click();
    }
}