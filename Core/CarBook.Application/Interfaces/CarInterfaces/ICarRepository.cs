using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Interfaces.CarInterfaces
{
    public interface ICarRepository
    {
        Task<List<Car>> GetCarsListWithBrand();
        Task<List<Car>> GetLast5CarsWithBrands();
        Task<Car> GetCarDetailsByCarId(int id);
        Task<CarDescription> GetCarDescriptionByCarId(int id);
    }
}
