namespace MultiShop.Comment.ViewModels.ReviewViewModels
{
    public class GetByIdReviewViewModel
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
    }
}
