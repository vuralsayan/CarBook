using CarBook.Application.Features.Mediator.Commands.CommentCommands;
using CarBook.Application.Features.Mediator.Queries.CommentQueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CommentsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> CommentList()
        {
            var values = await _mediator.Send(new GetCommentQuery());
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetComment(int id)
        {
            var values = await _mediator.Send(new GetCommentByIdQuery(id));
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateComment(CreateCommentCommand command)
        {
            await _mediator.Send(command);
            return Ok("Yorum başarıyla eklendi.");
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveComment(int id)
        {
            await _mediator.Send(new RemoveCommentCommand(id));
            return Ok("Yorum başarıyla silindi.");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateComment(UpdateCommentCommand command)
        {
            await _mediator.Send(command);
            return Ok("Yorum başarıyla güncellendi.");
        }

        [HttpGet("GetCommentListByBlogId")]
        public async Task<IActionResult> GetCommentListByBlogId(int id)
        {
            var values = await _mediator.Send(new GetCommentListByBlogIdQuery(id));
            return Ok(values);
        }

        [HttpGet("GetCommentCountByBlogId")]
        public async Task<IActionResult> GetCommentCountByBlogId(int id)
        {
            var values = await _mediator.Send(new GetCommentCountByBlogIdQuery(id));
            return Ok(values);
        }
    }
}
