using ProjectManager.CMD.Domain;
using ProjectManager.CMD.Domain.IRepositories;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using MediatR;
using Services.Common.DomainObjects;
using Services.Common.DomainObjects.Exceptions;
using Services.Common.Utilities;
using System.Threading;
using System.Threading.Tasks;

namespace ProjectManager.CMD.Api.Application.Commands
{
    public class UpdatePlanRegisterCommandHandler : PlanRegisterCommandHandler, IRequestHandler<UpdatePlanRegisterCommand, MethodResult<UpdatePlanRegisterCommandResponse>>
    {
        public UpdatePlanRegisterCommandHandler(IMapper mapper, IPlanRegisterRepository PlanRegisterRepository,IHttpContextAccessor httpContextAccessor) : base(mapper, PlanRegisterRepository,httpContextAccessor)
        {
        }

        /// <summary>
        /// Handle for update a existing PlanRegister.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<MethodResult<UpdatePlanRegisterCommandResponse>> Handle(UpdatePlanRegisterCommand request, CancellationToken cancellationToken)
        {
            var methodResult = new MethodResult<UpdatePlanRegisterCommandResponse>();
            var existingPlanRegister = await _planRegisterRepository.SingleOrDefaultAsync(x => x.Id == request.Id && x.IsDelete == false).ConfigureAwait(false);
            if (existingPlanRegister == null)
            {
                methodResult.AddAPIErrorMessage(nameof(ErrorCodeUpdate.UErr01), new[]
                {
                    ErrorHelpers.GenerateErrorResult(nameof(request.Id),request.Id)
                });
            }
            if (!methodResult.IsOk) throw new CommandHandlerException(methodResult.ErrorMessages);
            existingPlanRegister.IsActive = request.IsActive.HasValue ? request.IsActive : existingPlanRegister.IsActive;
            existingPlanRegister.IsVisible = request.IsVisible .HasValue ? request.IsVisible : existingPlanRegister.IsVisible;
            existingPlanRegister.Status = request.Status.HasValue ? request.Status : existingPlanRegister.Status;
            existingPlanRegister.SetParentId(request.ParentId);
            existingPlanRegister.SetDocumentTypeId(request.DocumentTypeId);
            existingPlanRegister.SetWorkItemId(request.WorkItemId);
            existingPlanRegister.SetCode(request.Code);
            existingPlanRegister.SetTitle(request.Title);
            existingPlanRegister.SetProjectId(request.ProjectId);
            existingPlanRegister.SetContractorInfoId(request.ContractorInfoId);
            existingPlanRegister.SetDescription(request.Description);
            existingPlanRegister.SetRequestDate(request.RequestDate);
            existingPlanRegister.SetResponseDate(request.ResponseDate);
            existingPlanRegister.SetExpectRequestDate(request.ExpectRequestDate);
            existingPlanRegister.SetExpectResponseDate(request.ExpectResponseDate);
            existingPlanRegister.SetUpdate(_user, 0);
            _planRegisterRepository.Update(existingPlanRegister);
            await _planRegisterRepository.UnitOfWork.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            methodResult.Result = _mapper.Map<UpdatePlanRegisterCommandResponse>(existingPlanRegister);
            return methodResult;
        }
    }
}