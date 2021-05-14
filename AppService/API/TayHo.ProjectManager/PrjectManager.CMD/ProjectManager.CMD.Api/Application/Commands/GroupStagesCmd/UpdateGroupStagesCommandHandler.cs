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
    public class UpdateGroupStagesCommandHandler : GroupStagesCommandHandler, IRequestHandler<UpdateGroupStagesCommand, MethodResult<UpdateGroupStagesCommandResponse>>
    {
        public UpdateGroupStagesCommandHandler(IMapper mapper, IGroupStagesRepository GroupStagesRepository,IHttpContextAccessor httpContextAccessor) : base(mapper, GroupStagesRepository,httpContextAccessor)
        {
        }

        /// <summary>
        /// Handle for update a existing GroupStages.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<MethodResult<UpdateGroupStagesCommandResponse>> Handle(UpdateGroupStagesCommand request, CancellationToken cancellationToken)
        {
            var methodResult = new MethodResult<UpdateGroupStagesCommandResponse>();
            var existingGroupStages = await _GroupStagesRepository.SingleOrDefaultAsync(x => x.Id == request.Id && x.IsDelete == false).ConfigureAwait(false);
            if (existingGroupStages == null)
            {
                methodResult.AddAPIErrorMessage(nameof(ErrorCodeUpdate.UErr01), new[]
                {
                    ErrorHelpers.GenerateErrorResult(nameof(request.Id),request.Id)
                });
            }
            if (!methodResult.IsOk) throw new CommandHandlerException(methodResult.ErrorMessages);
            existingGroupStages.IsActive = request.IsActive.HasValue ? request.IsActive : existingGroupStages.IsActive;
            existingGroupStages.IsVisible = request.IsVisible .HasValue ? request.IsVisible : existingGroupStages.IsVisible;
            existingGroupStages.Status = request.Status.HasValue ? request.Status : existingGroupStages.Status;
            existingGroupStages.SetGroupId(request.GroupId);
            existingGroupStages.SetStageId(request.StageId);
            existingGroupStages.SetUpdate(0, 0);
            _GroupStagesRepository.Update(existingGroupStages);
            await _GroupStagesRepository.UnitOfWork.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            methodResult.Result = _mapper.Map<UpdateGroupStagesCommandResponse>(existingGroupStages);
            return methodResult;
        }
    }
}