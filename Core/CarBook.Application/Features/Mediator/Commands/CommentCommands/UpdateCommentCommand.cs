using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Commands.CommentCommands
{
    public class UpdateCommentCommand : IRequest
    {
        public int CommentID { get; set; }
        public string? Name { get; set; }
        public DateTime CreatedDate { get; set; }
        public string? CommentText { get; set; }
        public int BlogID { get; set; }
    }
}
