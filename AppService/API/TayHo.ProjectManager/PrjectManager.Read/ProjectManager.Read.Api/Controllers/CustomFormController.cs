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

    public class CustomFormController : APIControllerBase
    {
        private readonly IDOBaseRepository<CustomFormDTO> _dOBaseRepository;
        private readonly ICustomFormRepository<CustomFormDetailDTO> _customFormRepository;
        private const string Detail = nameof(Detail); 
        private const string GetOwner = nameof(GetOwner);

        public CustomFormController(IMapper mapper, IHttpContextAccessor httpContextAccessor, IDOBaseRepository<CustomFormDTO> dOBaseRepository, ICustomFormRepository<CustomFormDetailDTO> customFormRepository) : base(mapper,httpContextAccessor)
        {
            _dOBaseRepository = dOBaseRepository;
            _customFormRepository = customFormRepository;
        }

        /// <summary>
        /// Get List of CustomForm.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(MethodResult<PagingItems<CustomFormResponseViewModel>>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(VoidMethodResult), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetCustomFormAsync([FromQuery] BaseRequestViewModel request)
        {
            var methodResult = new MethodResult<PagingItems<CustomFormResponseViewModel>>();
            RequestBaseFilterParam requestFilter = _mapper.Map<RequestBaseFilterParam>(request);
            requestFilter.TableName = QuanLyDuAnConstants.CustomForm_TABLENAME;
            var queryResult = await _dOBaseRepository.GetWithPaggingAsync(requestFilter).ConfigureAwait(false);
            methodResult.Result = new PagingItems<CustomFormResponseViewModel>
            {
                PagingInfo = queryResult.PagingInfo,
                Items = _mapper.Map<IEnumerable<CustomFormResponseViewModel>>(queryResult.Items)
            };
            return Ok(methodResult);
        }
        /// <summary>
        /// Get List of CustomFormOwner.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpGet]
        [Route(GetOwner)]
        [ProducesResponseType(typeof(MethodResult<PagingItems<CustomFormResponseViewModel>>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(VoidMethodResult), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetCustomFormOwnerAsync([FromQuery] BasePermitRequestViewModel request)
        {
            var methodResult = new MethodResult<PagingItems<CustomFormResponseViewModel>>();
            RequestHasAccountPermitFilterParam requestFilter = _mapper.Map<RequestHasAccountPermitFilterParam>(request);
            requestFilter.TableName = QuanLyDuAnConstants.CustomForm_TABLENAME;
            requestFilter.AccountId = _user;
            var queryResult = await _dOBaseRepository.GetWithPaggingAccountPermitAsync(requestFilter).ConfigureAwait(false);
            methodResult.Result = new PagingItems<CustomFormResponseViewModel>
            {
                PagingInfo = queryResult.PagingInfo,
                Items = _mapper.Map<IEnumerable<CustomFormResponseViewModel>>(queryResult.Items)
            };
            return Ok(methodResult);
        }
        /// <summary>
        /// Get List of CustomFormDetail.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpGet]
        [Route(Detail)]
        [ProducesResponseType(typeof(MethodResult<PagingItems<CustomFormDetailResponseViewModel>>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(VoidMethodResult), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetCustomFormDetailAsync([FromQuery] BaseRequestViewModel request)
        {
            var methodResult = new MethodResult<PagingItems<CustomFormDetailResponseViewModel>>();
            RequestHasAccountIdFilterParam requestFilter = _mapper.Map<RequestHasAccountIdFilterParam>(request);
            requestFilter.TableName = QuanLyDuAnConstants.CustomForm_TABLENAME;
            requestFilter.AccountId = _user;
            var queryResult = await _customFormRepository.GetCustomFormDetailAsync(requestFilter).ConfigureAwait(false);
            methodResult.Result = new PagingItems<CustomFormDetailResponseViewModel>
            {
                PagingInfo = queryResult.PagingInfo,
                Items = _mapper.Map<IEnumerable<CustomFormDetailResponseViewModel>>(queryResult.Items)
            };
            return Ok(methodResult);
        }
      
    }
}

