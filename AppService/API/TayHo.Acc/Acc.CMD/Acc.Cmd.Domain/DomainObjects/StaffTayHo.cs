using Services.Common.DomainObjects;
using System.ComponentModel.DataAnnotations;

namespace Acc.Cmd.Domain.DomainObjects
{
    public class StaffTayHo :EntityDO
    {
        #region Fields
        private string _userName;
        private string _title;
        private string _accountName;
        private byte[] _avatarImg;
        #endregion Fields
        #region Constructors

        private StaffTayHo()
        {
        }

        public StaffTayHo(string UserName,
                        string AccountName,
                        byte[] AvatarImg, string Title) : this()
        {
            _userName = UserName;
            _accountName = AccountName;
            _avatarImg = AvatarImg;
            _title = Title;
        }
        #endregion Constructors
        #region Properties
        [MaxLength(200, ErrorMessage = nameof(ErrorCodeInsert.IErr200))] public string UserName { get => _userName; }
        public string Title { get => _title; }
        [MaxLength(50, ErrorMessage = nameof(ErrorCodeInsert.IErr64))] public string AccountName { get => _accountName; }
        public byte[] AvatarImg { get => _avatarImg; }
        #endregion Properties

        #region Behaviours
        public sealed override bool IsValid()
        {
            return base.IsValid();
        }
        #endregion Behaviours
    }
}
