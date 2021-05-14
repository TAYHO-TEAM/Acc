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
    public class DeleteNS_KhauTruCommandHandler : NS_KhauTruCommandHandler, IRequestHandler<DeleteNS_KhauTruCommand, MethodResult<DeleteNS_KhauTruCommandResponse>>
    {
        public DeleteNS_KhauTruCommandHandler(IMapper mapper, INS_KhauTruRepository NS_KhauTruRepository,IHttpContextAccessor httpContextAccessor) : base(mapper, NS_KhauTruRepository,httpContextAccessor)
        {
        }

        /// <summary>
        /// Handle for deleting a existing NS_KhauTru.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<MethodResult<DeleteNS_KhauTruCommandResponse>> Handle(DeleteNS_KhauTruCommand request, CancellationToken cancellationToken)
        {
            var methodResult = new MethodResult<DeleteNS_KhauTruCommandResponse>();
            var existingNS_KhauTru = await _NS_KhauTruRepository.GetAllListAsync(x => request.Ids.Contains(x.Id) && x.IsDelete == false).ConfigureAwait(false);
            if (existingNS_KhauTru == null || !existingNS_KhauTru.Any())
            {
                methodResult.AddAPIErrorMessage(nameof(ErrorCodeDelete.DErr001), new[]
                {
                    ErrorHelpers.GenerateErrorResult(nameof(request.Ids),string.Join(',',request.Ids))
                });
            }
            if (!methodResult.IsOk) throw new CommandHandlerException(methodResult.ErrorMessages);

            DateTime utc = DateTime.UtcNow;
            DateTime now = DateTime.Now;
            foreach (var existingAssignment in existingNS_KhauTru)
            { 
                existingAssignment.UpdateDate = now;
                existingAssignment.UpdateDateUTC = utc;
                existingAssignment.IsDelete = true;
                existingAssignment.ModifyBy = 0;
                existingAssignment.SetUpdate(_user,0);
            }
            _NS_KhauTruRepository.UpdateRange(existingNS_KhauTru);
            await _NS_KhauTruRepository.UnitOfWork.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            var NS_KhauTruResponseDTOs = _mapper.Map<List<NS_KhauTruCommandResponseDTO>>(existingNS_KhauTru);
            methodResult.Result = new DeleteNS_KhauTruCommandResponse(NS_KhauTruResponseDTOs);
            return methodResult;
        }
    }
}