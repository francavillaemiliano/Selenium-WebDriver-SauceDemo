namespace SauceDemo.Selector
{
    public class CheckoutTwoSelector
    {
        public static string btn_cancel = "button[class=\"btn btn_secondary back btn_medium cart_cancel_link\"]";
        public static string btn_finish = "button[class=\"btn btn_action btn_medium cart_button\"]";

        public static string div_cartquantity = "div[class=\"cart_quantity\"]";
        public static string div_cartquantitylabel = "div[class=\"cart_quantity_label\"]";
        public static string div_descriptionlabel = "div[class=\"cart_desc_label\"]";
        public static string div_subtotallabel = "div[class=\"summary_subtotal_label\"]";
        public static string div_taxlabel = "div[class=\"summary_tax_label\"]";
        public static string div_totallabel = "div[class=\"summary_info_label summary_total_label\"]";

        public static string span_title = "span[class=\"title\"]";

        public static string text_freeponyexpress = "//div[text()=\"Free Pony Express Delivery!\"]";
        public static string text_paymentinformation = "//div[text()=\"Payment Information\"]";
        public static string text_pricetotal = "//div[text()=\"Price Total\"]";
        public static string text_saucecard = "//div[text()=\"SauceCard #31337\"]";
        public static string text_shippinginformation = "//div[text()=\"Shipping Information\"]";

        public static string a_itemname = "//div[@class=\"inventory_item_name\"]/ancestor::a";

        public static string div_cartitem = "div[class=\"cart_item\"]";
        public static string div_itemdescription = "div[class=\"inventory_item_desc\"]";
        public static string div_itemname = "div[class=\"inventory_item_name\"]";
        public static string div_itemprice = "div[class=\"inventory_item_price\"]";
    }
}
