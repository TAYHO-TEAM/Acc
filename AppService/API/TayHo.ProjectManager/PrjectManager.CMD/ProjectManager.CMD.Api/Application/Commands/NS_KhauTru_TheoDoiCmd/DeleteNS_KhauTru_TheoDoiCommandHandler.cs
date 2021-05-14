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
    public class DeleteNS_KhauTru_TheoDoiCommandHandler : NS_KhauTru_TheoDoiCommandHandler, IRequestHandler<DeleteNS_KhauTru_TheoDoiCommand, MethodResult<DeleteNS_KhauTru_TheoDoiCommandResponse>>
    {
        public DeleteNS_KhauTru_TheoDoiCommandHandler(IMapper mapper, INS_KhauTru_TheoDoiRepository NS_KhauTru_TheoDoiRepository,IHttpContextAccessor httpContextAccessor) : base(mapper, NS_KhauTru_TheoDoiRepository,httpContextAccessor)
        {
        }

        /// <summary>
        /// Handle for deleting a existing NS_KhauTru_TheoDoi.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<MethodResult<DeleteNS_KhauTru_TheoDoiCommandResponse>> Handle(DeleteNS_KhauTru_TheoDoiCommand request, CancellationToken cancellationToken)
        {
            var methodResult = new MethodResult<DeleteNS_KhauTru_TheoDoiCommandResponse>();
            var existingNS_KhauTru_TheoDoi = await _NS_KhauTru_TheoDoiRepository.GetAllListAsync(x => request.Ids.Contains(x.Id) && x.IsDelete == false).ConfigureAwait(false);
            if (existingNS_KhauTru_TheoDoi == null || !existingNS_KhauTru_TheoDoi.Any())
            {
                methodResult.AddAPIErrorMessage(nameof(ErrorCodeDelete.DErr001), new[]
                {
                    ErrorHelpers.GenerateErrorResult(nameof(request.Ids),string.Join(',',request.Ids))
                });
            }
            if (!methodResult.IsOk) throw new CommandHandlerException(methodResult.ErrorMessages);

            DateTime utc = DateTime.UtcNow;
            DateTime now = DateTime.Now;
            foreach (var existingAssignment in existingNS_KhauTru_TheoDoi)
            { 
                existingAssignment.UpdateDate = now;
                existingAssignment.UpdateDateUTC = utc;
                existingAssignment.IsDelete = true;
                existingAssignment.ModifyBy = 0;
                existingAssignment.SetUpdate(_user,0);
            }
            _NS_KhauTru_TheoDoiRepository.UpdateRange(existingNS_KhauTru_TheoDoi);
            await _NS_KhauTru_TheoDoiRepository.UnitOfWork.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            var NS_KhauTru_TheoDoiResponseDTOs = _mapper.Map<List<NS_KhauTru_TheoDoiCommandResponseDTO>>(existingNS_KhauTru_TheoDoi);
            methodResult.Result = new DeleteNS_KhauTru_TheoDoiCommandResponse(NS_KhauTru_TheoDoiResponseDTOs);
            return methodResult;
        }
    }
}