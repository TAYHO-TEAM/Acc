using Acc.Cmd.Api.Application.Commands;
using Acc.Cmd.Api.Controllers.v1.BaseClasses;
using Acc.Cmd.Api.ViewModels;
using Acc.Cmd.Domain.Repositories;
using Acc.Cmd.Domain.Services;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Common.DomainObjects;
using Services.Common.Security;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Acc.Cmd.Api.Controllers.V1
{
    public class AccountController : APIControllerBase
    {
        private const string Login = nameof(Login);
        private const string Logout = nameof(Logout);
        private const string RefreshToken = "Refresh-Token";
        private readonly IAccountService _accountService;

        #region login
        public AccountController(IMediator mediator, IAccountService accountService) : base(mediator)
        {
            _accountService = accountService;
        }
        ///// <summary>
        /////  Logging Account.
        ///// </summary>
        ///// <param name="command"></param>
        ///// <returns></returns>
        //[HttpGet]
        //[ProducesResponseType(typeof(MethodResult<TokenResult>), (int)HttpStatusCode.OK)]
        //[ProducesResponseType(typeof(VoidMethodResult), (int)HttpStatusCode.BadRequest)]
        //public async Task<IActionResult> LoginGet(LoginRequestViewModel command)
        //{
        //    var methodResult = new MethodResult<TokenResult>();
        //    methodResult.Result = await _accountService.LoginAsync(command.AccountName, command.Password).ConfigureAwait(false);
        //    return Ok(methodResult);
        //}
        /// <summary>
        ///  Logging Account.
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost]
        [Route(Login)]
        [ProducesResponseType(typeof(MethodResult<TokenAccountResult>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(VoidMethodResult), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> LoginAsync([FromBody] LoginRequestViewModel command)
        {
            var methodResult = new MethodResult<TokenAccountResult>();
            methodResult.Result = await _accountService.LoginAsync(command.UserName, command.Password,command.Device,command.DeviceToken,command.Browser).ConfigureAwait(false);
            return Ok(methodResult);
        }

        /// <summary>
        /// Logout Account.
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route(Logout)]
        [ProducesResponseType(typeof(VoidMethodResult), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> LogoutAsync()
        {
            var methodResult = new VoidMethodResult();
            await _accountService.LogoutAsync().ConfigureAwait(false);
            return Ok(methodResult);
        }

        /// <summary>
        /// Refreshing token.
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost]
        [Route(RefreshToken)]
        [ProducesResponseType(typeof(MethodResult<TokenAccountResult>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(VoidMethodResult), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> RefreshTokenAsync(RefreshTokenRequestViewModel command)
        {
            var a = User.Identity.Name;
            var methodResult = new MethodResult<TokenAccountResult>();
            methodResult.Result = await _accountService.RefreshTokenAsync(command.RefreshToken).ConfigureAwait(false);
            return Ok(methodResult);
        }
        #endregion login
        #region Account

        /// <summary>
        /// Create a new Account.
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(Services.Common.DomainObjects.MethodResult<CreateAccountsCommandResponse>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(VoidMethodResult), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> CreateAccountAsync([FromBody] CreateAccountsCommand command)
        {

            var result = await _mediator.Send(command).ConfigureAwait(false);
            return Ok(result);
        }

        /// <summary>
        /// Update a existing Account.
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPut]
        [ProducesResponseType(typeof(MethodResult<UpdateAccountsCommandResponse>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(VoidMethodResult), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> UpdateAccountAsync([FromBody] UpdateAccountsCommand command)
        {
            var result = await _mediator.Send(command).ConfigureAwait(false);
            return Ok(result);
        }

        /// <summary>
        /// Delete a existing Account.
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpDelete]
        [ProducesResponseType(typeof(MethodResult<DeleteAccountsCommandResponse>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(VoidMethodResult), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> DeleteAccountAsync([FromBody] DeleteAccountsCommand command)
        {
            var result = await _mediator.Send(command).ConfigureAwait(false);
            return Ok(result);
        }

        #endregion Account
    }
}
