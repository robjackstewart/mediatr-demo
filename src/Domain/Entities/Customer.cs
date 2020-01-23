using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class Customer
    {
        public Customer()
        {
            Callouts = new HashSet<Callout>();
        }

        public Guid CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public ICollection<Callout> Callouts { get; private set; }
    }
}
