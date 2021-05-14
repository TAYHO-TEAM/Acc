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
    public class DocumentReleasedController : APIControllerBase
    {
        private readonly IDOBaseRepository<DocumentReleasedDTO> _dOBaseRepository;
        private readonly IDocumentReleasedRepository<DocumentReleasedDTO> _documentReleasedRepository;
        private const string GetByAccountID = nameof(GetByAccountID);
        private const string GetByResiveID = nameof(GetByResiveID);
        public DocumentReleasedController(IMapper mapper, IHttpContextAccessor httpContextAccessor, IDOBaseRepository<DocumentReleasedDTO> dOBaseRepository, IDocumentReleasedRepository<DocumentReleasedDTO> documentReleasedRepository) : base(mapper,httpContextAccessor)
        {
            _dOBaseRepository = dOBaseRepository;
            _documentReleasedRepository = documentReleasedRepository;
        }

        /// <summary>
        /// Get List of DocumentReleased.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(MethodResult<PagingItems<DocumentReleasedResponseViewModel>>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(VoidMethodResult), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetDocumentReleasedAsync([FromQuery]BaseRequestViewModel request)
        {
            var methodResult = new MethodResult<PagingItems<DocumentReleasedResponseViewModel>>();
            RequestBaseFilterParam requestFilter = _mapper.Map<RequestBaseFilterParam>(request);
            requestFilter.TableName = QuanLyDuAnConstants.DocumentReleased_TABLENAME;
            var queryResult = await _dOBaseRepository.GetWithPaggingFKAsync(requestFilter).ConfigureAwait(false);
            methodResult.Result = new PagingItems<DocumentReleasedResponseViewModel>
            {
                PagingInfo = queryResult.PagingInfo,
                Items = _mapper.Map<IEnumerable<DocumentReleasedResponseViewModel>>(queryResult.Items)
            };
            return Ok(methodResult);
        }
        /// <summary>
        /// Get List of DocumentReleased by AccountId.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpGet]
        [Route(GetByAccountID)]
        [ProducesResponseType(typeof(MethodResult<PagingItems<DocumentReleasedResponseViewModel>>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(VoidMethodResult), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetDocumentReleasedByAccountAsync([FromQuery]BaseRequestViewModel request)
        {
            var methodResult = new MethodResult<PagingItems<DocumentReleasedResponseViewModel>>();
            RequestHasAccountIdFilterParam requestFilter = _mapper.Map<RequestHasAccountIdFilterParam>(request);
            requestFilter.AccountId = _user;
            requestFilter.TableName = QuanLyDuAnConstants.DocumentReleased_TABLENAME;
            var queryResult = await _documentReleasedRepository.GetWithPaggingStepPermistionAsync(requestFilter).ConfigureAwait(false);
            methodResult.Result = new PagingItems<DocumentReleasedResponseViewModel>
            {
                PagingInfo = queryResult.PagingInfo,
                Items = _mapper.Map<IEnumerable<DocumentReleasedResponseViewModel>>(queryResult.Items)
            };
            return Ok(methodResult);
        }
        /// <summary>
        /// Get List of DocumentReleased by Resive Account.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpGet]
        [Route(GetByResiveID)]
        [ProducesResponseType(typeof(MethodResult<PagingItems<DocumentReleasedResponseViewModel>>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(VoidMethodResult), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetDocumentReleasedByResiveAsync([FromQuery] BaseRequestViewModel request)
        {
            var methodResult = new MethodResult<PagingItems<DocumentReleasedResponseViewModel>>();
            RequestHasAccountIdFilterParam requestFilter = _mapper.Map<RequestHasAccountIdFilterParam>(request);
            requestFilter.AccountId = _user;
            requestFilter.TableName = QuanLyDuAnConstants.DocumentReleased_TABLENAME;
            var queryResult = await _documentReleasedRepository.GetWithPaggingResiveIdAsync(requestFilter).ConfigureAwait(false);
            methodResult.Result = new PagingItems<DocumentReleasedResponseViewModel>
            {
                PagingInfo = queryResult.PagingInfo,
                Items = _mapper.Map<IEnumerable<DocumentReleasedResponseViewModel>>(queryResult.Items)
            };
            return Ok(methodResult);
        }
    }
}
