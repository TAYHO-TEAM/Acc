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
    public class ResponseRegistController : APIControllerBase
    {
        private readonly IDOBaseRepository<ResponseRegistDTO> _dOBaseRepository;
        private readonly IResponseRegistRepository<ResponseRegistDTO> _responseRegistRepository;
        private const string getByAccount = nameof(getByAccount);
        public ResponseRegistController(IMapper mapper, IHttpContextAccessor httpContextAccessor, IDOBaseRepository<ResponseRegistDTO> dOBaseRepository, IResponseRegistRepository<ResponseRegistDTO> responseRegistRepository) : base(mapper, httpContextAccessor)
        {
            _dOBaseRepository = dOBaseRepository;
            _responseRegistRepository = responseRegistRepository;
        }
        /// <summary>
        /// Get List of ResponseRegist.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(MethodResult<PagingItems<ResponseRegistResponseViewModel>>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(VoidMethodResult), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetResponseRegistAsync([FromQuery] BaseRequestViewModel request)
        {
            var methodResult = new MethodResult<PagingItems<ResponseRegistResponseViewModel>>();
            RequestHasAccountIdFilterParam requestFilter = _mapper.Map<RequestHasAccountIdFilterParam>(request);
            requestFilter.TableName = QuanLyDuAnConstants.ResponseRegist_TABLENAME;
            requestFilter.AccountId = _user;
            var queryResult = await _dOBaseRepository.GetWithPaggingAccountFKAsync(requestFilter).ConfigureAwait(false);
            methodResult.Result = new PagingItems<ResponseRegistResponseViewModel>
            {
                PagingInfo = queryResult.PagingInfo,
                Items = _mapper.Map<IEnumerable<ResponseRegistResponseViewModel>>(queryResult.Items)
            };
            return Ok(methodResult);
        }
        /// <summary>
        /// Get List of ResponseRegist get by accoutn.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpGet]
        [Route(getByAccount)]
        [ProducesResponseType(typeof(MethodResult<PagingItems<ResponseRegistResponseViewModel>>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(VoidMethodResult), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetResponseRegistByAccountAsync([FromQuery] BaseRequestViewModel request)
        {
            var methodResult = new MethodResult<PagingItems<ResponseRegistResponseViewModel>>();
            RequestHasAccountIdFilterParam requestFilter = _mapper.Map<RequestHasAccountIdFilterParam>(request);
            requestFilter.TableName = QuanLyDuAnConstants.ResponseRegist_TABLENAME;
            requestFilter.AccountId = _user;
            var queryResult = await _responseRegistRepository.GetAllWithAccountAsync(requestFilter).ConfigureAwait(false);
            methodResult.Result = new PagingItems<ResponseRegistResponseViewModel>
            {
                PagingInfo = queryResult.PagingInfo,
                Items = _mapper.Map<IEnumerable<ResponseRegistResponseViewModel>>(queryResult.Items)
            };
            return Ok(methodResult);
        }
    }
}
