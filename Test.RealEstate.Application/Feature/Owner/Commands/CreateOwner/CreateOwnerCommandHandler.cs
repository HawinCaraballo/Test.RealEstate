// ***********************************************************************
// Assembly         : Test.RealEstate.Application.Feature.Owner.Commands.CreateOwner
// Author           : Hawin Caraballo
// Created          : 15-01-2024
//
// Last Modified By : 
// Last Modified On : 
// ***********************************************************************
// <copyright file="CreateOwnerCommandHandler.cs">
//     Copyright (c) All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace Test.RealEstate.Application.Feature.Owner.Commands.CreateOwner
{
    using AutoMapper;
    using MediatR;
    using Microsoft.Extensions.Logging;
    using Test.RealEstate.Application.Behaviours;
    using Test.RealEstate.Application.Constant;
    using Test.RealEstate.Application.Interfaces;
    using Test.RealEstate.Domain.Entities;
    using Test.RealEstate.Application.Feature.Owner.Dtos;
    using Test.RealEstate.Application.Constant.Feature.Owner;
    using System.Text.Json;

    public class CreateOwnerCommandHandler : IRequestHandler<CreateOwnerCommand, Response>
    {
        private readonly IOwnerRepository _repository;
        private readonly IMapper _mapper;
        private readonly ILogger<CreateOwnerCommandHandler> _logger;

        public CreateOwnerCommandHandler(IOwnerRepository repository, IMapper mapper, 
                                        ILogger<CreateOwnerCommandHandler> logger)
        {
            _repository = repository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Response> Handle(CreateOwnerCommand request, CancellationToken cancellationToken)
        {
            var response = new Response();
            _logger.LogInformation(ConstantValidationText.SuccesValidation);
            var ownerEntity = await _repository.AddAsync(_mapper.Map<Owner>(request));
            if (ownerEntity != null)
            {
                _logger.LogInformation($"{ConstantConfirmText.SuccessObject} {JsonSerializer.Serialize(ownerEntity)}");
                return response.SuccessResponse(_mapper.Map<OwnerDto>(ownerEntity), ConstantConfirmText.Success);
            }
            _logger.LogInformation(ConstantOwnerText.ErrorCreateOwner);
            return response.BadRequest(0, ConstantOwnerText.ErrorCreateOwner);
        }
    }
}
