using Acc.Cmd.Domain;
using Acc.Cmd.Domain.Repositories;
using AutoMapper;using Microsoft.AspNetCore.Http;
using MediatR;
using Services.Common.DomainObjects;
using Services.Common.DomainObjects.Exceptions;
using Services.Common.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace  Acc.Cmd.Api.Application.Commands
{
    public class DeleteCategorysCommandHandler : CategorysCommandHandler, IRequestHandler<DeleteCategorysCommand, MethodResult<DeleteCategorysCommandResponse>>
    {
        public DeleteCategorysCommandHandler(IMapper mapper, ICategorysRepository CategorysRepository,IHttpContextAccessor httpContextAccessor) : base(mapper, httpContextAccessor, CategorysRepository)
        {
        }

        /// <summary>
        /// Handle for deleting a existing Categorys.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<MethodResult<DeleteCategorysCommandResponse>> Handle(DeleteCategorysCommand request, CancellationToken cancellationToken)
        {
            var methodResult = new MethodResult<DeleteCategorysCommandResponse>();
            var existingCategoryss = await _CategorysRepository.GetAllListAsync(x => request.Ids.Contains(x.Id) && x.IsDelete == false).ConfigureAwait(false);
            if (existingCategoryss == null || !existingCategoryss.Any())
            {
                methodResult.AddAPIErrorMessage(nameof(ErrorCodeDelete.DErr001), new[]
                {
                    ErrorHelpers.GenerateErrorResult(nameof(request.Ids),string.Join(',',request.Ids))
                });
            }
            if (!methodResult.IsOk) throw new CommandHandlerException(methodResult.ErrorMessages);

            DateTime utc = DateTime.UtcNow;
            DateTime now = DateTime.Now;
            foreach (var existingCategorys in existingCategoryss)
            {
                existingCategorys.UpdateDate = now;
                existingCategorys.UpdateDateUTC = utc;
                existingCategorys.IsDelete = true;
                existingCategorys.SetUpdate(_user, null);

            }
            _CategorysRepository.UpdateRange(existingCategoryss);
            await _CategorysRepository.UnitOfWork.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            var CategorysResponseDTOs = _mapper.Map<List<CategorysCommandResponseDTO>>(existingCategoryss);
            methodResult.Result = new DeleteCategorysCommandResponse(CategorysResponseDTOs);
            return methodResult;
        }
    }
}