using System.Text.Json.Serialization;
using MultiShop.Comment.Models;

namespace MultiShop.Comment.ViewModels.ReviewViewModels
{
    public class UpdateReviewViewModel
    {
        public string Id { get; set; }
        public string Content { get; set; }
        public byte Rating { get; set; }
        public bool Status { get; set; }
        public DateTime created_date { get; set; }
        public string product_id { get; set; }
        public UserModel User { get; set; }

        public Review ConvertToReviewModel()
        {
            return new Review
            {
                Id = Id,
                Content = Content,
                Rating = Rating,
                Status = Status,
                ProductId = product_id,
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
}
