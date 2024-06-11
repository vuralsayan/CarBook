using CarBook.Application.Features.CQRS.Results.CarResults;
using CarBook.Application.Interfaces.CarInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.CarHandlers
{
    public class GetLast5CarsWithBrandsQueryHandler
    {
        private readonly ICarRepository _repository;

        public GetLast5CarsWithBrandsQueryHandler(ICarRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<GetLast5CarsWithBrandsQueryResult>> Handle()
        {
            var values = await _repository.GetLast5CarsWithBrands();
            return values.Select(x => new GetLast5CarsWithBrandsQueryResult
            {
                BrandName = x.Brand.Name,
                BrandID = x.BrandID,
                BigImageUrl = x.BigImageUrl,
                CarID = x.CarID,
                CoverImageUrl = x.CoverImageUrl,
                Fuel = x.Fuel,
                Km = x.Km,
                Luggage = x.Luggage,
                Model = x.Model,
                Seat = x.Seat,
                Transmission = x.Transmission
            }).ToList();
        }
    }
}
