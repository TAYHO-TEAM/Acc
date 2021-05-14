using ProjectManager.CMD.Domain;
using ProjectManager.CMD.Domain.IRepositories;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using MediatR;
using Services.Common.DomainObjects;
using Services.Common.DomainObjects.Exceptions;
using Services.Common.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace  ProjectManager.CMD.Api.Application.Commands
{
    public class DeleteProblemCategoryCommandHandler : ProblemCategoryCommandHandler, IRequestHandler<DeleteProblemCategoryCommand, MethodResult<DeleteProblemCategoryCommandResponse>>
    {
        public DeleteProblemCategoryCommandHandler(IMapper mapper, IProblemCategoryRepository ProblemCategoryRepository,IHttpContextAccessor httpContextAccessor) : base(mapper, ProblemCategoryRepository,httpContextAccessor)
        {
        }

        /// <summary>
        /// Handle for deleting a existing ProblemCategory.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<MethodResult<DeleteProblemCategoryCommandResponse>> Handle(DeleteProblemCategoryCommand request, CancellationToken cancellationToken)
        {
            var methodResult = new MethodResult<DeleteProblemCategoryCommandResponse>();
            var existingProblemCategorys = await _ProblemCategoryRepository.GetAllListAsync(x => request.Ids.Contains(x.Id) && x.IsDelete == false).ConfigureAwait(false);
            if (existingProblemCategorys == null || !existingProblemCategorys.Any())
            {
                methodResult.AddAPIErrorMessage(nameof(ErrorCodeDelete.DErr001), new[]
                {
                    ErrorHelpers.GenerateErrorResult(nameof(request.Ids),string.Join(',',request.Ids))
                });
            }
            if (!methodResult.IsOk) throw new CommandHandlerException(methodResult.ErrorMessages);

            DateTime utc = DateTime.UtcNow;
            DateTime now = DateTime.Now;
            foreach (var existingProblemCategory in existingProblemCategorys)
            {
                existingProblemCategory.UpdateDate = now;
                existingProblemCategory.UpdateDateUTC = utc;
                existingProblemCategory.IsDelete = true;
                existingProblemCategory.ModifyBy = 0;
                existingProblemCategory.SetUpdate(_user,0);
            }
            _ProblemCategoryRepository.UpdateRange(existingProblemCategorys);
            await _ProblemCategoryRepository.UnitOfWork.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            var ProblemCategoryResponseDTOs = _mapper.Map<List<ProblemCategoryCommandResponseDTO>>(existingProblemCategorys);
            methodResult.Result = new DeleteProblemCategoryCommandResponse(ProblemCategoryResponseDTOs);
            return methodResult;
        }
    }
}