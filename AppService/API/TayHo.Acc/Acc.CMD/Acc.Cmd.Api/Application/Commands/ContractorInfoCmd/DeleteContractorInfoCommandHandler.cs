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
    public class DeleteContractorInfoCommandHandler : ContractorInfoCommandHandler, IRequestHandler<DeleteContractorInfoCommand, MethodResult<DeleteContractorInfoCommandResponse>>
    {
        public DeleteContractorInfoCommandHandler(IMapper mapper, IContractorInfoRepository ContractorInfoRepository,IHttpContextAccessor httpContextAccessor) : base(mapper, httpContextAccessor, ContractorInfoRepository)
        {
        }

        /// <summary>
        /// Handle for deleting a existing ContractorInfo.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<MethodResult<DeleteContractorInfoCommandResponse>> Handle(DeleteContractorInfoCommand request, CancellationToken cancellationToken)
        {
            var methodResult = new MethodResult<DeleteContractorInfoCommandResponse>();
            var existingContractorInfos = await _ContractorInfoRepository.GetAllListAsync(x => request.Ids.Contains(x.Id) && x.IsDelete == false).ConfigureAwait(false);
            if (existingContractorInfos == null || !existingContractorInfos.Any())
            {
                methodResult.AddAPIErrorMessage(nameof(ErrorCodeDelete.DErr001), new[]
                {
                    ErrorHelpers.GenerateErrorResult(nameof(request.Ids),string.Join(',',request.Ids))
                });
            }
            if (!methodResult.IsOk) throw new CommandHandlerException(methodResult.ErrorMessages);

            DateTime utc = DateTime.UtcNow;
            DateTime now = DateTime.Now;
            foreach (var existingContractorInfo in existingContractorInfos)
            {
                existingContractorInfo.UpdateDate = now;
                existingContractorInfo.UpdateDateUTC = utc;
                existingContractorInfo.IsDelete = true;
                existingContractorInfo.SetUpdate(_user, null);

            }
            _ContractorInfoRepository.UpdateRange(existingContractorInfos);
            await _ContractorInfoRepository.UnitOfWork.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            var ContractorInfoResponseDTOs = _mapper.Map<List<ContractorInfoCommandResponseDTO>>(existingContractorInfos);
            methodResult.Result = new DeleteContractorInfoCommandResponse(ContractorInfoResponseDTOs);
            return methodResult;
        }
    }
}