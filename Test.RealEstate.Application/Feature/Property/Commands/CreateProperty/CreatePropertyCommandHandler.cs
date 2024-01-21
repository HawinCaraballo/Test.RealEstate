// ***********************************************************************
// Assembly         : Test.RealEstate.Application.Feature.Property.Commands.CreateProperty
// Author           : Hawin Caraballo
// Created          : 15-01-2024
//
// Last Modified By : 
// Last Modified On : 
// ***********************************************************************
// <copyright file="CreatePropertyCommandHandler.cs">
//     Copyright (c) All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace Test.RealEstate.Application.Feature.Property.Commands.CreateProperty
{
    using AutoMapper;
    using MediatR;
    using Microsoft.Extensions.Logging;
    using System.Text.Json;
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
        private readonly ILogger<CreatePropertyCommandHandler> _logger;

        public CreatePropertyCommandHandler(IPropertyRepository propertyRepository, 
                                            IMapper mapper, 
                                            ILogger<CreatePropertyCommandHandler> logger)
        {
            _repository = propertyRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Response> Handle(CreatePropertyCommand request, CancellationToken cancellationToken)
        {
            var response = new Response();
            _logger.LogInformation(ConstantValidationText.SuccesValidation);
            var propertyEntity = _mapper.Map<Property>(request);
            var resultEntity = await _repository.AddAsync(propertyEntity);
            if (resultEntity != null)
            {
                _logger.LogInformation($"{ConstantConfirmText.SuccessObject} {JsonSerializer.Serialize(resultEntity)}");
                return response.SuccessResponse(_mapper.Map<PropertyDto>(resultEntity), ConstantConfirmText.Success);
            }
            _logger.LogInformation(ConstantPropertyText.ErrorCreateProperty);
            return response.BadRequest(0, ConstantPropertyText.ErrorCreateProperty);
        }
    }
}
