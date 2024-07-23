using System.Text.Json.Serialization;
using MultiShop.Comment.Models;

namespace MultiShop.Comment.ViewModels.ReviewViewModels
{
    public class ResultReviewViewModel
    {
        public string Id { get; set; }
        public string Content { get; set; }
        public byte Rating { get; set; }
        public bool Status { get; set; }
        public DateTime CreatedDate { get; set; }
        public UserModel User { get; set; }
    }
}
