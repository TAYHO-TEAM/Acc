using Acc.Cmd.Domain;
using Acc.Cmd.Domain.DomainObjects;
using Acc.Cmd.Domain.Repositories;
using Acc.Cmd.Domain.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Services.Common.DomainObjects;
using Services.Common.DomainObjects.Exceptions;
using Services.Common.Options;
using Services.Common.Security;
using Services.Common.Utilities;
using System;
using System.Collections.Generic;
using System.DirectoryServices;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;

namespace Acc.Cmd.Infrastructure.Services
{
    public class AccountService : IAccountService
    {

        #region fields

        private readonly JwtOptions _jwtOptions;
        private readonly ITokenManager _tokenManager;
        private readonly IDeviceAccountRepository _deviceAccountRepository;
        private readonly IAccountsRepository _accountRepository;
        private readonly IStaffTayHoRepository _staffTayHoRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        //private readonly IUserBlackListCacheManager _userBlackListCacheManager;

        #endregion fields

        #region constructors
        public AccountService(IAccountsRepository accountRepository , IStaffTayHoRepository staffTayHoRepository, ITokenManager tokenManager, IOptionsSnapshot<JwtOptions> jwtOptionsSnapshot, IHttpContextAccessor httpContextAccessor, IDeviceAccountRepository deviceAccountRepository)//, IUserBlackListCacheManager userBlackListCacheManager)
        {
            _accountRepository = accountRepository;
            _staffTayHoRepository = staffTayHoRepository;
            _tokenManager = tokenManager;
            _httpContextAccessor = httpContextAccessor;
            //_userBlackListCacheManager = userBlackListCacheManager;
            _jwtOptions = jwtOptionsSnapshot.Value;
            _deviceAccountRepository = deviceAccountRepository;
        }

        #endregion constructors

        #region implementings

