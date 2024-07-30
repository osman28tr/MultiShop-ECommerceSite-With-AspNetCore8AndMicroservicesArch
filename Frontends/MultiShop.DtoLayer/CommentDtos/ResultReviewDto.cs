using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MultiShop.DtoLayer.CommentDtos
{
    public class ResultReviewDto
    {
        public string Id { get; set; }
        public string Content { get; set; }
        public byte Rating { get; set; }
        public bool Status { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ProductId { get; set; }
        public UserReviewDto User { get; set; }
    }
}
