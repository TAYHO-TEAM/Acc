using ProjectManager.CMD.Domain.DomainObjects.BaseClasses;
using Services.Common.DomainObjects.Exceptions;
using System.ComponentModel.DataAnnotations;


namespace ProjectManager.CMD.Domain.DomainObjects
{
    public class ResponseRegistReply : DOBase
    {
        #region Fields
        private string _title;
        private string _description;
        private int? _replyAccountId;
        private int? _responseRegitId;
        private byte? _noAttachment;
        #endregion Fields
        #region Constructors
        private ResponseRegistReply()
        {

        }

        public ResponseRegistReply(string Title,
                                    string Description,
                                    int? ReplyAccountId,
                                    int? ResponseRegitId,
                                    byte? NoAttachment) : this()
        {
            _title = Title;
            _description = Description;
            _replyAccountId = ReplyAccountId;
            _responseRegitId = ResponseRegitId;
            _noAttachment = NoAttachment;
            if (!IsValid()) throw new DomainException(_errorMessages);
        }
        #endregion Constructors
        #region Properties
        [MaxLength(256, ErrorMessage = nameof(ErrorCodeInsert.IErr256))] [Required(ErrorMessage = nameof(ErrorCodeInsert.IErr000))] public string Title { get => _title; }
        public string Description { get => _description; }
        public int? ReplyAccountId { get => _replyAccountId; }
        public int? ResponseRegitId { get => _responseRegitId; }
        public byte? NoAttachment { get => _noAttachment; }
        #endregion Properties

        #region Behaviours
        public void SetTitle(string Title) { _title = string.IsNullOrEmpty(Title) ? _title : Title; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetDescription(string Description) { _description = Description == null ? _description : Description; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetReplyAccountId(int? ReplyAccountId) { _replyAccountId = !ReplyAccountId.HasValue ? _replyAccountId : ReplyAccountId; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetResponseRegitId(int? ResponseRegitId) { _responseRegitId = !ResponseRegitId.HasValue ? _responseRegitId : ResponseRegitId; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetNoAttachment(byte? NoAttachment) { _noAttachment = !NoAttachment.HasValue ? _noAttachment : NoAttachment; if (!IsValid()) throw new DomainException(_errorMessages); }
        public sealed override bool IsValid()
        {
            return base.IsValid();
        }
        #endregion Behaviours
    }
}
