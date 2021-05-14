using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectManager.Common;
using ProjectManager.Read.Api.Controllers.v1.BaseClasses;
using ProjectManager.Read.Api.ViewModels.BaseClasses;
using ProjectManager.Read.Api.ViewModels;
using ProjectManager.Read.Sql.DTOs.DTO;
using ProjectManager.Read.Sql.Interfaces;
using ProjectManager.Read.Sql.Parameters;
using Services.Common.DomainObjects;
using Services.Common.Paging;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace ProjectManager.Read.Api.Controllers.v1
{
    public class NS_NhomCongViecController : APIControllerBase
    {
        private readonly IDOBaseRepository<NS_NhomCongViecDTO> _dOBaseRepository;
        private readonly INS_NhomCongViecRepository<NS_NhomCongViec_NhomCongViecDetailDTO> _nS_NhomCongViecRepository;
        private const string Detail = nameof(Detail); 
        private const string tableName = QuanLyDuAnConstants.NS_NhomCongViec_TABLENAME;

        public NS_NhomCongViecController(
            IMapper mapper, 
            IHttpContextAccessor httpContextAccessor, 
            IDOBaseRepository<NS_NhomCongViecDTO> dOBaseRepository,
            INS_NhomCongViecRepository<NS_NhomCongViec_NhomCongViecDetailDTO> nS_NhomCongViecRepository
        ) : base(mapper,httpContextAccessor)
        {
            _dOBaseRepository = dOBaseRepository;
            _nS_NhomCongViecRepository = nS_NhomCongViecRepository;
        }

        /// <summary>
        /// Get List of NS_NhomCongViec.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(MethodResult<PagingItems<NS_NhomCongViecResponseViewModel>>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(VoidMethodResult), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetNS_NhomCongViecAsync([FromQuery]BaseRequestViewModel request)
        {
            var methodResult = new MethodResult<PagingItems<NS_NhomCongViecResponseViewModel>>();
            RequestBaseFilterParam requestFilter = _mapper.Map<RequestBaseFilterParam>(request);
            requestFilter.TableName = tableName;
            var queryResult = await _dOBaseRepository.GetWithPaggingFKAsync(requestFilter).ConfigureAwait(false);
            methodResult.Result = new PagingItems<NS_NhomCongViecResponseViewModel>
            {
                PagingInfo = queryResult.PagingInfo,
                Items = _mapper.Map<IEnumerable<NS_NhomCongViecResponseViewModel>>(queryResult.Items)
            };
            return Ok(methodResult);
        }

        /// <summary>
        /// Get List of NS_NhomCongViec.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpGet]
        [Route(Detail)]
        [ProducesResponseType(typeof(MethodResult<PagingItems<NS_NhomCongViec_NhomCongViecDetailResponseViewModel>>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(VoidMethodResult), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetNS_NhomCongViec_NhomCongViecDetailAsync([FromQuery] BaseTreeRequestViewModel request)
        {
            var methodResult = new MethodResult<PagingItems<NS_NhomCongViec_NhomCongViecDetailResponseViewModel>>();
            RequestTreeListBaseFilterParam requestFilter = _mapper.Map<RequestTreeListBaseFilterParam>(request);
            requestFilter.TableName = tableName;
            var queryResult = await _nS_NhomCongViecRepository.GetNhomCongViec_NhomCongViecDetailAsync(requestFilter).ConfigureAwait(false);
            methodResult.Result = new PagingItems<NS_NhomCongViec_NhomCongViecDetailResponseViewModel>
            {
                PagingInfo = queryResult.PagingInfo,
                Items = _mapper.Map<IEnumerable<NS_NhomCongViec_NhomCongViecDetailResponseViewModel>>(queryResult.Items)
            };
            return Ok(methodResult);
        }
    }
}
