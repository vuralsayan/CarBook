using CarBook.Application.Features.Mediator.Queries.CarFeatureQueries;
using CarBook.Application.Features.Mediator.Results.CarFeatureResults;
using CarBook.Application.Interfaces;
using CarBook.Application.Interfaces.CarFeatureInterfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.CarFeatureHandlers
{
    public class GetCarFeatureByCarIdQueryHandler : IRequestHandler<GetCarFeatureByCarIdQuery, List<GetCarFeatureByCarIdQueryResult>>
    {
        private readonly ICarFeatureRepository _repository;

        public GetCarFeatureByCarIdQueryHandler(ICarFeatureRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<GetCarFeatureByCarIdQueryResult>> Handle(GetCarFeatureByCarIdQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetCarFeaturesByCarId(request.ID);
            return values.Select(x => new GetCarFeatureByCarIdQueryResult
            {
                CarID = x.CarID,
                Available = x.Available,
                CarFeatureID = x.CarFeatureID,
                FeatureID = x.FeatureID,
                FeatureName = x.Feature?.Name ?? "Özellik Adı Bulunamadı", 
                CarName = (x.Car?.Brand?.Name ?? "Bilinmeyen Marka") + " " + (x.Car?.Model ?? "Bilinmeyen Model") 
            }).ToList();
        }

    }
}
