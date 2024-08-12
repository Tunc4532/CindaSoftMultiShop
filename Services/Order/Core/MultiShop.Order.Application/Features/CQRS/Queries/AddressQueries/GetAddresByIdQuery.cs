using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Features.CQRS.Queries.AddressQueries
{
    public class GetAddresByIdQuery
    {
        public int Id { get; set; }
        public GetAddresByIdQuery(int id)
        {
            Id = id;
        }
    }
}
