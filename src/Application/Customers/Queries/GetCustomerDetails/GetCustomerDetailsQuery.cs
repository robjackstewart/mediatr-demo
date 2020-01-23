using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Customers.Queries.GetCustomerDetails
{
    public class GetCustomerDetailsQuery : IRequest<CustomerDetails>
    {
        public GetCustomerDetailsQuery(Guid CustomerId) => this.CustomerId = CustomerId;
        public Guid CustomerId { get; }
    }

    public class GetCustomerDetailsQueryValidator : AbstractValidator<GetCustomerDetailsQuery>
    {
        public GetCustomerDetailsQueryValidator()
        {
            RuleFor(x => x.CustomerId).NotEmpty();
        }
    }

    public class GetCustomerDetailsQueryHandler : IRequestHandler<GetCustomerDetailsQuery, CustomerDetails>
    {
        private readonly IMediator _mediator;
        private readonly IMediatRDemoDbContext _context;

        public GetCustomerDetailsQueryHandler(IMediator mediator, IMediatRDemoDbContext context)
        {
            _mediator = mediator;
            _context = context;
        }

        public async Task<CustomerDetails> Handle(GetCustomerDetailsQuery request, CancellationToken cancellationToken)
            => await _context.Customers
            .Where(x => x.CustomerId == request.CustomerId)
            .Select(x => new CustomerDetails(x.FirstName, x.LastName, x.Callouts.Count))
            .FirstOrDefaultAsync();
    }
}
