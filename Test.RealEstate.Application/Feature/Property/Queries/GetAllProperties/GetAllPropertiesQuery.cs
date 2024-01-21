// ***********************************************************************
// Assembly         : Test.RealEstate.Application.Feature.Property.Queries.GetAllProperties
// Author           : Hawin Caraballo
// Created          : 15-01-2024
//
// Last Modified By : 
// Last Modified On : 
// ***********************************************************************
// <copyright file="GetAllPropertiesQuery.cs">
//     Copyright (c) All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace Test.RealEstate.Application.Feature.Property.Queries.GetAllProperties
{
    using MediatR;
    using Test.RealEstate.Application.Behaviours;
    public class GetAllPropertiesQuery : IRequest<Response>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }

        public GetAllPropertiesQuery(int pageNumber, int pageSize)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
        }
    }
}
