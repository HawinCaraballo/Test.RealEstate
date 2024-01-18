
namespace Test.RealEstate.Application.Feature.Property.Queries.GetAllProperties
{
    public class GetAllPropertiesParameter
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public GetAllPropertiesParameter()
        {
            this.PageNumber = 1;
            this.PageSize = 10;
        }
        public GetAllPropertiesParameter(int pageNumber, int pageSize)
        {
            this.PageNumber = pageNumber < 1 ? 1 : pageNumber;
            this.PageSize = pageSize > 10 ? 10 : pageSize;
        }
    }
}
