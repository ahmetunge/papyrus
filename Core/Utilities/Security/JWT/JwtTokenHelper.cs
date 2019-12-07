using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using Core.Entities.Concrete;
using Core.Extensions;
using Core.Utilities.Security.Encryption;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Core.Utilities.Security.JWT
{
    public class JwtTokenHelper : ITokenHelper
    {
        public IConfiguration Configuration { get; }
        JwtTokenOptions _tokenOptions;

        public JwtTokenHelper(IConfiguration configuration)
        {
            Configuration = configuration;
            _tokenOptions = Configuration.GetSection("JwtTokenOptions").Get<JwtTokenOptions>();
        }
        public AccessToken CreateToken(User user, List<Role> roles)
        {
            var securityKey = SecurityKeyHelper.CreateSecurity(_tokenOptions.SecurityKey);

            var signingCredentials = SigningCredentialsHelper.CreateSigningCredentials(securityKey);

            var jwt = CreateSecurityToken(_tokenOptions, user, signingCredentials, roles);

            JwtSecurityTokenHandler jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            string token = jwtSecurityTokenHandler.WriteToken(jwt);

            AccessToken accessToken = new AccessToken
            {
                Token = token,
                Expiration = DateTime.Now.AddMinutes(_tokenOptions.AccessTokenExpiration)
            };

            return accessToken;

        }

        public JwtSecurityToken CreateSecurityToken(JwtTokenOptions tokenOptions,
        User user,
        SigningCredentials signingCredentials,
        List<Role> roles
        )
        {
            var jwt = new JwtSecurityToken(
                issuer: tokenOptions.Issuer,
                audience: tokenOptions.Audience,
                expires: DateTime.Now.AddMinutes(_tokenOptions.AccessTokenExpiration),
                notBefore: DateTime.Now,
                claims: SetClaims(user, roles),
                signingCredentials: signingCredentials
            );

            return jwt;
        }

        private IEnumerable<Claim> SetClaims(User user, List<Role> roles)
        {
            var claims = new List<Claim>();
            claims.AddEmail(user.Email);
            claims.AddName($"{user.Firstname} {user.Lastname}");
            claims.AddNameIdentifier(user.Id.ToString());
            claims.AddRoles(roles.Select(r => r.Name).ToList());

            return claims;
        }
    }
}