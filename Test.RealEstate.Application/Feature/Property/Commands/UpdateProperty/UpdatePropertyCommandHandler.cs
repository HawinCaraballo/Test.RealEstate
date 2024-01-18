
namespace Test.RealEstate.Application.Feature.Property.Commands.UpdateProperty
{
    using AutoMapper;
    using FluentValidation;
    using MediatR;
    using Microsoft.Extensions.Logging;
    using Newtonsoft.Json;
    using Test.RealEstate.Application.Behaviours;
    using Test.RealEstate.Application.Feature.Property.Dtos;
    using Test.RealEstate.Application.Interfaces;
    public class UpdatePropertyCommandHandler : IRequestHandler<UpdatePropertyCommand, Response>
    {
        private readonly IPropertyRepository _repository;
        private readonly IMapper _mapper;
        private readonly IEnumerable<IValidator<UpdatePropertyCommand>> _validators;
        private readonly ILogger<UpdatePropertyCommandHandler> _logger;

        public UpdatePropertyCommandHandler(IPropertyRepository repository, IMapper mapper, IEnumerable<IValidator<UpdatePropertyCommand>> validators, ILogger<UpdatePropertyCommandHandler> logger)
        {
            _repository = repository;
            _mapper = mapper;
            _validators = validators;
            _logger = logger;
        }

        public async Task<Response> Handle(UpdatePropertyCommand request, CancellationToken cancellationToken)
        {
            var response = new Response();
            try
            {
                var validationResponse = response.ValidateCommand(request, _validators);
                if (validationResponse != null)
                {
                    _logger.LogInformation($"Error validation => ({JsonConvert.SerializeObject(request)})");
                    return validationResponse;
                }

                var propertyEntity = await _repository.GetByIdAsync(request.IdProperty);
                if (propertyEntity is null)
                {
                    _logger.LogInformation($"Product does not exist");
                    return response.CreateNotFoundResponse(0, "Product does not exist");
                }

                propertyEntity.Name = propertyEntity.Name;
                propertyEntity.Address = propertyEntity.Address;
                propertyEntity.CodeInternal = request.CodeInternal;
                propertyEntity.Price = request.Price;
                propertyEntity.Year = request.Year;
                propertyEntity.IdOwner = request.IdOwner;

                var resultEntity = await _repository.UpdateAsync(propertyEntity);
                if (resultEntity is null)
                {
                    _logger.LogInformation($"Property does not found");
                    return response.CreateNotFoundResponse(0, "Property does not found");
                }
                else
                {
                    _logger.LogInformation($"Get Object return services => ({JsonConvert.SerializeObject(propertyEntity)})");
                    return response.SuccessResponse(_mapper.Map<PropertyDto>(propertyEntity), "Success");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"An error occurred while retrieving the Property => ({ex.Message})");
                return response.CreateInternalServerErrorResponse($"An error occurred while retrieving the Property.", ex.Message);
            }
        }
    }
}
