using System;
using System.Threading;
using System.Threading.Tasks;
using Domain.Entities;
using MediatR;

namespace Application.Customers.Commands.CreateCustomer
{
    public class CreateCustomerCommand : IRequest
    {
        public CreateCustomerCommand(string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
        }
        public string FirstName { get; }
        public string LastName { get; }
    }
}
