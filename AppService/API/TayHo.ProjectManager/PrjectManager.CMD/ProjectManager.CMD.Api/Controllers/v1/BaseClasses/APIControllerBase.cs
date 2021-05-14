using MediatR;
using Microsoft.AspNetCore.Mvc;
using Services.Common;
using System;

namespace ProjectManager.CMD.Api.Controllers.v1.BaseClasses
{
    [ApiVersion("1")]
    [Route(Settings.CommandAPIDefaultRoute)]
    [ApiExplorerSettings(GroupName = "v1")]
    [ApiController]
    public class APIControllerBase : ControllerBase
    {
        protected readonly IMediator _mediator;

        public APIControllerBase(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }
    }
}
