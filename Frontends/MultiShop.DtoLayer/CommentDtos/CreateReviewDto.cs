using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.DtoLayer.CommentDtos
{
    public class CreateReviewDto
    {
        public string Content { get; set; }
        public byte Rating { get; set; }
        public bool Status { get; set; }
        public DateTime CreatedDate { get; set; }
        public UserReviewDto User { get; set; }
    }
}
