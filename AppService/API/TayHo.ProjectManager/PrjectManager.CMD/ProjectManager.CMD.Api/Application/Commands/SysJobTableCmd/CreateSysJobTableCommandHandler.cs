using ProjectManager.CMD.Domain.DomainObjects;
using ProjectManager.CMD.Domain.IRepositories;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using MediatR;
using Services.Common.DomainObjects;
using System.Threading;
using System.Threading.Tasks;

namespace ProjectManager.CMD.Api.Application.Commands
{
    public class CreateSysJobTableCommandHandler : SysJobTableCommandHandler, IRequestHandler<CreateSysJobTableCommand, MethodResult<CreateSysJobTableCommandResponse>>
    {
        public CreateSysJobTableCommandHandler(IMapper mapper, IHttpContextAccessor httpContextAccessor, ISysJobTableRepository sysJobTableRepository) : base(mapper, httpContextAccessor, sysJobTableRepository)
        {
        }

        /// <summary>
        /// Handle for creating a new SysJobTable
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<MethodResult<CreateSysJobTableCommandResponse>> Handle(CreateSysJobTableCommand request, CancellationToken cancellationToken)
        {
            var methodResult = new MethodResult<CreateSysJobTableCommandResponse>();
            var newSysJobTable = new SysJobTable(request.SysJobId, request.No, request.Name, request.IsHeader, request.HeaderColor, request.HeaderBackGroundColor, request.Border, request.Color, request.BackGroundColor, request.BeginRow, request.BeginCol, request.Priority, request.Style);
            newSysJobTable.SetCreate(_user);
            newSysJobTable.Status = request.Status.HasValue ? request.Status : newSysJobTable.Status;
            newSysJobTable.IsActive = request.IsActive.HasValue ? request.IsActive : newSysJobTable.IsActive;
            newSysJobTable.IsVisible = request.IsVisible.HasValue ? request.IsVisible : newSysJobTable.IsVisible;
            await _sysJobTableRepository.AddAsync(newSysJobTable).ConfigureAwait(false);
            await _sysJobTableRepository.UnitOfWork.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            methodResult.Result = _mapper.Map<CreateSysJobTableCommandResponse>(newSysJobTable);
            return methodResult;
        }
    }
}
