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
			

        #endregion Fields
        #region Constructors

        private Conversation()
        {
        }

        public Conversation(string OwnerTable,int? TopicId,int? ParentId,string Content) : this()
        {
            _ownerTable = OwnerTable;
	 _topicId = TopicId;
			 _parentId = ParentId;
			 _content = Content;
			
        }

        #endregion Constructors
        #region Properties

        [MaxLength(128, ErrorMessage = nameof(ErrorCodeInsert.IErr128))]  public string OwnerTable { get=> _ownerTable;}
	 public int? TopicId { get=> _topicId;}
			 public int? ParentId { get=> _parentId;}
			 public string Content { get=> _content;}
			

        #endregion Properties
        #region Behaviours

         public void SetOwnerTable(string OwnerTable)
        { _ownerTable= OwnerTable == null? _ownerTable:OwnerTable;if (!IsValid()) throw new DomainException(_errorMessages);}
	 public void SetTopicId(int? TopicId)
        { _topicId= !TopicId.HasValue? _topicId:TopicId;if (!IsValid()) throw new DomainException(_errorMessages);}
			 public void SetParentId(int? ParentId)
        { _parentId= !ParentId.HasValue? _parentId:ParentId;if (!IsValid()) throw new DomainException(_errorMessages);}
			 public void SetContent(string Content)
        { _content= Content == null? _content:Content;if (!IsValid()) throw new DomainException(_errorMessages);}
			
       
        public sealed override bool IsValid()
        {
            return base.IsValid();
        }
        #endregion Behaviours
    }
}
