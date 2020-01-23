using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class Customer
    {
        public Guid CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public virtual ICollection<Callout> Callouts { get; set; }
    }
}
