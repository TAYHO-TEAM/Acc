using Acc.Common;
using Acc.Read.Api.Controllers.v1.BaseClasses;
using Acc.Read.Api.ViewModels;
using Acc.Read.Api.ViewModels.BaseClasses;
using Acc.Read.Sql.DTOs;
using Acc.Read.Sql.Interfaces;
using Acc.Read.Sql.Parameters;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Common.DomainObjects;
using Services.Common.Paging;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace Acc.Read.Api.Controllers.v1
{
   
    public class ActionsController : APIControllerBase
    {
        private readonly IDOBaseRepository<ActionsDTO> _dOBaseRepository;
        private readonly IActionsRepository<ActionsDTOCC> _actionsRepository;
        private const string getMenuOfUser = nameof(getMenuOfUser);

        public ActionsController(IMapper mapper, IHttpContextAccessor httpContextAccessor, IDOBaseRepository<ActionsDTO> dOBaseRepository, IActionsRepository<ActionsDTOCC> actionsRepository) : base(mapper,httpContextAccessor)
        {
            _dOBaseRepository = dOBaseRepository;
            _actionsRepository = actionsRepository;
        }

        /// <summary>
        /// Get List of Actions.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>

        [HttpGet]
        [ProducesResponseType(typeof(MethodResult<PagingItems<ActionsResponseViewModel>>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(VoidMethodResult), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetActionsAsync([FromQuery] BaseRequestViewModel request)
        {
            var methodResult = new MethodResult<PagingItems<ActionsResponseViewModel>>();
            RequestBaseFilterParam requestFilter = _mapper.Map<RequestBaseFilterParam>(request);
            requestFilter.TableName = QuanLyDuAnConstants.Actions_TABLENAME;
            var queryResult = await _dOBaseRepository.GetWithPaggingAsync(requestFilter).ConfigureAwait(false);
            methodResult.Result = new PagingItems<ActionsResponseViewModel>
            {
                PagingInfo = queryResult.PagingInfo,
                Items = _mapper.Map<IEnumerable<ActionsResponseViewModel>>(queryResult.Items)
            };
            return Ok(methodResult);
        }
        /// <summary>
        /// Get List of Actions of User.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>

        [HttpGet]
        [Route(getMenuOfUser)]
        [ProducesResponseType(typeof(MethodResult<PagingItems<ActionsResponseViewModel>>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(VoidMethodResult), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetActionsOfUserAsync([FromQuery] BaseRequestParentViewModel request)
        {
            var methodResult = new MethodResult<PagingItems<ActionsByPermistionResponseViewModel>>();
            RequestHasAccountIdFilterParam requestFilter = _mapper.Map<RequestHasAccountIdFilterParam>(request);
            requestFilter.TableName = QuanLyDuAnConstants.Actions_TABLENAME;
            requestFilter.AccountId = _user;
            var queryResult = await _actionsRepository.GetActionByUserAsync(requestFilter).ConfigureAwait(false);
            methodResult.Result = new PagingItems<ActionsByPermistionResponseViewModel>
            {
                PagingInfo = queryResult.PagingInfo,
                Items = _mapper.Map<IEnumerable<ActionsByPermistionResponseViewModel>>(queryResult.Items)
            };
            return Ok(methodResult);
        }
    }
}

