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
    public class CreateOperationProcessCommandHandler : OperationProcessCommandHandler, IRequestHandler<CreateOperationProcessCommand, MethodResult<CreateOperationProcessCommandResponse>>
    {
        public CreateOperationProcessCommandHandler(IMapper mapper, IOperationProcessRepository OperationProcessRepository,IHttpContextAccessor httpContextAccessor) : base(mapper, httpContextAccessor, OperationProcessRepository)
        {
        }

        /// <summary>
        /// Handle for creating a new OperationProcess
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<MethodResult<CreateOperationProcessCommandResponse>> Handle(CreateOperationProcessCommand request, CancellationToken cancellationToken)
        {
            var methodResult = new MethodResult<CreateOperationProcessCommandResponse>();
            var newOperationProcess = new OperationProcess(request.Code,
                                                            request.BarCode,
                                                            request.Title,
                                                            request.Description,
                                                            request.Priority,
                                                            request.ParentId,
                                                            request.Level,
                                                            request.PreviousId,
                                                            request.NextId);
            newOperationProcess.SetCreate(_user);
            newOperationProcess.Status = request.Status.HasValue ? request.Status : newOperationProcess.Status;
            newOperationProcess.IsActive = request.IsActive.HasValue ? request.IsActive : newOperationProcess.IsActive;
            newOperationProcess.IsVisible = request.IsVisible.HasValue ? request.IsVisible : newOperationProcess.IsVisible;
            await _OperationProcessRepository.AddAsync(newOperationProcess).ConfigureAwait(false);
            await _OperationProcessRepository.UnitOfWork.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            methodResult.Result = _mapper.Map<CreateOperationProcessCommandResponse>(newOperationProcess);
            return methodResult;
        }
    }
}