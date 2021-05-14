using ProjectManager.CMD.Domain.DomainObjects.BaseClasses;
using Services.Common.DomainObjects.Exceptions;
using System.ComponentModel.DataAnnotations;

namespace ProjectManager.CMD.Domain.DomainObjects
{
    public class OperationProcess : DOBase
    {
        #region Fields
        private string _code;
        private string _barCode;
        private string _title;
        private string _description;
        private byte? _priority;
        private int? _parentId;
        private int? _level;
        private int? _previousId;
        private int? _nextId;
        #endregion Fields
        #region Constructors

        private OperationProcess()
        {
        }

        public OperationProcess(string Code,
                                string BarCode,
                                string Title,
                                string Description,
                                byte? Priority,
                                int? ParentId,
                                int? Level,
                                int? PreviousId,
                                int? NextId) : this()
        {
            _code = Code;
            _barCode = BarCode;
            _title = Title;
            _description = Description;
            _priority = Priority;
            _parentId = ParentId;
            _level = Level;
            _previousId = PreviousId;
            _nextId = NextId;
        }
        #endregion Constructors
        #region Properties
        [MaxLength(64, ErrorMessage = nameof(ErrorCodeInsert.IErr64))] [Required(ErrorMessage = nameof(ErrorCodeInsert.IErr000))] public string Code { get => _code; }
        [MaxLength(128, ErrorMessage = nameof(ErrorCodeInsert.IErr128))] public string BarCode { get => _barCode; }
        [MaxLength(256, ErrorMessage = nameof(ErrorCodeInsert.IErr256))] public string Title { get => _title; }
        public string Description { get => _description; }
        public byte? Priority { get => _priority; }
        public int? ParentId { get => _parentId; }
        public int? Level { get => _level; }
        public int? PreviousId { get => _previousId; }
        public int? NextId { get => _nextId; }
        #endregion Properties

        #region Behaviours
        public void SetCode(string Code) { _code = string.IsNullOrEmpty(Code) ? _code : Code; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetBarCode(string BarCode) { _barCode = BarCode == null ? _barCode : BarCode; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetTitle(string Title) { _title = Title == null ? _title : Title; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetDescription(string Description) { _description = Description == null ? _description : Description; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetPriority(byte? Priority) { _priority = !Priority.HasValue ? _priority : Priority; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetParentId(int? ParentId) { _parentId = !ParentId.HasValue ? _parentId : ParentId; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetLevel(int? Level) { _level = !Level.HasValue ? _level : Level; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetPreviousId(int? PreviousId) { _previousId = !PreviousId.HasValue ? _previousId : PreviousId; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetNextId(int? NextId) { _nextId = !NextId.HasValue ? _nextId : NextId; if (!IsValid()) throw new DomainException(_errorMessages); }
        public sealed override bool IsValid()
        {
            return base.IsValid();
        }
   

        #endregion Behaviours
    }
}
