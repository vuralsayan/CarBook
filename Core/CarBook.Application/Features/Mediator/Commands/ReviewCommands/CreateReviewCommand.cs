﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Commands.ReviewCommands
{
    public class CreateReviewCommand : IRequest
    {
        public string? CustomerName { get; set; }
        public string? CustomerImage { get; set; }
        public string? Comment { get; set; }
        public int Star { get; set; }
        public DateTime ReviewDate { get; set; }
        public int CarID { get; set; }
    }
}
