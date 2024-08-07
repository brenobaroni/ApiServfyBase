using Api.Servfy.Base.Application.Handlers.User.GetUser.Request;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Servfy.Base.Controllers.V1
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class UserController : Controller
    {
        [HttpGet()]
        public async Task<IActionResult> Get([FromServices] IMediator mediator, [FromQuery] GetUserRequest query, CancellationToken cancellationToken)
        {
            var response = await mediator.Send(query, cancellationToken);

            if (!response.success)
                return BadRequest(response);

            return Ok(response);
        }
    }
}
