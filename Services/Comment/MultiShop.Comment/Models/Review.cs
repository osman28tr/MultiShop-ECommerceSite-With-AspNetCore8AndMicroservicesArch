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
        //formatted datetime as DD-MM-YYYY
        [JsonPropertyName("created_date")]
        public DateTime CreatedDate { get; set; }
        [JsonPropertyName("user_id")]
        public string UserId { get; set; }
        [JsonPropertyName("user_name")]
        public string UserName { get; set; }
        [JsonPropertyName("user_surname")]
        public string UserSurname { get; set; }
        [JsonPropertyName("user_email")]
        public string UserEmail { get; set; }
        [JsonPropertyName("user_image")]
        public string UserImage { get; set; }

        public ResultReviewViewModel ConvertToResultReviewViewModel()
        {
            return new ResultReviewViewModel
            {
                Id = Id,
                Content = Content,
                Rating = Rating,
                Status = Status,
                UserId = UserId,
                UserName = UserName,
                UserSurname = UserSurname,
                UserEmail = UserEmail,
                UserImage = UserImage
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
                UserId = UserId,
                UserName = UserName,
                UserSurname = UserSurname,
                UserEmail = UserEmail,
                UserImage = UserImage
            };
        }
    }
}
