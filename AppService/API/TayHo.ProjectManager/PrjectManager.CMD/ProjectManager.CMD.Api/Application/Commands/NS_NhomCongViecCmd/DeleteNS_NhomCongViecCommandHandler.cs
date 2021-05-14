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
    public class DeleteNS_NhomCongViecCommandHandler : NS_NhomCongViecCommandHandler, IRequestHandler<DeleteNS_NhomCongViecCommand, MethodResult<DeleteNS_NhomCongViecCommandResponse>>
    {
        public DeleteNS_NhomCongViecCommandHandler(IMapper mapper, INS_NhomCongViecRepository NS_NhomCongViecRepository,IHttpContextAccessor httpContextAccessor) : base(mapper, NS_NhomCongViecRepository,httpContextAccessor)
        {
        }

        /// <summary>
        /// Handle for deleting a existing NS_NhomCongViec.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<MethodResult<DeleteNS_NhomCongViecCommandResponse>> Handle(DeleteNS_NhomCongViecCommand request, CancellationToken cancellationToken)
        {
            var methodResult = new MethodResult<DeleteNS_NhomCongViecCommandResponse>();
            var existingNS_NhomCongViec = await _NS_NhomCongViecRepository.GetAllListAsync(x => request.Ids.Contains(x.Id) && x.IsDelete == false).ConfigureAwait(false);
            if (existingNS_NhomCongViec == null || !existingNS_NhomCongViec.Any())
            {
                methodResult.AddAPIErrorMessage(nameof(ErrorCodeDelete.DErr001), new[]
                {
                    ErrorHelpers.GenerateErrorResult(nameof(request.Ids),string.Join(',',request.Ids))
                });
            }
            if (!methodResult.IsOk) throw new CommandHandlerException(methodResult.ErrorMessages);

            DateTime utc = DateTime.UtcNow;
            DateTime now = DateTime.Now;
            foreach (var existingAssignment in existingNS_NhomCongViec)
            {
                existingAssignment.UpdateDate = now;
                existingAssignment.UpdateDateUTC = utc;
                existingAssignment.IsDelete = true;
                existingAssignment.ModifyBy = 0;
                existingAssignment.SetUpdate(_user,0);
            }
            _NS_NhomCongViecRepository.UpdateRange(existingNS_NhomCongViec);
            await _NS_NhomCongViecRepository.UnitOfWork.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            var NS_NhomCongViecResponseDTOs = _mapper.Map<List<NS_NhomCongViecCommandResponseDTO>>(existingNS_NhomCongViec);
            methodResult.Result = new DeleteNS_NhomCongViecCommandResponse(NS_NhomCongViecResponseDTOs);
            return methodResult;
        }
    }
}