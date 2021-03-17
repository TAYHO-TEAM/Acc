using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectManager.Common;
using ProjectManager.Read.Api.Controllers.v1.BaseClasses;
using Services.Common.DomainObjects;
using System.Net;
using System.Threading.Tasks;
using ProjectManager.Read.Api.ViewModels.DevExpressClasses;
using ProjectManager.Read.Sql.Interfaces;
using ProjectManager.Read.Sql.DTOs.BaseClasses;

namespace ProjectManager.Read.Api.Controllers.v1
{
    public class ProjectManagerController : APIControllerBase
    {
        
        private const string getAll = nameof(getAll);
        private readonly IProjectManagerRepository _projectManagerRepository;
        public ProjectManagerController(IMapper mapper, IHttpContextAccessor httpContextAccessor, IProjectManagerRepository projectManagerRepository) : base(mapper,httpContextAccessor)
        {
            _projectManagerRepository = projectManagerRepository;
        }
        /// <summary>
        /// Get List of ProjectManager get.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(VoidMethodResult), (int)HttpStatusCode.BadRequest)]
        //[Route(getAll)]
        public async Task<IActionResult> GetProjectManager([FromBody]DevRequestViewModel loadOptions)
        {
            DevLoadOptionsBase requestFilter = _mapper.Map<DevRequestLoadOptionsViewModel, DevLoadOptionsBase>(loadOptions.devRequestLoadOptionsViewModel);
            var abc = await _projectManagerRepository.GetAll(_user,loadOptions.nameEF, requestFilter, loadOptions.devRequestLoadOptionsViewModel.searchOperation, loadOptions.devRequestLoadOptionsViewModel.searchValue, loadOptions.devRequestLoadOptionsViewModel.searchExpr);
            return Ok(abc);
            //return Ok("abc");
        }
        /// <summary>
        /// Post List of ProjectManager get.
        /// </summary>
        /// <param name=" post request"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(VoidMethodResult), (int)HttpStatusCode.BadRequest)]
        //[Route(getAll)]
        public async Task<IActionResult> PostProjectManager([FromBody] DevRequestViewModel loadOptions)
        {

            DevLoadOptionsBase requestFilter = _mapper.Map<DevRequestLoadOptionsViewModel, DevLoadOptionsBase>(loadOptions.devRequestLoadOptionsViewModel);
            var abc = await _projectManagerRepository.GetAll(_user,loadOptions.nameEF, requestFilter, loadOptions.devRequestLoadOptionsViewModel.searchOperation, loadOptions.devRequestLoadOptionsViewModel.searchValue, loadOptions.devRequestLoadOptionsViewModel.searchExpr);
            return Ok(abc);
            //return Ok("abc");
        }

    }
}
