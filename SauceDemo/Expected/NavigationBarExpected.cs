using System.Net.NetworkInformation;

namespace SauceDemo.Expected
{
    public class NavigationBarExpected
    {        
        public static List<string> BurguerMenuOptions() 
        {
            List<string> burguerMenuOptions = new List<string>();

            burguerMenuOptions.Add("All Items");
            burguerMenuOptions.Add("About");
            burguerMenuOptions.Add("Logout");
            burguerMenuOptions.Add("Reset App State");

            return burguerMenuOptions;
        }

        
        public static int cartItemsEmpty = 0;
        public static int cartItemsFull = 6;
        public static string appLogoText = "Swag Labs";
    }
}
