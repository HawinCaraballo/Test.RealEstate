
namespace Test.RealEstate.Application.Feature.Property.Commands.ChangePriceProperty
{
    using AutoMapper;
    using MediatR;
    using Microsoft.Extensions.Logging;
    using Newtonsoft.Json;
    using Test.RealEstate.Application.Behaviours;
    using Test.RealEstate.Application.Constant;
    using Test.RealEstate.Application.Constant.Feature.Property;
    using Test.RealEstate.Application.Feature.Property.Dtos;
    using Test.RealEstate.Application.Interfaces;
    public class ChangePricePropertyCommandHandler : IRequestHandler<ChangePricePropertyCommand, Response>
    {
        private readonly IPropertyRepository repository;
        private readonly IMapper mapper;
        private readonly ILogger<ChangePricePropertyCommandHandler> logger;

        public ChangePricePropertyCommandHandler(IPropertyRepository repository, IMapper mapper, 
                                        ILogger<ChangePricePropertyCommandHandler> logger)
        {
            this.repository = repository;
            this.mapper = mapper;
            this.logger = logger;
        }

        public async Task<Response> Handle(ChangePricePropertyCommand request, CancellationToken cancellationToken)
        {
            var response = new Response();
            try
            {
                var propertyEntity = await repository.GetByIdAsync(request.IdProperty);
                if (propertyEntity is null) {
                    logger.LogInformation(ConstantPropertyText.PropertyNoExists);
                    return response.BadRequest(request.IdProperty, ConstantPropertyText.PropertyNoExists);
                }
                propertyEntity.Price = request.Price;
                var updateEntity = await repository.UpdateAsync(propertyEntity);
                if (updateEntity is null)
                {
                    logger.LogInformation(ConstantPropertyText.ErrorUpdatePropertyPrice);
                    return response.BadRequest(request.IdProperty, ConstantPropertyText.ErrorUpdatePropertyPrice);
                }
                logger.LogInformation($"{ConstantConfirmText.SuccessObject} {JsonConvert.SerializeObject(updateEntity)}");
                return response.SuccessResponse(mapper.Map<PropertyDto>(updateEntity), ConstantConfirmText.Success);

            }
            catch (Exception ex)
            {
                logger.LogError($"{ConstantErrorText.ErrorException} Property => ({ex.Message})");
                return response.CreateInternalServerErrorResponse($"{ConstantErrorText.ErrorException} Property.", ex.Message);
            }
        }
    }
}
