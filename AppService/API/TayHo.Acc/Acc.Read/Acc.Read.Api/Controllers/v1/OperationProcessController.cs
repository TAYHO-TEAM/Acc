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

    public class OperationProcessController : APIControllerBase
    {
        private readonly IDOBaseRepository<OperationProcessDTO> _dOBaseRepository;

        public OperationProcessController(IMapper mapper, IHttpContextAccessor httpContextAccessor, IDOBaseRepository<OperationProcessDTO> dOBaseRepository) : base(mapper,httpContextAccessor)
        {
            _dOBaseRepository = dOBaseRepository;
        }

        /// <summary>
        /// Get List of OperationProcess.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(MethodResult<PagingItems<OperationProcessResponseViewModel>>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(VoidMethodResult), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetOperationProcessAsync([FromQuery] BaseRequestViewModel request)
        {
            var methodResult = new MethodResult<PagingItems<OperationProcessResponseViewModel>>();
            RequestBaseFilterParam requestFilter = _mapper.Map<RequestBaseFilterParam>(request);
            requestFilter.TableName = QuanLyDuAnConstants.OperationProcess_TABLENAME;
            var queryResult = await _dOBaseRepository.GetWithPaggingAsync(requestFilter).ConfigureAwait(false);
            methodResult.Result = new PagingItems<OperationProcessResponseViewModel>
            {
                PagingInfo = queryResult.PagingInfo,
                Items = _mapper.Map<IEnumerable<OperationProcessResponseViewModel>>(queryResult.Items)
            };
            return Ok(methodResult);
        }
    }
}

