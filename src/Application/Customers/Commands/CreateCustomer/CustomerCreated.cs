using System.Threading;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.Customers.Commands.CreateCustomer
{
    public class CustomerCreated : INotification
    {
        public CustomerCreated(Customer customer)
            => this.Customer = customer;
        public Customer Customer { get; }
    }

    public class CustomerCreatedHandler : INotificationHandler<CustomerCreated>
    {
        private readonly INotificationService _notificationService;

        public CustomerCreatedHandler(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }

        public async Task Handle(CustomerCreated notification, CancellationToken cancellationToken)
        {
            await _notificationService.SendAsync($"Congratulations to our new customer {notification.Customer.FirstName} {notification.Customer.LastName}");
        }
    }
}
