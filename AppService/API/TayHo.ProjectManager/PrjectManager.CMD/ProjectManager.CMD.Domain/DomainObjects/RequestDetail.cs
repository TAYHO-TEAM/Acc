using ProjectManager.CMD.Domain.DomainObjects.BaseClasses;
using Services.Common.DomainObjects.Exceptions;
using System;

namespace ProjectManager.CMD.Domain.DomainObjects
{
    public class RequestDetail : DOBase
    {
        #region Fields
        private int? _requestId;
        private int? _problemCategoryId;
        private int? _replyByID;
        private string _title;
        private string _descriptions;
        private string _note;
        private int? _durationDate;
        private string _statusText;
        private DateTime? _fromDate;
        private DateTime? _toDate;
        private byte? _noAttachment;
        #endregion Fields
        #region Constructors
        private RequestDetail()
        {

        }

        public RequestDetail(int? RequestId,
                            int? ProblemCategoryId,
                            int? ReplyByID,
                            string Title,
                            string Descriptions,
                            string Note,
                            int? DurationDate,
                            string StatusText,
                            DateTime? FromDate,
                            DateTime? ToDate,
                            byte? NoAttachment) : this()
        {
            _requestId = RequestId;
            _problemCategoryId = ProblemCategoryId;
            _replyByID = ReplyByID;
            _title = Title;
            _descriptions = Descriptions;
            _note = Note;
            _durationDate = DurationDate;
            _statusText = StatusText;
            _fromDate = FromDate;
            _toDate = ToDate;
            _noAttachment = NoAttachment;
            if (!IsValid()) throw new DomainException(_errorMessages);
        }
        #endregion Constructors
        #region Properties
        public int? RequestId { get => _requestId; }
        public int? ProblemCategoryId { get => _problemCategoryId; }
        public int? ReplyByID { get => _replyByID; }
        public string Title { get => _title; }
        public string Descriptions { get => _descriptions; }
        public string Note { get => _note; }
        public int? DurationDate { get => _durationDate; }
        public string StatusText { get => _statusText; }
        public DateTime? FromDate { get => _fromDate; }
        public DateTime? ToDate { get => _toDate; }
        public byte? NoAttachment { get => _noAttachment; }
        #endregion Properties

        #region Behaviours
        public void SetRequestId(int? RequestId) { _requestId = RequestId.HasValue ? _requestId : RequestId; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetProblemCategoryId(int? ProblemCategoryId) { _problemCategoryId = ProblemCategoryId.HasValue ? _problemCategoryId : ProblemCategoryId; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetReplyByID(int? ReplyByID) { _replyByID = ReplyByID.HasValue ? _replyByID : ReplyByID; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetTitle(string Title) { _title = !string.IsNullOrEmpty(Title) ? _title : Title; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetDescriptions(string Descriptions) { _descriptions = !string.IsNullOrEmpty(Descriptions) ? _descriptions : Descriptions; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetNote(string Note) { _note = !string.IsNullOrEmpty(Note) ? _note : Note; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetDurationDate(int? DurationDate) { _durationDate = DurationDate.HasValue ? _durationDate : DurationDate; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetStatusText(string StatusText) { _statusText = !string.IsNullOrEmpty(StatusText) ? _statusText : StatusText; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetFromDate(DateTime? FromDate) { _fromDate = FromDate.HasValue ? _fromDate : FromDate; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetToDate(DateTime? ToDate) { _toDate = ToDate.HasValue ? _toDate : ToDate; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetNoAttachment(byte? NoAttachment) { _noAttachment = NoAttachment.HasValue ? _noAttachment : NoAttachment; if (!IsValid()) throw new DomainException(_errorMessages); }
        public sealed override bool IsValid()
        {
            return base.IsValid();
        }
        #endregion Behaviours
    }
}
