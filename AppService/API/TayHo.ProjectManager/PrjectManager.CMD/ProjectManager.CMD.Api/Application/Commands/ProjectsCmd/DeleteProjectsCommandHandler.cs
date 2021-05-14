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

namespace  ProjectManager.CMD.Api.Application.Commands
{
    public class DeleteProjectsCommandHandler : ProjectsCommandHandler, IRequestHandler<DeleteProjectsCommand, MethodResult<DeleteProjectsCommandResponse>>
    {
        public DeleteProjectsCommandHandler(IMapper mapper, IProjectsRepository ProjectsRepository,IHttpContextAccessor httpContextAccessor) : base(mapper, httpContextAccessor, ProjectsRepository)
        {
        }

        /// <summary>
        /// Handle for deleting a existing Projects.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<MethodResult<DeleteProjectsCommandResponse>> Handle(DeleteProjectsCommand request, CancellationToken cancellationToken)
        {
            var methodResult = new MethodResult<DeleteProjectsCommandResponse>();
            var existingProjects = await _ProjectsRepository.GetAllListAsync(x => request.Ids.Contains(x.Id) && x.IsDelete == false).ConfigureAwait(false);
            if (existingProjects == null || !existingProjects.Any())
            {
                methodResult.AddAPIErrorMessage(nameof(ErrorCodeDelete.DErr001), new[]
                {
                    ErrorHelpers.GenerateErrorResult(nameof(request.Ids),string.Join(',',request.Ids))
                });
            }
            if (!methodResult.IsOk) throw new CommandHandlerException(methodResult.ErrorMessages);

            DateTime utc = DateTime.UtcNow;
            DateTime now = DateTime.Now;
            foreach (var existingProject in existingProjects)
            {
                existingProject.UpdateDate = now;
                existingProject.UpdateDateUTC = utc;
                existingProject.IsDelete = true;
                existingProject.SetUpdate(_user, null);
            }
            _ProjectsRepository.UpdateRange(existingProjects);
            await _ProjectsRepository.UnitOfWork.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            var ProjectsResponseDTOs = _mapper.Map<List<ProjectsCommandResponseDTO>>(existingProjects);
            methodResult.Result = new DeleteProjectsCommandResponse(ProjectsResponseDTOs);
            return methodResult;
        }
    }
}