using ProjectManager.CMD.Api.Application.Commands;
using ProjectManager.CMD.Api.Controllers.v1.BaseClasses;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Services.Common.DomainObjects;
using System.Net;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace ProjectManager.CMD.Api.Controllers.v1
{
    public class CustomCellContentController : APIControllerBase
    {
        public CustomCellContentController(IMediator mediator) : base(mediator)
        {
        }
        private const string ListCellContent = nameof(ListCellContent);
        private const string FromForm = nameof(FromForm);

        #region CustomCellContent

        /// <summary>
        /// Create a new CustomCellContent.
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(MethodResult<CreateCustomCellContentCommandResponse>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(VoidMethodResult), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> CreateCustomCellContentAsync([FromBody] CreateCustomCellContentCommand command)
        {
            var result = await _mediator.Send(command).ConfigureAwait(false);
            return Ok(result);
        }
        /// <summary>
        /// Create a new FormCustomCellContent.
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost]
        [Route(FromForm)]
        [ProducesResponseType(typeof(MethodResult<CreateFormCustomCellContentCommandResponse>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(VoidMethodResult), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> CreateFormCustomCellContentAsync([FromForm] CreateFormCustomCellContentCommand command)
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
        /// Create a new ListCustomCellContent.
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost]
        [Route(ListCellContent)]
        [ProducesResponseType(typeof(MethodResult<CreateCustomCellContentCommandResponses>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(VoidMethodResult), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> CreateListCustomCellContentAsync([FromForm] CreateCustomCellContentCommands command)
        {
            var result = await _mediator.Send(command).ConfigureAwait(false);
            return Ok(result);
        }

        /// <summary>
        /// Update a existing CustomCellContent.
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPut]
        [ProducesResponseType(typeof(MethodResult<UpdateCustomCellContentCommandResponse>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(VoidMethodResult), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> UpdateCustomCellContentAsync([FromBody] UpdateCustomCellContentCommand command)
        {
            var result = await _mediator.Send(command).ConfigureAwait(false);
            return Ok(result);
        }

        /// <summary>
        /// Delete a existing CustomCellContent.
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpDelete]
        [ProducesResponseType(typeof(MethodResult<DeleteCustomCellContentCommandResponse>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(VoidMethodResult), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> DeleteCustomCellContentAsync([FromBody]DeleteCustomCellContentCommand command)
        {
            var result = await _mediator.Send(command).ConfigureAwait(false);
            return Ok(result);
        }

        #endregion CustomCellContent
    }
}
