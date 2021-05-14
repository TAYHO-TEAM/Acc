using Acc.Cmd.Domain.DomainObjects;
using Acc.Cmd.Domain.Repositories;
using AutoMapper;
using MediatR;
using Services.Common.DomainObjects;
using System.Threading;
using System.Threading.Tasks;

namespace  Acc.Cmd.Api.Application.Commands
{
    public class CreateStagesCommandHandler : StagesCommandHandler, IRequestHandler<CreateStagesCommand, MethodResult<CreateStagesCommandResponse>>
    {
        public CreateStagesCommandHandler(IMapper mapper, IStagesRepository StagesRepository) : base(mapper, StagesRepository)
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
            var newStages = new Stages(request.ActionId,
                                                request.ParentId,
                                                request.Title,
                                                request.Descriptions,
                                                request.Icon,
                                                request.Url,
                                                request.CategoryId,
                                                request.Level);
            newStages.Status = request.Status.HasValue ? request.Status : newStages.Status;
            newStages.IsActive = request.IsActive.HasValue ? request.IsActive : newStages.IsActive;
            newStages.IsVisible = request.IsActive.HasValue ? request.IsVisible : newStages.IsVisible;
            await _StagesRepository.AddAsync(newStages).ConfigureAwait(false);
            await _StagesRepository.UnitOfWork.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            methodResult.Result = _mapper.Map<CreateStagesCommandResponse>(newStages);
            return methodResult;
        }
    }
}