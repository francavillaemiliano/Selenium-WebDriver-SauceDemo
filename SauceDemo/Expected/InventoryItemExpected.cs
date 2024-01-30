namespace SauceDemo.Expected
{
    public class InventoryItemExpected
    {
        public static List<string> SortingOptions()
        {
            List<string> sortingOptions = new List<string>();

            sortingOptions.Add("Name (A to Z)");
            sortingOptions.Add("Name (Z to A)");
            sortingOptions.Add("Price (low to high)");
            sortingOptions.Add("Price (high to low)");

            return sortingOptions;  
        }

        public static string tagNameSelect = "select";
        public static string tagNameLink = "a";

        public static string defaultSortingOption = "Name (A to Z)";

        public static List<string> itemsOrderNameAtoZ()
        {
            List<string[]> itemsOrder = new List<string[]>()
            {
                Data.Items.sauceLabsBackpackAdd,
                Data.Items.sauceLabsBikeLightAdd,
                Data.Items.sauceLabsBoltTshirtAdd,
                Data.Items.sauceLabsFleeceJacketAdd,
                Data.Items.sauceLabsOnesieAdd,
                Data.Items.testAllTheThingsTshirtRedAdd
            };

            List<string> items = itemsOrder.SelectMany(array => array).ToList();
            return items;
        }

        public static List<string> itemsOrderNameZtoA()
        {
            List<string[]> itemsOrder = new List<string[]>()
            {
                Data.Items.testAllTheThingsTshirtRedAdd,
                Data.Items.sauceLabsOnesieAdd,
                Data.Items.sauceLabsFleeceJacketAdd,
                Data.Items.sauceLabsBoltTshirtAdd,
                Data.Items.sauceLabsBikeLightAdd,
                Data.Items.sauceLabsBackpackAdd
            };

            List<string> items = itemsOrder.SelectMany(array => array).ToList();
            return items;
        }

        public static List<string> itemsOrderPriceLowToHigh()
        {
            List<string[]> itemsOrder = new List<string[]>()
            {
                Data.Items.sauceLabsOnesieAdd,
                Data.Items.sauceLabsBikeLightAdd,
                Data.Items.sauceLabsBoltTshirtAdd,
                Data.Items.testAllTheThingsTshirtRedAdd,              
                Data.Items.sauceLabsBackpackAdd,
                Data.Items.sauceLabsFleeceJacketAdd
            };

            List<string> items = itemsOrder.SelectMany(array => array).ToList();
            return items;
        }

        public static List<string> itemsOrderPriceHighToLow()
        {
            List<string[]> itemsOrder = new List<string[]>()
            {
                Data.Items.sauceLabsFleeceJacketAdd,
                Data.Items.sauceLabsBackpackAdd,
                Data.Items.sauceLabsBoltTshirtAdd,
                Data.Items.testAllTheThingsTshirtRedAdd,
                Data.Items.sauceLabsBikeLightAdd,
                Data.Items.sauceLabsOnesieAdd
            };

            List<string> items = itemsOrder.SelectMany(array => array).ToList();
            return items;
        }

        public static List<string> itemsUrl() 
        {
            List<string> itemsUrl = new List<string>();

            itemsUrl.Add("https://www.saucedemo.com/inventory-item.html?id=4");
            itemsUrl.Add("https://www.saucedemo.com/inventory-item.html?id=0");
            itemsUrl.Add("https://www.saucedemo.com/inventory-item.html?id=1");
            itemsUrl.Add("https://www.saucedemo.com/inventory-item.html?id=5");
            itemsUrl.Add("https://www.saucedemo.com/inventory-item.html?id=2");
            itemsUrl.Add("https://www.saucedemo.com/inventory-item.html?id=3");

            return itemsUrl;
        }
    }
}
