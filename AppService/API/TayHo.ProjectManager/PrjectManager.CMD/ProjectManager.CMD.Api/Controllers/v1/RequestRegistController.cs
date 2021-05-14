using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProjectManager.CMD.Api.Application.Commands;
using ProjectManager.CMD.Api.Controllers.v1.BaseClasses;
using Services.Common.DomainObjects;
using System.Net;
using System.Threading.Tasks;

namespace ProjectManager.CMD.Api.Controllers.v1
{
    public class RequestRegistController : APIControllerBase
    {
        private int Action = 27;
        private const string RequestRegistFull = nameof(RequestRegistFull);
        public RequestRegistController(IMediator mediator) : base(mediator)
        {
        }


        #region RequestRegist

        /// <summary>
        /// Create a new RequestRegist.
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(Services.Common.DomainObjects.MethodResult<CreateRequestRegistCommandResponse>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(VoidMethodResult), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> CreateRequestRegistAsync([FromForm]CreateRequestRegistCommand command)
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
        /// Update a existing RequestRegist.
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPut]
        [ProducesResponseType(typeof(MethodResult<UpdateRequestRegistCommandResponse>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(VoidMethodResult), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> UpdateRequestRegistAsync([FromBody] UpdateRequestRegistCommand command)
        {
            var result = await _mediator.Send(command).ConfigureAwait(false);
            return Ok(result);
        }

        /// <summary>
        /// Delete a existing RequestRegist.
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpDelete]
        [ProducesResponseType(typeof(MethodResult<DeleteRequestRegistCommandResponse>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(VoidMethodResult), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> DeleteRequestRegistAsync([FromBody] DeleteRequestRegistCommand command)
        {
            var result = await _mediator.Send(command).ConfigureAwait(false);
            return Ok(result);
        }
        ///// <summary>
        ///// Create a new RequestRegistFull.
        ///// </summary>
        ///// <param name="command"></param>
        ///// <returns></returns>
        //[HttpPost]
        //[Route(RequestRegistFull)]
        //[ProducesResponseType(typeof(Services.Common.DomainObjects.MethodResult<CreateRequestRegistCommandResponse>), (int)HttpStatusCode.OK)]
        //[ProducesResponseType(typeof(VoidMethodResult), (int)HttpStatusCode.BadRequest)]
        //public async Task<IActionResult> CreateRequestRegistFullAsync([FromForm] CreateRequestRegistCommand command)
        //{
        //    var files = Request.Form.Files;
        //    if (files != null)
        //    {
        //        command.setFile(files);
        //    }
        //    var result = await _mediator.Send(command).ConfigureAwait(false);
        //    return Ok(result);
        //}

        #endregion RequestRegist
    }
}
