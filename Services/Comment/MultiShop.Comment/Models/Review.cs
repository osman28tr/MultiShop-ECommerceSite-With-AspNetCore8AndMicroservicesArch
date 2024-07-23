using System.Text.Json.Serialization;
using MultiShop.Comment.ViewModels.ReviewViewModels;
using Newtonsoft.Json.Converters;

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
        [JsonPropertyName("created_date")]
        public DateTime CreatedDate { get; set; }
        [JsonPropertyName("user")]
        public UserModel User { get; set; }
        public ResultReviewViewModel ConvertToResultReviewViewModel()
        {
            return new ResultReviewViewModel
            {
                Id = Id,
                Content = Content,
                Rating = Rating,
                Status = Status,
                CreatedDate = CreatedDate,
                User = new UserModel()
                {
                    Id = User.Id,
                    Name = User.Name,
                    Surname = User.Surname,
                    Email = User.Email,
                    Image = User.Image
                }
            };
        }

        public GetByIdReviewViewModel ConvertToGetByIdReviewViewModel()
        {
            return new GetByIdReviewViewModel
            {
                Id = Id,
                Content = Content,
                Rating = Rating,
                Status = Status,
                CreatedDate = CreatedDate,
                User = new UserModel()
                {
                    Id = User.Id,
                    Name = User.Name,
                    Surname = User.Surname,
                    Email = User.Email,
                    Image = User.Image
                }
            };
        }
    }

    public class UserModel
    {
        [JsonPropertyName("id")]
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
