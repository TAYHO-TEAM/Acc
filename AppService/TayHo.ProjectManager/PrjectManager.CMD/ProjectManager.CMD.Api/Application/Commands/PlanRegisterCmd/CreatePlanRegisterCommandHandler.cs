using ProjectManager.CMD.Domain.DomainObjects;
using ProjectManager.CMD.Domain.IRepositories;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using MediatR;
using Services.Common.DomainObjects;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace ProjectManager.CMD.Api.Application.Commands
{
    public class CreatePlanRegisterCommandHandler : PlanRegisterCommandHandler, IRequestHandler<CreatePlanRegisterCommand, MethodResult<CreatePlanRegisterCommandResponse>>
    {
        public CreatePlanRegisterCommandHandler(IMapper mapper, IPlanRegisterRepository PlanRegisterRepository, IHttpContextAccessor httpContextAccessor) : base(mapper, PlanRegisterRepository, httpContextAccessor)
        {
        }

        /// <summary>
        /// Handle for creating a new PlanRegister
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<MethodResult<CreatePlanRegisterCommandResponse>> Handle(CreatePlanRegisterCommand requests, CancellationToken cancellationToken)
        {
            var methodResult = new MethodResult<CreatePlanRegisterCommandResponse>();
            List<PlanRegister> listPlanRegister = new List<PlanRegister>();
            foreach (var request in requests.planRegisters)
            {
                var newPlanRegister = new PlanRegister(request.ParentId,
                                                  request.DocumentTypeId,
                                                  request.WorkItemId,
                                                  request.Code,
                                                  request.Title,
                                                  request.ProjectId,
                                                  request.ContractorInfoId,
                                                  request.Description,
                                                  request.RequestDate,
                                                  request.ResponseDate,
                                                  request.ExpectRequestDate,
                                                  request.ExpectResponseDate);
                newPlanRegister.SetCreate(_user);
                newPlanRegister.Status = request.Status.HasValue ? request.Status : newPlanRegister.Status;
                newPlanRegister.IsActive = request.IsActive.HasValue ? request.IsActive : newPlanRegister.IsActive;
                newPlanRegister.IsVisible = request.IsVisible.HasValue ? request.IsVisible : newPlanRegister.IsVisible;
                listPlanRegister.Add(newPlanRegister);
            }

            await _planRegisterRepository.AddRangeAsync(listPlanRegister).ConfigureAwait(false);
            await _planRegisterRepository.UnitOfWork.SaveChangesAndDispatchEventsAsync(cancellationToken).ConfigureAwait(false);
            var PlanRegisterResponseDTOs = _mapper.Map<List<PlanRegisterCommandResponseDTO>>(listPlanRegister);
            methodResult.Result = new CreatePlanRegisterCommandResponse(PlanRegisterResponseDTOs);
            return methodResult;
        }
        /// <summary>
        /// Handle for creating a new List PlanRegister
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        //public async Task<MethodResult<CreatePlanRegisterCommandResponse>> Handle(List<CreatePlanRegisterCommand> requests, CancellationToken cancellationToken)
        //{
        //    var methodResult = new MethodResult<CreatePlanRegisterCommandResponse>();
        //    List<PlanRegister> listPlanRegister = new List<PlanRegister>();
        //    foreach (var request in requests)
        //    {
        //        var newPlanRegister = new PlanRegister(request.ParentId,
        //                                          request.DocumentTypeId,
        //                                          request.WorkItemId,
        //                                          request.Code,
        //                                          request.Title,
        //                                          request.ProjectId,
        //                                          request.ContractorInfoId,
        //                                          request.Description,
        //                                          request.RequestDate,
        //                                          request.ResponseDate,
        //                                          request.ExpectRequestDate,
        //                                          request.ExpectResponseDate);
        //        newPlanRegister.SetCreate(_user);
        //        newPlanRegister.Status = request.Status.HasValue ? request.Status : newPlanRegister.Status;
        //        newPlanRegister.IsActive = request.IsActive.HasValue ? request.IsActive : newPlanRegister.IsActive;
        //        newPlanRegister.IsVisible = request.IsVisible.HasValue ? request.IsVisible : newPlanRegister.IsVisible;
        //        listPlanRegister.Add(newPlanRegister);
        //    }

        //    await _planRegisterRepository.AddRangeAsync(listPlanRegister).ConfigureAwait(false);
        //    await _planRegisterRepository.UnitOfWork.SaveChangesAndDispatchEventsAsync(cancellationToken).ConfigureAwait(false);
        //    methodResult.Result = _mapper.Map<CreatePlanRegisterCommandResponse>(listPlanRegister);
        //    return methodResult;
        //}
    }
}