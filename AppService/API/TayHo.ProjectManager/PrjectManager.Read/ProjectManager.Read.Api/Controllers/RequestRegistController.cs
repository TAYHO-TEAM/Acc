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
    public class RequestRegistController : APIControllerBase
    {
        private readonly IDOBaseRepository<RequestRegistDTO> _dOBaseRepository;
        private readonly IRequestRegistRepository<RequestRegistDTO> _requestRegistRepository;
        private readonly IRequestRegistRepository<RequestRegistDetailDTO> _requestRegistDetailRepository;
        private const string GetByAccountID= nameof(GetByAccountID);
        private const string GetDetail = nameof(GetDetail);
        public RequestRegistController(IMapper mapper, IHttpContextAccessor httpContextAccessor, IDOBaseRepository<RequestRegistDTO> dOBaseRepository, IRequestRegistRepository<RequestRegistDTO> requestRegistRepository, IRequestRegistRepository<RequestRegistDetailDTO> requestRegistDetailRepository) : base(mapper,httpContextAccessor)
        {
            _dOBaseRepository = dOBaseRepository;
            _requestRegistRepository=requestRegistRepository;
            _requestRegistDetailRepository = requestRegistDetailRepository;
        }
        /// <summary>
        /// Get List of RequestRegist.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(MethodResult<PagingItems<RequestRegistResponseViewModel>>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(VoidMethodResult), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetRequestRegistAsync([FromQuery] BaseRequestViewModel request)
        {
            var methodResult = new MethodResult<PagingItems<RequestRegistResponseViewModel>>();
            RequestHasAccountIdFilterParam requestFilter = _mapper.Map<RequestHasAccountIdFilterParam>(request);
            requestFilter.TableName = QuanLyDuAnConstants.RequestRegist_TABLENAME;
            requestFilter.AccountId = _user;
            var queryResult = await _dOBaseRepository.GetWithPaggingAccountFKAsync(requestFilter).ConfigureAwait(false);
            methodResult.Result = new PagingItems<RequestRegistResponseViewModel>
            {
                PagingInfo = queryResult.PagingInfo,
                Items = _mapper.Map<IEnumerable<RequestRegistResponseViewModel>>(queryResult.Items)
            };
            return Ok(methodResult);
        }
        /// <summary>
        /// Get List of RequestRegistWithAccontId.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpGet]
        [Route(GetByAccountID)]
        [ProducesResponseType(typeof(MethodResult<PagingItems<RequestRegistResponseViewModel>>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(VoidMethodResult), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetRequestRegistWithAccountAsync([FromQuery]BaseRequestViewModel request)
        {
            var methodResult = new MethodResult<PagingItems<RequestRegistResponseViewModel>>();
            RequestHasAccountIdFilterParam requestFilter = _mapper.Map<RequestHasAccountIdFilterParam>(request);
            requestFilter.TableName = QuanLyDuAnConstants.RequestRegist_TABLENAME;
            requestFilter.AccountId = _user;
            var queryResult = await _requestRegistRepository.GetWithPaggingStepPermistionAsync(requestFilter).ConfigureAwait(false);
            methodResult.Result = new PagingItems<RequestRegistResponseViewModel>
            {
                PagingInfo = queryResult.PagingInfo,
                Items = _mapper.Map<IEnumerable<RequestRegistResponseViewModel>>(queryResult.Items)
            };
            return Ok(methodResult);
        }
        /// <summary>
        /// Get List of RequestRegistDetail.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpGet]
        [Route(GetDetail)]
        [ProducesResponseType(typeof(MethodResult<PagingItems<ResponseRegistResponseViewModel>>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(VoidMethodResult), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetRequestRegisDetailAsync([FromQuery] BaseRequestViewModel request)
        {
            var methodResult = new MethodResult<PagingItems<RequestRegistResponseDetailViewModel>>();
            RequestHasAccountIdFilterParam requestFilter = _mapper.Map<RequestHasAccountIdFilterParam>(request);
            requestFilter.TableName = QuanLyDuAnConstants.RequestRegist_TABLENAME;
            requestFilter.AccountId = _user;
            var queryResult = await _requestRegistDetailRepository.GetWithDetailAsync(requestFilter).ConfigureAwait(false);
            methodResult.Result = new PagingItems<RequestRegistResponseDetailViewModel>
            {
                PagingInfo = queryResult.PagingInfo,
                Items = _mapper.Map<IEnumerable<RequestRegistResponseDetailViewModel>>(queryResult.Items)
            };
            return Ok(methodResult);
        }
    }
}
