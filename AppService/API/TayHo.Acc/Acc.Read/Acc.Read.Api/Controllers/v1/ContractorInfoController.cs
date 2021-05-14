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

    public class ContractorInfoController : APIControllerBase
    {
        private readonly IDOBaseRepository<ContractorInfoDTO> _dOBaseRepository;

        public ContractorInfoController(IMapper mapper, IHttpContextAccessor httpContextAccessor, IDOBaseRepository<ContractorInfoDTO> dOBaseRepository) : base(mapper,httpContextAccessor)
        {
            _dOBaseRepository = dOBaseRepository;
        }

        /// <summary>
        /// Get List of ContractorInfo.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(MethodResult<PagingItems<ContractorInfoResponseViewModel>>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(VoidMethodResult), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetContractorInfoAsync([FromQuery] BaseRequestViewModel request)
        {
            var methodResult = new MethodResult<PagingItems<ContractorInfoResponseViewModel>>();
            RequestBaseFilterParam requestFilter = _mapper.Map<RequestBaseFilterParam>(request);
            requestFilter.TableName = QuanLyDuAnConstants.ContractorInfo_TABLENAME;
            var queryResult = await _dOBaseRepository.GetWithPaggingAsync(requestFilter).ConfigureAwait(false);
            methodResult.Result = new PagingItems<ContractorInfoResponseViewModel>
            {
                PagingInfo = queryResult.PagingInfo,
                Items = _mapper.Map<IEnumerable<ContractorInfoResponseViewModel>>(queryResult.Items)
            };
            return Ok(methodResult);
        }
    }
}

