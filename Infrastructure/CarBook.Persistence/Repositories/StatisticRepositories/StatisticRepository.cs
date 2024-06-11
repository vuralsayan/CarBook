using CarBook.Application.Interfaces.StatisticInterfaces;
using CarBook.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Persistence.Repositories.StatisticRepositories
{
    public class StatisticRepository : IStatisticRepository
    {
        private readonly CarBookContext _context;

        public StatisticRepository(CarBookContext context)
        {
            _context = context;
        }

        public async Task<int> GetAuthorCount()
        {
            var values = await _context.Authors.CountAsync();
            return values;
        }

        public async Task<int> GetBlogCount()
        {
            var values = await _context.Blogs.CountAsync();
            return values;
        }

        public async Task<string> GetBlogTitleWithTheMostComments()
        {
            var values = await _context.Comments.GroupBy(x => x.BlogID).OrderByDescending(x => x.Count()).Select(x => x.Key).FirstOrDefaultAsync(); // En fazla yoruma sahip blogun ID'si
            var blogTitle = await _context.Blogs.Where(x => x.BlogID == values).Select(x => x.Title).FirstOrDefaultAsync(); // En fazla yoruma sahip blogun başlığı
            return blogTitle ?? "Blog bulunamadı";
        }

        public async Task<int> GetBrandCount()
        {
            var values = await _context.Brands.CountAsync();
            return values;
        }

        public async Task<string> GetBrandWithTheMostCar()
        {
            var values = await _context.Cars.GroupBy(x => x.BrandID).OrderByDescending(x => x.Count()).Select(x => x.Key).FirstOrDefaultAsync();
            var brandName = await _context.Brands.Where(x => x.BrandID == values).Select(x => x.Name).FirstOrDefaultAsync();
            return brandName ?? "Marka bulunamadı";
        }

        public async Task<int> GetCarCount()
        {
            var values = await _context.Cars.CountAsync();
            return values;
        }

        public async Task<string> GetCarModelWithTheCheapestDailyPricing()
        {
            var values = await _context.CarPricings.Where(x => x.PricingID == 3).OrderBy(x => x.Amount).Select(x => x.CarID).FirstOrDefaultAsync();
            var carModel = await _context.Cars.Where(x => x.CarID == values).Select(x => x.Model).FirstOrDefaultAsync();
            return carModel ?? "Araç bulunamadı";
        }

        public async Task<string> GetCarModelWithTheMostExpensiveDailyPricing()
        {
            var values = await _context.CarPricings.Where(x => x.PricingID == 3).OrderByDescending(x => x.Amount).Select(x => x.CarID).FirstOrDefaultAsync();
            var carModel = await _context.Cars.Where(x => x.CarID == values).Select(x => x.Model).FirstOrDefaultAsync();
            return carModel ?? "Araç bulunamadı";
        }

        public async Task<int> GetCarsWithAutomaticTransmission()
        {
            var values = await _context.Cars.Where(x => x.Transmission == "Otomatik").CountAsync();
            return values;
        }

        public async Task<int> GetCarWithLessThan1000Km()
        {
            var values = await _context.Cars.Where(x => x.Km < 1000).CountAsync();
            return values;
        }

        public async Task<decimal> GetDailyAvgPricing()
        {
            var values = await _context.CarPricings.Where(x => x.PricingID == 3).AverageAsync(x => x.Amount);
            return values;
        }

        public async Task<int> GetElectricCar()
        {
            var values = await _context.Cars.Where(x => x.Fuel == "Elektrik").CountAsync();
            return values;
        }

        public async Task<int> GetGasolineOrDieselCar()
        {
            var values = await _context.Cars.Where(x => x.Fuel == "Benzin" || x.Fuel == "Dizel").CountAsync();
            return values;
        }

        public async Task<decimal> GetHourlyAvgPricing()
        {
            var values = await _context.CarPricings.Where(x => x.PricingID == 2).AverageAsync(x => x.Amount);
            return values;
        }

        public async Task<int> GetLocationCount()
        {
            var values = await _context.Locations.CountAsync();
            return values;
        }

        public async Task<decimal> GetWeeklyAvgPricing()
        {
            var values = await _context.CarPricings.Where(x => x.PricingID == 4).AverageAsync(x => x.Amount);
            return values;
        }
    }
}
