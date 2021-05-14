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
    public class UpdateSysJobTableCommandHandler : SysJobTableCommandHandler,IRequestHandler<UpdateSysJobTableCommand, MethodResult<UpdateSysJobTableCommandResponse>>
    {
        public UpdateSysJobTableCommandHandler(IMapper mapper,IHttpContextAccessor httpContextAccessor, ISysJobTableRepository sysJobTableRepository) : base(mapper,httpContextAccessor,sysJobTableRepository)
        {
        }

        /// <summary>
        /// Handle for update a existing SysJobTable.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<MethodResult<UpdateSysJobTableCommandResponse>> Handle(UpdateSysJobTableCommand request, CancellationToken cancellationToken)
        {
            var methodResult = new MethodResult<UpdateSysJobTableCommandResponse>();
            var existingSysJobTable = await _sysJobTableRepository.SingleOrDefaultAsync(x => x.Id == request.Id && x.IsDelete == false).ConfigureAwait(false);
            if (existingSysJobTable == null)
            {
                methodResult.AddAPIErrorMessage(nameof(ErrorCodeUpdate.UErr01), new[]
                {
                    ErrorHelpers.GenerateErrorResult(nameof(request.Id),request.Id)
                });
            }
            if (!methodResult.IsOk) throw new CommandHandlerException(methodResult.ErrorMessages);
            existingSysJobTable.IsActive = request.IsActive.HasValue ? request.IsActive : existingSysJobTable.IsActive;
            existingSysJobTable.IsVisible = request.IsVisible.HasValue ? request.IsVisible : existingSysJobTable.IsVisible;
            existingSysJobTable.Status = request.Status.HasValue ? request.Status : existingSysJobTable.Status;

            existingSysJobTable.SetSysJobId(request.SysJobId);
	existingSysJobTable.SetNo(request.No);
			existingSysJobTable.SetName(request.Name);
			existingSysJobTable.SetIsHeader(request.IsHeader);
			existingSysJobTable.SetHeaderColor(request.HeaderColor);
			existingSysJobTable.SetHeaderBackGroundColor(request.HeaderBackGroundColor);
			existingSysJobTable.SetBorder(request.Border);
			existingSysJobTable.SetColor(request.Color);
			existingSysJobTable.SetBackGroundColor(request.BackGroundColor);
			existingSysJobTable.SetBeginRow(request.BeginRow);
			existingSysJobTable.SetBeginCol(request.BeginCol);
			existingSysJobTable.SetPriority(request.Priority);
			existingSysJobTable.SetStyle(request.Style);
			

            existingSysJobTable.SetUpdate(_user,null);
            _sysJobTableRepository.Update(existingSysJobTable);
            await _sysJobTableRepository.UnitOfWork.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            methodResult.Result = _mapper.Map<UpdateSysJobTableCommandResponse>(existingSysJobTable);
            return methodResult;
        }
    }
}
