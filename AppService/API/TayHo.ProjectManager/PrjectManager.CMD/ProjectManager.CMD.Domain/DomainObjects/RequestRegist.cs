using ProjectManager.CMD.Domain.DomainEvents.RequestRegistDomainEvent;
using ProjectManager.CMD.Domain.DomainObjects.BaseClasses;
using Services.Common.DomainObjects.Exceptions;
using System.ComponentModel.DataAnnotations;


namespace ProjectManager.CMD.Domain.DomainObjects
{
    public class RequestRegist : DOBase
    {
        #region Fields
        private int? _planRegisterId;
        private string _code;
        private string _barCode;
        private string _title;
        private string _descriptions;
        private string _note;
        private int? _parentId;
        private int? _level;
        private byte? _noAttachment;
        private int? _projectId;
        private int? _workItemId;
        private int? _documentTypeId;
        private int? _rev;
        #endregion Fields
        #region Constructors
        private RequestRegist()
        {

        }

        public RequestRegist(int? PlanRegisterId,
                                string Code,
                                string BarCode,
                                string Title,
                                string Descriptions,
                                string Note,
                                int? ParentId,
                                int? Level,
                                byte? NoAttachment,
                                int? ProjectId,
                                int? WorkItemId,
                                int? DocumentTypeId,
                                int? Rev) : this()
        {
            _planRegisterId = PlanRegisterId;
            _code = Code;
            _barCode = BarCode;
            _title = Title;
            _descriptions = Descriptions;
            _note = Note;
            _parentId = ParentId;
            _level = Level;
            _noAttachment = NoAttachment;
            _projectId = ProjectId;
            _workItemId = WorkItemId;
            _documentTypeId = DocumentTypeId;
            _rev = Rev;
            //AddRequestRegistCreatedDomainEvent();
            if (!IsValid()) throw new DomainException(_errorMessages);
            
        }
        #endregion Constructors
        #region Properties
        public int? PlanRegisterId { get => _planRegisterId; }
        [MaxLength(64, ErrorMessage = nameof(ErrorCodeInsert.IErr64))] public string Code { get => _code; }
        [MaxLength(128, ErrorMessage = nameof(ErrorCodeInsert.IErr128))] public string BarCode { get => _barCode; }
        [MaxLength(256, ErrorMessage = nameof(ErrorCodeInsert.IErr256))] public string Title { get => _title; }
        public string Descriptions { get => _descriptions; }
        public string Note { get => _note; }
        public int? ParentId { get => _parentId; }
        public int? Level { get => _level; }
        public byte? NoAttachment { get => _noAttachment; }
        public int? ProjectId { get => _projectId; }
        public int? WorkItemId { get => _workItemId; }
        public int? DocumentTypeId { get => _documentTypeId; }
        public int? Rev { get => _rev; }
        #endregion Properties

        #region Behaviours
        public void SetPlanRegisterId(int? PlanRegisterId) { _planRegisterId = !PlanRegisterId.HasValue ? _planRegisterId : PlanRegisterId; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetCode(string Code) { _code = Code == null ? _code : Code; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetBarCode(string BarCode) { _barCode = BarCode == null ? _barCode : BarCode; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetTitle(string Title) { _title = Title == null ? _title : Title; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetDescriptions(string Descriptions) { _descriptions = Descriptions == null ? _descriptions : Descriptions; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetNote(string Note) { _note = Note == null ? _note : Note; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetParentId(int? ParentId) { _parentId = !ParentId.HasValue ? _parentId : ParentId; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetLevel(int? Level) { _level = !Level.HasValue ? _level : Level; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetNoAttachment(byte? NoAttachment) { _noAttachment = !NoAttachment.HasValue ? _noAttachment : NoAttachment; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetProjectId(int? ProjectId) { _projectId = !ProjectId.HasValue ? _projectId : ProjectId; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetWorkItemId(int? WorkItemId) { _workItemId = !WorkItemId.HasValue ? _workItemId : WorkItemId; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetDocumentTypeId(int? DocumentTypeId) { _documentTypeId = !DocumentTypeId.HasValue ? _documentTypeId : DocumentTypeId; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetRev(int? Rev) { _rev = !Rev.HasValue ? _rev : Rev; if (!IsValid()) throw new DomainException(_errorMessages); }
        public sealed override bool IsValid()
        {
            return base.IsValid();
        }
        public void AddRequestRegistCreatedDomainEvent()
        {
            var requestRegistCreatedDomainEvent = new RequestRegistCreatedDomainEvent(this);
            ClearDomainEvents();
            AddDomainEvent(requestRegistCreatedDomainEvent);
        }
        #endregion Behaviours
    }
}
