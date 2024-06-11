using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Dto.TagCloudDtos
{
    public class GetTagCloudByBlogIdDto
    {
        public int TagCloudId { get; set; }
        public string? TagName { get; set; }
        public int BlogID { get; set; }
    }
}
