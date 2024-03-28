using Microsoft.AspNetCore.Mvc;
using PassIn.Application.UseCases.Events.Register;
using PassIn.Application.UseCases.Events.RegisterAttendee;
using PassIn.Communication.Requests;
using PassIn.Communication.Responses;
using PassIn.Exceptions;

namespace PassIn.Api.Controllers;

[Route("api/[controller]")]
public class EventsController : ControllerBase
{
    [HttpPost]
    [ProducesResponseType(typeof(ResponseEventJson), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
    public IActionResult Register([FromBody] RequestEventJson request)
    {
       var useCase = new RegisterEventUseCase();

        var response = useCase.Execute(request);

        return Created(string.Empty, response);
    }

    [HttpPost]
    [Route("{id}")]
    [ProducesResponseType(typeof(ResponseEventJson), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
    public IActionResult GetById([FromBody] Guid id)
    {
        var useCase = new GetEventByIdUseCase();

        var response = useCase.Execute(id);

        return Ok(response); 
    }

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
}
