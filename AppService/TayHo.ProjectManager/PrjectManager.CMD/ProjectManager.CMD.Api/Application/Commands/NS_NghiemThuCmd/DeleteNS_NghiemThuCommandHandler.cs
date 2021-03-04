using ProjectManager.CMD.Domain;
using ProjectManager.CMD.Domain.IRepositories;
using AutoMapper;
using MediatR;
using Services.Common.DomainObjects;
using Services.Common.DomainObjects.Exceptions;
using Services.Common.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace ProjectManager.CMD.Api.Application.Commands
{
    public class DeleteNS_NghiemThuCommandHandler : NS_NghiemThuCommandHandler, IRequestHandler<DeleteNS_NghiemThuCommand, MethodResult<DeleteNS_NghiemThuCommandResponse>>
    {
        public DeleteNS_NghiemThuCommandHandler(IMapper mapper, INS_NghiemThuRepository NS_NghiemThuRepository, IHttpContextAccessor httpContextAccessor) : base(mapper, NS_NghiemThuRepository, httpContextAccessor)
        {
        }

        /// <summary>
        /// Handle for deleting a existing NS_NghiemThu.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<MethodResult<DeleteNS_NghiemThuCommandResponse>> Handle(DeleteNS_NghiemThuCommand request, CancellationToken cancellationToken)
        {
            var methodResult = new MethodResult<DeleteNS_NghiemThuCommandResponse>();
            var existingNS_NghiemThus = await _nS_NghiemThuRepository.GetAllListAsync(x => request.Ids.Contains(x.Id) && x.IsDelete == false).ConfigureAwait(false);
            if (existingNS_NghiemThus == null || !existingNS_NghiemThus.Any())
            {
                methodResult.AddAPIErrorMessage(nameof(ErrorCodeDelete.DErr001), new[]
                {
                    ErrorHelpers.GenerateErrorResult(nameof(request.Ids),string.Join(',',request.Ids))
                });
            }
            if (!methodResult.IsOk) throw new CommandHandlerException(methodResult.ErrorMessages);

            DateTime utc = DateTime.UtcNow;
            DateTime now = DateTime.Now;
            foreach (var existingNS_NghiemThu in existingNS_NghiemThus)
            {
                existingNS_NghiemThu.UpdateDate = now;
                existingNS_NghiemThu.UpdateDateUTC = utc;
                existingNS_NghiemThu.IsDelete = true;
                existingNS_NghiemThu.SetUpdate(_user, null);
            }
            _nS_NghiemThuRepository.UpdateRange(existingNS_NghiemThus);
            await _nS_NghiemThuRepository.UnitOfWork.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            var NS_NghiemThuResponseDTOs = _mapper.Map<List<NS_NghiemThuCommandResponseDTO>>(existingNS_NghiemThus);
            methodResult.Result = new DeleteNS_NghiemThuCommandResponse(NS_NghiemThuResponseDTOs);
            return methodResult;
        }
    }
}
