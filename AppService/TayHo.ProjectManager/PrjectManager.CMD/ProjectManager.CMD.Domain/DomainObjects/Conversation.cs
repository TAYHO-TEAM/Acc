using ProjectManager.CMD.Domain.DomainObjects.BaseClasses;
using Services.Common.DomainObjects.Exceptions;
using System.ComponentModel.DataAnnotations;


namespace ProjectManager.CMD.Domain.DomainObjects
{
    public class Conversation : DOBase
    {
        #region Fields

        private string _ownerTable;
        private int? _topicId;
        private int? _parentId;
        private string _content;
        private byte? _noAttachment;

        #endregion Fields
        #region Constructors

        private Conversation()
        {
        }

        public Conversation(string OwnerTable, int? TopicId, int? ParentId, string Content, byte? NoAttachment) : this()
        {
            _ownerTable = OwnerTable;
            _topicId = TopicId;
            _parentId = ParentId;
            _content = Content;
            _noAttachment = NoAttachment;
            if (!IsValid()) throw new DomainException(_errorMessages);
        }

        #endregion Constructors
        #region Properties

        [MaxLength(128, ErrorMessage = nameof(ErrorCodeInsert.IErr128))] public string OwnerTable { get => _ownerTable; }
        public int? TopicId { get => _topicId; }
        public int? ParentId { get => _parentId; }
        public string Content { get => _content; }
        public byte? NoAttachment { get => _noAttachment; }

        #endregion Properties
        #region Behaviours

        public void SetOwnerTable(string OwnerTable)
        { _ownerTable = OwnerTable == null ? _ownerTable : OwnerTable; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetTopicId(int? TopicId)
        { _topicId = !TopicId.HasValue ? _topicId : TopicId; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetParentId(int? ParentId)
        { _parentId = !ParentId.HasValue ? _parentId : ParentId; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetContent(string Content)
        { _content = Content == null ? _content : Content; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetNoAttachment(byte? NoAttachment) 
        { _noAttachment = !NoAttachment.HasValue ? _noAttachment : NoAttachment; if (!IsValid()) throw new DomainException(_errorMessages); }

        public sealed override bool IsValid()
        {
            return base.IsValid();
        }
        #endregion Behaviours
    }
}
