namespace MultiShop.Comment.ViewModels.ReviewViewModels
{
	public class SearchViewModel
	{
		public string Content { get; set; }
		public byte Rating { get; set; }
		public bool Status { get; set; }
		public DateTime CreatedDate { get; set; }
		public string ProductId { get; set; }
		public string UserName { get; set; }
	}
}
