using Acc.Cmd.Domain.DomainObjects;
using Services.Common.Security;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Acc.Cmd.Domain.Services
{
    public interface  ITokenManager
    {
        TokenAccountResult GenerateTokens(Claim[] claims, DateTime now);
        TokenAccountResult RefreshToken(string refreshToken, string accessToken, DateTime now);
        (ClaimsPrincipal, JwtSecurityToken) DecodeJwtToken(string token);
        Task<bool> IsCurrentActiveTokenAsync();
        Task<bool> IsActiveAsync(string token);
        Task DeactivateCurrentAsync();
        Task DeactivateAsync(string token);
    }
}
