using Acc.Cmd.Domain;
using Acc.Cmd.Domain.Repositories;
using AutoMapper;
using MediatR;
using Services.Common.DomainObjects;
using Services.Common.DomainObjects.Exceptions;
using Services.Common.Utilities;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace  Acc.Cmd.Api.Application.Commands
{
    public class UpdateStagesCommandHandler : StagesCommandHandler,IRequestHandler<UpdateStagesCommand, MethodResult<UpdateStagesCommandResponse>>
    {
        public UpdateStagesCommandHandler(IMapper mapper, IStagesRepository accountRepository) : base(mapper, accountRepository)
        {
        }

        /// <summary>
        /// Handle for update a existing Stages.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<MethodResult<UpdateStagesCommandResponse>> Handle(UpdateStagesCommand request, CancellationToken cancellationToken)
        {
            var methodResult = new MethodResult<UpdateStagesCommandResponse>();
            var existingStages = await _StagesRepository.SingleOrDefaultAsync(x => x.Id == request.Id && x.IsDelete == false).ConfigureAwait(false);
            if (existingStages == null)
            {
                methodResult.AddAPIErrorMessage(nameof(ErrorCodeUpdate.UErr01), new[]
                {
                    ErrorHelpers.GenerateErrorResult(nameof(request.Id),request.Id)
                });
            }
            if (!methodResult.IsOk) throw new CommandHandlerException(methodResult.ErrorMessages);
            existingStages.SetActionId(request.ActionId);
            existingStages.SetParentId(request.ParentId);
            existingStages.SetTitle(request.Title);
            existingStages.SetDescriptions(request.Descriptions);
            existingStages.SetIcon(request.Icon);
            existingStages.SetUrl(request.Url);
            existingStages.SetCategoryId(request.CategoryId);
            existingStages.SetLevel(request.Level);

            existingStages.SetUpdate(0,0);
            _StagesRepository.Update(existingStages);
            await _StagesRepository.UnitOfWork.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            methodResult.Result = _mapper.Map<UpdateStagesCommandResponse>(existingStages);
            return methodResult;
        }
    }
}