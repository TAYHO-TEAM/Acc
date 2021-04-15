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

namespace ProjectManager.CMD.Api.Application.Commands
{
    public class UpdateSysJobColumCommandHandler : SysJobColumCommandHandler, IRequestHandler<UpdateSysJobColumCommand, MethodResult<UpdateSysJobColumCommandResponse>>
    {
        public UpdateSysJobColumCommandHandler(IMapper mapper, IHttpContextAccessor httpContextAccessor, ISysJobColumRepository sysJobColumRepository) : base(mapper, httpContextAccessor, sysJobColumRepository)
        {
        }

        /// <summary>
        /// Handle for update a existing SysJobColum.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<MethodResult<UpdateSysJobColumCommandResponse>> Handle(UpdateSysJobColumCommand request, CancellationToken cancellationToken)
        {
            var methodResult = new MethodResult<UpdateSysJobColumCommandResponse>();
            var existingSysJobColum = await _sysJobColumRepository.SingleOrDefaultAsync(x => x.Id == request.Id && x.IsDelete == false).ConfigureAwait(false);
            if (existingSysJobColum == null)
            {
                methodResult.AddAPIErrorMessage(nameof(ErrorCodeUpdate.UErr01), new[]
                {
                    ErrorHelpers.GenerateErrorResult(nameof(request.Id),request.Id)
                });
            }
            if (!methodResult.IsOk) throw new CommandHandlerException(methodResult.ErrorMessages);
            existingSysJobColum.IsActive = request.IsActive.HasValue ? request.IsActive : existingSysJobColum.IsActive;
            existingSysJobColum.IsVisible = request.IsVisible.HasValue ? request.IsVisible : existingSysJobColum.IsVisible;
            existingSysJobColum.Status = request.Status.HasValue ? request.Status : existingSysJobColum.Status;

            existingSysJobColum.SetNoCol(request.NoCol);
            existingSysJobColum.SetSysJobTableId(request.SysJobTableId);
            existingSysJobColum.SetStyle(request.Style);
            existingSysJobColum.SetFormulas(request.Formulas);
            existingSysJobColum.SetFunctions(request.Functions);


            existingSysJobColum.SetUpdate(_user, null);
            _sysJobColumRepository.Update(existingSysJobColum);
            await _sysJobColumRepository.UnitOfWork.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            methodResult.Result = _mapper.Map<UpdateSysJobColumCommandResponse>(existingSysJobColum);
            return methodResult;
        }
    }
}
