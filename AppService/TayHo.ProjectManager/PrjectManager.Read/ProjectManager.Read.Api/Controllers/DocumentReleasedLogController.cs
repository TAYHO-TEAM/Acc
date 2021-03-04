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
    public class DocumentReleasedLogController : APIControllerBase
    {
        private readonly IDOBaseRepository<DocumentReleasedLogDTO> _dOBaseRepository;
        private readonly IDocumentReleasedLogRepository<DocumentReleasedLogDetailDTO> _documentReleasedLogRepository;
        private const string GetListDetail = nameof(GetListDetail);
        public DocumentReleasedLogController(IMapper mapper, IHttpContextAccessor httpContextAccessor, IDOBaseRepository<DocumentReleasedLogDTO> dOBaseRepository,IDocumentReleasedLogRepository<DocumentReleasedLogDetailDTO> documentReleasedLogRepository) : base(mapper,httpContextAccessor)
        {
            _dOBaseRepository = dOBaseRepository;
            _documentReleasedLogRepository = documentReleasedLogRepository;
        }

        /// <summary>
        /// Get List of DocumentReleasedLog.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(MethodResult<PagingItems<DocumentReleasedLogResponseViewModel>>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(VoidMethodResult), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetDocumentReleasedLogAsync([FromQuery]BaseRequestViewModel request)
        {
            var methodResult = new MethodResult<PagingItems<DocumentReleasedLogResponseViewModel>>();
            RequestBaseFilterParam requestFilter = _mapper.Map<RequestBaseFilterParam>(request);
            requestFilter.TableName = QuanLyDuAnConstants.DocumentReleasedLog_TABLENAME;
            var queryResult = await _dOBaseRepository.GetWithPaggingFKAsync(requestFilter).ConfigureAwait(false);
            methodResult.Result = new PagingItems<DocumentReleasedLogResponseViewModel>
            {
                PagingInfo = queryResult.PagingInfo,
                Items = _mapper.Map<IEnumerable<DocumentReleasedLogResponseViewModel>>(queryResult.Items)
            };
            return Ok(methodResult);
        }

        /// <summary>
        /// Get List of DocumentReleasedLog Get list with Detail.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpGet]
        [Route(GetListDetail)]
        [ProducesResponseType(typeof(MethodResult<PagingItems<DocumentReleasedLogResponseViewModel>>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(VoidMethodResult), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetDocumentReleasedLogDetailAsync([FromQuery] BaseRequestViewModel request)
        {
            var methodResult = new MethodResult<PagingItems<DocumentReleasedLogDetailResponseViewModel>>();
            RequestHasAccountIdFilterParam requestFilter = _mapper.Map<RequestHasAccountIdFilterParam>(request);
            requestFilter.TableName = QuanLyDuAnConstants.DocumentReleasedLog_TABLENAME;
            requestFilter.AccountId = _user;
            var queryResult = await _documentReleasedLogRepository.GetWithPaggingDetailAsync(requestFilter).ConfigureAwait(false);
            methodResult.Result = new PagingItems<DocumentReleasedLogDetailResponseViewModel>
            {
                PagingInfo = queryResult.PagingInfo,
                Items = _mapper.Map<IEnumerable<DocumentReleasedLogDetailResponseViewModel>>(queryResult.Items)
            };
            return Ok(methodResult);
        }
    }
}
