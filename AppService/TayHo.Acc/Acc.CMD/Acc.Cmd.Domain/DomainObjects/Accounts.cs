using Acc.Cmd.Domain.DomainObjects.BaseClasses;
using Services.Common.DomainObjects;
using Services.Common.DomainObjects.Exceptions;
using Services.Common.Security;
using Services.Common.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Acc.Cmd.Domain.DomainObjects
{
    public class Accounts : DOBase
    {
        #region Fields
        private string _code;
        private byte? _type;
        private string _accountName;
        private string _passwordHash;
        private string _password;
        private string _salt;
        private string _tokenKey;
        private DateTime? _expiryTimeUTC;
        private DateTime? _expiryTime;
        private string _refreshToken;
        private int? _userId;
        #endregion Fields
        #region Constructors
        private Accounts()
        {
            _salt = Helpers.RandomSecretKey();
        }

        public Accounts(string Code,
                        byte? Type,
                        string AccountName,
                        string Password,
                        string TokenKey,
                        DateTime? ExpiryTimeUTC,
                        DateTime? ExpiryTime,
                        string RefreshToken,
                        int? UserId) : this()
        {
            _code = Code;
            _type = Type;
            _accountName = AccountName;
            _password = Password;
            _tokenKey = TokenKey;
            _expiryTimeUTC = ExpiryTimeUTC;
            _expiryTime = ExpiryTime;
            _refreshToken = RefreshToken;
            _userId = UserId;
            if (!string.IsNullOrEmpty(Password)) _passwordHash = Hash.Create(_password, _salt);
            ValidatePassword(_password);
            if (!IsValid()) throw new DomainException(_errorMessages);
        }
        #endregion Constructors
        #region Properties

        [MaxLength(32, ErrorMessage = nameof(ErrorCodeInsert.IErr32))] public string Code { get => _code; }
        public byte? Type { get => _type; }
        [MaxLength(128, ErrorMessage = nameof(ErrorCodeInsert.IErr128))] [Required(ErrorMessage = nameof(ErrorCodeInsert.IErr000))] public string AccountName { get => _accountName; }
        [MaxLength(128, ErrorMessage = nameof(ErrorCodeInsert.IErr128))] public string PasswordHash { get => _passwordHash; }
        [MaxLength(512, ErrorMessage = nameof(ErrorCodeInsert.IErr512))] public string Salt { get => _salt; }
        [MaxLength(128, ErrorMessage = nameof(ErrorCodeInsert.IErr128))] public string TokenKey { get => _tokenKey; }
        public DateTime? ExpiryTimeUTC { get => _expiryTimeUTC; }
        public DateTime? ExpiryTime { get => _expiryTime; }
        [MaxLength(256, ErrorMessage = nameof(ErrorCodeInsert.IErr256))] public string RefreshToken { get => _refreshToken; }
        public int? UserId { get => _userId; }
        #endregion Properties
        #region Behaviours 
        public void SetCode(string Code) { _code = string.IsNullOrEmpty(Code) ? _code : Code; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetType(byte? Type) { _type = Type.HasValue ? Type : _type; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetAccountName(string AccountName) { _accountName = string.IsNullOrEmpty(AccountName) ? _accountName : AccountName; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetPasswordHash(string Password)
        {
            _passwordHash = string.IsNullOrEmpty(Password) ? _passwordHash : Hash.Create(Password, _salt); if (!IsValid()) throw new DomainException(_errorMessages);

        }
        public void SetSalt(string Salt) { _salt = string.IsNullOrEmpty(Salt) ? _salt : Salt; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetTokenKey(string TokenKey) { _tokenKey = string.IsNullOrEmpty(TokenKey) ? _tokenKey : TokenKey; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetExpiryTimeUTC(DateTime? ExpiryTimeUTC) { _expiryTimeUTC = ExpiryTimeUTC.HasValue ? ExpiryTimeUTC : _expiryTimeUTC; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetExpiryTime(DateTime? ExpiryTime) { _expiryTime = ExpiryTime.HasValue ? ExpiryTime : _expiryTime; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetRefreshToken(string RefreshToken) { _refreshToken = string.IsNullOrEmpty(RefreshToken) ? _refreshToken : RefreshToken; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetUserId(int? UserId) { _userId = UserId.HasValue ? UserId : _userId; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void ValidatePassword(string password)
        {
            if (string.IsNullOrEmpty(password))
            {
                _errorMessages.Add(new ErrorResult
                {
                    ErrorCode = "-101",
                    ErrorMessage = nameof(ErrorCodeInsert.IErr000),
                    ErrorValues = new List<string>
                    {
                        ErrorHelpers.GenerateErrorResult(nameof(password),password)
                    }
                });
            }
        }
        #endregion Behaviours
    }
}
