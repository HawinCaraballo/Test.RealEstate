using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.RealEstate.Domain.Entities;

namespace Test.RealEstate.Application.Feature.Property.Dtos
{
    public class PropertyDto
    {
        public string Name { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public double Price { get; set; } 
        public int CodeInternal { get; set; }
        public int Year { get; set; }
    }
}
