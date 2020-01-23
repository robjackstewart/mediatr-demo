using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace Application.Customers.Queries.GetCustomerDetails
{
    public class GetCustomerDetailsQueryHandler : IRequestHandler<GetCustomerDetailsQuery, CustomerDetails>
    {
        public async Task<CustomerDetails> Handle(GetCustomerDetailsQuery request, CancellationToken cancellationToken)
        {
            return new CustomerDetails("", "", 0);
        }
    }
}
