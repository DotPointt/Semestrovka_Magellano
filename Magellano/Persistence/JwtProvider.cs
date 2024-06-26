﻿using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Application.Interfaces.Auth;
using Domain;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using static System.Net.WebRequestMethods;


namespace Persistence
{
    public class JwtProvider : IJwtProvider
    {
        public readonly JwtOptions _options;
        public JwtProvider(IOptions<JwtOptions> options)
        {
            _options = options.Value;
        }

        public string GenerateToken(User user)
        {
            Claim[] claims = new Claim[]
            {
                new Claim("userId", user.Id.ToString()),
            new Claim("userName", user.Name),
                //new Claim("PhotoUrl", user.PhotoUrl ?? "https://avatars.mds.yandex.net/i?id=2e42503fe87768dd7ef28f749daffa7dff684a85-12866313-images-thumbs&n=13")
            };


            var signingCredentials = new SigningCredentials(
                new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_options.SecretKey)),
                SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                claims: claims,
                signingCredentials: signingCredentials,
                expires: DateTime.UtcNow.AddHours(_options.ExpiresHours));

            var tokenValue = new JwtSecurityTokenHandler().WriteToken(token);

            return tokenValue;
        }
    }
}
