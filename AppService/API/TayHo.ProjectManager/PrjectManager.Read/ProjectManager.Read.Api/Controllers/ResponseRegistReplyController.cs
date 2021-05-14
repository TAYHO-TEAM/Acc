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
    public class ResponseRegistReplyController : APIControllerBase
    {
        private readonly IDOBaseRepository<ResponseRegistReplyDTO> _dOBaseRepository;

        public ResponseRegistReplyController(IMapper mapper, IHttpContextAccessor httpContextAccessor, IDOBaseRepository<ResponseRegistReplyDTO> dOBaseRepository) : base(mapper,httpContextAccessor)
        {
            _dOBaseRepository = dOBaseRepository;
        }

        /// <summary>
        /// Get List of ResponseRegistReply.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(MethodResult<PagingItems<ResponseRegistReplyResponseViewModel>>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(VoidMethodResult), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetResponseRegistReplyAsync([FromQuery]BaseRequestViewModel request)
        {
            var methodResult = new MethodResult<PagingItems<ResponseRegistReplyResponseViewModel>>();
            RequestHasAccountIdFilterParam requestFilter = _mapper.Map<RequestHasAccountIdFilterParam>(request);
            requestFilter.TableName = QuanLyDuAnConstants.ResponseRegistReply_TABLENAME;
            requestFilter.AccountId = _user;
            var queryResult = await _dOBaseRepository.GetWithPaggingAccountFKAsync(requestFilter).ConfigureAwait(false);
            methodResult.Result = new PagingItems<ResponseRegistReplyResponseViewModel>
            {
                PagingInfo = queryResult.PagingInfo,
                Items = _mapper.Map<IEnumerable<ResponseRegistReplyResponseViewModel>>(queryResult.Items)
            };
            return Ok(methodResult);
        }
    }
}
