using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Commands.CarFeatureCommands
{
    public class UpdateCarFeatureAvailableChangeToTrueCommand : IRequest
    {
        public UpdateCarFeatureAvailableChangeToTrueCommand(int id)
        {
            ID = id;
        }

        public int ID { get; set; } 
    }
}
