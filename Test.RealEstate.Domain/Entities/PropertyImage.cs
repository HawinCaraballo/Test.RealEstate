using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.RealEstate.Domain.Common;

namespace Test.RealEstate.Domain.Entities
{
    public class PropertyImage : BaseEntity
    {
        public int IdPropertyImage { get; set; }
        public int IdProperty { get; set; }
        public byte[] File { get; set; } = [];
        public bool Enabled { get; set; }
        public string FileName { get; set; } = string.Empty;
        public virtual Property IdPropertyNavigation { get; set; } = null!;
    }
}
