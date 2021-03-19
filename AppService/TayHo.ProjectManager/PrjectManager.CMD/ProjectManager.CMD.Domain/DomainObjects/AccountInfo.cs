using ProjectManager.CMD.Domain.DomainObjects.BaseClasses;
using Services.Common.DomainObjects.Exceptions;
using System.ComponentModel.DataAnnotations;

namespace ProjectManager.CMD.Domain.DomainObjects
{
    public class AccountInfo :DOBase
    {
        #region Fields
        private int? _accountId;
        private string _accountName;
        private string _userName;
        private byte[]? _avatarImg;
        private string _title;
        private string _department;
        private string _email;
        private byte? _type;
        #endregion Fields
        #region Constructors
        private AccountInfo()
        {

        }

        public AccountInfo(int? AccountId,
                            string AccountName,
                            string UserName,
                            byte[]? AvatarImg,
                            string Title,
                            string Department,
                            string Email,
                            byte? Type) : this()
        {
            _accountId = AccountId;
            _accountName = AccountName;
            _userName = UserName;
            _avatarImg = AvatarImg;
            _title = Title;
            _department = Department;
            _email = Email;
            _type = Type;
            //if (!IsValid()) throw new DomainException(_errorMessages);
        }
        #endregion Constructors
        #region Properties
        [Required(ErrorMessage = nameof(ErrorCodeInsert.IErr000))] public int? AccountId { get => _accountId; }
        [MaxLength(128, ErrorMessage = nameof(ErrorCodeInsert.IErr128))] [Required(ErrorMessage = nameof(ErrorCodeInsert.IErr000))] public string AccountName { get => _accountName; }
        [MaxLength(256, ErrorMessage = nameof(ErrorCodeInsert.IErr256))] public string UserName { get => _userName; }
        public byte[]? AvatarImg { get => _avatarImg; }
        [MaxLength(200, ErrorMessage = nameof(ErrorCodeInsert.IErr200))] public string Title { get => _title; }
        [MaxLength(256, ErrorMessage = nameof(ErrorCodeInsert.IErr256))] public string Department { get => _department; }
        [MaxLength(128, ErrorMessage = nameof(ErrorCodeInsert.IErr128))] public string Email { get => _email; }
        public byte? Type { get => _type; }
        #endregion Properties

        #region Behaviours
        //public void SetAccountId(int? AccountId) { _accountId = !AccountId.HasValue ? _accountId : AccountId; if (!IsValid()) throw new DomainException(_errorMessages); }
        //public void SetAccountName(string AccountName) { _accountName = string.IsNullOrEmpty(AccountName) ? _accountName : AccountName; if (!IsValid()) throw new DomainException(_errorMessages); }
        //public void SetUserName(string UserName) { _userName = UserName == null ? _userName : UserName; if (!IsValid()) throw new DomainException(_errorMessages); }
        ////public void SetAvatarImg(byte[]? AvatarImg) { _avatarImg = !AvatarImg.HasValue ? _avatarImg : AvatarImg; if (!IsValid()) throw new DomainException(_errorMessages); }
        //public void SetTitle(string Title) { _title = Title == null ? _title : Title; if (!IsValid()) throw new DomainException(_errorMessages); }
        //public void SetDepartment(string Department) { _department = Department == null ? _department : Department; if (!IsValid()) throw new DomainException(_errorMessages); }
        //public void SetEmail(string Email) { _email = Email == null ? _email : Email; if (!IsValid()) throw new DomainException(_errorMessages); }
        //public void SetType(byte? Type) { _type = !Type.HasValue ? _type : Type; if (!IsValid()) throw new DomainException(_errorMessages); }
        //public sealed override bool IsValid()
        //{
        //    return base.IsValid();
        //}
        #endregion Behaviours
    }
}
