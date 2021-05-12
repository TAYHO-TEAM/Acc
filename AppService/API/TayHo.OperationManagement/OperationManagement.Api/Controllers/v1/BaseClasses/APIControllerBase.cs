using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectManager.CMD.Infrastructure;
using Services.Common;
using Services.Common.Security;
using System;


namespace OperationManagement.Api.Controllers.v1.BaseClasses
{
    [ApiVersion("1")]
    [Route(Settings.ReadAPIDefaultRoute)]
    [ApiExplorerSettings(GroupName = "v1")]
    [ApiController]
    public class APIControllerBase : ControllerBase
    {
        protected readonly IMapper _mapper;
        //protected readonly QuanLyDuAnContext _dbContext;
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
