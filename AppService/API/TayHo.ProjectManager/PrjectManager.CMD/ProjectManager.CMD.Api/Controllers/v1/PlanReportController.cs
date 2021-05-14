using ProjectManager.CMD.Api.Application.Commands;
using ProjectManager.CMD.Api.Controllers.v1.BaseClasses;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Services.Common.DomainObjects;
using System.Net;
using System.Threading.Tasks;

namespace ProjectManager.CMD.Api.Controllers.v1
{
    public class PlanReportController : APIControllerBase
    {
        public PlanReportController(IMediator mediator) : base(mediator)
        {
        }


        #region PlanReport

        /// <summary>
        /// Create a new PlanReport.
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(Services.Common.DomainObjects.MethodResult<CreatePlanReportCommandResponse>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(VoidMethodResult), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> CreatePlanReportAsync([FromBody] CreatePlanReportCommand command)
        {
            var result = await _mediator.Send(command).ConfigureAwait(false);
            return Ok(result);
        }

        /// <summary>
        /// Update a existing PlanReport.
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPut]
        [ProducesResponseType(typeof(MethodResult<UpdatePlanReportCommandResponse>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(VoidMethodResult), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> UpdatePlanReportAsync([FromBody] UpdatePlanReportCommand command)
        {
            var result = await _mediator.Send(command).ConfigureAwait(false);
            return Ok(result);
        }

        /// <summary>
        /// Delete a existing PlanReport.
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpDelete]
        [ProducesResponseType(typeof(MethodResult<DeletePlanReportCommandResponse>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(VoidMethodResult), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> DeletePlanReportAsync([FromBody]DeletePlanReportCommand command)
        {
            var result = await _mediator.Send(command).ConfigureAwait(false);
            return Ok(result);
        }

        #endregion PlanReport
    }
}
