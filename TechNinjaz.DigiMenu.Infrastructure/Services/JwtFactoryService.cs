﻿using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Text.Unicode;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using TechNinjaz.DigiMenu.Core.Entities.Identity;
using TechNinjaz.DigiMenu.Core.Interfaces;

namespace TechNinjaz.DigiMenu.Infrastructure.Services
{
    public class JwtFactoryService : IJwtFactory
    {
        private readonly IConfiguration _config;
        private readonly SymmetricSecurityKey _key;

        public JwtFactoryService(IConfiguration config)
        {
            _config = config;
            _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Token:key"]));
        }

        string IJwtFactory.CreatedToken(AuthUser user)
        {
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(JwtRegisteredClaimNames.GivenName, user.DisplayName)
            };

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = new SigningCredentials(_key, SecurityAlgorithms.HmacSha512Signature),
                Issuer = _config["Token:Issuer"]
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}