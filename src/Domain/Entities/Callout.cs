using System;

namespace Domain.Entities
{
    public class Callout
    {
        public Callout() { }
        public Guid CalloutId { get; private set; }
        public Guid CustomerId { get; private set; }

        public Customer Customer { get; set; }
    }
}
