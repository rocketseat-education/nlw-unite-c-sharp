using Microsoft.AspNetCore.Mvc;
using PassIn.Application.UseCases.Events.Register;
using PassIn.Communication.Requests;
using PassIn.Communication.Responses;

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
}
