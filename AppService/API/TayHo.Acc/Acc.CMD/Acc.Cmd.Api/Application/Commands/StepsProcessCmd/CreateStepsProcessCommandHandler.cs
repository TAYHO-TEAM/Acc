using Acc.Cmd.Domain.DomainObjects;
using Acc.Cmd.Domain.Repositories;
using AutoMapper;
using MediatR;
using Services.Common.DomainObjects;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace  Acc.Cmd.Api.Application.Commands
{
    public class CreateStepsProcessCommandHandler : StepsProcessCommandHandler, IRequestHandler<CreateStepsProcessCommand, MethodResult<CreateStepsProcessCommandResponse>>
    {
        public CreateStepsProcessCommandHandler(IMapper mapper, IStepsProcessRepository StepsProcessRepository,IHttpContextAccessor httpContextAccessor) : base(mapper, httpContextAccessor, StepsProcessRepository)
        {
        }

        /// <summary>
        /// Handle for creating a new StepsProcess
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<MethodResult<CreateStepsProcessCommandResponse>> Handle(CreateStepsProcessCommand request, CancellationToken cancellationToken)
        {
            var methodResult = new MethodResult<CreateStepsProcessCommandResponse>();

            var newStepsProcess = new StepsProcess(request.Code,
                                                    request.Title,
                                                    request.Priority,
                                                    request.ParentId,
                                                    request.Level,
                                                    request.PreviousId,
                                                    request.NextId,
                                                    request.OperationProcessId);

            newStepsProcess.SetCreate(_user);
            newStepsProcess.Status = request.Status.HasValue ? request.Status : newStepsProcess.Status;
            newStepsProcess.IsActive = request.IsActive.HasValue ? request.IsActive : newStepsProcess.IsActive;
            newStepsProcess.IsVisible = request.IsVisible.HasValue ? request.IsVisible : newStepsProcess.IsVisible;
            await _StepsProcessRepository.AddAsync(newStepsProcess).ConfigureAwait(false);
            await _StepsProcessRepository.UnitOfWork.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            methodResult.Result = _mapper.Map<CreateStepsProcessCommandResponse>(newStepsProcess);
            return methodResult;
        }
    }
}