
namespace Test.RealEstate.Application.Feature.Property.Queries.GetAllProperties
{
    using AutoMapper;
    using MediatR;
    using Microsoft.Extensions.Logging;
    using Newtonsoft.Json;
    using Test.RealEstate.Application.Behaviours;
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
                var propertyEntity = await _repository.GetPagedReponseAsync(request.PageNumber, request.PageSize);
                if (propertyEntity is null)
                {
                    _logger.LogInformation($"Property does not exists");
                    return response.CreateNotFoundResponse(0, "Property not exists");
                }

                _logger.LogInformation($"Get Object return services => ({JsonConvert.SerializeObject(propertyEntity)})");
                return response.SuccessResponse(_mapper.Map<PropertyDto>(propertyEntity), "Success");

            }
            catch (Exception ex)
            {
                _logger.LogError($"An error occurred while retrieving the Property => ({ex.Message})");
                return response.CreateInternalServerErrorResponse($"An error occurred while retrieving the Property.", ex.Message);
            }
        }
    }
}
