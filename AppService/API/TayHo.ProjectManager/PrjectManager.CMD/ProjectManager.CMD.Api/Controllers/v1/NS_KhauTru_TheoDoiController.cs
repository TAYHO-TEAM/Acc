using ProjectManager.CMD.Api.Application.Commands;
using ProjectManager.CMD.Api.Controllers.v1.BaseClasses;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Services.Common.DomainObjects;
using System.Net;
using System.Threading.Tasks;

namespace ProjectManager.CMD.Api.Controllers.v1
{
    public class NS_KhauTru_TheoDoiController : APIControllerBase
    {
        public NS_KhauTru_TheoDoiController(IMediator mediator) : base(mediator)
        {
        }

        #region NS_KhauTru_TheoDoi

        /// <summary>
        /// Create a new NS_KhauTru_TheoDoi.
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(Services.Common.DomainObjects.MethodResult<CreateNS_KhauTru_TheoDoiCommandResponse>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(VoidMethodResult), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> CreateNS_KhauTru_TheoDoiAsync([FromBody] CreateNS_KhauTru_TheoDoiCommand command)
        {
            var result = await _mediator.Send(command).ConfigureAwait(false);
            return Ok(result);
        }

        /// <summary>
        /// Update a existing NS_KhauTru_TheoDoi.
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPut]
        [ProducesResponseType(typeof(MethodResult<UpdateNS_KhauTru_TheoDoiCommandResponse>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(VoidMethodResult), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> UpdateNS_KhauTru_TheoDoiAsync([FromBody] UpdateNS_KhauTru_TheoDoiCommand command)
        {
            var result = await _mediator.Send(command).ConfigureAwait(false);
            return Ok(result);
        }

        /// <summary>
        /// Delete a existing NS_KhauTru_TheoDoi.
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpDelete]
        [ProducesResponseType(typeof(MethodResult<DeleteNS_KhauTru_TheoDoiCommandResponse>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(VoidMethodResult), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> DeleteNS_KhauTru_TheoDoiAsync([FromBody]DeleteNS_KhauTru_TheoDoiCommand command)
        {
            var result = await _mediator.Send(command).ConfigureAwait(false);
            return Ok(result);
        } 
        #endregion NS_KhauTru_TheoDoi
    }
}
