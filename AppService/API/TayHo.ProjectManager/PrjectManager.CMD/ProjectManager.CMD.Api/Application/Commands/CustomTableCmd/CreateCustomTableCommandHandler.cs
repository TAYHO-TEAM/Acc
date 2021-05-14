using ProjectManager.CMD.Domain.DomainObjects;
using ProjectManager.CMD.Domain.IRepositories;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using MediatR;
using Services.Common.DomainObjects;
using System.Threading;
using System.Threading.Tasks;

namespace  ProjectManager.CMD.Api.Application.Commands
{
    public class CreateCustomTableCommandHandler : CustomTableCommandHandler, IRequestHandler<CreateCustomTableCommand, MethodResult<CreateCustomTableCommandResponse>>
    {
        public CreateCustomTableCommandHandler(IMapper mapper, ICustomTableRepository CustomTableRepository,IHttpContextAccessor httpContextAccessor) : base(mapper, CustomTableRepository,httpContextAccessor)
        {
        }

        /// <summary>
        /// Handle for creating a new CustomTable
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<MethodResult<CreateCustomTableCommandResponse>> Handle(CreateCustomTableCommand request, CancellationToken cancellationToken)
        {
            var methodResult = new MethodResult<CreateCustomTableCommandResponse>();
            var newCustomTable = new CustomTable(request.Code,
                                                    request.Title,
                                                    request.NoColum,
                                                    request.NoRown,
                                                    request.Style,
                                                    request.Priority);
            newCustomTable.SetCreate(_user);
            newCustomTable.Status = request.Status.HasValue ? request.Status : newCustomTable.Status;
            newCustomTable.IsActive = request.IsActive.HasValue ? request.IsActive : newCustomTable.IsActive;
            newCustomTable.IsVisible = request.IsVisible .HasValue ? request.IsVisible : newCustomTable.IsVisible;
            await _customTableRepository.AddAsync(newCustomTable).ConfigureAwait(false);
            await _customTableRepository.UnitOfWork.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            methodResult.Result = _mapper.Map<CreateCustomTableCommandResponse>(newCustomTable);
            return methodResult;
        }
    }
}