using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using Domain.Entities;
using FluentValidation;
using MediatR;

namespace Application.Customers.Commands.CreateCustomer
{
    public class CreateCustomerCommand : IRequest
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }

    public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand>
    {
        private readonly IMediator _mediator;
        private readonly IMediatRDemoDbContext _context;

        public CreateCustomerCommandHandler(IMediator mediator, IMediatRDemoDbContext context)
        {
            _mediator = mediator;
            _context = context;
        }

        public async Task<Unit> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            var entity = new Customer
            {
                CustomerId = Guid.NewGuid(),
                FirstName = request.FirstName,
                LastName = request.LastName
            };

            await _context.Customers.AddAsync(entity);
            await _context.SaveChangesAsync(cancellationToken);

            await _mediator.Publish(new CustomerCreated(entity), cancellationToken);

            return Unit.Value;
        }

        public class CreateCustomerCommandValidator : AbstractValidator<CreateCustomerCommand>
        {
            public CreateCustomerCommandValidator()
            {
                RuleFor(x => x.FirstName).NotEmpty();
                RuleFor(x => x.LastName).NotEmpty();
            }
        }
    }
}
