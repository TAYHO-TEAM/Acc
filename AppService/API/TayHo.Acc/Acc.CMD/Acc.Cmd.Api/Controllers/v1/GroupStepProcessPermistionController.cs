using Acc.Cmd.Api.Application.Commands;
using Acc.Cmd.Api.Controllers.v1.BaseClasses;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Services.Common.DomainObjects;
using System.Net;
using System.Threading.Tasks;

namespace Acc.Cmd.Api.Controllers.v1
{
    public class GroupStepProcessPermistionController : APIControllerBase
    {
        public GroupStepProcessPermistionController(IMediator mediator) : base(mediator)
        {
        }


        #region GroupStepProcessPermistion

        /// <summary>
        /// Create a new GroupStepProcessPermistion.
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(Services.Common.DomainObjects.MethodResult<CreateGroupStepProcessPermistionCommandResponse>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(VoidMethodResult), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> CreateGroupStepProcessPermistionAsync([FromBody] CreateGroupStepProcessPermistionCommand command)
        {
            var result = await _mediator.Send(command).ConfigureAwait(false);
            return Ok(result);
        }

        /// <summary>
        /// Update a existing GroupStepProcessPermistion.
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPut]
        [ProducesResponseType(typeof(MethodResult<UpdateGroupStepProcessPermistionCommandResponse>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(VoidMethodResult), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> UpdateGroupStepProcessPermistionAsync([FromBody] UpdateGroupStepProcessPermistionCommand command)
        {
            var result = await _mediator.Send(command).ConfigureAwait(false);
            return Ok(result);
        }

        /// <summary>
        /// Delete a existing GroupStepProcessPermistion.
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpDelete]
        [ProducesResponseType(typeof(MethodResult<DeleteGroupStepProcessPermistionCommandResponse>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(VoidMethodResult), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> DeleteGroupStepProcessPermistionAsync([FromBody]DeleteGroupStepProcessPermistionCommand command)
        {
            var result = await _mediator.Send(command).ConfigureAwait(false);
            return Ok(result);
        }

        #endregion GroupStepProcessPermistion
    }
}
