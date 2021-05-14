using ProjectManager.CMD.Domain.DomainObjects;
using ProjectManager.CMD.Domain.IRepositories;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using MediatR;
using Services.Common.DomainObjects;
using System.Threading;
using System.Threading.Tasks;
using ProjectManager.CMD.Domain;
using Services.Common.Utilities;
using Services.Common.DomainObjects.Exceptions;

namespace  ProjectManager.CMD.Api.Application.Commands
{
    public class CreateContractorInfoCommandHandler : ContractorInfoCommandHandler, IRequestHandler<CreateContractorInfoCommand, MethodResult<CreateContractorInfoCommandResponse>>
    {
        private int _function = 2;
        public CreateContractorInfoCommandHandler(IMapper mapper, IContractorInfoRepository ContractorInfoRepository,IHttpContextAccessor httpContextAccessor) : base(mapper, ContractorInfoRepository,httpContextAccessor)
        {
        }

        /// <summary>
        /// Handle for creating a new ContractorInfo
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<MethodResult<CreateContractorInfoCommandResponse>> Handle(CreateContractorInfoCommand request, CancellationToken cancellationToken)
        {
            var methodResult = new MethodResult<CreateContractorInfoCommandResponse>();
            if ((await _ContractorInfoRepository.BaseCheckPermistion(0, _user, _actionId, _tableName, _function)) < 1)
            {
                methodResult.AddAPIErrorMessage(nameof(ErrorCodeInsert.IErrN101), new[]
               {
                    ErrorHelpers.GenerateErrorResult(nameof(request.Id),request.Id)
                });
            }
            if (!methodResult.IsOk) throw new CommandHandlerException(methodResult.ErrorMessages);
            var newContractorInfo = new ContractorInfo(request.Code,
                                                        request.TaxCode,
                                                        request.AvatarImg,
                                                        request.Name,
                                                        request.Descriptions,
                                                        request.BusinessAreas,
                                                        request.Country,
                                                        request.City,
                                                        request.District,
                                                        request.Address,
                                                        request.Phone,
                                                        request.Email);
            newContractorInfo.SetCreate(_user);
            newContractorInfo.Status = request.Status.HasValue ? request.Status : newContractorInfo.Status;
            newContractorInfo.IsActive = request.IsActive.HasValue ? request.IsActive : newContractorInfo.IsActive;
            newContractorInfo.IsVisible = request.IsVisible .HasValue ? request.IsVisible : newContractorInfo.IsVisible;
            await _ContractorInfoRepository.AddAsync(newContractorInfo).ConfigureAwait(false);
            await _ContractorInfoRepository.UnitOfWork.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            methodResult.Result = _mapper.Map<CreateContractorInfoCommandResponse>(newContractorInfo);
            return methodResult;
        }
    }
}