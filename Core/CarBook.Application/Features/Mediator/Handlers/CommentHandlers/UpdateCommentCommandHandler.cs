using CarBook.Application.Features.Mediator.Commands.CommentCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.CommentHandlers
{
    public class UpdateCommentCommandHandler : IRequestHandler<UpdateCommentCommand>
    {
        private readonly IRepository<Comment> _repository;

        public UpdateCommentCommandHandler(IRepository<Comment> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateCommentCommand request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.CommentID);
            values.Name = request.Name;
            values.CreatedDate = request.CreatedDate;
            values.CommentText = request.CommentText;
            values.BlogID = request.BlogID;
            await _repository.UpdateAsync(values);
        }
    }
}
