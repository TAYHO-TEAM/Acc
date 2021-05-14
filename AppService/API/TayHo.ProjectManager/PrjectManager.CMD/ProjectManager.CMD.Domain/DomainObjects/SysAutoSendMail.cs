using ProjectManager.CMD.Domain.DomainObjects.BaseClasses;
using Services.Common.DomainObjects.Exceptions;
using System;
using System.ComponentModel.DataAnnotations;


namespace ProjectManager.CMD.Domain.DomainObjects
{
    public class SysAutoSendMail : DOBase
    {
        #region Fields

        private int? _sysJobId;
        private int? _templateMailId;
        private string _subMail;
        private string _titleMail;
        private string _bodyMail;
        private DateTime? _startTime;
        private DateTime? _endTime;
        private DateTime? _startDate;
        private DateTime? _endDate;
        private DateTime? _firstDate;
        private DateTime? _lastDate;
        private DateTime? _nextDate;
        private int? _times;
        private byte? _unit;
        private int? _stepTime;


        #endregion Fields
        #region Constructors

        private SysAutoSendMail()
        {
        }

        public SysAutoSendMail(int? SysJobId, int? TemplateMailId, string SubMail, string TitleMail, string BodyMail, DateTime? StartTime, DateTime? EndTime, DateTime? StartDate, DateTime? EndDate, DateTime? FirstDate, DateTime? LastDate, DateTime? NextDate, int? Times, byte? Unit, int? StepTime) : this()
        {
            _sysJobId = SysJobId;
            _templateMailId = TemplateMailId;
            _subMail = SubMail;
            _titleMail = TitleMail;
            _bodyMail = BodyMail;
            _startTime = StartTime;
            _endTime = EndTime;
            _startDate = StartDate;
            _endDate = EndDate;
            _firstDate = FirstDate;
            _lastDate = LastDate;
            _nextDate = NextDate;
            _times = Times;
            _unit = Unit;
            _stepTime = StepTime;

        }

        #endregion Constructors
        #region Properties

        public int? SysJobId { get => _sysJobId; }
        public int? TemplateMailId { get => _templateMailId; }
        [MaxLength(1024, ErrorMessage = nameof(ErrorCodeInsert.IErr1024))] public string SubMail { get => _subMail; }
        [MaxLength(1024, ErrorMessage = nameof(ErrorCodeInsert.IErr1024))] public string TitleMail { get => _titleMail; }
        public string BodyMail { get => _bodyMail; }
        public DateTime? StartTime { get => _startTime; }
        public DateTime? EndTime { get => _endTime; }
        public DateTime? StartDate { get => _startDate; }
        public DateTime? EndDate { get => _endDate; }
        public DateTime? FirstDate { get => _firstDate; }
        public DateTime? LastDate { get => _lastDate; }
        public DateTime? NextDate { get => _nextDate; }
        public int? Times { get => _times; }
        public byte? Unit { get => _unit; }
        public int? StepTime { get => _stepTime; }


        #endregion Properties
        #region Behaviours

        public void SetSysJobId(int? SysJobId)
        { _sysJobId = !SysJobId.HasValue ? _sysJobId : SysJobId; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetTemplateMailId(int? TemplateMailId)
        { _templateMailId = !TemplateMailId.HasValue ? _templateMailId : TemplateMailId; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetSubMail(string SubMail)
        { _subMail = SubMail == null ? _subMail : SubMail; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetTitleMail(string TitleMail)
        { _titleMail = TitleMail == null ? _titleMail : TitleMail; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetBodyMail(string BodyMail)
        { _bodyMail = BodyMail == null ? _bodyMail : BodyMail; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetStartTime(DateTime? StartTime)
        { _startTime = !StartTime.HasValue ? _startTime : StartTime; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetEndTime(DateTime? EndTime)
        { _endTime = !EndTime.HasValue ? _endTime : EndTime; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetStartDate(DateTime? StartDate)
        { _startDate = !StartDate.HasValue ? _startDate : StartDate; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetEndDate(DateTime? EndDate)
        { _endDate = !EndDate.HasValue ? _endDate : EndDate; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetFirstDate(DateTime? FirstDate)
        { _firstDate = !FirstDate.HasValue ? _firstDate : FirstDate; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetLastDate(DateTime? LastDate)
        { _lastDate = !LastDate.HasValue ? _lastDate : LastDate; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetNextDate(DateTime? NextDate)
        { _nextDate = !NextDate.HasValue ? _nextDate : NextDate; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetTimes(int? Times)
        { _times = !Times.HasValue ? _times : Times; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetUnit(byte? Unit)
        { _unit = !Unit.HasValue ? _unit : Unit; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetStepTime(int? StepTime)
        { _stepTime = !StepTime.HasValue ? _stepTime : StepTime; if (!IsValid()) throw new DomainException(_errorMessages); }

        public sealed override bool IsValid()
        {
            return base.IsValid();
        }
        #endregion Behaviours
    }
}
