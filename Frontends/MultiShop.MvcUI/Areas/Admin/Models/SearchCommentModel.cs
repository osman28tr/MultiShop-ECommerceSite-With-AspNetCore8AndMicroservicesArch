namespace MultiShop.MvcUI.Areas.Admin.Models
{
    public class SearchCommentModel
    {
        public string? Content { get; set; }
        public byte? Rating { get; set; }
        public bool Status { get; set; }
        public string? UserName { get; set; }
    }
}
