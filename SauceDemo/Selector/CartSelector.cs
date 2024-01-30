namespace SauceDemo.Selector
{
    public class CartSelector
    {
        public static string btn_checkout = "button[class=\"btn btn_action btn_medium checkout_button \"]";
        public static string btn_continueshopping = "button[class=\"btn btn_secondary back btn_medium\"]";

        public static string div_descriptionlabel = "div[class=\"cart_desc_label\"]";        
        public static string div_quantitylabel = "div[class=\"cart_quantity_label\"]";

        public static string span_title = "span[class=\"title\"]";

        public static string a_itemname = "//div[@class=\"inventory_item_name\"]/ancestor::a";
        public static string a_shoppingcart = "a[class=\"shopping_cart_link\"]";

        public static string btn_removefromcart = "button[class=\"btn btn_secondary btn_small cart_button\"]";

        public static string div_cartitem = "div[class=\"cart_item\"]";
        public static string div_cartquantity = "div[class=\"cart_quantity\"]";

        public static string div_itemdescription = "div[class=\"inventory_item_desc\"]";
        public static string div_itemname = "div[class=\"inventory_item_name\"]";
        public static string div_itemprice = "div[class=\"inventory_item_price\"]";
    }
}
