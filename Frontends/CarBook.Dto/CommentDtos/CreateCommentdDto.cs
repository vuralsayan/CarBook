using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Dto.CommentDtos
{
    public class CreateCommentdDto
    {
        public string? Name { get; set; }
        public DateTime CreatedDate { get; set; }
        public string? CommentText { get; set; }
        public int BlogID { get; set; }
        public string? Email { get; set; }  
    }
}
