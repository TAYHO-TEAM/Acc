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
    public class UpdateCustomCellContentCommandHandler : CustomCellContentCommandHandler,IRequestHandler<UpdateCustomCellContentCommand, MethodResult<UpdateCustomCellContentCommandResponse>>
    {
        public UpdateCustomCellContentCommandHandler(IMapper mapper, ICustomCellContentRepository CustomCellContentRepository,IHttpContextAccessor httpContextAccessor) : base(mapper, CustomCellContentRepository,httpContextAccessor)
        {
        }

        /// <summary>
        /// Handle for update a existing CustomCellContent.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<MethodResult<UpdateCustomCellContentCommandResponse>> Handle(UpdateCustomCellContentCommand request, CancellationToken cancellationToken)
        {
            var methodResult = new MethodResult<UpdateCustomCellContentCommandResponse>();
            var existingCustomCellContent = await _customCellContentRepository.SingleOrDefaultAsync(x => x.Id == request.Id && x.IsDelete == false).ConfigureAwait(false);
            if (existingCustomCellContent == null)
            {
                methodResult.AddAPIErrorMessage(nameof(ErrorCodeUpdate.UErr01), new[]
                {
                    ErrorHelpers.GenerateErrorResult(nameof(request.Id),request.Id)
                });
            }
            if (!methodResult.IsOk) throw new CommandHandlerException(methodResult.ErrorMessages);
            existingCustomCellContent.IsActive = request.IsActive.HasValue ? request.IsActive : existingCustomCellContent.IsActive;
            existingCustomCellContent.IsVisible = request.IsVisible .HasValue ? request.IsVisible : existingCustomCellContent.IsVisible;
            existingCustomCellContent.Status = request.Status.HasValue ? request.Status : existingCustomCellContent.Status;



            existingCustomCellContent.SetCustomFormContentId(request.CustomFormContentId);
            existingCustomCellContent.SetCustomFormBodyId(request.CustomFormBodyId);
            existingCustomCellContent.SetCustomColumId(request.CustomColumId);
            existingCustomCellContent.SetContents(request.Contents);
            existingCustomCellContent.SetNoRown(request.NoRown);

            existingCustomCellContent.SetUpdate(_user,0);
            _customCellContentRepository.Update(existingCustomCellContent);
            await _customCellContentRepository.UnitOfWork.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            methodResult.Result = _mapper.Map<UpdateCustomCellContentCommandResponse>(existingCustomCellContent);
            return methodResult;
        }
    }
}