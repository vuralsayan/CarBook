using CarBook.Application.Interfaces.CarInterfaces;
using CarBook.Domain.Entities;
using CarBook.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Persistence.Repositories.CarRepositories
{
	public class CarRepository : ICarRepository
	{
		private readonly CarBookContext _context;

		public CarRepository(CarBookContext context)
		{
			_context = context;
		}

        public async Task<CarDescription> GetCarDescriptionByCarId(int id)
        {
			var values = await _context.CarDescriptions.FirstOrDefaultAsync(x => x.CarID == id);
			if (values == null)
            {
                throw new Exception($"{id} id sine sahip araç açıklaması bulunamadı");
            }
            return values;
        }

        public async Task<Car> GetCarDetailsByCarId(int id)
		{
			var values = await _context.Cars.Include(x => x.Brand).FirstOrDefaultAsync(x => x.CarID == id);
			if (values == null)
			{
				throw new Exception($"{id} id sine sahip araç bulunamadı");
			}
			return values;
		}


		public async Task<List<Car>> GetCarsListWithBrand()
		{
			var values = await _context.Cars.Include(x => x.Brand).ToListAsync();
			return values;
		}

		public async Task<List<Car>> GetLast5CarsWithBrands()
		{
			var values = await _context.Cars.Include(x => x.Brand).OrderByDescending(x => x.CarID).Take(5).ToListAsync();
			return values;
		}
	}
}
