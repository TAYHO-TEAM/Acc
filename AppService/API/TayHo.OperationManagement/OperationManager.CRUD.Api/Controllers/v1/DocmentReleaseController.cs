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
using OperationManager.CRUD.Api.Common;
using OperationManager.CRUD.BLL.IRepositories.BaseClasses;

namespace OperationManager.CRUD.Api.Controllers.v1
{
    public class DocmentReleaseController : APIControllerBase
    {
        const string VALIDATION_ERROR = "The request failed due to a validation error";
        public string nameEF = OperationManagerConstants.DocumentReleased_TABLENAME;
        IQuanLyVanHanhRepository _quanLyVanHanhRepository;
        public DocmentReleaseController(IMapper mapper, IHttpContextAccessor httpContextAccessor, QuanLyVanHanhContext dbContext, IQuanLyVanHanhRepository quanLyVanHanhRepository) : base(mapper, httpContextAccessor, dbContext)
        {
            _quanLyVanHanhRepository = quanLyVanHanhRepository;
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
           return Ok(await _quanLyVanHanhRepository.GetAll(_user,nameEF,loadOptions));
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
            var methodResult = new MethodResult<object>();
            HttpRequestMessage request = new HttpRequestMessage();
            try
            {
                var values = form.Get("values");
                var model = new DocumentReleased();
                JsonConvert.PopulateObject(values, model);
                if (!ModelState.IsValid) throw new CommandHandlerException( new ErrorResult());

                return Ok(await _quanLyVanHanhRepository.Insert( nameEF, model));
            }
            catch (Exception ex)
            {
                return new OkObjectResult(HttpStatusCode.BadRequest);
            }
        }
        /// <summary>
        /// Update  of DocmentRelease.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPut]
        [ProducesResponseType(typeof(VoidMethodResult), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Put(FormDataCollection form)
        {
            try
            {
                var key = Convert.ToInt32(form.Get("key"));
                string values = form.Get("values");
                var model = dbContext.Districts.FirstOrDefault(x => x.ID == key);

                JsonConvert.PopulateObject(values, model);

                if (!ModelState.IsValid) throw new CommandHandlerException(new ErrorResult());

                await dbContext.SaveChangesAsync();

                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return Ok(HttpStatusCode.BadRequest);
            }
            //try
            //{
            //    var order = await _dbContext.DocumentReleased.FirstOrDefaultAsync(item => item.Id == key);
            //    if (!TryValidateModel(order))
            //        return BadRequest(VALIDATION_ERROR);

            //    await _dbContext.SaveChangesAsync();
            //    return Ok();
            //}
            //catch (Exception ex)
            //{
            //    return Ok();
            //}

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
