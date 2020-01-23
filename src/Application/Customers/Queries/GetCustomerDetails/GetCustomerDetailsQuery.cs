using System;
using MediatR;

namespace Application.Customers.Queries.GetCustomerDetails
{
    public class GetCustomerDetailsQuery : IRequest<CustomerDetails>
    {
        public GetCustomerDetailsQuery(Guid CustomerId) => this.CustomerId = CustomerId;
        public Guid CustomerId { get; }
    }
}
