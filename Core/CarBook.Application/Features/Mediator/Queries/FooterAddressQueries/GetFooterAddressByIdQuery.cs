using CarBook.Application.Features.Mediator.Results.FooterAddressResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Queries.FooterAddressQueries
{
    public class GetFooterAddressByIdQuery :IRequest<GetFooterAddressByIdQueryResult>
    {
        public GetFooterAddressByIdQuery(int id)
        {
            ID = id;
        }

        public int ID { get; set; }
    }
}
