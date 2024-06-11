﻿using CarBook.Application.Features.Mediator.Queries.StatisticQueries;
using CarBook.Application.Features.Mediator.Results.StatisticResults;
using CarBook.Application.Interfaces.StatisticInterfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.StatisticHandlers
{
    public class GetCarsWithAutomaticTransmissionQueryHandler : IRequestHandler<GetCarsWithAutomaticTransmissionQuery, GetCarsWithAutomaticTransmissionQueryResult>
    {
        private readonly IStatisticRepository _repository;

        public GetCarsWithAutomaticTransmissionQueryHandler(IStatisticRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetCarsWithAutomaticTransmissionQueryResult> Handle(GetCarsWithAutomaticTransmissionQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetCarsWithAutomaticTransmission();
            return new GetCarsWithAutomaticTransmissionQueryResult { AutomaticTransmissionCarCount = values };
        }
    }
}
