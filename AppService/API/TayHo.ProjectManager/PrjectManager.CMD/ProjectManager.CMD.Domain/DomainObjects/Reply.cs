using ProjectManager.CMD.Domain.DomainObjects.BaseClasses;
using Services.Common.DomainObjects.Exceptions;
using System.ComponentModel.DataAnnotations;


namespace ProjectManager.CMD.Domain.DomainObjects
{
    public class Reply : DOBase
    {
        #region Fields
        private int? _requestDetailId;
        private string _title;
        private byte? _noAttachment;
        private string _content;
        #endregion Fields
        #region Constructors
        private Reply()
        {
           
        }

        public Reply(int? RequestDetailId,
                        string Title,
                        byte? NoAttachment,
                        string Content) : this()
        {
            _requestDetailId = RequestDetailId;
            _title = Title;
            _noAttachment = NoAttachment;
            _content = Content;
            if (!IsValid()) throw new DomainException(_errorMessages);
        }
        #endregion Constructors
        #region Properties
        public int? RequestDetailId { get => _requestDetailId; }
        [MaxLength(256, ErrorMessage = nameof(ErrorCodeInsert.IErr256))] public string Title { get => _title; }
        public byte? NoAttachment { get => _noAttachment; }
        public string Content { get => _content; }
        #endregion Properties

        #region Behaviours
        public void SetRequestDetailId(int? RequestDetailId) { _requestDetailId = RequestDetailId.HasValue ? _requestDetailId : RequestDetailId; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetTitle(string Title) { _title = !string.IsNullOrEmpty(Title) ? _title : Title; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetNoAttachment(byte? NoAttachment) { _noAttachment = NoAttachment.HasValue ? _noAttachment : NoAttachment; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetContent(string Content) { _content = !string.IsNullOrEmpty(Content) ? _content : Content; if (!IsValid()) throw new DomainException(_errorMessages); }
        public sealed override bool IsValid()
        {
            return base.IsValid();
        }
        #endregion Behaviours
    }
}
