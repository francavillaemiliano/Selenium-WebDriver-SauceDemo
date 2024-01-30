namespace SauceDemo.Selector
{
    public class InventoryItemSelector
    {
        public static string a_itemname = "//div[@class=\"inventory_item_name \"]/ancestor::a";

        public static string btn_addtocart = "button[class=\"btn btn_primary btn_small btn_inventory \"]";
        public static string btn_removefromcart = "button[class=\"btn btn_secondary btn_small btn_inventory \"]";

        public static string div_item = "div[class=\"inventory_item\"]";
        public static string div_itemname = "div[class=\"inventory_item_name \"]";
        public static string div_itemdescription = "div[class=\"inventory_item_desc\"]";
        public static string div_itemprice = "div[class=\"inventory_item_price\"]";

        public static string img_itemimage = "img[class=inventory_item_img]";

        public static string select_sorting = "select[class=\"product_sort_container\"]";

        public static string span_productstitle = "span[class=\"title\"]";
    }
}
