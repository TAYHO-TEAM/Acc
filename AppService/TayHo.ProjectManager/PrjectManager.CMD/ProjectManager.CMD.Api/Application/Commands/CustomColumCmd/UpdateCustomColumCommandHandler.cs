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
    public class UpdateCustomColumCommandHandler : CustomColumCommandHandler,IRequestHandler<UpdateCustomColumCommand, MethodResult<UpdateCustomColumCommandResponse>>
    {
        public UpdateCustomColumCommandHandler(IMapper mapper, ICustomColumRepository CustomColumRepository,IHttpContextAccessor httpContextAccessor) : base(mapper, CustomColumRepository,httpContextAccessor)
        {
        }

        /// <summary>
        /// Handle for update a existing CustomColum.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<MethodResult<UpdateCustomColumCommandResponse>> Handle(UpdateCustomColumCommand request, CancellationToken cancellationToken)
        {
            var methodResult = new MethodResult<UpdateCustomColumCommandResponse>();
            var existingCustomColum = await _customColumRepository.SingleOrDefaultAsync(x => x.Id == request.Id && x.IsDelete == false).ConfigureAwait(false);
            if (existingCustomColum == null)
            {
                methodResult.AddAPIErrorMessage(nameof(ErrorCodeUpdate.UErr01), new[]
                {
                    ErrorHelpers.GenerateErrorResult(nameof(request.Id),request.Id)
                });
            }
            if (!methodResult.IsOk) throw new CommandHandlerException(methodResult.ErrorMessages);
            existingCustomColum.IsActive = request.IsActive.HasValue ? request.IsActive : existingCustomColum.IsActive;
            existingCustomColum.IsVisible = request.IsVisible .HasValue ? request.IsVisible : existingCustomColum.IsVisible;
            existingCustomColum.Status = request.Status.HasValue ? request.Status : existingCustomColum.Status;



            existingCustomColum.SetCustomTableId(request.CustomTableId);
            existingCustomColum.SetColIndex(request.ColIndex);
            existingCustomColum.SetHeader(request.Header);
            existingCustomColum.SetTypeParam(request.TypeParam);
            existingCustomColum.SetStyle(request.Style);
            existingCustomColum.SetSourceValue(request.SourceValue);
            existingCustomColum.SetSourceLink(request.SourceLink);

            existingCustomColum.SetUpdate(_user,0);
            _customColumRepository.Update(existingCustomColum);
            await _customColumRepository.UnitOfWork.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            methodResult.Result = _mapper.Map<UpdateCustomColumCommandResponse>(existingCustomColum);
            return methodResult;
        }
    }
}