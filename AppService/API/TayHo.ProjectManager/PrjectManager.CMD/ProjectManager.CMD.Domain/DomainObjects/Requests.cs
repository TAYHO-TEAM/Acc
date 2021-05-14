using ProjectManager.CMD.Domain.DomainObjects.BaseClasses;
using Services.Common.DomainObjects.Exceptions;
using System;
using System.ComponentModel.DataAnnotations;


namespace ProjectManager.CMD.Domain.DomainObjects
{
    public class Requests : DOBase
    {
        #region Fields
        private int? _projectId;
        private string _code;
        private int? _requestFromId;
        private int? _stageId;
        private byte? _priority;
        private int? _replyById;
        private DateTime? _sendDateTime;
        private byte? _noAttachment;
        #endregion Fields
        #region Constructors
        private Requests()
        {

        }

        public Requests(string Code, int? ProjectId, int? RequestFromId, int? StageId, byte? Priority, int? ReplyById, DateTime? SendDateTime, byte? NoAttachment) : this()
        {
            _projectId = ProjectId;
            _code = Code;
            _requestFromId = RequestFromId;
            _stageId = StageId;
            _priority = Priority;
            _replyById = ReplyById;
            _sendDateTime = SendDateTime;
            _noAttachment = NoAttachment;
            if (!IsValid()) throw new DomainException(_errorMessages);
        }
        #endregion Constructors
        #region Properties
        public int? ProjectId { get => _projectId; }
        [MaxLength(32, ErrorMessage = nameof(ErrorCodeInsert.IErr32))]
        public string Code { get => _code; }
        public int? RequestFromId { get => _requestFromId; }
        public int? StageId { get => _stageId; }
        public byte? Priority { get => _priority; }
        public int? ReplyById { get => _replyById; }
        public DateTime? SendDateTime { get => _sendDateTime; }
        public byte? NoAttachment { get => _noAttachment; }
        #endregion Properties

        #region Behaviours
        public void SetProjectId(int? ProjectId) { _projectId = ProjectId.HasValue ? _projectId : ProjectId; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetCode(string Code) { _code = !string.IsNullOrEmpty(Code) ? _code : Code; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetRequestFromId(int? RequestFromId) { _requestFromId = RequestFromId.HasValue ? _requestFromId : RequestFromId; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetStageId(int? StageId) { _stageId = StageId.HasValue ? _stageId : StageId; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetPriority(byte? Priority) { _priority = Priority.HasValue ? _priority : Priority; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetReplyById(int? ReplyById) { _replyById = ReplyById.HasValue ? _replyById : ReplyById; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetSendDateTime(DateTime? SendDateTime) { _sendDateTime = SendDateTime.HasValue ? _sendDateTime : SendDateTime; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetNoAttachment(byte? NoAttachment) { _noAttachment = NoAttachment.HasValue ? _noAttachment : NoAttachment; if (!IsValid()) throw new DomainException(_errorMessages); }
        public sealed override bool IsValid()
        {
            return base.IsValid();
        }
        #endregion Behaviours
    }
}
