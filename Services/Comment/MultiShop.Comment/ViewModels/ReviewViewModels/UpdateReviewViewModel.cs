using MultiShop.Comment.Models;

namespace MultiShop.Comment.ViewModels.ReviewViewModels
{
    public class UpdateReviewViewModel
    {
        public string Id { get; set; }
        public string Content { get; set; }
        public byte Rating { get; set; }
        public bool Status { get; set; }
        public DateTime CreatedDate { get; set; }
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string UserSurname { get; set; }
        public string UserEmail { get; set; }
        public string UserImage { get; set; }

        public Review ConvertToReviewModel()
        {
            return new Review
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
