using Acc.Cmd.Domain.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Primitives;
using Microsoft.IdentityModel.Tokens;
using Services.Common.Options;
using Services.Common.Security;
using Services.Common.Utilities;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Acc.Cmd.Infrastructure.Services
{
    public class TokenManager : ITokenManager 
    {
        private readonly JwtOptions _jwtOptions;
        private readonly IDistributedCache _cache;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public TokenManager(IOptionsSnapshot<JwtOptions> jwtOptionsSnapshot, IDistributedCache cache, IHttpContextAccessor httpContextAccessor)
        {
            _cache = cache;
            _httpContextAccessor = httpContextAccessor;
            _jwtOptions = jwtOptionsSnapshot.Value;
        }

        public TokenAccountResult GenerateTokens(Claim[] claims, DateTime now)
        {
            var shouldAddAudienceClaim = string.IsNullOrWhiteSpace(claims?.FirstOrDefault(x => x.Type == JwtRegisteredClaimNames.Aud)?.Value);
            var jwtToken = new JwtSecurityToken(
                _jwtOptions.Issuer,
                shouldAddAudienceClaim ? _jwtOptions.Audience : string.Empty,
                claims,
                expires: now.AddMinutes(_jwtOptions.AccessTokenExpiration),
                signingCredentials: new SigningCredentials(new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_jwtOptions.SecretKey)), SecurityAlgorithms.HmacSha256Signature));
            var accessToken = new JwtSecurityTokenHandler().WriteToken(jwtToken);
            var refreshToken = Helpers.RandomSecretKey(_jwtOptions.LengthOfRefreshToken);
            var expiresIn = (int)_jwtOptions.ValidForTimeSpan.TotalSeconds;
            TokenAccountResult tokenResult = new TokenAccountResult(accessToken, refreshToken, expiresIn);
            return tokenResult;
        }

        public TokenAccountResult RefreshToken(string refreshToken, string accessToken, DateTime now)
        {
            throw new NotImplementedException();
        }

        public (ClaimsPrincipal, JwtSecurityToken) DecodeJwtToken(string token)
        {
            if (string.IsNullOrEmpty(token))
            {
                throw new SecurityTokenException("Invalid Token");
            }
            var principal = new JwtSecurityTokenHandler()
                .ValidateToken(token,
                    new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateIssuerSigningKey = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,

                        ValidIssuer = _jwtOptions.Issuer,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_jwtOptions.SecretKey)),
                        ValidAudience = _jwtOptions.Audience,
                        ClockSkew = TimeSpan.FromMinutes(1)
                    },
                    out var validatedToken);
            return (principal, validatedToken as JwtSecurityToken);
        }

        public async Task<bool> IsCurrentActiveTokenAsync()
        {
            return await IsActiveAsync(GetCurrentAsync());
        }

        public async Task<bool> IsActiveAsync(string token)
        {
            return await _cache.GetStringAsync(Helpers.GenerateDeactivatedToken(token)) == null;
        }

        public async Task DeactivateCurrentAsync()
        {
            await DeactivateAsync(GetCurrentAsync());
        }

        public async Task DeactivateAsync(string token)
        {
            await _cache.SetStringAsync(Helpers.GenerateDeactivatedToken(token), " ", new DistributedCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.MinValue,
                AbsoluteExpiration = DateTimeOffset.MinValue,
                SlidingExpiration = TimeSpan.MinValue
            });
        }

        #region private functions

        private string GetCurrentAsync()
        {
            var authorizationHeader = _httpContextAccessor.HttpContext.Request.Headers["authorization"];
            return authorizationHeader == StringValues.Empty
                ? string.Empty
                : authorizationHeader.Single().Split(" ").Last();
        }

        #endregion private functions
    }
}
