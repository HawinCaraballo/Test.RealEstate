
using Test.RealEstate.Domain.Common;

namespace Test.RealEstate.Domain.Entities
{
    public class PropertyTrace : BaseEntity
    {
        public int IdPropertyTrace { get; set; }
        public DateTime DateSale { get; set; }
        public string Name { get; set; } = null!;
        public double Value { get; set; }
        public double Tax { get; set; }
        public int IdProperty { get; set; }
        public virtual Property IdPropertyNavigation { get; set; }

    }
}
