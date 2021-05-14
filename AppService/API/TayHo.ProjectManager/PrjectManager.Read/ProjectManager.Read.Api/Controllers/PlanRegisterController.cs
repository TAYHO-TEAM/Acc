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
    public class PlanRegisterController : APIControllerBase
    {
        private readonly IDOBaseRepository<PlanRegisterDTO> _dOBaseRepository;
        private readonly IPlanRegisterRepository<PlanRegisterDTO> _planRegisterRepository;
        private const string GetByContractorID = nameof(GetByContractorID);

        public PlanRegisterController(IMapper mapper, IHttpContextAccessor httpContextAccessor, IDOBaseRepository<PlanRegisterDTO> dOBaseRepository, IPlanRegisterRepository<PlanRegisterDTO> planRegisterRepository) : base(mapper,httpContextAccessor)
        {
            _dOBaseRepository = dOBaseRepository;
            _planRegisterRepository = planRegisterRepository;
        }

        /// <summary>
        /// Get List of PlanRegister.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(MethodResult<PagingItems<RequestRegistResponseViewModel>>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(VoidMethodResult), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetPlanRegistAsync([FromQuery] BaseRequestViewModel request)
        {
            var methodResult = new MethodResult<PagingItems<PlanRegisterResponseViewModel>>();
            RequestBaseFilterParam requestFilter = _mapper.Map<RequestBaseFilterParam>(request);
            requestFilter.TableName = QuanLyDuAnConstants.PlanRegister_TABLENAME;
            //requestFilter.AccountId = _user;
            var queryResult = await _dOBaseRepository.GetWithPaggingAsync(requestFilter).ConfigureAwait(false);
            methodResult.Result = new PagingItems<PlanRegisterResponseViewModel>
            {
                PagingInfo = queryResult.PagingInfo,
                Items = _mapper.Map<IEnumerable<PlanRegisterResponseViewModel>>(queryResult.Items)
            };
            return Ok(methodResult);
        }
        /// <summary>
         /// Get List of PlanRegister by ContractorId.
         /// </summary>
         /// <param name="request"></param>
         /// <returns></returns>
        [HttpGet]
        [Route(GetByContractorID)]
        [ProducesResponseType(typeof(MethodResult<PagingItems<RequestRegistResponseViewModel>>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(VoidMethodResult), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetPlanRegistContractorIdAsync([FromQuery] BaseRequestViewModel request)
        {
            var methodResult = new MethodResult<PagingItems<PlanRegisterResponseViewModel>>();
            RequestHasAccountIdFilterParam requestFilter = _mapper.Map<RequestHasAccountIdFilterParam>(request);
            requestFilter.TableName = QuanLyDuAnConstants.PlanRegister_TABLENAME;
            requestFilter.AccountId = _user;
            var queryResult = await _planRegisterRepository.GetWithPaggingContractorInfoAsync(requestFilter).ConfigureAwait(false);
            methodResult.Result = new PagingItems<PlanRegisterResponseViewModel>
            {
                PagingInfo = queryResult.PagingInfo,
                Items = _mapper.Map<IEnumerable<PlanRegisterResponseViewModel>>(queryResult.Items)
            };
            return Ok(methodResult);
        }
    }
}
