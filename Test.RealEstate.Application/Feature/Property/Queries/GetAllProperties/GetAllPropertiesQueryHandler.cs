
namespace Test.RealEstate.Application.Feature.Property.Queries.GetAllProperties
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
    public class GetAllPropertiesQueryHandler : IRequestHandler<GetAllPropertiesQuery, Response>
    {
        private readonly IPropertyRepository _repository;
        private readonly IMapper _mapper;
        private readonly ILogger<GetAllPropertiesQueryHandler> _logger;

        public GetAllPropertiesQueryHandler(IPropertyRepository repository, IMapper mapper, ILogger<GetAllPropertiesQueryHandler> logger)
        {
            _repository = repository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Response> Handle(GetAllPropertiesQuery request, CancellationToken cancellationToken)
        {
            var response = new Response();
            try
            {
                var listPropertyEntity = await _repository.GetPagedReponseAsync(request.PageNumber, request.PageSize);
                if (listPropertyEntity is null)
                {
                    _logger.LogInformation(ConstantPropertyText.PropertyNoExists);
                    return response.BadRequest(0, ConstantPropertyText.PropertyNoExists);
                }

                _logger.LogInformation($"{ConstantConfirmText.SuccesReturnObject} {JsonConvert.SerializeObject(listPropertyEntity)}");
                return response.SuccessResponse(_mapper.Map<List<PropertyDto>>(listPropertyEntity), ConstantConfirmText.Success);

            }
            catch (Exception ex)
            {
                _logger.LogError($"{ConstantErrorText.ErrorException} Property => ({ex.Message})");
                return response.CreateInternalServerErrorResponse($"{ConstantErrorText.ErrorException} Property.", ex.Message);
            }
        }
    }
}
