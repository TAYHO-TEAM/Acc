using ProjectManager.CMD.Api.Application.Commands;
using ProjectManager.CMD.Api.Controllers.v1.BaseClasses;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Services.Common.DomainObjects;
using System.Net;
using System.Threading.Tasks;

namespace ProjectManager.CMD.Api.Controllers.v1
{
    public class PlanMasterController : APIControllerBase
    {
        const string FormPlanMaster = nameof(FormPlanMaster);
        const string FormProgressPlanMaster = nameof(FormProgressPlanMaster);
        public PlanMasterController(IMediator mediator) : base(mediator)
        {
        }


        #region PlanMaster

        /// <summary>
        /// Create a new PlanMaster.
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(MethodResult<CreatePlanMasterCommandResponse>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(VoidMethodResult), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> CreatePlanMasterAsync([FromBody] CreatePlanMasterCommand command)
        {
            var result = await _mediator.Send(command).ConfigureAwait(false);
            return Ok(result);
        }

        /// <summary>
        /// Create a new PlanMaster by  Form.
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost]
        [Route(FormPlanMaster)]
        [ProducesResponseType(typeof(MethodResult<CreateFormPlanMasterCommandResponse>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(VoidMethodResult), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> CreateFormPlanMasterAsync([FromForm] CreateFormPlanMasterCommand command)
        {
            var files = Request.Form.Files;
            if (files != null)
            {
                command.setFile(files);
            }
            var result = await _mediator.Send(command).ConfigureAwait(false);
            return Ok(result);
        }
        /// <summary>
        /// Create a new Progress PlanMaster by  Form.
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost]
        [Route(FormProgressPlanMaster)]
        [ProducesResponseType(typeof(MethodResult<CreateFormProgressPlanMasterCommand>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(VoidMethodResult), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> CreateFormProgressPlanMasterAsync([FromForm] CreateFormProgressPlanMasterCommand command)
        {
            var files = Request.Form.Files;
            if (files != null)
            {
                command.setFile(files);
            }
            var result = await _mediator.Send(command).ConfigureAwait(false);
            return Ok(result);
        }
        /// <summary>
        /// Update a existing PlanMaster.
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPut]
        [ProducesResponseType(typeof(MethodResult<UpdatePlanMasterCommandResponse>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(VoidMethodResult), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> UpdatePlanMasterAsync([FromBody] UpdatePlanMasterCommand command)
        {
            var result = await _mediator.Send(command).ConfigureAwait(false);
            return Ok(result);
        }

        /// <summary>
        /// Delete a existing PlanMaster.
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpDelete]
        [ProducesResponseType(typeof(MethodResult<DeletePlanMasterCommandResponse>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(VoidMethodResult), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> DeletePlanMasterAsync([FromBody]DeletePlanMasterCommand command)
        {
            var result = await _mediator.Send(command).ConfigureAwait(false);
            return Ok(result);
        }

        #endregion PlanMaster
    }
}
