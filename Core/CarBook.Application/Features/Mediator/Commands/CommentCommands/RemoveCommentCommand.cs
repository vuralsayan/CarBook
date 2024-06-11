using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Commands.CommentCommands
{
    public class RemoveCommentCommand : IRequest
    {
        public RemoveCommentCommand(int id)
        {
            ID = id;
        }

        public int ID { get; set; }
    }
}
