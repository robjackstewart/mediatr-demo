using System.Threading.Tasks;
using Application.Callouts.Commands.RaiseCalloutCommand;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    public class CalloutsController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Raise([FromBody] RaiseCalloutCommand command)
        {
            await Mediator.Send(command);
            return NoContent();
        }
    }
}
