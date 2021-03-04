using ProjectManager.CMD.Domain.DomainObjects.BaseClasses;
using Services.Common.DomainObjects.Exceptions;
using System;
using System.ComponentModel.DataAnnotations;


namespace ProjectManager.CMD.Domain.DomainObjects
{
    public class PlanJob : DOBase
    {
        #region Fields

        private int? _planMasterId;
        private int? _parentId;
        private string _title;
        private string _description;
        private string _unit;
        private int? _amount;
        private DateTime? _startDate;
        private DateTime? _endDate;
        private int? _modifyTimes;
        private int? _priority;
        private byte? _importantLevel;
        private bool? _isDone;


        #endregion Fields
        #region Constructors

        private PlanJob()
        {
        }

        public PlanJob(int? PlanMasterId, int? ParentId, string Title, string Description, string Unit, int? Amount, DateTime? StartDate, DateTime? EndDate, int? ModifyTimes, int? Priority, byte? ImportantLevel, bool? IsDone) : this()
        {
            _planMasterId = PlanMasterId;
            _parentId = ParentId;
            _title = Title;
            _description = Description;
            _unit = Unit;
            _amount = Amount;
            _startDate = StartDate;
            _endDate = EndDate;
            _modifyTimes = ModifyTimes;
            _priority = Priority;
            _importantLevel = ImportantLevel;
            _isDone = IsDone;

        }

        #endregion Constructors
        #region Properties

        public int? PlanMasterId { get => _planMasterId; }
        public int? ParentId { get => _parentId; }
        [MaxLength(256, ErrorMessage = nameof(ErrorCodeInsert.IErr256))] public string Title { get => _title; }
        public string Description { get => _description; }
        [MaxLength(64, ErrorMessage = nameof(ErrorCodeInsert.IErr64))] public string Unit { get => _unit; }
        public int? Amount { get => _amount; }
        public DateTime? StartDate { get => _startDate; }
        public DateTime? EndDate { get => _endDate; }
        public int? ModifyTimes { get => _modifyTimes; }
        public int? Priority { get => _priority; }
        public byte? ImportantLevel { get => _importantLevel; }
        public bool? IsDone { get => _isDone; }


        #endregion Properties
        #region Behaviours

        public void SetPlanMasterId(int? PlanMasterId)
        { _planMasterId = !PlanMasterId.HasValue ? _planMasterId : PlanMasterId; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetParentId(int? ParentId)
        { _parentId = !ParentId.HasValue ? _parentId : ParentId; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetTitle(string Title)
        { _title = Title == null ? _title : Title; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetDescription(string Description)
        { _description = Description == null ? _description : Description; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetUnit(string Unit)
        { _unit = Unit == null ? _unit : Unit; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetAmount(int? Amount)
        { _amount = !Amount.HasValue ? _amount : Amount; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetStartDate(DateTime? StartDate)
        { _startDate = !StartDate.HasValue ? _startDate : StartDate; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetEndDate(DateTime? EndDate)
        { _endDate = !EndDate.HasValue ? _endDate : EndDate; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetModifyTimes(int? ModifyTimes)
        { _modifyTimes = !ModifyTimes.HasValue ? _modifyTimes : ModifyTimes; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetPriority(int? Priority)
        { _priority = !Priority.HasValue ? _priority : Priority; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetImportantLevel(byte? ImportantLevel)
        { _importantLevel = !ImportantLevel.HasValue ? _importantLevel : ImportantLevel; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetIsDone(bool? IsDone)
        { _isDone = !IsDone.HasValue ? _isDone : IsDone; if (!IsValid()) throw new DomainException(_errorMessages); }


        public sealed override bool IsValid()
        {
            return base.IsValid();
        }
        #endregion Behaviours
    }
}
