using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OperationManager.CRUD.Api.Controllers.v1.BaseClasses;
using Services.Common.DevExpress;
using Services.Common.DomainObjects;
using System.Net;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System;
using Services.Common.DomainObjects.Exceptions;
using OperationManager.CRUD.DAL.DTO.OperationManagerDTO;
using OperationManager.CRUD.BLL.IRepositories.BaseClasses;
using OperationManager.CRUD.Common;

namespace OperationManager.CRUD.Api.Controllers.v1
{
    public class SysJobWithAccountController : APIControllerBase
    {
        const string VALIDATION_ERROR = "The request failed due to a validation error";
        public string nameEF = OperationManagerConstants.SysJobWithAccount_TABLENAME;
        protected readonly ISysJobWithAccountRepository _sysJobWithAccountRepository;
        public SysJobWithAccountController(IMapper mapper, IHttpContextAccessor httpContextAccessor, ISysJobWithAccountRepository sysJobWithAccountRepository) : base(mapper, httpContextAccessor)
        {
            _sysJobWithAccountRepository = sysJobWithAccountRepository;
        }
        /// <summary>
        /// Get List of SysJobWithAccount.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(VoidMethodResult), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetAll([FromQuery] DataLoadOptionsHelper loadOptions)
        {
            return Ok(await _sysJobWithAccountRepository.GetAll(_user, nameEF, loadOptions));
        }
    }
}
