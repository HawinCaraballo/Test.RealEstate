using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.RealEstate.Application.Feature.ImageProperty.Dtos
{
    public class PropertyImageDto
    {
        public int IdPropertyImage { get; set; }
        public int IdProperty { get; set; }
        public byte[] File { get; set; } = new byte[0];
        public string FileName { get; set; } = string.Empty;
        public bool Enabled { get; set; }
    }
}
