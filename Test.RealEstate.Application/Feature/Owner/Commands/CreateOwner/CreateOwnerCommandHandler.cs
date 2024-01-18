﻿
namespace Test.RealEstate.Application.Feature.Owner.Commands.CreateOwner
{
    using AutoMapper;
    using FluentValidation;
    using MediatR;
    using Microsoft.Extensions.Logging;
    using Newtonsoft.Json;
    using Test.RealEstate.Application.Behaviours;
    using Test.RealEstate.Application.Constant;
    using Test.RealEstate.Application.Interfaces;
    using Test.RealEstate.Domain.Entities;
    using Test.RealEstate.Application.Feature.Owner.Dtos;
    using Test.RealEstate.Application.Constant.Feature.Owner;

    public class CreateOwnerCommandHandler : IRequestHandler<CreateOwnerCommand, Response>
    {
        private readonly IOwnerRepository _repository;
        private readonly IMapper _mapper;
        private readonly IEnumerable<IValidator<CreateOwnerCommand>> _validators;
        private readonly ILogger<CreateOwnerCommandHandler> _logger;

        public CreateOwnerCommandHandler(IOwnerRepository repository, IMapper mapper, 
                                        IEnumerable<IValidator<CreateOwnerCommand>> validators, 
                                        ILogger<CreateOwnerCommandHandler> logger)
        {
            _repository = repository;
            _mapper = mapper;
            _validators = validators;
            _logger = logger;
        }

        public async Task<Response> Handle(CreateOwnerCommand request, CancellationToken cancellationToken)
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
                var ownerEntity = await _repository.AddAsync(_mapper.Map<Owner>(request));
                if (ownerEntity != null)
                {
                    _logger.LogInformation($"{ConstantConfirmText.SuccessObject} {JsonConvert.SerializeObject(ownerEntity)}");
                    return response.SuccessResponse(_mapper.Map<OwnerDto>(ownerEntity), ConstantConfirmText.Success);
                }
                _logger.LogInformation(ConstantOwnerText.ErrorCreateOwner);
                return response.CreateNotFoundResponse(0, ConstantOwnerText.ErrorCreateOwner);
            }
            catch (Exception ex)
            {
                _logger.LogError($"{ConstantErrorText.ErrorException} Owner => ({ex.Message})");
                return response.CreateInternalServerErrorResponse($"{ConstantErrorText.ErrorException} Owner.", ex.Message);
            }
        }
    }
}