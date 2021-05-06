using ProjectManager.CMD.Domain.DomainObjects.BaseClasses;
using Services.Common.DomainObjects;
using Services.Common.DomainObjects.Exceptions;
using Services.Common.Security;
using Services.Common.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace ProjectManager.CMD.Domain.DomainObjects
{
    public class SysJob : DOBase
    {
        #region Fields

        private string _jobName;
        private string _nameDataBase;
        private string _nameStoreProce;
        private string _connStringHash;
        private string _salt;
        private TimeSpan? _startTime;
        private TimeSpan? _endTime;
        private DateTime? _startDate;
        private DateTime? _endDate;
        private DateTime? _firstDate;
        private DateTime? _lastDate;
        private DateTime? _nextDate;
        private int? _times;
        private byte? _unit;
        private int? _stepTime;
        private bool? _isTemplate;


        #endregion Fields
        #region Constructors

        public SysJob()
        {
            _salt = Helpers.RandomSecretKey();
        }

        public SysJob(string JobName, string NameDataBase, string NameStoreProce, string ConnStringHash, TimeSpan? StartTime, TimeSpan? EndTime, DateTime? StartDate, DateTime? EndDate, DateTime? FirstDate, DateTime? LastDate, DateTime? NextDate, int? Times, byte? Unit, int? StepTime, bool? IsTemplate) : this()
        {
            _jobName = JobName;
            _nameDataBase = NameDataBase;
            _nameStoreProce = NameStoreProce;
            _connStringHash = ConnStringHash;
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
            _isTemplate = IsTemplate;
            if (!string.IsNullOrEmpty(ConnStringHash)) _connStringHash = Hash.Create(ConnStringHash, _salt);
            ValidateConnection(_connStringHash);
            if (!IsValid()) throw new DomainException(_errorMessages);

        }

        #endregion Constructors
        #region Properties

        [MaxLength(256, ErrorMessage = nameof(ErrorCodeInsert.IErr256))] public string JobName { get => _jobName; set { _jobName = value; } }
        [MaxLength(256, ErrorMessage = nameof(ErrorCodeInsert.IErr256))] public string NameDataBase { get => _nameDataBase; set { _nameDataBase = value; } }
        [MaxLength(512, ErrorMessage = nameof(ErrorCodeInsert.IErr512))] public string NameStoreProce { get => _nameStoreProce; set { _nameStoreProce = value; } }
        [MaxLength(512, ErrorMessage = nameof(ErrorCodeInsert.IErr512))] public string ConnStringHash { get => _connStringHash; set { _connStringHash = value; } }
        [MaxLength(512, ErrorMessage = nameof(ErrorCodeInsert.IErr512))] public string Salt { get => _salt; }
        public TimeSpan? StartTime { get => _startTime; set { _startTime = value; } }
        public TimeSpan? EndTime { get => _endTime; set { _endTime = value; } }
        public DateTime? StartDate { get => _startDate; set { _startDate = value; } }
        public DateTime? EndDate { get => _endDate; set { _endDate = value; } }
        public DateTime? FirstDate { get => _firstDate; set { _firstDate = value; } }
        public DateTime? LastDate { get => _lastDate; set { _lastDate = value; } }
        public DateTime? NextDate { get => _nextDate; set { _nextDate = value; } }
        public int? Times { get => _times; set { _times = value; } }
        public byte? Unit { get => _unit; set { _unit = value; } }
        public int? StepTime { get => _stepTime; set { _stepTime = value; } }
        public bool? IsTemplate { get => _isTemplate; set { _isTemplate = value; } }

        #endregion Properties
        #region Behaviours

        public void SetJobName(string JobName)
        { _jobName = JobName == null ? _jobName : JobName; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetNameDataBase(string NameDataBase)
        { _nameDataBase = NameDataBase == null ? _nameDataBase : NameDataBase; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetNameStoreProce(string NameStoreProce)
        { _nameStoreProce = NameStoreProce == null ? _nameStoreProce : NameStoreProce; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetStartTime(TimeSpan? StartTime)
        { _startTime = !StartTime.HasValue ? _startTime : StartTime; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetEndTime(TimeSpan? EndTime)
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
        public void SetConnStringHash(string ConnStringHash)
        {
            _connStringHash = string.IsNullOrEmpty(ConnStringHash) ? _connStringHash : Hash.Create(ConnStringHash, _salt); if (!IsValid()) throw new DomainException(_errorMessages);

        }
        public void SetSalt(string Salt) { _salt = string.IsNullOrEmpty(Salt) ? _salt : Salt; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetIsTemplate(bool? IsTemplate)
        { _isTemplate = !IsTemplate.HasValue ? _isTemplate : false ; if (!IsValid()) throw new DomainException(_errorMessages); }

        public sealed override bool IsValid()
        {
            return base.IsValid();
        }
        public void ValidateConnection(string connection)
        {
            if (string.IsNullOrEmpty(connection))
            {
                _errorMessages.Add(new ErrorResult
                {
                    ErrorCode = "-101",
                    ErrorMessage = nameof(ErrorCodeInsert.IErr000),
                    ErrorValues = new List<string>
                    {
                        ErrorHelpers.GenerateErrorResult(nameof(connection),connection)
                    }
                });
            }
        }
        #endregion Behaviours
    }
}
