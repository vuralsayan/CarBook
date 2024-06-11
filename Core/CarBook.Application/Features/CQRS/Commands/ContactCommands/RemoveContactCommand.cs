using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Commands.ContactCommands
{
    public class RemoveContactCommand
    {
        public RemoveContactCommand(int id)
        {
            ID = id;
        }

        public int ID { get; set; }
    }
}
