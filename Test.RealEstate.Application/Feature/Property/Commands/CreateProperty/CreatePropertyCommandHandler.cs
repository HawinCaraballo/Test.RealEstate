

namespace Test.RealEstate.Application.Feature.Property.Commands.CreateProperty
{
    using AutoMapper;
    using FluentValidation;
    using MediatR;
    using Microsoft.Extensions.Logging;
    using Newtonsoft.Json;
    using System.Threading;
    using System.Threading.Tasks;
    using Test.RealEstate.Application.Behaviours;
    using Test.RealEstate.Application.Constant;
    using Test.RealEstate.Application.Constant.Feature.Property;
    using Test.RealEstate.Application.Feature.Property.Dtos;
    using Test.RealEstate.Application.Interfaces;
    using Test.RealEstate.Domain.Entities;

    public class CreatePropertyCommandHandler : IRequestHandler<CreatePropertyCommand, Response>
    {
        private readonly IPropertyRepository _repository;
        private readonly IMapper _mapper;
        private readonly IEnumerable<IValidator<CreatePropertyCommand>> _validators;
        private readonly ILogger<CreatePropertyCommandHandler> _logger;

        public CreatePropertyCommandHandler(IPropertyRepository propertyRepository, IMapper mapper, IEnumerable<IValidator<CreatePropertyCommand>> validators, ILogger<CreatePropertyCommandHandler> logger)
        {
            _repository = propertyRepository;
            _mapper = mapper;
            _validators = validators;
            _logger = logger;
        }

        public async Task<Response> Handle(CreatePropertyCommand request, CancellationToken cancellationToken)
        {
            var response = new Response();
            try
            {
                var validationResponse = response.ValidateCommand(request, _validators);
                if (validationResponse != null)
                {
                    _logger.LogInformation($"{ConstantValidationText.ErrorValidationFrom} {JsonConvert.SerializeObject(request)}");
                    return validationResponse;
                }
                _logger.LogInformation(ConstantValidationText.SuccesValidation);
                var propertyEntity = _mapper.Map<Property>(request);
                var resultEntity = await _repository.AddAsync(propertyEntity);
                if (resultEntity != null)
                {
                    _logger.LogInformation($"{ConstantConfirmText.SuccessObject} {JsonConvert.SerializeObject(resultEntity)}");
                    return response.SuccessResponse(_mapper.Map<PropertyDto>(resultEntity), ConstantConfirmText.Success);
                }
                _logger.LogInformation(ConstantPropertyText.ErrorCreateProperty);
                return response.CreateNotFoundResponse(0, ConstantPropertyText.ErrorCreateProperty);
            }
            catch (Exception ex)
            {
                _logger.LogError($"{ConstantErrorText.ErrorException} Property => ({ex.Message})");
                return response.CreateInternalServerErrorResponse($"{ConstantErrorText.ErrorException} Property.", ex.Message);
            }
        }
    }
}
