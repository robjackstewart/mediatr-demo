namespace Application.Customers.Queries.GetCustomerDetails
{
    public class CustomerDetails
    {
        public CustomerDetails(string firstName, string lastName, int calloutCount)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.CalloutCount = calloutCount;
        }
        public string FirstName { get; }
        public string LastName { get; }
        public int CalloutCount { get; }
    }
}
