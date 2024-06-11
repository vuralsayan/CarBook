﻿using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Commands.CarFeatureCommands
{
    public class CreateCarFeatureByCarIdCommand : IRequest
    {
        public int CarID { get; set; }
        public int FeatureID { get; set; }
        public bool Available { get; set; }
    }
}
