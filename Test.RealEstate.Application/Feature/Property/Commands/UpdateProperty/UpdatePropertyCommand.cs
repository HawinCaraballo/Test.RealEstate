using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.RealEstate.Application.Behaviours;

namespace Test.RealEstate.Application.Feature.Property.Commands.UpdateProperty
{
    public class UpdatePropertyCommand : IRequest<Response>
    {
        public int IdProperty { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public double Price { get; set; }
        public string CodeInternal { get; set; } = string.Empty;
        public int Year { get; set; }
        public int IdOwner { get; set; }

    }
}
