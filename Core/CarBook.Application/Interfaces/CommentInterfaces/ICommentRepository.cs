using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Interfaces.CommentInterfaces
{
    public interface ICommentRepository
    {
        Task<List<Comment>> GetCommentListByBlogId(int id);
        Task<int> GetCommentCountByBlogId(int id);
    }
}
