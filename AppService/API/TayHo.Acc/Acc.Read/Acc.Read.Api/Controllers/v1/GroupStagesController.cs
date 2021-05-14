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

    public class GroupStagesController : APIControllerBase
    {
        private readonly IDOBaseRepository<GroupStagesDTO> _dOBaseRepository;

        public GroupStagesController(IMapper mapper, IHttpContextAccessor httpContextAccessor, IDOBaseRepository<GroupStagesDTO> dOBaseRepository) : base(mapper,httpContextAccessor)
        {
            _dOBaseRepository = dOBaseRepository;
        }

        /// <summary>
        /// Get List of GroupStages.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(MethodResult<PagingItems<GroupStagesResponseViewModel>>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(VoidMethodResult), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetGroupStagesAsync([FromQuery] BaseRequestViewModel request)
        {
            var methodResult = new MethodResult<PagingItems<GroupStagesResponseViewModel>>();
            RequestBaseFilterParam requestFilter = _mapper.Map<RequestBaseFilterParam>(request);
            requestFilter.TableName = QuanLyDuAnConstants.GroupStages_TABLENAME;
            var queryResult = await _dOBaseRepository.GetWithPaggingAsync(requestFilter).ConfigureAwait(false);
            methodResult.Result = new PagingItems<GroupStagesResponseViewModel>
            {
                PagingInfo = queryResult.PagingInfo,
                Items = _mapper.Map<IEnumerable<GroupStagesResponseViewModel>>(queryResult.Items)
            };
            return Ok(methodResult);
        }
    }
}

