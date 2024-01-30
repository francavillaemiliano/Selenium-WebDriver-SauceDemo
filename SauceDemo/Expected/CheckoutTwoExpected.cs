namespace SauceDemo.Expected
{
    public class CheckoutTwoExpected
    {
        public static string itemQTY = "1";
        public static string itemNameTagName = "a";

        public static List<string> ItemList()
        {
            List<string[]> itemList = new List<string[]>()
            {
                Data.Items.sauceLabsBackpack,
                Data.Items.sauceLabsBikeLight,
                Data.Items.sauceLabsBoltTshirt,
                Data.Items.sauceLabsFleeceJacket,
                Data.Items.sauceLabsOnesie,
                Data.Items.testAllTheThingsTshirtRed
            };

            List<string> items = itemList.SelectMany(array => array).ToList();
            return items;
        }

        public static string paymentInformationLabel = "Payment Information";
        public static string sauceCardLabel = "SauceCard #31337";
        public static string shippingInformationLabel = "Shipping Information";
        public static string freePonyExpressDeliveryLabel = "Free Pony Express Delivery!";
        public static string subtotalLabel = "Item total: $129.94";
        public static string pricetotalLabel = "Price Total";
        public static string taxLabel = "Tax: $10.40";
        public static string totalSum = "Total: $140.34";
        public static string cancelButton = "Cancel";
        public static string finishButton = "Finish";
    }
}
