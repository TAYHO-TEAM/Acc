using ProjectManager.CMD.Domain.DomainObjects.BaseClasses;
using Services.Common.DomainObjects.Exceptions;
using System.ComponentModel.DataAnnotations;


namespace ProjectManager.CMD.Domain.DomainObjects
{
    public class SysMailAccount : DOBase
    {
        #region Fields

        private int? _sysAutoSendMailId;
        private string _email;
        private int? _type;


        #endregion Fields
        #region Constructors

        private SysMailAccount()
        {
        }

        public SysMailAccount(int? SysAutoSendMailId, string Email, int? Type) : this()
        {
            _sysAutoSendMailId = SysAutoSendMailId;
            _email = Email;
            _type = Type;

        }

        #endregion Constructors
        #region Properties

        public int? SysAutoSendMailId { get => _sysAutoSendMailId; }
        [MaxLength(1024, ErrorMessage = nameof(ErrorCodeInsert.IErr1024))] public string Email { get => _email; }
        public int? Type { get => _type; }


        #endregion Properties
        #region Behaviours

        public void SetSysAutoSendMailId(int? SysAutoSendMailId)
        { _sysAutoSendMailId = !SysAutoSendMailId.HasValue ? _sysAutoSendMailId : SysAutoSendMailId; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetEmail(string Email)
        { _email = Email == null ? _email : Email; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetType(int? Type)
        { _type = !Type.HasValue ? _type : Type; if (!IsValid()) throw new DomainException(_errorMessages); }


        public sealed override bool IsValid()
        {
            return base.IsValid();
        }
        #endregion Behaviours
    }
}
