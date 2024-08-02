namespace MultiShop.MvcUI.Settings
{
    public class ClientSetting
    {
        public Client MultiShopClient { get; set; }
        public Client MultiShopManagerClient { get; set; }
        public Client MultiShopAdminClient { get; set; }
    }
    public class Client
    {
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
    }
}
