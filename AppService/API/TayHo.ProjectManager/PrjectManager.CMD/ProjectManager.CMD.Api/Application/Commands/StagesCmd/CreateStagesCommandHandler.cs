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
    public class CreateStagesCommandHandler : StagesCommandHandler, IRequestHandler<CreateStagesCommand, MethodResult<CreateStagesCommandResponse>>
    {
        public CreateStagesCommandHandler(IMapper mapper, IStagesRepository StagesRepository,IHttpContextAccessor httpContextAccessor) : base(mapper, StagesRepository,httpContextAccessor)
        {
        }

        /// <summary>
        /// Handle for creating a new Stages
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<MethodResult<CreateStagesCommandResponse>> Handle(CreateStagesCommand request, CancellationToken cancellationToken)
        {
            var methodResult = new MethodResult<CreateStagesCommandResponse>();
            var newStages = new Stages(request.Code, request.Title, request.Descriptions);
            newStages.SetCreate(_user);
            newStages.Status = request.Status.HasValue ? request.Status : newStages.Status;
            newStages.IsActive = request.IsActive.HasValue ? request.IsActive : newStages.IsActive;
            newStages.IsVisible = request.IsVisible .HasValue ? request.IsVisible : newStages.IsVisible;
            await _StagesRepository.AddAsync(newStages).ConfigureAwait(false);
            await _StagesRepository.UnitOfWork.SaveChangesAndDispatchEventsAsync(cancellationToken).ConfigureAwait(false);
            methodResult.Result = _mapper.Map<CreateStagesCommandResponse>(newStages);
            return methodResult;
        }
    }
}