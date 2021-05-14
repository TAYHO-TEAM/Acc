using ProjectManager.CMD.Domain.DomainObjects.BaseClasses;
using Services.Common.DomainObjects.Exceptions;
using System;
using System.ComponentModel.DataAnnotations;


namespace ProjectManager.CMD.Domain.DomainObjects
{
    public class PlanMaster : DOBase
    {
        #region Fields

        private string _code;
        private int? _parentId;
        private string _planProjectId;
        private string _title;
        private int? _timeLine;
        private string _description;
        private string _note;
        private DateTime? _startDate;
        private DateTime? _endDate;
        private string _unit;
        private int? _amount;
        private string _reportPeriodicalType;
        private int? _reportPeriodical;
        private int? _reportFrequency;
        private int? _priority;
        private byte? _importantLevel;
        private byte? _noAttachment;


        #endregion Fields
        #region Constructors

        private PlanMaster()
        {
        }

        public PlanMaster(string Code, int? ParentId, string PlanProjectId, string Title, int? TimeLine, string Description, string Note, DateTime? StartDate, DateTime? EndDate, string Unit, int? Amount, string ReportPeriodicalType, int? ReportPeriodical, int? ReportFrequency, int? Priority, byte? ImportantLevel, byte? NoAttachment) : this()
        {
            _code = Code;
            _parentId = ParentId;
            _planProjectId = PlanProjectId;
            _title = Title;
            _timeLine = TimeLine;
            _description = Description;
            _note = Note;
            _startDate = StartDate;
            _endDate = EndDate;
            _unit = Unit;
            _amount = Amount;
            _reportPeriodicalType = ReportPeriodicalType;
            _reportPeriodical = ReportPeriodical;
            _reportFrequency = ReportFrequency;
            _priority = Priority;
            _importantLevel = ImportantLevel;
            _noAttachment = NoAttachment;

        }

        #endregion Constructors
        #region Properties

        [MaxLength(128, ErrorMessage = nameof(ErrorCodeInsert.IErr128))] public string Code { get => _code; }
        public int? ParentId { get => _parentId; }
        [MaxLength(128, ErrorMessage = nameof(ErrorCodeInsert.IErr128))] public string PlanProjectId { get => _planProjectId; }
        [MaxLength(256, ErrorMessage = nameof(ErrorCodeInsert.IErr256))] public string Title { get => _title; }
        public int? TimeLine { get => _timeLine; }
        public string Description { get => _description; }
        public string Note { get => _note; }
        public DateTime? StartDate { get => _startDate; }
        public DateTime? EndDate { get => _endDate; }
        [MaxLength(64, ErrorMessage = nameof(ErrorCodeInsert.IErr64))] public string Unit { get => _unit; }
        public int? Amount { get => _amount; }
        [MaxLength(128, ErrorMessage = nameof(ErrorCodeInsert.IErr128))] public string ReportPeriodicalType { get => _reportPeriodicalType; }
        public int? ReportPeriodical { get => _reportPeriodical; }
        public int? ReportFrequency { get => _reportFrequency; }
        public int? Priority { get => _priority; }
        public byte? ImportantLevel { get => _importantLevel; }
        public byte? NoAttachment { get => _noAttachment; }


        #endregion Properties
        #region Behaviours

        public void SetCode(string Code)
        { _code = Code == null ? _code : Code; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetParentId(int? ParentId)
        { _parentId = !ParentId.HasValue ? _parentId : ParentId; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetPlanProjectId(string PlanProjectId)
        { _planProjectId = PlanProjectId == null ? _planProjectId : PlanProjectId; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetTitle(string Title)
        { _title = Title == null ? _title : Title; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetTimeLine(int? TimeLine)
        { _timeLine = !TimeLine.HasValue ? _timeLine : TimeLine; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetDescription(string Description)
        { _description = Description == null ? _description : Description; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetNote(string Note)
        { _note = Note == null ? _note : Note; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetStartDate(DateTime? StartDate)
        { _startDate = !StartDate.HasValue ? _startDate : StartDate; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetEndDate(DateTime? EndDate)
        { _endDate = !EndDate.HasValue ? _endDate : EndDate; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetUnit(string Unit)
        { _unit = Unit == null ? _unit : Unit; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetAmount(int? Amount)
        { _amount = !Amount.HasValue ? _amount : Amount; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetReportPeriodicalType(string ReportPeriodicalType)
        { _reportPeriodicalType = ReportPeriodicalType == null ? _reportPeriodicalType : ReportPeriodicalType; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetReportPeriodical(int? ReportPeriodical)
        { _reportPeriodical = !ReportPeriodical.HasValue ? _reportPeriodical : ReportPeriodical; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetReportFrequency(int? ReportFrequency)
        { _reportFrequency = !ReportFrequency.HasValue ? _reportFrequency : ReportFrequency; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetPriority(int? Priority)
        { _priority = !Priority.HasValue ? _priority : Priority; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetImportantLevel(byte? ImportantLevel)
        { _importantLevel = !ImportantLevel.HasValue ? _importantLevel : ImportantLevel; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetNoAttachment(byte? NoAttachment)
        { _noAttachment = !NoAttachment.HasValue ? _noAttachment : NoAttachment; if (!IsValid()) throw new DomainException(_errorMessages); }


        public sealed override bool IsValid()
        {
            return base.IsValid();
        }
        #endregion Behaviours
    }
}
