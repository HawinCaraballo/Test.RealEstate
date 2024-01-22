// ***********************************************************************
// Assembly         : Test.RealEstate.Application.Interfaces.Identity
// Author           : Hawin Caraballo
// Created          : 21-01-2024
//
// Last Modified By : 
// Last Modified On : 
// ***********************************************************************
// <copyright file="IAccountService.cs">
//     Copyright (c) All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace Test.RealEstate.Application.Interfaces.Identity
{
    using Test.RealEstate.Application.Models.Account;
    public interface IAccountService
    {
        Task<AuthenticationResponse> Login(AuthenticationRequest request);
        Task<RegisterResponse> Register(RegisterRequest request);

    }
}
