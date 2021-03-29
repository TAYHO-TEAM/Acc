using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using ProjectManager.CMD.Api.Application.Commands;
using ProjectManager.CMD.Api.Controllers.v1.BaseClasses;
using Services.Common.DomainObjects;
using System.Net;
using System.Threading.Tasks;

namespace ProjectManager.CMD.Api.Controllers.v1
{
    [Authorize]
    [EnableCors("EnableCORS")]
    public class DocumentReleasedAccountController : APIControllerBase
    {
        public DocumentReleasedAccountController(IMediator mediator) : base(mediator)
        {
        }


        #region DocumentReleasedAccount

        /// <summary>
        /// Create a new DocumentReleasedAccount.
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        //[Authorize]
        [HttpPost]
        [ProducesResponseType(typeof(Services.Common.DomainObjects.MethodResult<CreateDocumentReleasedAccountCommandResponse>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(VoidMethodResult), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> CreateDocumentReleasedAccountAsync([FromBody] CreateDocumentReleasedAccountCommand command)
        {
            var result = await _mediator.Send(command).ConfigureAwait(false);
            return Ok(result);
        }

        /// <summary>
        /// Update a existing DocumentReleasedAccount.
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPut]
        [ProducesResponseType(typeof(MethodResult<UpdateDocumentReleasedAccountCommandResponse>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(VoidMethodResult), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> UpdateDocumentReleasedAccountAsync([FromBody] UpdateDocumentReleasedAccountCommand command)
        {
            var result = await _mediator.Send(command).ConfigureAwait(false);
            return Ok(result);
        }

        /// <summary>
        /// Delete a existing DocumentReleasedAccount.
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpDelete]
        [ProducesResponseType(typeof(MethodResult<DeleteDocumentReleasedAccountCommandResponse>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(VoidMethodResult), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> DeleteDocumentReleasedAccountAsync([FromBody] DeleteDocumentReleasedAccountCommand command)
        {
            var result = await _mediator.Send(command).ConfigureAwait(false);
            return Ok(result);
        }

        #endregion DocumentReleasedAccount
    }
}
