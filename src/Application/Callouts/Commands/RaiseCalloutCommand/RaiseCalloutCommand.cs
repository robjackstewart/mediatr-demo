using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using Domain.Entities;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Callouts.Commands.RaiseCalloutCommand
{
    public class RaiseCalloutCommand : IRequest
    {
        public Guid CustomerId { get; set; }
        public string Reason { get; set; }
        public DateTime EngineerToAttendOn { get; set; }
    }

    public class RaiseCalloutCommandValidator : AbstractValidator<RaiseCalloutCommand>
    {
        private readonly IMediatRDemoDbContext _context;
        public RaiseCalloutCommandValidator(IMediatRDemoDbContext context)
        {
            _context = context;
            RuleFor(x => x.CustomerId).NotEmpty()
                .DependentRules(() =>
                {
                    RuleFor(x => x.CustomerId).MustAsync((x, cancellation) => _context.Customers.AnyAsync());
                });
            RuleFor(x => x.Reason).NotEmpty();
        }
    }

    public class RaiseCalloutCommandHandler : IRequestHandler<RaiseCalloutCommand>
    {
        private readonly IMediator _mediator;
        private readonly IMediatRDemoDbContext _context;
        public RaiseCalloutCommandHandler(IMediator mediator, IMediatRDemoDbContext context)
        {
            _mediator = mediator;
            _context = context;
        }

        public async Task<Unit> Handle(RaiseCalloutCommand request, CancellationToken cancellationToken)
        {
            var entity = new Callout
            {
                CalloutId = Guid.NewGuid(),
                Customer = await _context.Customers.FirstOrDefaultAsync(x => x.CustomerId == request.CustomerId),
                EngineerToAttendOn = request.EngineerToAttendOn,
                Reason = request.Reason
            };

            await _context.Callouts.AddAsync(entity, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            await _mediator.Publish(new CalloutRaised(entity));

            return Unit.Value;
        }
    }
}
