using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Queries.CategoryQueries
{
    public class GetCategoryByIdQuery
    {
        public GetCategoryByIdQuery(int id)
        {
            ID = id;
        }

        public int ID { get; set; }
    }
}
