using System.Text.Json.Serialization;

namespace MultiShop.Comment.Models
{
    public class Review
    {
        [JsonPropertyName("_id")]
        public string Id { get; set; }
        [JsonPropertyName("content")]
        public string Content { get; set; }
        [JsonPropertyName("rating")]
        public byte Rating { get; set; }
        [JsonPropertyName("status")]
        public bool Status { get; set; }
        [JsonPropertyName("user")]
        public UserModel User { get; set; }
    }

    public class UserModel
    {
        [JsonPropertyName("_id")]
        public string Id { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("surname")]
        public string Surname { get; set; }
        [JsonPropertyName("email")]
        public string Email { get; set; }
        [JsonPropertyName("image")]
        public string Image { get; set; }
    }
}
