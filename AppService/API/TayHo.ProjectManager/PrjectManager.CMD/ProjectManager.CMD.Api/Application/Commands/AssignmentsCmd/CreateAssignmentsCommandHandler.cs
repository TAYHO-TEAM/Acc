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
    public class CreateAssignmentsCommandHandler : AssignmentsCommandHandler, IRequestHandler<CreateAssignmentsCommand, MethodResult<CreateAssignmentsCommandResponse>>
    {
        public CreateAssignmentsCommandHandler(IMapper mapper, IAssignmentsRepository AssignmentsRepository,IHttpContextAccessor httpContextAccessor) : base(mapper, AssignmentsRepository,httpContextAccessor)
        {
        }

        /// <summary>
        /// Handle for creating a new Assignments
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<MethodResult<CreateAssignmentsCommandResponse>> Handle(CreateAssignmentsCommand request, CancellationToken cancellationToken)
        {
            var methodResult = new MethodResult<CreateAssignmentsCommandResponse>();
            var newAssignments = new Assignments(request.AccountId,
                                                request.RequestId,
                                                request.RequestDetailId);
            newAssignments.SetCreate(_user);
            newAssignments.Status = request.Status.HasValue ? request.Status : newAssignments.Status;
            newAssignments.IsActive = request.IsActive.HasValue ? request.IsActive : newAssignments.IsActive;
            newAssignments.IsVisible = request.IsVisible .HasValue ? request.IsVisible : newAssignments.IsVisible;
            await _AssignmentsRepository.AddAsync(newAssignments).ConfigureAwait(false);
            await _AssignmentsRepository.UnitOfWork.SaveChangesAndDispatchEventsAsync(cancellationToken).ConfigureAwait(false);
            methodResult.Result = _mapper.Map<CreateAssignmentsCommandResponse>(newAssignments);
            return methodResult;
        }
    }
}