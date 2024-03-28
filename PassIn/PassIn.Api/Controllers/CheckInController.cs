using Microsoft.AspNetCore.Mvc;
using PassIn.Communication.Responses;

namespace PassIn.Api.Controllers;

[Route("api/[controller]")]
public class CheckInController : ControllerBase
{
    [HttpPost]
    [Route("{attendeeId}")]
    [ProducesResponseType(typeof(ResponseRegisterJson), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status409Conflict)]
    public IActionResult Checkin([FromRoute] Guid attendeeId)
    {
        return Created();
    }
}