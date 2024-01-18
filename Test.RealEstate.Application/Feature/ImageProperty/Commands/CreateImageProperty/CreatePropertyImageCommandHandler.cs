namespace Test.RealEstate.Application.Feature.ImageProperty.Commands.CreateImageProperty
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
    using Test.RealEstate.Application.Constant.Feature.PropertyImage;
    using Test.RealEstate.Application.Feature.Property.Dtos;
    using Test.RealEstate.Application.Interfaces;
    using Test.RealEstate.Domain.Entities;

    public class CreatePropertyImageCommandHandler : IRequestHandler<CreatePropertyImageCommand, Response>
    {
        private readonly IMapper _mapper;
        private readonly IPropertyImageRepository _repository;
        private readonly ILogger<CreatePropertyImageCommandHandler> _logger;
        private readonly IEnumerable<IValidator<CreatePropertyImageCommand>> _validators;

        public CreatePropertyImageCommandHandler(IMapper mapper, IPropertyImageRepository repository, 
                                                ILogger<CreatePropertyImageCommandHandler> logger, 
                                                IEnumerable<IValidator<CreatePropertyImageCommand>> validators)
        {
            _mapper = mapper;
            _repository = repository;
            _logger = logger;
            _validators = validators;
        }

        public async Task<Response> Handle(CreatePropertyImageCommand request, CancellationToken cancellationToken)
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
                var propertyImageEntity = await _repository.AddAsync(_mapper.Map<PropertyImage>(request));
                if (propertyImageEntity is null)
                {
                    _logger.LogInformation(ConstantPropertyImageText.ErrorCreatePropertyImage);
                    return response.CreateNotFoundResponse(request.IdProperty, ConstantPropertyImageText.ErrorCreatePropertyImage);
                }
                _logger.LogInformation($"{ConstantConfirmText.SuccessObject} {JsonConvert.SerializeObject(propertyImageEntity)}");
                return response.SuccessResponse(_mapper.Map<PropertyDto>(propertyImageEntity), ConstantConfirmText.Success);
            }
            catch (Exception ex)
            {
                _logger.LogError($"{ConstantErrorText.ErrorException} PropertyImage => ({ex.Message})");
                return response.CreateInternalServerErrorResponse($"{ConstantErrorText.ErrorException} PropertyImage.", ex.Message);
            }
        }
    }
}
