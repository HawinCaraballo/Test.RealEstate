namespace Test.RealState.API.Controllers
{
    using MediatR;
    using Microsoft.AspNetCore.Mvc;
    using System.Net;
    using Test.Backend.Application.Behaviours;
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

        [HttpPost(Name = "CreatePropertyImage")]
        [ProducesResponseType(typeof(Response<int>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(Response<IEnumerable<ValidationErrorResponse>>), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(Response), (int)HttpStatusCode.InternalServerError)]
        public async Task<ActionResult<Response>> CreatePropertyImage([FromForm] UploadImage file)
        {
            var imageCommand = new CreatePropertyImageCommand();
            imageCommand.FileName = file.FileImage.FileName;
            imageCommand.IdProperty = file.IdProperty;

            using (var memoryStream = new MemoryStream())
            {
                await file.FileImage.CopyToAsync(memoryStream);
                imageCommand.File = memoryStream.ToArray();
            }

            var response = await _mediator.Send(imageCommand);
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
