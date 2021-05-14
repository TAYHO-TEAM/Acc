using ProjectManager.CMD.Domain.DomainObjects;
using ProjectManager.CMD.Domain.IRepositories;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using MediatR;
using Services.Common.DomainObjects;
using System.Threading;
using System.Threading.Tasks;

namespace  ProjectManager.CMD.Api.Application.Commands
{
    public class CreateRequestDetailCommandHandler : RequestDetailCommandHandler, IRequestHandler<CreateRequestDetailCommand, MethodResult<CreateRequestDetailCommandResponse>>
    {
        public CreateRequestDetailCommandHandler(IMapper mapper, IRequestDetailRepository RequestDetailRepository,IHttpContextAccessor httpContextAccessor) : base(mapper, RequestDetailRepository,httpContextAccessor)
        {
        }

        /// <summary>
        /// Handle for creating a new RequestDetail
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<MethodResult<CreateRequestDetailCommandResponse>> Handle(CreateRequestDetailCommand request, CancellationToken cancellationToken)
        {
            var methodResult = new MethodResult<CreateRequestDetailCommandResponse>();
            var newRequestDetail = new RequestDetail(request.RequestId,
                                                        request.ProblemCategoryId,
                                                        request.ReplyByID,
                                                        request.Title,
                                                        request.Descriptions,
                                                        request.Note,
                                                        request.DurationDate,
                                                        request.StatusText,
                                                        request.FromDate,
                                                        request.ToDate,
                                                        request.NoAttachment);
            newRequestDetail.SetCreate(_user);
            newRequestDetail.Status = request.Status.HasValue ? request.Status : 0;
            newRequestDetail.IsActive = request.IsActive.HasValue ? request.IsActive : newRequestDetail.IsActive;
            newRequestDetail.IsVisible = request.IsVisible .HasValue ? request.IsVisible : newRequestDetail.IsVisible;
            await _RequestDetailRepository.AddAsync(newRequestDetail).ConfigureAwait(false);
            await _RequestDetailRepository.UnitOfWork.SaveChangesAndDispatchEventsAsync(cancellationToken).ConfigureAwait(false);
            methodResult.Result = _mapper.Map<CreateRequestDetailCommandResponse>(newRequestDetail);
            return methodResult;
        }
    }
}