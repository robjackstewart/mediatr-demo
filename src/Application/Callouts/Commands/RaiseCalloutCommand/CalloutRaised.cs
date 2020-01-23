using System.Threading;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.Callouts.Commands.RaiseCalloutCommand
{
    public class CalloutRaised : INotification
    {
        public CalloutRaised(Callout callout)
            => this.Callout = callout;

        public Callout Callout { get; }
    }

    public class NotifyEngineerOfNewCalloutHandler : INotificationHandler<CalloutRaised>
    {
        private readonly INotificationService _notificationService;

        public NotifyEngineerOfNewCalloutHandler(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }

        public Task Handle(CalloutRaised notification, CancellationToken cancellationToken)
            => _notificationService.SendAsync($"Hey Mr engineer, you've got a new callout for {notification.Callout.Customer.FirstName} {notification.Callout.Customer.LastName} due to {notification.Callout.Reason}");
    }

    public class NotifyCustomerOfRaisedCalloutHandler : INotificationHandler<CalloutRaised>
    {
        private readonly INotificationService _notificationService;

        public NotifyCustomerOfRaisedCalloutHandler(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }

        public Task Handle(CalloutRaised notification, CancellationToken cancellationToken)
            => _notificationService.SendAsync($"Hey {notification.Callout.Customer.FirstName} {notification.Callout.Customer.LastName}, an engineer will be with you at {notification.Callout.EngineerToAttendOn.ToShortDateString()} {notification.Callout.EngineerToAttendOn.ToShortTimeString()}");
    }
}
