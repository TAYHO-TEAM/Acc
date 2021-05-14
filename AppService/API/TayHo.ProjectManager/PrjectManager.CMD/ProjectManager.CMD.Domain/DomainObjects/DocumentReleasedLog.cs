using ProjectManager.CMD.Domain.DomainObjects.BaseClasses;
using Services.Common.DomainObjects.Exceptions;
using System.ComponentModel.DataAnnotations;


namespace ProjectManager.CMD.Domain.DomainObjects
{
    public class DocumentReleasedLog : DOBase
    {
        #region Fields
        private int? _accountId;
        private int? _documentReleasedId;
        private string _note;
        #endregion Fields
        #region Constructors
        private DocumentReleasedLog()
        {
           
        }

        public DocumentReleasedLog(int? AccountId,
                                    int? DocumentReleasedId,
                                    string Note) : this()
        {
            _accountId = AccountId;
            _documentReleasedId = DocumentReleasedId;
            _note = Note;
            if (!IsValid()) throw new DomainException(_errorMessages);
        }
        #endregion Constructors
        #region Properties
        public int? AccountId { get => _accountId; }
        public int? DocumentReleasedId { get => _documentReleasedId; }
        [MaxLength(50, ErrorMessage = nameof(ErrorCodeInsert.IErr50))] public string Note { get => _note; }
        #endregion Properties

        #region Behaviours
        public void SetAccountId(int? AccountId) { _accountId = !AccountId.HasValue ? _accountId : AccountId; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetDocumentReleasedId(int? DocumentReleasedId) { _documentReleasedId = !DocumentReleasedId.HasValue ? _documentReleasedId : DocumentReleasedId; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetNote(string Note) { _note = Note == null ? _note : Note; if (!IsValid()) throw new DomainException(_errorMessages); }
        public sealed override bool IsValid()
        {
            return base.IsValid();
        }
        #endregion Behaviours
    }
}
