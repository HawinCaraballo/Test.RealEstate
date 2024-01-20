namespace Test.RealState.API.Controllers
{
    using MediatR;
    using Microsoft.AspNetCore.Mvc;
    using Swashbuckle.AspNetCore.Annotations;
    using System.Net;
    using Test.RealEstate.Application.Behaviours;
    using Test.RealEstate.Application.Feature.Property.Commands.ChangePriceProperty;
    using Test.RealEstate.Application.Feature.Property.Commands.CreateProperty;
    using Test.RealEstate.Application.Feature.Property.Commands.UpdateProperty;
    using Test.RealEstate.Application.Feature.Property.Dtos;
    using Test.RealEstate.Application.Feature.Property.Queries.GetAllProperties;
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

        [HttpPost("Create")]
        [ProducesResponseType(typeof(Response<int>), (int)HttpStatusCode.OK)]
        //[ProducesResponseType(typeof(Response<IEnumerable<ValidationErrorResponse>>), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(Response), (int)HttpStatusCode.InternalServerError)]
        [SwaggerOperation(Summary = "Method to create a property", Description = "Create a property and return the created values")]
        /// <summary>
        /// Create a new property.
        /// </summary>
        /// <param name="command">The command to create a property.</param>
        public async Task<ActionResult<Response>> CreateProperty([FromBody] CreatePropertyCommand command)
        {
            var response = await _mediator.Send(command);
            return response.ResponseCode switch
            {
                (int)HttpStatusCode.OK => Ok(response),
                (int)HttpStatusCode.BadRequest => BadRequest(response),
                (int)HttpStatusCode.InternalServerError => StatusCode((int)HttpStatusCode.InternalServerError, response),
                _ => throw new NotImplementedException()
            };

        }

        [HttpPut("Update")]
        [ProducesResponseType(typeof(Response<PropertyDto>), (int)HttpStatusCode.OK)]
        //[ProducesResponseType(typeof(Response<IEnumerable<ValidationErrorResponse>>), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(Response), (int)HttpStatusCode.InternalServerError)]
        [SwaggerOperation(Summary = "Method to update an existing property", Description = "update an existing property and return the update values")]
        /// <summary>
        /// Update an existing property.
        /// </summary>
        /// <param name="command">The command to update a property exists.</param>
        public async Task<ActionResult<Response>> UpdateProperty([FromBody] UpdatePropertyCommand command)
        {
            var response = await _mediator.Send(command);
            return response.ResponseCode switch
            {
                (int)HttpStatusCode.OK => Ok(response),
                (int)HttpStatusCode.BadRequest => BadRequest(response),
                (int)HttpStatusCode.InternalServerError => StatusCode((int)HttpStatusCode.InternalServerError, response),
                _ => throw new NotImplementedException()
            };

        }

        [HttpPut("ChangePrice")]
        [ProducesResponseType(typeof(Response<PropertyDto>), (int)HttpStatusCode.OK)]
        //[ProducesResponseType(typeof(Response<IEnumerable<ValidationErrorResponse>>), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(Response), (int)HttpStatusCode.InternalServerError)]
        [SwaggerOperation(Summary = "Method to update price of an existing property", Description = "update price of an existing property and return the update values")]
        /// <summary>
        /// Update price of an existing property.
        /// </summary>
        /// <param name="command">The command to update price of an existing property.</param>
        public async Task<ActionResult<Response>> ChangePriceProperty([FromBody] ChangePricePropertyCommand command)
        {
            var response = await _mediator.Send(command);
            return response.ResponseCode switch
            {
                (int)HttpStatusCode.OK => Ok(response),
                (int)HttpStatusCode.BadRequest => BadRequest(response),
                (int)HttpStatusCode.InternalServerError => StatusCode((int)HttpStatusCode.InternalServerError, response),
                _ => throw new NotImplementedException()
            };

        }


        [HttpGet("List")]
        [ProducesResponseType(typeof(Response<List<PropertyDto>>), (int)HttpStatusCode.OK)]
        //[ProducesResponseType(typeof(Response<IEnumerable<ValidationErrorResponse>>), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(Response), (int)HttpStatusCode.InternalServerError)]
        [SwaggerOperation(Summary = "Get a list of all properties", Description = "Retrieve a list of all properties.")]
        /// <summary>
        /// Get a list of all properties.
        /// </summary>
        /// <param name="command">The command for filter data.</param>
        public async Task<ActionResult<Response>> GetProperties([FromQuery] GetAllPropertiesParameter filter)
        {
            var response = await _mediator.Send(new GetAllPropertiesQuery(filter.PageNumber, filter.PageSize)); ;
            return response.ResponseCode switch
            {
                (int)HttpStatusCode.OK => Ok(response),
                (int)HttpStatusCode.BadRequest => BadRequest(response),
                (int)HttpStatusCode.InternalServerError => StatusCode((int)HttpStatusCode.InternalServerError, response),
                _ => throw new NotImplementedException()
            };

        }
    }
}
