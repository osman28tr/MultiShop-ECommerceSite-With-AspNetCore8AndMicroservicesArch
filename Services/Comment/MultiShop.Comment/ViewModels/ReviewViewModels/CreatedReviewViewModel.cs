using System.Text.Json.Serialization;
using MultiShop.Comment.Models;

namespace MultiShop.Comment.ViewModels.ReviewViewModels
{
    public class CreatedReviewViewModel
    {
        public string Content { get; set; }
        public byte Rating { get; set; }
        [JsonPropertyName("created_date")]
        public DateTime CreatedDate { get; set; }
        public bool Status { get; set; }
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string UserSurname { get; set; }
        public string UserEmail { get; set; }
        public string UserImage { get; set; }

        public Review ConvertToReviewModel()
        {
            return new Review()
            {
                Content = Content,
                Rating = Rating,
                Status = Status,
                CreatedDate = DateTime.Now,
                UserId = UserId,
                UserName = UserName,
                UserSurname = UserSurname,
                UserEmail = UserEmail,
                UserImage = UserImage
            };
        }
    }
}
