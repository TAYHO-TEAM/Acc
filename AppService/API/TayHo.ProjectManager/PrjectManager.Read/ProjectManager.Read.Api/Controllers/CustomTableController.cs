using ProjectManager.Common;
using ProjectManager.Read.Api.Controllers.v1.BaseClasses;
using ProjectManager.Read.Api.ViewModels;
using ProjectManager.Read.Api.ViewModels.BaseClasses;
using ProjectManager.Read.Sql.DTOs.DTO;
using ProjectManager.Read.Sql.Interfaces;
using ProjectManager.Read.Sql.Parameters;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Common.DomainObjects;
using Services.Common.Paging;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace ProjectManager.Read.Api.Controllers.v1
{

    public class CustomTableController : APIControllerBase
    {
        private readonly IDOBaseRepository<CustomTableDTO> _dOBaseRepository;
        private readonly ICustomTableRepository<CustomTableDetailDTO> _customTableRepositor;
        private const string Detail = nameof(Detail);

        public CustomTableController(IMapper mapper, IHttpContextAccessor httpContextAccessor, IDOBaseRepository<CustomTableDTO> dOBaseRepository, ICustomTableRepository<CustomTableDetailDTO> customTableRepositor) : base(mapper,httpContextAccessor)
        {
            _dOBaseRepository = dOBaseRepository;
            _customTableRepositor = customTableRepositor;
        }

        /// <summary>
        /// Get List of CustomTable.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(MethodResult<PagingItems<CustomTableResponseViewModel>>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(VoidMethodResult), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetCustomTableAsync([FromQuery] BaseRequestViewModel request)
        {
            var methodResult = new MethodResult<PagingItems<CustomTableResponseViewModel>>();
            RequestBaseFilterParam requestFilter = _mapper.Map<RequestBaseFilterParam>(request);
            requestFilter.TableName = QuanLyDuAnConstants.CustomTable_TABLENAME;
            var queryResult = await _dOBaseRepository.GetWithPaggingAsync(requestFilter).ConfigureAwait(false);
            methodResult.Result = new PagingItems<CustomTableResponseViewModel>
            {
                PagingInfo = queryResult.PagingInfo,
                Items = _mapper.Map<IEnumerable<CustomTableResponseViewModel>>(queryResult.Items)
            };
            return Ok(methodResult);
        }
        /// <summary>
        /// Get List of CustomTableDetail.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpGet]
        [Route(Detail)]
        [ProducesResponseType(typeof(MethodResult<PagingItems<CustomTableResponseViewModel>>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(VoidMethodResult), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetCustomTableDetailAsync([FromQuery] BaseRequestViewModel request)
        {
            var methodResult = new MethodResult<PagingItems<CustomTableResponseViewModel>>();
            RequestHasAccountIdFilterParam requestFilter = _mapper.Map<RequestHasAccountIdFilterParam>(request);
            requestFilter.TableName = QuanLyDuAnConstants.CustomTable_TABLENAME;
            requestFilter.AccountId = _user;
            var queryResult = await _customTableRepositor.GetCustomTableDetailAsync(requestFilter).ConfigureAwait(false);
            methodResult.Result = new PagingItems<CustomTableResponseViewModel>
            {
                PagingInfo = queryResult.PagingInfo,
                Items = _mapper.Map<IEnumerable<CustomTableResponseViewModel>>(queryResult.Items)
            };
            return Ok(methodResult);
        }
    }
}

