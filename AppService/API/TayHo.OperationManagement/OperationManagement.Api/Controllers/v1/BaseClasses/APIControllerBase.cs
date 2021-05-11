using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProjectManager.CMD.Infrastructure;
using Services.Common;
using System;


namespace OperationManagement.Api.Controllers.v1.BaseClasses
{
    [ApiVersion("1")]
    [Route(Settings.CommandAPIDefaultRoute)]
    [ApiExplorerSettings(GroupName = "v1")]
    [ApiController]
    public class APIControllerBase : ControllerBase
    {
        protected readonly QuanLyDuAnContext _dbContext;

        public APIControllerBase()
        {

        }
    }
}
