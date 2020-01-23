using System;

namespace Domain.Entities
{
    public class Customer
    {
        public Customer(string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
        }

        public Guid CustomerId { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
    }
}
