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

namespace  ProjectManager.CMD.Api.Application.Commands
{
    public class UpdateRequestRegistCommandHandler : RequestRegistCommandHandler,IRequestHandler<UpdateRequestRegistCommand, MethodResult<UpdateRequestRegistCommandResponse>>
    {
        public UpdateRequestRegistCommandHandler(IMapper mapper, IRequestRegistRepository RequestRegistRepository,IHttpContextAccessor httpContextAccessor) : base(mapper, RequestRegistRepository,httpContextAccessor)
        {
        }

        /// <summary>
        /// Handle for update a existing RequestRegist.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<MethodResult<UpdateRequestRegistCommandResponse>> Handle(UpdateRequestRegistCommand request, CancellationToken cancellationToken)
        {
            var methodResult = new MethodResult<UpdateRequestRegistCommandResponse>();
            var existingRequestRegist = await _requestRegistRepository.SingleOrDefaultAsync(x => x.Id == request.Id && x.IsDelete == false).ConfigureAwait(false);
            if (existingRequestRegist == null)
            {
                methodResult.AddAPIErrorMessage(nameof(ErrorCodeUpdate.UErr01), new[]
                {
                    ErrorHelpers.GenerateErrorResult(nameof(request.Id),request.Id)
                });
            }
            if (!methodResult.IsOk) throw new CommandHandlerException(methodResult.ErrorMessages);
            existingRequestRegist.IsActive = request.IsActive.HasValue ? request.IsActive : existingRequestRegist.IsActive;
            existingRequestRegist.IsVisible = request.IsVisible .HasValue ? request.IsVisible : existingRequestRegist.IsVisible;
            existingRequestRegist.Status = request.Status.HasValue ? request.Status : existingRequestRegist.Status;

            existingRequestRegist.SetPlanRegisterId(request.PlanRegisterId);
            existingRequestRegist.SetBarCode(request.BarCode);
            existingRequestRegist.SetTitle(request.Title);
            existingRequestRegist.SetDescriptions(request.Descriptions);
            existingRequestRegist.SetNote(request.Note);
            existingRequestRegist.SetParentId(request.ParentId);
            existingRequestRegist.SetLevel(request.Level);
            existingRequestRegist.SetNoAttachment(request.NoAttachment);
            existingRequestRegist.SetProjectId(request.ProjectId);
            existingRequestRegist.SetWorkItemId(request.WorkItemId);
            existingRequestRegist.SetDocumentTypeId(request.DocumentTypeId);
            existingRequestRegist.SetRev(request.Rev);

            //existingRequestRegist.SetCode((await _requestRegistRepository.IsGetTitleRequestRegistAsync((int)existingRequestRegist.ProjectId, (int)existingRequestRegist.WorkItemId, _user, (int)existingRequestRegist.DocumentTypeId).ConfigureAwait(false)).Replace("-", ""));

            existingRequestRegist.SetUpdate(_user,0);
            _requestRegistRepository.Update(existingRequestRegist);
            await _requestRegistRepository.UnitOfWork.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            methodResult.Result = _mapper.Map<UpdateRequestRegistCommandResponse>(existingRequestRegist);
            return methodResult;
        }
    }
}