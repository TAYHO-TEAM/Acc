using ProjectManager.CMD.Api.Application.Commands;
using ProjectManager.CMD.Api.Controllers.v1.BaseClasses;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Services.Common.DomainObjects;
using System.Net;
using System.Threading.Tasks;

namespace ProjectManager.CMD.Api.Controllers.v1
{
    public class NS_DuChiController : APIControllerBase
    {
        public NS_DuChiController(IMediator mediator) : base(mediator)
        {
        }

        #region NS_DuChi

        /// <summary>
        /// Create a new NS_DuChi.
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(Services.Common.DomainObjects.MethodResult<CreateNS_DuChiCommandResponse>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(VoidMethodResult), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> CreateNS_DuChiAsync([FromBody] CreateNS_DuChiCommand command)
        {
            var result = await _mediator.Send(command).ConfigureAwait(false);
            return Ok(result);
        }

        /// <summary>
        /// Update a existing NS_DuChi.
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPut]
        [ProducesResponseType(typeof(MethodResult<UpdateNS_DuChiCommandResponse>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(VoidMethodResult), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> UpdateNS_DuChiAsync([FromBody] UpdateNS_DuChiCommand command)
        {
            var result = await _mediator.Send(command).ConfigureAwait(false);
            return Ok(result);
        }

        /// <summary>
        /// Delete a existing NS_DuChi.
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpDelete]
        [ProducesResponseType(typeof(MethodResult<DeleteNS_DuChiCommandResponse>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(VoidMethodResult), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> DeleteNS_DuChiAsync([FromBody]DeleteNS_DuChiCommand command)
        {
            var result = await _mediator.Send(command).ConfigureAwait(false);
            return Ok(result);
        } 
        #endregion NS_DuChi
    }
}
