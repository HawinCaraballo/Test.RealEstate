namespace Test.RealEstate.Domain.Entities
{
    using Test.RealEstate.Domain.Common;
    public class Property : BaseEntity
    {
        public int IdProperty { get; set; }
        public string Name { get; set; } = null!;
        public string Address { get; set; } = null!;
        public double Price { get; set; }
        public string CodeInternal { get; set; } = string.Empty;
        public int? Year { get; set; }
        public int IdOwner { get; set; }
        public virtual Owner IdOwnerNavigation { get; set; } 
        public virtual ICollection<PropertyImage> PropertyImages { get; set; } = new List<PropertyImage>();
        public virtual ICollection<PropertyTrace> PropertyTraces { get; set; } = new List<PropertyTrace>();

    }
}
