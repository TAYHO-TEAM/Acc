using ProjectManager.CMD.Domain.DomainObjects.BaseClasses;
using Services.Common.DomainObjects.Exceptions;
using System;
using System.ComponentModel.DataAnnotations;

namespace ProjectManager.CMD.Domain.DomainObjects
{
    public class PlanRegister : DOBase
    {
        #region Fields
        private int? _parentId;
        private int? _documentTypeId;
        private int? _workItemId;
        private string _code;
        private string _title;
        private int? _projectId;
        private int? _contractorInfoId;
        private string _description;
        private DateTime? _requestDate;
        private DateTime? _responseDate;
        private DateTime? _expectRequestDate;
        private DateTime? _expectResponseDate;
        #endregion Fields
        #region Constructors
        private PlanRegister()
        {
           
        }

        public PlanRegister(int? ParentId,
                            int? DocumentTypeId,
                            int? WorkItemId,
                            string Code,
                            string Title,
                            int? ProjectId,
                            int? ContractorInfoId,
                            string Description,
                            DateTime? RequestDate,
                            DateTime? ResponseDate,
                            DateTime? ExpectRequestDate,
                            DateTime? ExpectResponseDate) : this()
        {
            _parentId = ParentId;
            _documentTypeId = DocumentTypeId;
            _workItemId = WorkItemId;
            _code = Code;
            _title = Title;
            _projectId = ProjectId;
            _contractorInfoId = ContractorInfoId;
            _description = Description;
            _requestDate = RequestDate;
            _responseDate = ResponseDate;
            _expectRequestDate = ExpectRequestDate;
            _expectResponseDate = ExpectResponseDate;
            if (!IsValid()) throw new DomainException(_errorMessages);
        }
        #endregion Constructors
        #region Properties
        public int? ParentId { get => _parentId; }
        public int? DocumentTypeId { get => _documentTypeId; }
        public int? WorkItemId { get => _workItemId; }
        [MaxLength(128, ErrorMessage = nameof(ErrorCodeInsert.IErr128))] public string Code { get => _code; }
        [MaxLength(512, ErrorMessage = nameof(ErrorCodeInsert.IErr512))] public string Title { get => _title; }
        public int? ProjectId { get => _projectId; }
        public int? ContractorInfoId { get => _contractorInfoId; }
        public string Description { get => _description; }
        public DateTime? RequestDate { get => _requestDate; }
        public DateTime? ResponseDate { get => _responseDate; }
        public DateTime? ExpectRequestDate { get => _expectRequestDate; }
        public DateTime? ExpectResponseDate { get => _expectResponseDate; }
        #endregion Properties

        #region Behaviours
        public void SetParentId(int? ParentId) { _parentId = !ParentId.HasValue ? _parentId : ParentId; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetDocumentTypeId(int? DocumentTypeId) { _documentTypeId = !DocumentTypeId.HasValue ? _documentTypeId : DocumentTypeId; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetWorkItemId(int? WorkItemId) { _workItemId = !WorkItemId.HasValue ? _workItemId : WorkItemId; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetCode(string Code) { _code = Code == null ? _code : Code; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetTitle(string Title) { _title = Title == null ? _title : Title; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetProjectId(int? ProjectId) { _projectId = !ProjectId.HasValue ? _projectId : ProjectId; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetContractorInfoId(int? ContractorInfoId) { _contractorInfoId = !ContractorInfoId.HasValue ? _contractorInfoId : ContractorInfoId; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetDescription(string Description) { _description = Description == null ? _description : Description; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetRequestDate(DateTime? RequestDate) { _requestDate = !RequestDate.HasValue ? _requestDate : RequestDate; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetResponseDate(DateTime? ResponseDate) { _responseDate = !ResponseDate.HasValue ? _responseDate : ResponseDate; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetExpectRequestDate(DateTime? ExpectRequestDate) { _expectRequestDate = !ExpectRequestDate.HasValue ? _expectRequestDate : ExpectRequestDate; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetExpectResponseDate(DateTime? ExpectResponseDate) { _expectResponseDate = !ExpectResponseDate.HasValue ? _expectResponseDate : ExpectResponseDate; if (!IsValid()) throw new DomainException(_errorMessages); }

        public sealed override bool IsValid()
        {
            return base.IsValid();
        }
        #endregion Behaviours
    }
}
