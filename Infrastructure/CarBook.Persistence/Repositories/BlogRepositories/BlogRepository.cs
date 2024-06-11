using CarBook.Application.Interfaces.BlogInterfaces;
using CarBook.Domain.Entities;
using CarBook.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Persistence.Repositories.BlogRepositories
{
    public class BlogRepository : IBlogRepository
    {
        private readonly CarBookContext _context;

        public BlogRepository(CarBookContext context)
        {
            _context = context;
        }

        public async Task<List<Blog>> GetAllBlogsWithAuthors()
        {
            var values = await _context.Blogs.Include(x => x.Author).ToListAsync();
            return values;
        }

        public async Task<Blog> GetAuthorByBlogId(int id)
        {
            var values = await _context.Blogs.Include(x => x.Author).Where(x => x.BlogID == id).FirstOrDefaultAsync();
            if (values == null)
            {
                throw new Exception("İlgili bloga ait yazar bulunamadı");
            }
            return values;
        }

        public async Task<List<Blog>> GetLast3BlogsWithAuthors()
        {
            var values = await _context.Blogs.Include(x => x.Author).OrderByDescending(x => x.BlogID).Take(3).ToListAsync();
            return values;
        }
    }
}
