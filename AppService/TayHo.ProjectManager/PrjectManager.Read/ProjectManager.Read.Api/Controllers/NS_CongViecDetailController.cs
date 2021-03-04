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
    public class NS_CongViecDetailController : APIControllerBase
    {
        private readonly IDOBaseRepository<NS_CongViecDetailDTO> _dOBaseRepository;
        private readonly INS_CongViecDetail_GoiThau_GiaiDoanRepository<NS_CongViecDetail_GoiThau_GiaiDoanDTO> _nS_CongViecDetail_GoiThau_GiaiDoanRepository;
        private const string Detail = nameof(Detail);

        public NS_CongViecDetailController(
            IMapper mapper, 
            IHttpContextAccessor httpContextAccessor, 
            IDOBaseRepository<NS_CongViecDetailDTO> dOBaseRepository,
            INS_CongViecDetail_GoiThau_GiaiDoanRepository<NS_CongViecDetail_GoiThau_GiaiDoanDTO> nS_CongViecDetail_GoiThau_GiaiDoanRepository
        ) : base(mapper,httpContextAccessor)
        {
            _dOBaseRepository = dOBaseRepository;
            _nS_CongViecDetail_GoiThau_GiaiDoanRepository = nS_CongViecDetail_GoiThau_GiaiDoanRepository;
        }

        /// <summary>
        /// Get List of NS_CongViecDetail.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(MethodResult<PagingItems<NS_CongViecDetailResponseViewModel>>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(VoidMethodResult), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetNS_CongViecDetailAsync([FromQuery]BaseRequestViewModel request)
        {
            var methodResult = new MethodResult<PagingItems<NS_CongViecDetailResponseViewModel>>();
            RequestBaseFilterParam requestFilter = _mapper.Map<RequestBaseFilterParam>(request);
            requestFilter.TableName = QuanLyDuAnConstants.NS_CongViecDetail_TABLENAME;
            var queryResult = await _dOBaseRepository.GetWithPaggingFKAsync(requestFilter).ConfigureAwait(false);
            methodResult.Result = new PagingItems<NS_CongViecDetailResponseViewModel>
            {
                PagingInfo = queryResult.PagingInfo,
                Items = _mapper.Map<IEnumerable<NS_CongViecDetailResponseViewModel>>(queryResult.Items)
            };
            return Ok(methodResult);
        }

        /// <summary>
        /// Get List of NS_CongViecDetail.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpGet]
        [Route(Detail)]
        [ProducesResponseType(typeof(MethodResult<PagingItems<NS_CongViecDetail_GoiThau_GiaiDoanResponseViewModel>>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(VoidMethodResult), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetNS_CongViecDetail_GoiThau_GiaiDoanAsync([FromQuery] BaseRequestViewModel request)
        {
            var methodResult = new MethodResult<PagingItems<NS_CongViecDetail_GoiThau_GiaiDoanResponseViewModel>>();
            RequestBaseFilterParam requestFilter = _mapper.Map<RequestBaseFilterParam>(request);
            requestFilter.TableName = QuanLyDuAnConstants.NS_CongViecDetail_GoiThau_GiaiDoan_TABLENAME;
            var queryResult = await _nS_CongViecDetail_GoiThau_GiaiDoanRepository.GetCongViecDetail_GoiThau_GiaiDoanAsync(requestFilter).ConfigureAwait(false);
            methodResult.Result = new PagingItems<NS_CongViecDetail_GoiThau_GiaiDoanResponseViewModel>
            {
                PagingInfo = queryResult.PagingInfo,
                Items = _mapper.Map<IEnumerable<NS_CongViecDetail_GoiThau_GiaiDoanResponseViewModel>>(queryResult.Items)
            };
            return Ok(methodResult);
        }
    }
}
