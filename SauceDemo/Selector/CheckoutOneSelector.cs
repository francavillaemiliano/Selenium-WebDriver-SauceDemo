namespace SauceDemo.Selector
{
    public class CheckoutOneSelector
    {
        public static string btn_cancel = "button[class=\"btn btn_secondary back btn_medium cart_cancel_link\"]";
        public static string btn_continue = "input[class=\"submit-button btn btn_primary cart_button btn_action\"]";

        public static string input_firstname = "input[name=\"firstName\"]";
        public static string input_lastname = "input[name=\"lastName\"]";
        public static string input_postalcode = "input[name=\"postalCode\"]";

        public static string span_title = "span[class=\"title\"]";

        public static string h3_error = "h3[data-test=\"error\"]";
    }
}
