using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Common;
using Services.Common.Security;
using System;


namespace Acc.Read.Api.Controllers.v1.BaseClasses
{

    [ApiVersion("1")]
    [Route(Settings.ReadAPIDefaultRoute)]
    [ApiExplorerSettings(GroupName = "v1")]
    [ApiController]
    public class APIControllerBase : ControllerBase
    {
        protected readonly IMapper _mapper;
        protected readonly IHttpContextAccessor _httpContextAccessor;
        protected int _user { get; }
        public APIControllerBase(IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _httpContextAccessor = httpContextAccessor ?? throw new ArgumentNullException(nameof(mapper));
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