        public async Task LogoutAsync()
        {
            if (_httpContextAccessor.HttpContext.Items.Any(x => (string)x.Key == ClaimsTypeName.ACCOUNT_ID))
            {
               
                int? userId = (int)_httpContextAccessor.HttpContext.Items[ClaimsTypeName.ACCOUNT_ID];
                Accounts existingAccount = await _accountRepository.SingleOrDefaultAsync(x => x.Id == userId).ConfigureAwait(false);
        
                if (existingAccount != null)
                {
                    existingAccount.SetRefreshToken(string.Empty);
                    existingAccount.SetExpiryTime(DateTime.Now);
                    existingAccount.SetExpiryTimeUTC(DateTime.UtcNow);
                    _accountRepository.Update(existingAccount, x => x.ExpiryTime, x => x.ExpiryTimeUTC, x => x.RefreshToken);
                    await _accountRepository.UnitOfWork.SaveChangesAsync(CancellationToken.None).ConfigureAwait(false);
                    //await _userBlackListCacheManager.AddUserToBlackListAsync(existingAccount.Id);
                   
                }
            }
        }
        public async Task<TokenAccountResult> LoginAsync(string userName, string password,string device, string deviceToken,string browser )
        {
            // Validation

            string status = "OK";
           
            try
            {
                DirectoryEntry entry = new DirectoryEntry("LDAP://192.168.1.20", userName, password);
                object nativeObject = entry.NativeObject;
                Accounts currentAcc = new Accounts("",1,userName, password,"", null, null, "",null);
                if (!(await _accountRepository.AnyAsync(x => x.AccountName == currentAcc.AccountName && x.IsDelete == false)))
                {
                    currentAcc.SetType(1);
                    currentAcc.IsActive = true;
                    currentAcc.UpdateDate = null;
                    currentAcc.UpdateDateUTC = null;
                    await _accountRepository.AddAsync(currentAcc).ConfigureAwait(false);
                    await _accountRepository.UnitOfWork.SaveChangesAsync(CancellationToken.None).ConfigureAwait(false);
                  
                }
            }
            catch (DirectoryServicesCOMException cex)
            {
                status = cex.Message;
            }
            catch (Exception ex)
            {
                status = ex.Message;
            }
            List<ErrorResult> errorResults = new List<ErrorResult>();
            Accounts existingAccount = await _accountRepository.SingleOrDefaultAsync(x => x.AccountName == userName && x.IsDelete == false && x.IsActive == true).ConfigureAwait(false);
            if (existingAccount == null)
            {
                errorResults.Add(new ErrorResult
                {
                    ErrorCode = nameof(ErrorCodeLogin.LErr001),
                    ErrorMessage = AccExtensions.GetErrorMessage( nameof(ErrorCodeLogin.LErr001)),
                    ErrorValues = new List<string> { ErrorHelpers.GenerateErrorResult(nameof(userName), userName) }
                });
            }
            if (existingAccount != null && !Hash.Validate(password, existingAccount.Salt, existingAccount.PasswordHash))
            {
                errorResults.Add(new ErrorResult
                {
                    ErrorCode = nameof(ErrorCodeLogin.LErr005),
                    ErrorMessage = AccExtensions.GetErrorMessage(nameof(ErrorCodeLogin.LErr005)),
                    ErrorValues = new List<string> { ErrorHelpers.GenerateErrorResult(nameof(userName), userName) }
                });
            }
            if (errorResults.Any()) throw new ServiceException(errorResults);
            var tokenResult = await GetTokenResultByUserAsync(existingAccount).ConfigureAwait(false);
            if (existingAccount.Type ==1)
            {
                StaffTayHo existingStaffTaHo = await _staffTayHoRepository.SingleOrDefaultAsync(x => x.AccountName == existingAccount.AccountName).ConfigureAwait(false);
                if (existingStaffTaHo != null)
                {
                    tokenResult.Title = existingStaffTaHo.Title;
                    tokenResult.AvatarImg = existingStaffTaHo.AvatarImg;
                    tokenResult.UserName = existingStaffTaHo.UserName;
                    tokenResult.AccountId = existingAccount.Id;
                }     
            }
            DeviceAccount existDeviceAccount = await _deviceAccountRepository.SingleOrDefaultAsync(x => x.DeviceToken == deviceToken && (x.IsDelete == false || !x.IsDelete.HasValue)) ;// new DeviceAccount(device, existingAccount.Id, deviceToken, browser);
            if (existDeviceAccount != null )
            {
                if(existDeviceAccount.Status == null)
                {
                    existDeviceAccount.SetUpdate(0, 1);
                    existDeviceAccount.Status = 1;
                }    
                else
                {
                    try
                    {
                        byte intValue = (byte)(existDeviceAccount.Status + 1);
                        existDeviceAccount.SetUpdate(0, intValue);
                        existDeviceAccount.Status=intValue;
                    }
                    catch
                    {
                        existDeviceAccount.SetUpdate(0, 255);
                        existDeviceAccount.Status = 255;
                    }
                }
                if(existDeviceAccount.AccountId != existingAccount.Id )
                {
                    existDeviceAccount.SetAccountId(existingAccount.Id);
                    existDeviceAccount.SetBrowser(browser);
                    _deviceAccountRepository.Update(existDeviceAccount);
                    await _deviceAccountRepository.UnitOfWork.SaveChangesAsync(CancellationToken.None).ConfigureAwait(false);
                }    
              
            }
            else
            {
                DeviceAccount newDeviceAccount = new DeviceAccount(device, existingAccount.Id, deviceToken, browser);
                newDeviceAccount.IsActive = true;
                newDeviceAccount.IsVisible = true;
                newDeviceAccount.IsDelete = false;
                newDeviceAccount.Status = 1;
                await _deviceAccountRepository.AddAsync(newDeviceAccount);
                await _deviceAccountRepository.UnitOfWork.SaveChangesAsync(CancellationToken.None).ConfigureAwait(false);
            }    
            return tokenResult;
        }
        public async Task<TokenAccountResult> RefreshTokenAsync(string refreshToken)
        {
            if (_httpContextAccessor.HttpContext.Items.Any(x => (string)x.Key == ClaimsTypeName.ACCOUNT_ID) && !string.IsNullOrEmpty(refreshToken))
            {
                List<ErrorResult> errorResults = new List<ErrorResult>();
                int? userId = (int)_httpContextAccessor.HttpContext.Items[ClaimsTypeName.ACCOUNT_ID];
                Accounts existingAccount = await _accountRepository.SingleOrDefaultAsync(x => x.Id == userId && x.IsDelete == false).ConfigureAwait(false);
                if (existingAccount == null)
                {
                    errorResults.Add(new ErrorResult
                    {
                        ErrorCode = nameof(ErrorCodeLogin.LErr001),
                        ErrorMessage = AccExtensions.GetErrorMessage(nameof(ErrorCodeLogin.LErr001)),
                        ErrorValues = new List<string>()
                    });
                }
                if (existingAccount != null && !string.IsNullOrEmpty(existingAccount.RefreshToken) && existingAccount.RefreshToken != refreshToken)
                {
                    errorResults.Add(new ErrorResult
                    {
                        ErrorCode = nameof(ErrorCodeLogin.LErr006),
                        ErrorMessage = AccExtensions.GetErrorMessage(nameof(ErrorCodeLogin.LErr006)),
                        ErrorValues = new List<string> { ErrorHelpers.GenerateErrorResult(nameof(refreshToken), refreshToken) }
                    });
                }
                if (errorResults.Any()) throw new ServiceException(errorResults);
                return null;//await GetTokenResultByUserAsync(existingAccount).ConfigureAwait(false);
            }

            return default;
        }

        #endregion implementings

        #region private functions

        private Claim[] GetClaims(Accounts account)
        {
            return new[]
            {
                new Claim(JwtRegisteredClaimNames.Jti,_jwtOptions.JtiGenerator()),
                new Claim(JwtRegisteredClaimNames.Sub,account.AccountName),
                new Claim(ClaimsTypeName.ACCOUNT_ID, account.Id.ToString()),
                new Claim(ClaimsTypeName.ACCOUNT_NAME, account.AccountName),
                //new Claim(ClaimsTypeName.LASTNAME, account.LastName),
                //new Claim(ClaimsTypeName.PERMISSIONS, JsonConvert.SerializeObject(permissions.Select(x => x.A_ControllerName + "_" + x.A_ActionName + "_" + x.A_ActionType)))
            };
        }

        private async Task<TokenAccountResult> GetTokenResultByUserAsync(Accounts existingAccount)
        {
            DateTime utcNow = DateTime.UtcNow;
            TokenAccountResult tokenResult = _tokenManager.GenerateTokens(GetClaims(existingAccount), utcNow);
            existingAccount.SetRefreshToken(tokenResult.RefreshToken);
            existingAccount.SetExpiryTime(DateTime.Now);
            existingAccount.SetExpiryTimeUTC(utcNow);
            _accountRepository.Update(existingAccount, x => x.ExpiryTimeUTC,x=>x.ExpiryTime, x => x.RefreshToken);
            await _accountRepository.UnitOfWork.SaveChangesAsync(CancellationToken.None).ConfigureAwait(false);
            return tokenResult;
        }

        #endregion private functions
    }
}
