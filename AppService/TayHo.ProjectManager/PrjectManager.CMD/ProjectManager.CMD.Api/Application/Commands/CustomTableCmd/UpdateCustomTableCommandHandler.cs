using ProjectManager.CMD.Domain;
using ProjectManager.CMD.Domain.IRepositories;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using MediatR;
using Services.Common.DomainObjects;
using Services.Common.DomainObjects.Exceptions;
using Services.Common.Utilities;
using System.Threading;
using System.Threading.Tasks;

namespace  ProjectManager.CMD.Api.Application.Commands
{
    public class UpdateCustomTableCommandHandler : CustomTableCommandHandler,IRequestHandler<UpdateCustomTableCommand, MethodResult<UpdateCustomTableCommandResponse>>
    {
        public UpdateCustomTableCommandHandler(IMapper mapper, ICustomTableRepository CustomTableRepository,IHttpContextAccessor httpContextAccessor) : base(mapper, CustomTableRepository,httpContextAccessor)
        {
        }

        /// <summary>
        /// Handle for update a existing CustomTable.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<MethodResult<UpdateCustomTableCommandResponse>> Handle(UpdateCustomTableCommand request, CancellationToken cancellationToken)
        {
            var methodResult = new MethodResult<UpdateCustomTableCommandResponse>();
            var existingCustomTable = await _customTableRepository.SingleOrDefaultAsync(x => x.Id == request.Id && x.IsDelete == false).ConfigureAwait(false);
            if (existingCustomTable == null)
            {
                methodResult.AddAPIErrorMessage(nameof(ErrorCodeUpdate.UErr01), new[]
                {
                    ErrorHelpers.GenerateErrorResult(nameof(request.Id),request.Id)
                });
            }
            if (!methodResult.IsOk) throw new CommandHandlerException(methodResult.ErrorMessages);
            existingCustomTable.IsActive = request.IsActive.HasValue ? request.IsActive : existingCustomTable.IsActive;
            existingCustomTable.IsVisible = request.IsVisible .HasValue ? request.IsVisible : existingCustomTable.IsVisible;
            existingCustomTable.Status = request.Status.HasValue ? request.Status : existingCustomTable.Status;
            existingCustomTable.SetTitle(request.Title);


            existingCustomTable.SetCode(request.Code);
            existingCustomTable.SetTitle(request.Title);
            existingCustomTable.SetNoColum(request.NoColum);
            existingCustomTable.SetNoRown(request.NoRown);
            existingCustomTable.SetStyle(request.Style);
            existingCustomTable.SetPriority(request.Priority);

            existingCustomTable.SetUpdate(_user,0);
            _customTableRepository.Update(existingCustomTable);
            await _customTableRepository.UnitOfWork.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            methodResult.Result = _mapper.Map<UpdateCustomTableCommandResponse>(existingCustomTable);
            return methodResult;
        }
    }
}