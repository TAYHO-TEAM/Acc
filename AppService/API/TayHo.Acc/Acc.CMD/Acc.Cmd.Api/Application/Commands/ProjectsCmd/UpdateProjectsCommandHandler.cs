using Acc.Cmd.Domain;
using Acc.Cmd.Domain.Repositories;
using AutoMapper;
using MediatR;
using Services.Common.DomainObjects;
using Services.Common.DomainObjects.Exceptions;
using Services.Common.Utilities;
using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace  Acc.Cmd.Api.Application.Commands
{
    public class UpdateProjectsCommandHandler : ProjectsCommandHandler,IRequestHandler<UpdateProjectsCommand, MethodResult<UpdateProjectsCommandResponse>>
    {
        public UpdateProjectsCommandHandler(IMapper mapper, IProjectsRepository accountRepository,IHttpContextAccessor httpContextAccessor) : base(mapper, httpContextAccessor, accountRepository)
        {
        }

        /// <summary>
        /// Handle for update a existing Projects.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<MethodResult<UpdateProjectsCommandResponse>> Handle(UpdateProjectsCommand request, CancellationToken cancellationToken)
        {
            var methodResult = new MethodResult<UpdateProjectsCommandResponse>();
            var existingProjects = await _ProjectsRepository.SingleOrDefaultAsync(x => x.Id == request.Id && x.IsDelete == false).ConfigureAwait(false);
            if (existingProjects == null)
            {
                methodResult.AddAPIErrorMessage(nameof(ErrorCodeUpdate.UErr01), new[]
                {
                    ErrorHelpers.GenerateErrorResult(nameof(request.Id),request.Id)
                });
            }
            if (!methodResult.IsOk) throw new CommandHandlerException(methodResult.ErrorMessages);
            existingProjects.IsActive = request.IsActive.HasValue ? request.IsActive : existingProjects.IsActive;
            existingProjects.IsVisible = request.IsVisible.HasValue ? request.IsVisible : existingProjects.IsVisible;
            existingProjects.Status = request.Status.HasValue ? request.Status : existingProjects.Status;
            existingProjects.SetCode(request.Code);
            existingProjects.SetBarCode(request.BarCode);
            existingProjects.SetTitle(request.Title);
            existingProjects.SetDescriptions(request.Descriptions);
            existingProjects.SetParentId(request.ParentId);
            existingProjects.SetNodeLevel(request.NodeLevel);
            existingProjects.SetOldId(request.OldId);

            existingProjects.SetUpdate(_user,null);
            _ProjectsRepository.Update(existingProjects);
            await _ProjectsRepository.UnitOfWork.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            methodResult.Result = _mapper.Map<UpdateProjectsCommandResponse>(existingProjects);
            return methodResult;
        }
    }
}