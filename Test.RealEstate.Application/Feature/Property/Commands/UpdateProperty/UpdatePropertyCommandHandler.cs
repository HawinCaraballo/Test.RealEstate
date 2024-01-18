﻿
namespace Test.RealEstate.Application.Feature.Property.Commands.UpdateProperty
{
    using AutoMapper;
    using FluentValidation;
    using MediatR;
    using Microsoft.Extensions.Logging;
    using Newtonsoft.Json;
    using Test.RealEstate.Application.Behaviours;
    using Test.RealEstate.Application.Constant;
    using Test.RealEstate.Application.Constant.Feature.Property;
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
                    _logger.LogInformation($"{ConstantValidationText.ErrorValidationFrom} ({JsonConvert.SerializeObject(request)})");
                    return validationResponse;
                }

                var propertyEntity = await _repository.GetByIdAsync(request.IdProperty);
                if (propertyEntity is null)
                {
                    _logger.LogInformation(ConstantPropertyText.PropertyNoExists);
                    return response.BadRequest(0, ConstantPropertyText.PropertyNoExists);
                }

                propertyEntity.Name = request.Name == string.Empty ? propertyEntity.Name : request.Name;
                propertyEntity.Address = request.Address == string.Empty ? propertyEntity.Address : request.Address; ;
                propertyEntity.CodeInternal = request.CodeInternal == string.Empty ? propertyEntity.CodeInternal : request.CodeInternal;
                propertyEntity.Price = request.Price == 0 ? propertyEntity.Price : request.Price; ;
                propertyEntity.Year = request.Year == 0 ? propertyEntity.Year : request.Year; 
                propertyEntity.IdOwner = request.IdOwner == 0 ? propertyEntity.IdOwner : request.IdOwner;

                var resultEntity = await _repository.UpdateAsync(propertyEntity);
                if (resultEntity is null)
                {
                    _logger.LogInformation(ConstantPropertyText.ErrorUpdateProperty);
                    return response.BadRequest(0, ConstantPropertyText.ErrorUpdateProperty);
                }
                else
                {
                    _logger.LogInformation($"{ConstantConfirmText.SuccesReturnObject} {JsonConvert.SerializeObject(resultEntity)}");
                    return response.SuccessResponse(_mapper.Map<PropertyDto>(resultEntity), ConstantConfirmText.Success);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"{ConstantErrorText.ErrorException} Property => ({ex.Message})");
                return response.CreateInternalServerErrorResponse($"{ConstantErrorText.ErrorException} Property.", ex.Message);
            }
        }
    }
}
