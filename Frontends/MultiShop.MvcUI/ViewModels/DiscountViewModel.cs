using System.Text.Json.Serialization;

namespace MultiShop.MvcUI.ViewModels
{
    public class DiscountViewModel
    {
        [JsonPropertyName("message")]
        public string Message { get; set; }
        [JsonPropertyName("data")]
        public string Data { get; set; }
    }
}
