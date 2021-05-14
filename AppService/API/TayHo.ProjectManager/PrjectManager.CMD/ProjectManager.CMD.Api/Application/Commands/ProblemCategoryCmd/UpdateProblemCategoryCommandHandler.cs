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
    public class UpdateProblemCategoryCommandHandler : ProblemCategoryCommandHandler,IRequestHandler<UpdateProblemCategoryCommand, MethodResult<UpdateProblemCategoryCommandResponse>>
    {
        public UpdateProblemCategoryCommandHandler(IMapper mapper, IProblemCategoryRepository ProblemCategoryRepository,IHttpContextAccessor httpContextAccessor) : base(mapper, ProblemCategoryRepository,httpContextAccessor)
        {
        }

        /// <summary>
        /// Handle for update a existing ProblemCategory.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<MethodResult<UpdateProblemCategoryCommandResponse>> Handle(UpdateProblemCategoryCommand request, CancellationToken cancellationToken)
        {
            var methodResult = new MethodResult<UpdateProblemCategoryCommandResponse>();
            var existingProblemCategory = await _ProblemCategoryRepository.SingleOrDefaultAsync(x => x.Id == request.Id && x.IsDelete == false).ConfigureAwait(false);
            if (existingProblemCategory == null)
            {
                methodResult.AddAPIErrorMessage(nameof(ErrorCodeUpdate.UErr01), new[]
                {
                    ErrorHelpers.GenerateErrorResult(nameof(request.Id),request.Id)
                });
            }
            if (!methodResult.IsOk) throw new CommandHandlerException(methodResult.ErrorMessages);
            existingProblemCategory.IsActive = request.IsActive.HasValue ? request.IsActive : existingProblemCategory.IsActive;
            existingProblemCategory.IsVisible = request.IsVisible .HasValue ? request.IsVisible : existingProblemCategory.IsVisible;
            existingProblemCategory.Status = request.Status.HasValue ? request.Status : existingProblemCategory.Status;
            existingProblemCategory.SetTitle(request.Title);
            existingProblemCategory.SetDescriptions(request.Descriptions);
            existingProblemCategory.SetPriotity(request.Priotity);
            existingProblemCategory.SetTitle(request.Title);
            existingProblemCategory.SetUpdate(_user,0);
            _ProblemCategoryRepository.Update(existingProblemCategory);
            await _ProblemCategoryRepository.UnitOfWork.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            methodResult.Result = _mapper.Map<UpdateProblemCategoryCommandResponse>(existingProblemCategory);
            return methodResult;
        }
    }
}