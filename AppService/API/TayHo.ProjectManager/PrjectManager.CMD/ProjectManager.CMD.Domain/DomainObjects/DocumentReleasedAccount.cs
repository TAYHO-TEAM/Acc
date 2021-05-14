using ProjectManager.CMD.Domain.DomainObjects.BaseClasses;
using Services.Common.DomainObjects.Exceptions;
using System.ComponentModel.DataAnnotations;


namespace ProjectManager.CMD.Domain.DomainObjects
{
    public class DocumentReleasedAccount : DOBase
    {
        #region Fields
        private int? _accountId;
        private int? _groupId;
        private int? _documentReleasedId;
        #endregion Fields
        #region Constructors
        private DocumentReleasedAccount()
        {
           
        }

        public DocumentReleasedAccount(int? AccountId,
                                        int? DocumentReleasedId,
                                        int? GroupId) : this()
        {
            _accountId = AccountId;
            _documentReleasedId = DocumentReleasedId;
            _groupId = GroupId;
            if (!IsValid()) throw new DomainException(_errorMessages);
        }
        #endregion Constructors
        #region Properties
        [Required(ErrorMessage = nameof(ErrorCodeInsert.IErr000))] public int? AccountId { get => _accountId; }
        [Required(ErrorMessage = nameof(ErrorCodeInsert.IErr000))] public int? DocumentReleasedId { get => _documentReleasedId; }
        public int? GroupId { get => _groupId; }
        #endregion Properties

        #region Behaviours
        public void SetAccountId(int? AccountId) { _accountId = !AccountId.HasValue ? _accountId : AccountId; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetDocumentReleasedId(int? DocumentReleasedId) { _documentReleasedId = !DocumentReleasedId.HasValue ? _documentReleasedId : DocumentReleasedId; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetGroupId(int? GroupId) { _groupId = !GroupId.HasValue ? _groupId : GroupId; if (!IsValid()) throw new DomainException(_errorMessages); }
        public sealed override bool IsValid()
        {
            return base.IsValid();
        }
        #endregion Behaviours
    }
}
