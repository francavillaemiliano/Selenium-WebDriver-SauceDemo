namespace SauceDemo.Expected
{
    public class CartExpected
    {
        public static string itemQTY = "1";
        public static string itemNameTag = "a";

        public static List<string> ItemList()
        {
            List<string[]> itemList = new List<string[]>()
            {
                Data.Items.sauceLabsBackpackRemove,
                Data.Items.sauceLabsBikeLightRemove,
                Data.Items.sauceLabsBoltTshirtRemove,
                Data.Items.sauceLabsFleeceJacketRemove,
                Data.Items.sauceLabsOnesieRemove,
                Data.Items.testAllTheThingsTshirtRedRemove
            };

            List<string> items = itemList.SelectMany(array => array).ToList();
            return items;
        }

        public static int cartitemsFull = 6;
        public static int cartitemsEmpty = 0;

    }
}
