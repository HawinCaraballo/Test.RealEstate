// ***********************************************************************
// Assembly         : Test.RealEstate.Application.Feature.ImageProperty.Commands.CreateImageProperty
// Author           : Hawin Caraballo
// Created          : 15-01-2024
//
// Last Modified By : 
// Last Modified On : 
// ***********************************************************************
// <copyright file="CreatePropertyImageCommandHandler.cs">
//     Copyright (c) All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace Test.RealEstate.Application.Feature.ImageProperty.Commands.CreateImageProperty
{
    using AutoMapper;
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

        public CreatePropertyImageCommandHandler(IMapper mapper, IPropertyImageRepository repository, 
                                                ILogger<CreatePropertyImageCommandHandler> logger)
        {
            _mapper = mapper;
            _repository = repository;
            _logger = logger;
        }

        public async Task<Response> Handle(CreatePropertyImageCommand request, CancellationToken cancellationToken)
        {
            var response = new Response();
            var propertyImageEntity = await _repository.AddAsync(_mapper.Map<PropertyImage>(request));
            if (propertyImageEntity is null)
            {
                _logger.LogInformation(ConstantPropertyImageText.ErrorCreatePropertyImage);
                return response.BadRequest(request.IdProperty, ConstantPropertyImageText.ErrorCreatePropertyImage);
            }
            _logger.LogInformation($"{ConstantConfirmText.SuccessObject} {JsonConvert.SerializeObject(propertyImageEntity)}");
            return response.SuccessResponse(_mapper.Map<PropertyDto>(propertyImageEntity), ConstantConfirmText.Success);
        }
    }
}
