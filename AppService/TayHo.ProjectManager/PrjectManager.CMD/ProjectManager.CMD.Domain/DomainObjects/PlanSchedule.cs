using ProjectManager.CMD.Domain.DomainObjects.BaseClasses;
using Services.Common.DomainObjects.Exceptions;
using System;
using System.ComponentModel.DataAnnotations;


namespace ProjectManager.CMD.Domain.DomainObjects
{
    public class PlanSchedule : DOBase
    {
        #region Fields

        private int? _planMasterId;
        private int? _planJobId;
        private string _title;
        private string _note;
        private DateTime? _remind;
        private int? _repead;
        private string _repeadType;
        private DateTime? _startDate;
        private DateTime? _endDate;
        private int? _modifyTimes;


        #endregion Fields
        #region Constructors

        private PlanSchedule()
        {
        }

        public PlanSchedule(int? PlanMasterId, int? PlanJobId, string Title, string Note, DateTime? Remind, int? Repead, string RepeadType, DateTime? StartDate, DateTime? EndDate, int? ModifyTimes) : this()
        {
            _planMasterId = PlanMasterId;
            _planJobId = PlanJobId;
            _title = Title;
            _note = Note;
            _remind = Remind;
            _repead = Repead;
            _repeadType = RepeadType;
            _startDate = StartDate;
            _endDate = EndDate;
            _modifyTimes = ModifyTimes;

        }

        #endregion Constructors
        #region Properties

        public int? PlanMasterId { get => _planMasterId; }
        public int? PlanJobId { get => _planJobId; }
        [MaxLength(256, ErrorMessage = nameof(ErrorCodeInsert.IErr256))] public string Title { get => _title; }
        public string Note { get => _note; }
        public DateTime? Remind { get => _remind; }
        public int? Repead { get => _repead; }
        [MaxLength(128, ErrorMessage = nameof(ErrorCodeInsert.IErr128))] public string RepeadType { get => _repeadType; }
        public DateTime? StartDate { get => _startDate; }
        public DateTime? EndDate { get => _endDate; }
        public int? ModifyTimes { get => _modifyTimes; }


        #endregion Properties
        #region Behaviours

        public void SetPlanMasterId(int? PlanMasterId)
        { _planMasterId = !PlanMasterId.HasValue ? _planMasterId : PlanMasterId; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetPlanJobId(int? PlanJobId)
        { _planJobId = !PlanJobId.HasValue ? _planJobId : PlanJobId; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetTitle(string Title)
        { _title = Title == null ? _title : Title; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetNote(string Note)
        { _note = Note == null ? _note : Note; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetRemind(DateTime? Remind)
        { _remind = !Remind.HasValue ? _remind : Remind; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetRepead(int? Repead)
        { _repead = !Repead.HasValue ? _repead : Repead; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetRepeadType(string RepeadType)
        { _repeadType = RepeadType == null ? _repeadType : RepeadType; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetStartDate(DateTime? StartDate)
        { _startDate = !StartDate.HasValue ? _startDate : StartDate; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetEndDate(DateTime? EndDate)
        { _endDate = !EndDate.HasValue ? _endDate : EndDate; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetModifyTimes(int? ModifyTimes)
        { _modifyTimes = !ModifyTimes.HasValue ? _modifyTimes : ModifyTimes; if (!IsValid()) throw new DomainException(_errorMessages); }


        public sealed override bool IsValid()
        {
            return base.IsValid();
        }
        #endregion Behaviours
    }
}
