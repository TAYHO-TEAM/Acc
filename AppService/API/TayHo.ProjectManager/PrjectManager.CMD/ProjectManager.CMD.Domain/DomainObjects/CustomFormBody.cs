using ProjectManager.CMD.Domain.DomainObjects.BaseClasses;
using Services.Common.DomainObjects.Exceptions;
using System.ComponentModel.DataAnnotations;

namespace ProjectManager.CMD.Domain.DomainObjects
{
    public class CustomFormBody : DOBase
    {
        #region Fields
        private string _header;
        private int? _customTableId;
        private int? _customFormId;
        private byte? _priority;
        #endregion Fields
        #region Constructors

        private CustomFormBody()
        {
        }

        public CustomFormBody(string Header,
                                int? CustomTableId,
                                int? CustomFormId,
                                byte? Priority) : this()
        {
            _header = Header;
            _customTableId = CustomTableId;
            _customFormId = CustomFormId;
            _priority = Priority;
        }
        #endregion Constructors
        #region Properties
        [MaxLength(1028, ErrorMessage = nameof(ErrorCodeInsert.IErr1028))] public string Header { get => _header; }
        public int? CustomTableId { get => _customTableId; }
        public int? CustomFormId { get => _customFormId; }
        public byte? Priority { get => _priority; }
        #endregion Properties

        #region Behaviours
        public void SetHeader(string Header) { _header = Header == null ? _header : Header; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetCustomTableId(int? CustomTableId) { _customTableId = !CustomTableId.HasValue ? _customTableId : CustomTableId; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetCustomFormId(int? CustomFormId) { _customFormId = !CustomFormId.HasValue ? _customFormId : CustomFormId; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetPriority(byte? Priority) { _priority = !Priority.HasValue ? _priority : Priority; if (!IsValid()) throw new DomainException(_errorMessages); }
        public sealed override bool IsValid()
        {
            return base.IsValid();
        }
        #endregion Behaviours
    }
}
