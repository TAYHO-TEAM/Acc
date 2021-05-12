using AutoMapper;
using DevExtreme.AspNet.Data.ResponseModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OperationManager.CRUD.Api.Controllers.v1.BaseClasses;
using Services.Common.DevExpress;
using Services.Common.DomainObjects;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using System.Linq;
using DevExtreme.AspNet.Data;
using System.Net.Http;
using System.Net.Http.Formatting;
using Newtonsoft.Json;
using System;
using Services.Common.DomainObjects.Exceptions;
using Microsoft.EntityFrameworkCore;
using OperationManager.CRUD.DAL.DBContext;
using OperationManager.CRUD.DAL.DTO;

namespace OperationManager.CRUD.Api.Controllers.v1
{
    public class DocmentReleaseController : APIControllerBase
    {
        protected readonly QuanLyVanHanhContext  _dbContext;
        const string VALIDATION_ERROR = "The request failed due to a validation error";
        public DocmentReleaseController(IMapper mapper, IHttpContextAccessor httpContextAccessor, QuanLyVanHanhContext dbContext) : base(mapper, httpContextAccessor, dbContext)
        {
            _dbContext = dbContext;
        }
        /// <summary>
        /// Get List of DocmentRelease.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(VoidMethodResult), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetAll([FromQuery]DataSourceLoadOptions loadOptions)
        {
            var list = from x in _dbContext.DocumentReleased
                       where x.IsDelete == false
                       orderby x.Id
                       select new { x.Code, x.Description, x.Id, x, x.IsDelete, x.IsModify, x.Location };
            //var methodResult = new MethodResult<PagingItems<DocumentReleased>>();
            var abc = new LoadResult();
            return Ok(await DataSourceLoader.LoadAsync(list, loadOptions));
        }
        /// <summary>
        /// Create  of DocmentRelease.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(VoidMethodResult), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Insert(FormDataCollection form)
        {
            HttpRequestMessage request = new HttpRequestMessage();
            try
            {
                var values = form.Get("values");
                var model = new DocumentReleased();
                JsonConvert.PopulateObject(values, model);
              
                if (!ModelState.IsValid) throw new CommandHandlerException( new ErrorResult(new List<string>().Add("ValidateDistricts Model Error")));

                var result = _dbContext.DocumentReleased.Add(model);
                await _dbContext.SaveChangesAsync();

                return Ok(new { result.Entity.Id });
            }
            catch (Exception ex)
            {
                return new OkObjectResult(new object { HttpStatusCode.BadRequest, ex });
            }
        }
        /// <summary>
        /// Update  of DocmentRelease.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPut]
        [ProducesResponseType(typeof(VoidMethodResult), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Put(int key, string values)
        {
            try
            {
                var order = await _dbContext.DocumentReleased.FirstOrDefaultAsync(item => item.Id == key);
                if (!TryValidateModel(order))
                    return BadRequest(VALIDATION_ERROR);

                await _dbContext.SaveChangesAsync();
                return Ok();
            }
            catch (Exception ex)
            {
                return Ok();
            }

        }

        /// <summary>
        /// Delete  of DocmentRelease.
        /// </summary>
        /// <param name="DocmentRelease"></param>
        /// <returns></returns>
        [HttpDelete]
        [ProducesResponseType(typeof(VoidMethodResult), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Delete(int key)
        {
            try
            {
                var moldel = await _dbContext.DocumentReleased.FirstOrDefaultAsync(item => item.Id == key);
                _dbContext.DocumentReleased.Remove(moldel);
                await _dbContext.SaveChangesAsync();
                return Ok();
            }
            catch(Exception ex)
            {
                return Ok();
            }
            
        }

    }
}
