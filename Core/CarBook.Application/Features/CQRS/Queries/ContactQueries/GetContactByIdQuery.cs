using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Queries.ContactQueries
{
    public class GetContactByIdQuery
    {
        public GetContactByIdQuery(int id)
        {
            ID = id;
        }

        public int ID { get; set; }
    }
}
