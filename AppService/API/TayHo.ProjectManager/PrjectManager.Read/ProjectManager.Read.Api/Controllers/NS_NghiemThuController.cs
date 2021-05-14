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
    public class NS_NghiemThuController : APIControllerBase
    {
        private readonly IDOBaseRepository<NS_NghiemThuDTO> _dOBaseRepository;
        private readonly INS_NghiemThuRepository<NS_NghiemThuDetailDTO> _nS_NghiemThuRepository; 

        public NS_NghiemThuController(
            IMapper mapper, 
            IHttpContextAccessor httpContextAccessor, 
            IDOBaseRepository<NS_NghiemThuDTO> dOBaseRepository,
            INS_NghiemThuRepository<NS_NghiemThuDetailDTO> nS_NghiemThuRepository
        ) : base(mapper,httpContextAccessor)
        {
            _dOBaseRepository = dOBaseRepository;
            _nS_NghiemThuRepository = nS_NghiemThuRepository;
        }

        /// <summary>
        /// Get List of NS_NghiemThu.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpGet] 
        [ProducesResponseType(typeof(MethodResult<PagingItems<NS_NghiemThuDetailViewModel>>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(VoidMethodResult), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetNS_NghiemThuAsync([FromQuery]BaseRequestViewModel request)
        {
            var methodResult = new MethodResult<PagingItems<NS_NghiemThuDetailViewModel>>();
            RequestBaseFilterParam requestFilter = _mapper.Map<RequestBaseFilterParam>(request);
            requestFilter.TableName = QuanLyDuAnConstants.NS_NghiemThu_TABLENAME;
            var queryResult = await _nS_NghiemThuRepository.GetNS_NghiemThuDetailAsync(requestFilter).ConfigureAwait(false);
            methodResult.Result = new PagingItems<NS_NghiemThuDetailViewModel>
            {
                PagingInfo = queryResult.PagingInfo,
                Items = _mapper.Map<IEnumerable<NS_NghiemThuDetailViewModel>>(queryResult.Items)
            };
            return Ok(methodResult);
        } 
    }
}
