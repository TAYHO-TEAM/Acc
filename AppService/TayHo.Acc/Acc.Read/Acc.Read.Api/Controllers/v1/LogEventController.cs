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

    public class LogEventController : APIControllerBase
    {
        private readonly IDOBaseRepository<LogEventDTO> _dOBaseRepository;

        public LogEventController(IMapper mapper, IHttpContextAccessor httpContextAccessor, IDOBaseRepository<LogEventDTO> dOBaseRepository) : base(mapper,httpContextAccessor)
        {
            _dOBaseRepository = dOBaseRepository;
        }

        /// <summary>
        /// Get List of LogEvent.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(MethodResult<PagingItems<LogEventResponseViewModel>>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(VoidMethodResult), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetLogEventAsync([FromQuery] BaseRequestParentViewModel request)
        {
            var methodResult = new MethodResult<PagingItems<LogEventResponseViewModel>>();
            RequestParentBaseFilterParam requestFilter = _mapper.Map<RequestParentBaseFilterParam>(request);
            requestFilter.TableName = QuanLyDuAnConstants.LogEvent_TABLENAME;
            var queryResult = await _dOBaseRepository.GetWithPaggingFKAsync(requestFilter).ConfigureAwait(false);
            methodResult.Result = new PagingItems<LogEventResponseViewModel>
            {
                PagingInfo = queryResult.PagingInfo,
                Items = _mapper.Map<IEnumerable<LogEventResponseViewModel>>(queryResult.Items)
            };
            return Ok(methodResult);
        }
    }
}

