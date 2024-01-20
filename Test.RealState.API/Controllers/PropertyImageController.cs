namespace Test.RealState.API.Controllers
{
    using MediatR;
    using Microsoft.AspNetCore.Mvc;
    using Swashbuckle.AspNetCore.Annotations;
    using System.Net;
    using Test.RealEstate.Application.Behaviours;
    using Test.RealEstate.Application.Feature.ImageProperty.Commands.CreateImageProperty;
    using Test.RealEstate.Application.Wrappers;
    using Test.RealState.API.Model;

    [ApiController]
    [Route("api/[controller]")]
    public class PropertyImageController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PropertyImageController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("Create")]
        [ProducesResponseType(typeof(Response<int>), (int)HttpStatusCode.OK)]
        //[ProducesResponseType(typeof(Response<IEnumerable<ValidationErrorResponse>>), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(Response), (int)HttpStatusCode.InternalServerError)]
        [SwaggerOperation(Summary = "Method to create a PropertyImage", Description = "Create a PropertyImage and return the created values")]
        /// <summary>
        /// Creates a new PropertyImage.
        /// </summary>
        /// <param name="command">The command to create a PropertyImage.</param>
        public async Task<ActionResult<Response>> CreatePropertyImage([FromForm] UploadImage file)
        {
            CreatePropertyImageCommand propertyImageCommand = await GetPropertyImage(file);
            var response = await _mediator.Send(propertyImageCommand);
            return response.ResponseCode switch
            {
                (int)HttpStatusCode.OK => Ok(response),
                (int)HttpStatusCode.NoContent => NoContent(),
                (int)HttpStatusCode.BadRequest => BadRequest(response),
                (int)HttpStatusCode.InternalServerError => StatusCode((int)HttpStatusCode.InternalServerError, response),
                _ => throw new NotImplementedException()
            };

        }

        /// <summary>
        /// Get memorystream of UploadImage for CreatePropertyImage.File 
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        private static async Task<CreatePropertyImageCommand> GetPropertyImage(UploadImage file)
        {
            var propertyImageCommand = new CreatePropertyImageCommand
            {
                FileName = file.FileImage.FileName,
                IdProperty = file.IdProperty
            };

            using (var memoryStream = new MemoryStream())
            {
                await file.FileImage.CopyToAsync(memoryStream);
                propertyImageCommand.File = memoryStream.ToArray();
            }

            return propertyImageCommand;
        }

    }
}
