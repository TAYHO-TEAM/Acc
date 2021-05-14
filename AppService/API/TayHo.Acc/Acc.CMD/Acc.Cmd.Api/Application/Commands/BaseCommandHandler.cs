using Microsoft.AspNetCore.Http;
using Services.Common.Security;

namespace Acc.Cmd.Api.Application.Commands
{

    public class BaseCommandHandler
    {
        public int _user { get; }
        private IHttpContextAccessor _httpContextAccessor ;
        public BaseCommandHandler(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            try
            {
                _user = (int)_httpContextAccessor.HttpContext.Items[ClaimsTypeName.ACCOUNT_ID];
            }
            catch
            {
                _user = 0;
            }
        }
    }

}
