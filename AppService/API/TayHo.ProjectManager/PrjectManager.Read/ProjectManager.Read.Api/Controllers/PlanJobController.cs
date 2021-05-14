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
    public class PlanJobController : APIControllerBase
    {
        private readonly IDOBaseRepository<PlanJobDTO> _dOBaseRepository;
        private readonly IPlanJobRepository<PlanJobAccountPermitDTO> _planJobRepository;
        private const string GetWithAccount = nameof(GetWithAccount);
        public PlanJobController(IMapper mapper, IHttpContextAccessor httpContextAccessor, IDOBaseRepository<PlanJobDTO> dOBaseRepository, IPlanJobRepository<PlanJobAccountPermitDTO> PlanJobRepository) : base(mapper,httpContextAccessor)
        {
            _dOBaseRepository = dOBaseRepository;
            _planJobRepository = PlanJobRepository;
        }

        /// <summary>
        /// Get List of PlanJob.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(MethodResult<PagingItems<PlanJobResponseViewModel>>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(VoidMethodResult), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetPlanJobAsync([FromQuery]BaseRequestViewModel request)
        {
            var methodResult = new MethodResult<PagingItems<PlanJobResponseViewModel>>();
            RequestBaseFilterParam requestFilter = _mapper.Map<RequestBaseFilterParam>(request);
            requestFilter.TableName = QuanLyDuAnConstants.PlanJob_TABLENAME;
            var queryResult = await _dOBaseRepository.GetWithPaggingAsync(requestFilter).ConfigureAwait(false);
            methodResult.Result = new PagingItems<PlanJobResponseViewModel>
            {
                PagingInfo = queryResult.PagingInfo,
                Items = _mapper.Map<IEnumerable<PlanJobResponseViewModel>>(queryResult.Items)
            };
            return Ok(methodResult);
        }


        /// <summary>
        /// Get List of PlanJobAccount.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpGet]
        [Route(GetWithAccount)]
        [ProducesResponseType(typeof(MethodResult<PagingItems<PlanJobAccountPermitResponseViewModel>>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(VoidMethodResult), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetPlanJobAccountAsync([FromQuery] BasePermitRequestViewModel request)
        {
            var methodResult = new MethodResult<PagingItems<PlanJobAccountPermitResponseViewModel>>();
            RequestHasAccountPermitFilterParam requestFilter = _mapper.Map<RequestHasAccountPermitFilterParam>(request);
            requestFilter.TableName = QuanLyDuAnConstants.PlanJob_TABLENAME;
            requestFilter.AccountId = _user;
            var queryResult = await _planJobRepository.GetWithPaggingPermistionAsync(requestFilter).ConfigureAwait(false);
            methodResult.Result = new PagingItems<PlanJobAccountPermitResponseViewModel>
            {
                PagingInfo = queryResult.PagingInfo,
                Items = _mapper.Map<IEnumerable<PlanJobAccountPermitResponseViewModel>>(queryResult.Items)
            };
            return Ok(methodResult);
        }
    }
}
