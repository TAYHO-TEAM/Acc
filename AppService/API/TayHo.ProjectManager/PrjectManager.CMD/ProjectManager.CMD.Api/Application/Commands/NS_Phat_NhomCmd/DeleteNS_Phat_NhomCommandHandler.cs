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
    public class DeleteNS_Phat_NhomCommandHandler : NS_Phat_NhomCommandHandler, IRequestHandler<DeleteNS_Phat_NhomCommand, MethodResult<DeleteNS_Phat_NhomCommandResponse>>
    {
        public DeleteNS_Phat_NhomCommandHandler(IMapper mapper, INS_Phat_NhomRepository NS_Phat_NhomRepository,IHttpContextAccessor httpContextAccessor) : base(mapper, NS_Phat_NhomRepository,httpContextAccessor)
        {
        }

        /// <summary>
        /// Handle for deleting a existing NS_Phat_Nhom.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<MethodResult<DeleteNS_Phat_NhomCommandResponse>> Handle(DeleteNS_Phat_NhomCommand request, CancellationToken cancellationToken)
        {
            var methodResult = new MethodResult<DeleteNS_Phat_NhomCommandResponse>();
            var existingNS_Phat_Nhom = await _NS_Phat_NhomRepository.GetAllListAsync(x => request.Ids.Contains(x.Id) && x.IsDelete == false).ConfigureAwait(false);
            if (existingNS_Phat_Nhom == null || !existingNS_Phat_Nhom.Any())
            {
                methodResult.AddAPIErrorMessage(nameof(ErrorCodeDelete.DErr001), new[]
                {
                    ErrorHelpers.GenerateErrorResult(nameof(request.Ids),string.Join(',',request.Ids))
                });
            }
            if (!methodResult.IsOk) throw new CommandHandlerException(methodResult.ErrorMessages);

            DateTime utc = DateTime.UtcNow;
            DateTime now = DateTime.Now;
            foreach (var existingAssignment in existingNS_Phat_Nhom)
            { 
                existingAssignment.UpdateDate = now;
                existingAssignment.UpdateDateUTC = utc;
                existingAssignment.IsDelete = true;
                existingAssignment.ModifyBy = 0;
                existingAssignment.SetUpdate(_user,0);
            }
            _NS_Phat_NhomRepository.UpdateRange(existingNS_Phat_Nhom);
            await _NS_Phat_NhomRepository.UnitOfWork.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            var NS_Phat_NhomResponseDTOs = _mapper.Map<List<NS_Phat_NhomCommandResponseDTO>>(existingNS_Phat_Nhom);
            methodResult.Result = new DeleteNS_Phat_NhomCommandResponse(NS_Phat_NhomResponseDTOs);
            return methodResult;
        }
    }
}