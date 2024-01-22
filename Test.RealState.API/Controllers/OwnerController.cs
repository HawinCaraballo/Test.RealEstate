// ***********************************************************************
// Assembly         : Test.RealState.API.Controllers
// Author           : Hawin Caraballo
// Created          : 21-01-2024
//
// Last Modified By : 
// Last Modified On : 
// ***********************************************************************
// <copyright file="OwnerController.cs">
//     Copyright (c) All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace Test.RealState.API.Controllers
{
    using MediatR;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Swashbuckle.AspNetCore.Annotations;
    using System.Net;
    using Test.RealEstate.Application.Behaviours;
    using Test.RealEstate.Application.Feature.Owner.Commands.CreateOwner;
    using Test.RealEstate.Application.Wrappers;

    [ApiController]
    [Route("api/[controller]")]
    public class OwnerController : ControllerBase
    {
        private readonly IMediator _mediator;
        public OwnerController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("Create")]
        [Authorize]
        [ProducesResponseType(typeof(Response<int>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(Response), (int)HttpStatusCode.InternalServerError)]
        [SwaggerOperation(Summary = "Method to create a owner", Description = "Create a owner and return the created values")]
        /// <summary>
        /// Creates a new Owner.
        /// </summary>
        /// <param name="command">The command to create a Owner.</param>
        public async Task<ActionResult<Response>> CreateOwner([FromBody] CreateOwnerCommand command)
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
