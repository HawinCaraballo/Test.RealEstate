namespace Test.RealState.API.Controllers
{
    using MediatR;
    using Microsoft.AspNetCore.Mvc;
    using System.Net;
    using Test.Backend.Application.Behaviours;
    using Test.RealEstate.Application.Behaviours;
    using Test.RealEstate.Application.Feature.Property.Commands.CreateProperty;
    using Test.RealEstate.Application.Wrappers;

    [ApiController]
    [Route("api/[controller]")]
    public class PropertyController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PropertyController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost(Name = "CreateProperty")]
        [ProducesResponseType(typeof(Response<int>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(Response<IEnumerable<ValidationErrorResponse>>), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(Response), (int)HttpStatusCode.InternalServerError)]
        public async Task<ActionResult<Response>> CreateProperty([FromBody] CreatePropertyCommand command)
        {
            var response = await _mediator.Send(command);
            return response.ResponseCode switch
            {
                (int)HttpStatusCode.OK => Ok(response),
                (int)HttpStatusCode.NoContent => NoContent(),
                (int)HttpStatusCode.BadRequest => BadRequest(response),
                (int)HttpStatusCode.InternalServerError => StatusCode((int)HttpStatusCode.InternalServerError, response),
                _ => throw new NotImplementedException()
            };

        }
    }
}
