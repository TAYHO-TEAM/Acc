using ProjectManager.CMD.Domain.DomainObjects.BaseClasses;
using Services.Common.DomainObjects.Exceptions;
using System.ComponentModel.DataAnnotations;


namespace ProjectManager.CMD.Domain.DomainObjects
{
    public class StepsProcess : DOBase
    {
        #region Fields
        private string _code;
        private string _title;
        private byte? _priority;
        private int? _parentId;
        private int? _level;
        private int? _previousId;
        private int? _nextId;
        private int? _operationProcessId;
        #endregion Fields
        #region Constructors

        private StepsProcess()
        {
        }

        public StepsProcess(string Code,
                            string Title,
                            byte? Priority,
                            int? ParentId,
                            int? Level,
                            int? PreviousId,
                            int? NextId,
                            int? OperationProcessId) : this()
        {
            _code = Code;
            _title = Title;
            _priority = Priority;
            _parentId = ParentId;
            _level = Level;
            _previousId = PreviousId;
            _nextId = NextId;
            _operationProcessId = OperationProcessId;

        }
        #endregion Constructors
        #region Properties
        [MaxLength(64, ErrorMessage = nameof(ErrorCodeInsert.IErr64))] public string Code { get => _code; }
        [MaxLength(256, ErrorMessage = nameof(ErrorCodeInsert.IErr256))] public string Title { get => _title; }
        public byte? Priority { get => _priority; }
        public int? ParentId { get => _parentId; }
        public int? Level { get => _level; }
        public int? PreviousId { get => _previousId; }
        public int? NextId { get => _nextId; }
        public int? OperationProcessId { get => _operationProcessId; }
        #endregion Properties

        #region Behaviours
        public void SetCode(string Code) { _code = Code == null ? _code : Code; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetTitle(string Title) { _title = Title == null ? _title : Title; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetPriority(byte? Priority) { _priority = !Priority.HasValue ? _priority : Priority; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetParentId(int? ParentId) { _parentId = !ParentId.HasValue ? _parentId : ParentId; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetLevel(int? Level) { _level = !Level.HasValue ? _level : Level; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetPreviousId(int? PreviousId) { _previousId = !PreviousId.HasValue ? _previousId : PreviousId; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetNextId(int? NextId) { _nextId = !NextId.HasValue ? _nextId : NextId; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetOperationProcessId(int? OperationProcessId) { _operationProcessId = !OperationProcessId.HasValue ? _operationProcessId : OperationProcessId; if (!IsValid()) throw new DomainException(_errorMessages); }
        public sealed override bool IsValid()
        {
            return base.IsValid();
        }
        #endregion Behaviours
    }
}
