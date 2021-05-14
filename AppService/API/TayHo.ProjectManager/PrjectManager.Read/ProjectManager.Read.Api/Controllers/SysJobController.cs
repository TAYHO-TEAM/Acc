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

    public class SysJobController : APIControllerBase
    {
        private readonly IDOBaseRepository<SysJobDTO> _dOBaseRepository;
        private readonly ISysJobRepository<SysJobDTO> _sysJobRepository;
        private const string SysJobDataBase = nameof(SysJobDataBase);
        private const string SysJobStoreProc = nameof(SysJobStoreProc);
        private const string SysJobParameter = nameof(SysJobParameter);

        public SysJobController(IMapper mapper, IHttpContextAccessor httpContextAccessor, IDOBaseRepository<SysJobDTO> dOBaseRepository, ISysJobRepository<SysJobDTO> sysJobRepository) : base(mapper,httpContextAccessor)
        {
            _dOBaseRepository = dOBaseRepository;
            _sysJobRepository = sysJobRepository;
        }

        /// <summary>
        /// Get List of SysJob.
        /// </summary>
        /// <param name="SysJob"></param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(MethodResult<PagingItems<SysJobResponseViewModel>>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(VoidMethodResult), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetSysJobAsync([FromQuery] BaseRequestViewModel request)
        {
            var methodResult = new MethodResult<PagingItems<SysJobResponseViewModel>>();
            RequestBaseFilterParam requestFilter = _mapper.Map<RequestBaseFilterParam>(request);
            requestFilter.TableName = QuanLyDuAnConstants.SysJob_TABLENAME;
            var queryResult = await _dOBaseRepository.GetWithPaggingAsync(requestFilter).ConfigureAwait(false);
            methodResult.Result = new PagingItems<SysJobResponseViewModel>
            {
                PagingInfo = queryResult.PagingInfo,
                Items = _mapper.Map<IEnumerable<SysJobResponseViewModel>>(queryResult.Items)
            };
            return Ok(methodResult);
        }
        /// <summary>
        /// Get List of SysJob DataBase.
        /// </summary>
        /// <param name="SysJobDataBase"></param>
        /// <returns></returns>
        [Route(SysJobDataBase)]
        [HttpGet]
        [ProducesResponseType(typeof(MethodResult<PagingItems<SysJobDataBaseResponseViewModel>>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(VoidMethodResult), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetSysJobDataBaseAsync([FromQuery] SysJobRequestViewModel request)
        {
            var methodResult = new MethodResult<PagingItems<SysJobDataBaseResponseViewModel>>();
            RequestSysJobFilterParam requestFilter = _mapper.Map<RequestSysJobFilterParam>(request);
            var queryResult = await _sysJobRepository.GetDataBaseAsync(requestFilter).ConfigureAwait(false);
            methodResult.Result = new PagingItems<SysJobDataBaseResponseViewModel>
            {
                PagingInfo = queryResult.PagingInfo,
                Items = _mapper.Map<IEnumerable<SysJobDataBaseResponseViewModel>>(queryResult.Items)
            };
            return Ok(methodResult);
        }
        /// <summary>
        /// Get List of SysJob StoreProcedure.
        /// </summary>
        /// <param name="SysJobStoreProcedure"></param>
        /// <returns></returns>
        [Route(SysJobStoreProc)]
        [HttpGet]
        [ProducesResponseType(typeof(MethodResult<PagingItems<SysJobStoreProcedureResponseViewModel>>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(VoidMethodResult), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetSysJobStoreProcedureAsync([FromQuery] SysJobRequestViewModel request)
        {
            var methodResult = new MethodResult<PagingItems<SysJobStoreProcedureResponseViewModel>>();
            RequestSysJobFilterParam requestFilter = _mapper.Map<RequestSysJobFilterParam>(request);
            var queryResult = await _sysJobRepository.GetStoreProcedureAsync(requestFilter).ConfigureAwait(false);
            methodResult.Result = new PagingItems<SysJobStoreProcedureResponseViewModel>
            {
                PagingInfo = queryResult.PagingInfo,
                Items = _mapper.Map<IEnumerable<SysJobStoreProcedureResponseViewModel>>(queryResult.Items)
            };
            return Ok(methodResult);
        }
        /// <summary>
        /// Get List of SysJob Parameter.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns> 
        [Route(SysJobParameter)]
        [HttpGet]
        [ProducesResponseType(typeof(MethodResult<PagingItems<SysJobParameterResponseViewModel>>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(VoidMethodResult), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetSysJobParameterAsync([FromQuery] SysJobRequestViewModel request)
        {
            var methodResult = new MethodResult<PagingItems<SysJobParameterResponseViewModel>>();
            RequestSysJobFilterParam requestFilter = _mapper.Map<RequestSysJobFilterParam>(request);
            var queryResult = await _sysJobRepository.GetParameterAsync(requestFilter).ConfigureAwait(false);
            methodResult.Result = new PagingItems<SysJobParameterResponseViewModel>
            {
                PagingInfo = queryResult.PagingInfo,
                Items = _mapper.Map<IEnumerable<SysJobParameterResponseViewModel>>(queryResult.Items)
            };
            return Ok(methodResult);
        }
    }
}

