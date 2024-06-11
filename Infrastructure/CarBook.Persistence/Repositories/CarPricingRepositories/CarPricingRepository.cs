using CarBook.Application.Interfaces.CarPricingInterfaces;
using CarBook.Application.ViewModels;
using CarBook.Domain.Entities;
using CarBook.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CarBook.Persistence.Repositories.CarPricingRepositories
{
	public class CarPricingRepository : ICarPricingRepository
	{
		private readonly CarBookContext _context;

		public CarPricingRepository(CarBookContext context)
		{
			_context = context;
		}

		public async Task<List<CarPricing>> GetCarPricingWithCars()
		{
			var values = await _context.CarPricings.Include(x => x.Car).ThenInclude(y => y.Brand).Include(z => z.Pricing).Where(v => v.PricingID == 2).ToListAsync();
			return values;
		}


		public async Task<List<CarPricingViewModel>> GetCarPricingWithTimePeriod()
		{
			var query = from carPricing in _context.CarPricings
						join car in _context.Cars on carPricing.CarID equals car.CarID
						join brand in _context.Brands on car.BrandID equals brand.BrandID
						select new
						{
							brand.Name,
							car.Model,
							car.CoverImageUrl,
							carPricing.PricingID,
							carPricing.Amount
						};

			var data = await query.ToListAsync();

			var pivotData = data
				.GroupBy(d => new { d.Name, d.Model, d.CoverImageUrl })
				.Select(g => new CarPricingViewModel
				{
					BrandName = g.Key.Name,
					Model = g.Key.Model,
					CoverImageUrl = g.Key.CoverImageUrl,
					Amounts = g.OrderBy(x => x.PricingID)
							   .Select(x => x.Amount)
							   .ToList()
				})
				.ToList();

			return pivotData;
		}

	}
}
