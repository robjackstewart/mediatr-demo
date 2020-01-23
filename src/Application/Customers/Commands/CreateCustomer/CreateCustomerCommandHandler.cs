using System;
using System.Threading;
using System.Threading.Tasks;
using Domain.Entities;
using MediatR;

namespace Application.Customers.Commands.CreateCustomer
{
    public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand>
    {
        private readonly IMediator _mediator;

        public CreateCustomerCommandHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<Unit> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            var entity = new Customer
            {
                CustomerId = Guid.NewGuid(),
                FirstName = request.FirstName,
                LastName = request.LastName
            };

            return Unit.Value;
        }
    }
}
