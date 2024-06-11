using CarBook.Application.Interfaces.CommentInterfaces;
using CarBook.Domain.Entities;
using CarBook.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Persistence.Repositories.CommentRepositories
{
    public class CommentRepository : ICommentRepository
    {
        private readonly CarBookContext _context;

        public CommentRepository(CarBookContext context)
        {
            _context = context;
        }

        public async Task<int> GetCommentCountByBlogId(int id)
        {
            var values = await _context.Comments.Where(x => x.BlogID == id).CountAsync();
            return values;  
        }

        public async Task<List<Comment>> GetCommentListByBlogId(int id)
        {
            var values = await _context.Comments.Include(x => x.Blog).Where(y => y.BlogID == id).ToListAsync();
            return values;
        }
    }
}
