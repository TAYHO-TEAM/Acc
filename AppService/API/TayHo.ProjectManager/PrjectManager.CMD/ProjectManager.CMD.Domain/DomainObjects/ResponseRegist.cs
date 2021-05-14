using ProjectManager.CMD.Domain.DomainObjects.BaseClasses;
using Services.Common.DomainObjects.Exceptions;
using System.ComponentModel.DataAnnotations;


namespace ProjectManager.CMD.Domain.DomainObjects
{
    public class ResponseRegist : DOBase
    {
        #region Fields
        private string _title;
        private string _description;
        private int? _stepProcessId;
        private int? _requestRegistId;
        private int? _groupId;
        private int? _replyId;
        private byte? _noAttachment;
        private bool? _isApprove;
        private byte? _typeOfResult;
        #endregion Fields
        #region Constructors
        private ResponseRegist()
        {

        }

        public ResponseRegist(string Title,
                                string Description,
                                int? StepProcessId,
                                int? RequestRegistId,
                                int? GroupId,
                                int? ReplyId,
                                byte? NoAttachment,
                                bool? IsApprove,
                                byte? TypeOfResult) : this()
        {
            _title = Title;
            _description = Description;
            _stepProcessId = StepProcessId;
            _requestRegistId = RequestRegistId;
            _groupId = GroupId;
            _replyId = ReplyId;
            _noAttachment = NoAttachment;
            _isApprove = IsApprove;
            _typeOfResult = TypeOfResult;
            if (!IsValid()) throw new DomainException(_errorMessages);
        }
        #endregion Constructors
        #region Properties
        [MaxLength(256, ErrorMessage = nameof(ErrorCodeInsert.IErr256))] public string Title { get => _title; }
        public string Description { get => _description; }
        public int? StepProcessId { get => _stepProcessId; }
        public int? RequestRegistId { get => _requestRegistId; }
        public int? GroupId { get => _groupId; }
        public int? ReplyId { get => _replyId; }
        public byte? NoAttachment { get => _noAttachment; }
        public bool? IsApprove { get => _isApprove; }
        public byte? TypeOfResult { get => _typeOfResult; }
        #endregion Properties

        #region Behaviours
        public void SetTitle(string Title) { _title = Title == null ? _title : Title; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetDescription(string Description) { _description = Description == null ? _description : Description; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetStepProcessId(int? StepProcessId) { _stepProcessId = !StepProcessId.HasValue ? _stepProcessId : StepProcessId; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetRequestRegistId(int? RequestRegistId) { _requestRegistId = !RequestRegistId.HasValue ? _requestRegistId : RequestRegistId; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetGroupId(int? GroupId) { _groupId = !GroupId.HasValue ? _groupId : GroupId; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetReplyId(int? ReplyId) { _replyId = !ReplyId.HasValue ? _replyId : ReplyId; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetNoAttachment(byte? NoAttachment) { _noAttachment = !NoAttachment.HasValue ? _noAttachment : NoAttachment; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetIsApprove(bool? IsApprove) { _isApprove = !IsApprove.HasValue ? _isApprove : IsApprove; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetTypeOfResult(byte? TypeOfResult) { _typeOfResult = !TypeOfResult.HasValue ? _typeOfResult : TypeOfResult; if (!IsValid()) throw new DomainException(_errorMessages); }
        public sealed override bool IsValid()
        {
            return base.IsValid();
        }
        #endregion Behaviours
    }
}
