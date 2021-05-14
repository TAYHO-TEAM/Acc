using Acc.Common;
using Acc.Read.Api.Controllers.v1.BaseClasses;
using Acc.Read.Api.ViewModels;
using Acc.Read.Api.ViewModels.BaseClasses;
using Acc.Read.Sql.DTOs;
using Acc.Read.Sql.Interfaces;
using Acc.Read.Sql.Parameters;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Common.DomainObjects;
using Services.Common.Paging;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace Acc.Read.Api.Controllers.v1
{
    public class GroupAccountController : APIControllerBase
    {
        private readonly IDOBaseRepository<GroupAccountDTO> _dOBaseRepository;

        public GroupAccountController(IMapper mapper, IHttpContextAccessor httpContextAccessor, IDOBaseRepository<GroupAccountDTO> dOBaseRepository) : base(mapper,httpContextAccessor)
        {
            _dOBaseRepository = dOBaseRepository;
        }

        /// <summary>
        /// Get List of GroupAccount.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(MethodResult<PagingItems<GroupAccountResponseViewModel>>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(VoidMethodResult), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetGroupAccountAsync([FromQuery] BaseRequestViewModel request)
        {
            var methodResult = new MethodResult<PagingItems<GroupAccountResponseViewModel>>();
            RequestBaseFilterParam requestFilter = _mapper.Map<RequestBaseFilterParam>(request);
            requestFilter.TableName = QuanLyDuAnConstants.GroupAccount_TABLENAME;
            var queryResult = await _dOBaseRepository.GetWithPaggingAsync(requestFilter).ConfigureAwait(false);
            methodResult.Result = new PagingItems<GroupAccountResponseViewModel>
            {
                PagingInfo = queryResult.PagingInfo,
                Items = _mapper.Map<IEnumerable<GroupAccountResponseViewModel>>(queryResult.Items)
            };
            return Ok(methodResult);
        }
    }
}

