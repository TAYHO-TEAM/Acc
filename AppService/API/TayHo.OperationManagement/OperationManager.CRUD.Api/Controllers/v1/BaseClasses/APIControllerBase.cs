using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OperationManager.CRUD.DAL.DBContext;
using Services.Common;
using Services.Common.Security;
using System;

namespace OperationManager.CRUD.Api.Controllers.v1.BaseClasses
{
    [ApiVersion("1")]
    [Route(Settings.APIDefaultRoute)]
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
