using System;

namespace Domain.Entities
{
    public class Callout
    {
        public Guid CalloutId { get; set; }
        public Guid CustomerId { get; set; }
        public DateTime EngineerToAttendOn { get; set; }
        public string Reason { get; set; }

        public virtual Customer Customer { get; set; }
    }
}
