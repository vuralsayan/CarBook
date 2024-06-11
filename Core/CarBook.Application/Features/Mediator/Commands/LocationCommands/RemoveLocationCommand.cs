using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Commands.LocationCommands
{
    public class RemoveLocationCommand : IRequest
    {
        public RemoveLocationCommand(int ıD)
        {
            ID = ıD;
        }

        public int ID { get; set; } 
    }
}
