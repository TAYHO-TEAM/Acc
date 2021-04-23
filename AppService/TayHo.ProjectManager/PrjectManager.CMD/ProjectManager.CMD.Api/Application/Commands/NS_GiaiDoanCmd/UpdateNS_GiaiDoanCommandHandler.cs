using ProjectManager.CMD.Domain;
using ProjectManager.CMD.Domain.IRepositories;
using AutoMapper;
using MediatR;
using Services.Common.DomainObjects;
using Services.Common.DomainObjects.Exceptions;
using Services.Common.Utilities;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace  ProjectManager.CMD.Api.Application.Commands
{
    public class UpdateNS_GiaiDoanCommandHandler : NS_GiaiDoanCommandHandler,IRequestHandler<UpdateNS_GiaiDoanCommand, MethodResult<UpdateNS_GiaiDoanCommandResponse>>
    {
        public UpdateNS_GiaiDoanCommandHandler(IMapper mapper, INS_GiaiDoanRepository NS_GiaiDoanRepository, IHttpContextAccessor httpContextAccessor) : base(mapper, NS_GiaiDoanRepository, httpContextAccessor)
        {
        }

        /// <summary>
        /// Handle for update a existing NS_GiaiDoan.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<MethodResult<UpdateNS_GiaiDoanCommandResponse>> Handle(UpdateNS_GiaiDoanCommand request, CancellationToken cancellationToken)
        {
            var methodResult = new MethodResult<UpdateNS_GiaiDoanCommandResponse>();
            var existingNS_GiaiDoan = await _NS_GiaiDoanRepository.SingleOrDefaultAsync(x => x.Id == request.Id && x.IsDelete == false).ConfigureAwait(false);
            if (existingNS_GiaiDoan == null)
            {
                methodResult.AddAPIErrorMessage(nameof(ErrorCodeUpdate.UErr01), new[]
                {
                    ErrorHelpers.GenerateErrorResult(nameof(request.Id),request.Id)
                });
            }
            if (!methodResult.IsOk) throw new CommandHandlerException(methodResult.ErrorMessages);
            existingNS_GiaiDoan.IsActive = request.IsActive.HasValue ? request.IsActive : existingNS_GiaiDoan.IsActive;
            existingNS_GiaiDoan.IsVisible = request.IsVisible.HasValue ? request.IsVisible : existingNS_GiaiDoan.IsVisible;
            existingNS_GiaiDoan.Status = request.Status.HasValue ? request.Status : existingNS_GiaiDoan.Status;
            existingNS_GiaiDoan.SetTenGiaiDoan(request.TenGiaiDoan);
            existingNS_GiaiDoan.SetDienGiai(request.DienGiai);
            existingNS_GiaiDoan.SetProjectId(request.ProjectId);
            existingNS_GiaiDoan.SetGroupId(request.GroupId);
            existingNS_GiaiDoan.SetCapDo(request.CapDo);
            existingNS_GiaiDoan.SetSortIndex(request.SortIndex);
            existingNS_GiaiDoan.SetUpdate(_user, 0);
            _NS_GiaiDoanRepository.Update(existingNS_GiaiDoan);
            await _NS_GiaiDoanRepository.UnitOfWork.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            methodResult.Result = _mapper.Map<UpdateNS_GiaiDoanCommandResponse>(existingNS_GiaiDoan);
            return methodResult;
        }
    }
}