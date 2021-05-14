using Acc.Cmd.Api.Application.Commands;
using Acc.Cmd.Api.Controllers.v1.BaseClasses;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Services.Common.DomainObjects;
using System.Net;
using System.Threading.Tasks;

namespace Acc.Cmd.Api.Controllers.v1
{
    public class GroupPermistionController : APIControllerBase
    {
        public GroupPermistionController(IMediator mediator) : base(mediator)
        {
        }


        #region GroupPermistion

        /// <summary>
        /// Create a new GroupPermistion.
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(Services.Common.DomainObjects.MethodResult<CreateGroupPermistionCommandResponse>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(VoidMethodResult), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> CreateGroupPermistionAsync([FromBody] CreateGroupPermistionCommand command)
        {
            var result = await _mediator.Send(command).ConfigureAwait(false);
            return Ok(result);
        }

        /// <summary>
        /// Update a existing GroupPermistion.
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPut]
        [ProducesResponseType(typeof(MethodResult<UpdateGroupPermistionCommandResponse>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(VoidMethodResult), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> UpdateGroupPermistionAsync([FromBody] UpdateGroupPermistionCommand command)
        {
            var result = await _mediator.Send(command).ConfigureAwait(false);
            return Ok(result);
        }

        /// <summary>
        /// Delete a existing GroupPermistion.
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpDelete]
        [ProducesResponseType(typeof(MethodResult<DeleteGroupPermistionCommandResponse>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(VoidMethodResult), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> DeleteGroupPermistionAsync([FromBody]DeleteGroupPermistionCommand command)
        {
            var result = await _mediator.Send(command).ConfigureAwait(false);
            return Ok(result);
        }

        #endregion GroupPermistion
    }
}
