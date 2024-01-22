// ***********************************************************************
// Assembly         : Test.RealEstate.Infraestructure.Identity.Services
// Author           : Hawin Caraballo
// Created          : 21-01-2024
//
// Last Modified By : 
// Last Modified On : 
// ***********************************************************************
// <copyright file="AccountService.cs">
//     Copyright (c) All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace Test.RealEstate.Infraestructure.Identity.Services
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.Extensions.Options;
    using Microsoft.IdentityModel.Tokens;
    using System.IdentityModel.Tokens.Jwt;
    using System.Security.Claims;
    using System.Text;
    using Test.RealEstate.Application.Constant;
    using Test.RealEstate.Application.Interfaces.Identity;
    using Test.RealEstate.Application.Models.Account;
    using Test.RealEstate.Domain.Settings;
    using Test.RealEstate.Infraestructure.Identity.Models;
    public class AccountService : IAccountService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly JwtSettings _jwtSettings;

        public AccountService(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IOptions<JwtSettings> jwtSettings)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _jwtSettings = jwtSettings.Value;
        }

        public async Task<AuthenticationResponse> Login(AuthenticationRequest request)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);
            if (user is null)
            {
                throw new Exception($"The User with email({request.Email}) does not exist.");
            }
            var result = await _signInManager.PasswordSignInAsync(user.UserName, user.PasswordHash, false, lockoutOnFailure: false);
            if(result is null)
            {
                throw new Exception($"The creadential incorrect.");
            }

            var token = await GeneratorToken(user);
            var authenticationResponse = new AuthenticationResponse()
            {
                Id = user.Id,
                UserName = user.UserName,
                Email = user.Email,
                Token = new JwtSecurityTokenHandler().WriteToken(token)
            };
            return authenticationResponse;
        }

        public async Task<RegisterResponse> Register(RegisterRequest request)
        {
            var existingUser = await _userManager.FindByNameAsync(request.Username);
            if (existingUser is null)
            {
                throw new Exception("The username is already used by another account.");
            }

            var existingEmail = await _userManager.FindByEmailAsync(request.Email);
            if (existingEmail is null)
            {
                throw new Exception("The email is already used by another account.");
            }

            var user = new ApplicationUser()
            {
                Email = request.Email,
                Name = request.Name,
                LastName = request.LastName,
                UserName = request.Username,
                EmailConfirmed = true
            };

            var result = await _userManager.CreateAsync(user, request.Password);
            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, "Operator");
                var token = await GeneratorToken(user);
                return new RegisterResponse()
                {
                    Email = user.Email,
                    Token = new JwtSecurityTokenHandler().WriteToken(token),
                    UserId = user.Id,
                    Username = user.UserName
                };
            }
            throw new Exception($"{result.Errors}");
        }

        private async Task<JwtSecurityToken> GeneratorToken(ApplicationUser user)
        {
            var userClaims = await _userManager.GetClaimsAsync(user);
            var roles = await _userManager.GetRolesAsync(user);

            var roleClaim = new List<Claim>();

            foreach (var role in roles)
            {
                roleClaim.Add(new Claim(ClaimTypes.Role, role));
            }

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(CustomClaimTypes.Uid, user.Id),
            }
            .Union(userClaims)
            .Union(roleClaim);

            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Key));
            var signningCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

            var jwtSecurityToken = new JwtSecurityToken(
                issuer: _jwtSettings.Issuer,
                audience: _jwtSettings.Audience,
                claims: claims,
                expires: DateTime.Now.AddMinutes(_jwtSettings.DurationInMinutes),
                signingCredentials: signningCredentials);

            return jwtSecurityToken;
        }
    }
}
