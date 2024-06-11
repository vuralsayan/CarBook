using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Queries.BrandQueries
{
    public class GetBrandByIdQuery
    {
        public GetBrandByIdQuery(int id)
        {
            ID = id;
        }

        public int ID { get; set; }
    }
}
