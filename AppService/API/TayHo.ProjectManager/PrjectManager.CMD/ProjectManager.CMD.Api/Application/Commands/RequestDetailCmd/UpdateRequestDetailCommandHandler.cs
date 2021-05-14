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
    public class UpdateRequestDetailCommandHandler : RequestDetailCommandHandler,IRequestHandler<UpdateRequestDetailCommand, MethodResult<UpdateRequestDetailCommandResponse>>
    {
        public UpdateRequestDetailCommandHandler(IMapper mapper, IRequestDetailRepository RequestDetailRepository,IHttpContextAccessor httpContextAccessor) : base(mapper, RequestDetailRepository,httpContextAccessor)
        {
        }

        /// <summary>
        /// Handle for update a existing RequestDetail.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<MethodResult<UpdateRequestDetailCommandResponse>> Handle(UpdateRequestDetailCommand request, CancellationToken cancellationToken)
        {
            var methodResult = new MethodResult<UpdateRequestDetailCommandResponse>();
            var existingRequestDetail = await _RequestDetailRepository.SingleOrDefaultAsync(x => x.Id == request.Id && x.IsDelete == false).ConfigureAwait(false);
            if (existingRequestDetail == null)
            {
                methodResult.AddAPIErrorMessage(nameof(ErrorCodeUpdate.UErr01), new[]
                {
                    ErrorHelpers.GenerateErrorResult(nameof(request.Id),request.Id)
                });
            }
            if (!methodResult.IsOk) throw new CommandHandlerException(methodResult.ErrorMessages);
            existingRequestDetail.IsActive = request.IsActive.HasValue ? request.IsActive : existingRequestDetail.IsActive;
            existingRequestDetail.IsVisible = request.IsVisible .HasValue ? request.IsVisible : existingRequestDetail.IsVisible;
            existingRequestDetail.Status = request.Status.HasValue ? request.Status : existingRequestDetail.Status;
            existingRequestDetail.SetRequestId(request.RequestId);
            existingRequestDetail.SetProblemCategoryId(request.ProblemCategoryId);
            existingRequestDetail.SetReplyByID(request.ReplyByID);
            existingRequestDetail.SetTitle(request.Title);
            existingRequestDetail.SetDescriptions(request.Descriptions);
            existingRequestDetail.SetNote(request.Note);
            existingRequestDetail.SetDurationDate(request.DurationDate);
            existingRequestDetail.SetStatusText(request.StatusText);
            existingRequestDetail.SetFromDate(request.FromDate);
            existingRequestDetail.SetToDate(request.ToDate);
            existingRequestDetail.SetNoAttachment(request.NoAttachment);
            existingRequestDetail.SetUpdate(_user,0);
           
            _RequestDetailRepository.Update(existingRequestDetail);
            await _RequestDetailRepository.UnitOfWork.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            methodResult.Result = _mapper.Map<UpdateRequestDetailCommandResponse>(existingRequestDetail);
            return methodResult;
        }
    }
}