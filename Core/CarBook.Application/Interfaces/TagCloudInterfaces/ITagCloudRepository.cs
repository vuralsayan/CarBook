using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Interfaces.TagCloudInterfaces
{
    public interface ITagCloudRepository
    {
        Task<List<TagCloud>> GetTagCloudsByBlogId(int id);
    }
}
