using ProjectManager.CMD.Api.Application.Commands;
using ProjectManager.CMD.Api.Controllers.v1.BaseClasses;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Services.Common.DomainObjects;
using System.Net;
using System.Threading.Tasks;

namespace ProjectManager.CMD.Api.Controllers.v1
{
    public class NS_ThucChiController : APIControllerBase
    {
        public NS_ThucChiController(IMediator mediator) : base(mediator)
        {
        }

        #region NS_ThucChi

        /// <summary>
        /// Create a new NS_ThucChi.
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(Services.Common.DomainObjects.MethodResult<CreateNS_ThucChiCommandResponse>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(VoidMethodResult), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> CreateNS_ThucChiAsync([FromBody] CreateNS_ThucChiCommand command)
        {
            var result = await _mediator.Send(command).ConfigureAwait(false);
            return Ok(result);
        }

        /// <summary>
        /// Update a existing NS_ThucChi.
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPut]
        [ProducesResponseType(typeof(MethodResult<UpdateNS_ThucChiCommandResponse>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(VoidMethodResult), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> UpdateNS_ThucChiAsync([FromBody] UpdateNS_ThucChiCommand command)
        {
            var result = await _mediator.Send(command).ConfigureAwait(false);
            return Ok(result);
        }

        /// <summary>
        /// Delete a existing NS_ThucChi.
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpDelete]
        [ProducesResponseType(typeof(MethodResult<DeleteNS_ThucChiCommandResponse>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(VoidMethodResult), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> DeleteNS_ThucChiAsync([FromBody]DeleteNS_ThucChiCommand command)
        {
            var result = await _mediator.Send(command).ConfigureAwait(false);
            return Ok(result);
        } 
        #endregion NS_ThucChi
    }
}
