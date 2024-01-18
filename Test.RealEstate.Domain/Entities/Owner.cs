namespace Test.RealEstate.Domain.Entities
{
    using System.ComponentModel.DataAnnotations;
    using Test.RealEstate.Domain.Common;
    public class Owner : BaseEntity
    {
        public int IdOwner { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string? Photo { get; set; }
        public DateOnly? Birthday { get; set; }
        public virtual ICollection<Property> Properties { get; set; } = new List<Property>();
    }
}
