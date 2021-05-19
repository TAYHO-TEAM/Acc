using Acc.Cmd.Domain;
using Acc.Cmd.Domain.Repositories;
using AutoMapper;using Microsoft.AspNetCore.Http;
using MediatR;
using Services.Common.DomainObjects;
using Services.Common.DomainObjects.Exceptions;
using Services.Common.Utilities;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace  Acc.Cmd.Api.Application.Commands
{
    public class UpdateContractorInfoCommandHandler : ContractorInfoCommandHandler,IRequestHandler<UpdateContractorInfoCommand, MethodResult<UpdateContractorInfoCommandResponse>>
    {
        public UpdateContractorInfoCommandHandler(IMapper mapper, IContractorInfoRepository accountRepository,IHttpContextAccessor httpContextAccessor) : base(mapper, httpContextAccessor, accountRepository)
        {
        }

        /// <summary>
        /// Handle for update a existing ContractorInfo.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<MethodResult<UpdateContractorInfoCommandResponse>> Handle(UpdateContractorInfoCommand request, CancellationToken cancellationToken)
        {
            var methodResult = new MethodResult<UpdateContractorInfoCommandResponse>();
            var existingContractorInfo = await _ContractorInfoRepository.SingleOrDefaultAsync(x => x.Id == request.Id && x.IsDelete == false).ConfigureAwait(false);
            if (existingContractorInfo == null)
            {
                methodResult.AddAPIErrorMessage(nameof(ErrorCodeUpdate.UErr01), new[]
                {
                    ErrorHelpers.GenerateErrorResult(nameof(request.Id),request.Id)
                });
            }
            if (!methodResult.IsOk) throw new CommandHandlerException(methodResult.ErrorMessages);
            existingContractorInfo.IsActive = request.IsActive.HasValue ? request.IsActive : existingContractorInfo.IsActive;
            existingContractorInfo.IsVisible = request.IsVisible.HasValue ? request.IsVisible : existingContractorInfo.IsVisible;
            existingContractorInfo.Status = request.Status.HasValue ? request.Status : existingContractorInfo.Status;
            existingContractorInfo.SetCode(request.Code);
            existingContractorInfo.SetTaxCode(request.TaxCode);
            existingContractorInfo.SetAvatarImg(request.AvatarImg);
            existingContractorInfo.SetName(request.Name);
            existingContractorInfo.SetDescriptions(request.Descriptions);
            existingContractorInfo.SetBusinessAreas(request.BusinessAreas);
            existingContractorInfo.SetCountry(request.Country);
            existingContractorInfo.SetCity(request.City);
            existingContractorInfo.SetDistrict(request.District);
            existingContractorInfo.SetAddress(request.Address);
            existingContractorInfo.SetPhone(request.Phone);
            existingContractorInfo.SetEmail(request.Email);
            existingContractorInfo.SetImage(request.Image);
            existingContractorInfo.SetUpdate(_user,null);
            
            _ContractorInfoRepository.Update(existingContractorInfo);
            await _ContractorInfoRepository.UnitOfWork.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            methodResult.Result = _mapper.Map<UpdateContractorInfoCommandResponse>(existingContractorInfo);
            return methodResult;
        }
    }
}