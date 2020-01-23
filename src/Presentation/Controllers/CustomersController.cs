using System;
using System.Threading.Tasks;
using Application.Customers.Commands.CreateCustomer;
using Application.Customers.Queries.GetCustomerDetails;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    public class CustomersController : ControllerBase
    {
        [HttpGet("customerId")]
        public async Task<ActionResult<CustomerDetails>> GetDetails(Guid customerId)
            => Ok(await Mediator.Send(new GetCustomerDetailsQuery(customerId)));

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateCustomerCommand command)
        {
            await Mediator.Send(command);
            return NoContent();
        }
    }
}
