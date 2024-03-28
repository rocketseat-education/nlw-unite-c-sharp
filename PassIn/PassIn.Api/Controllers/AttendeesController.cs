using Microsoft.AspNetCore.Mvc;
using PassIn.Application.UseCases.Attendees.GetAllByEventId;
using PassIn.Application.UseCases.Events.RegisterAttendee;
using PassIn.Communication.Requests;
using PassIn.Communication.Responses;

namespace PassIn.Api.Controllers;

[Route("api/[controller]")]
public class AttendeesController : ControllerBase
{
    [HttpPost]
    [Route("{id}/register")]
    [ProducesResponseType(typeof(ResponseRegisterJson), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
    public IActionResult Register([FromRoute] Guid eventId, [FromBody] RequestRegisterEventJson request)
    {
        var useCase = new RegisterAttendeeOnEventUseCase();

        var response = useCase.Execute(eventId, request);

        return Created(string.Empty, response);
    }

    [HttpGet]
    [Route("{eventId}")]
    [ProducesResponseType(typeof(ResponseRegisterJson), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
    public IActionResult GetAll([FromRoute] Guid eventId)
    {
        var useCase = new GetAllAttendeesByEventIdUseCase();

        var response = useCase.Execute(eventId);
        
        return Ok(response);
    }
}