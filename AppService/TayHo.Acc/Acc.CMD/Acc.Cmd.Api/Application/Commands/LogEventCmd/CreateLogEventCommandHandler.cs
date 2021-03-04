using Acc.Cmd.Domain.DomainObjects;
using Acc.Cmd.Domain.Repositories;
using AutoMapper;using Microsoft.AspNetCore.Http;
using MediatR;
using Services.Common.DomainObjects;
using System.Threading;
using System.Threading.Tasks;

namespace  Acc.Cmd.Api.Application.Commands
{
    public class CreateLogEventCommandHandler : LogEventCommandHandler, IRequestHandler<CreateLogEventCommand, MethodResult<CreateLogEventCommandResponse>>
    {
        public CreateLogEventCommandHandler(IMapper mapper, ILogEventRepository LogEventRepository,IHttpContextAccessor httpContextAccessor) : base(mapper, httpContextAccessor, LogEventRepository)
        {
        }

        /// <summary>
        /// Handle for creating a new LogEvent
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<MethodResult<CreateLogEventCommandResponse>> Handle(CreateLogEventCommand request, CancellationToken cancellationToken)
        {
            var methodResult = new MethodResult<CreateLogEventCommandResponse>();
            var newLogEvent = new LogEvent(request.UserId,
                request.Event,
                request.Action,
                request.OwnerById,
                request.OwnerByTable,
                request.FunctionId,
                request.Message);
            newLogEvent.SetCreate(_user);
            newLogEvent.Status = request.Status.HasValue ? request.Status : newLogEvent.Status;
            newLogEvent.IsActive = request.IsActive.HasValue ? request.IsActive : newLogEvent.IsActive;
            newLogEvent.IsVisible = request.IsVisible.HasValue ? request.IsVisible : newLogEvent.IsVisible;
            await _LogEventRepository.AddAsync(newLogEvent).ConfigureAwait(false);
            await _LogEventRepository.UnitOfWork.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            methodResult.Result = _mapper.Map<CreateLogEventCommandResponse>(newLogEvent);
            return methodResult;
        }
    }
}