using CarBook.Application.Interfaces.ReviewInterfaces;
using CarBook.Domain.Entities;
using CarBook.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Persistence.Repositories.ReviewRepositories
{
    public class ReviewRepository : IReviewRepository
    {
        private readonly CarBookContext _context;

        public ReviewRepository(CarBookContext context)
        {
            _context = context;
        }

        public async Task<List<Review>> GetReviewListByCarId(int id)
        {
            var values = await _context.Reviews.Where(x => x.CarID == id).ToListAsync();
            return values;
        }
    }
}
