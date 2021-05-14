using Acc.Cmd.Domain.DomainObjects.BaseClasses;
using Services.Common.DomainObjects.Exceptions;
using System.ComponentModel.DataAnnotations;


namespace Acc.Cmd.Domain.DomainObjects
{
    public class WorkItems : DOBase
    {
        #region Fields
        private string _code;
        private string _barCode;
        private string _title;
        private string _description;
        private int? _parentId;
        private int? _level;
        private int? _projectId;
        #endregion Fields
        #region Constructors

        private WorkItems()
        {
        }

        public WorkItems(string Code,
                        string BarCode,
                        string Title,
                        string Description,
                        int? ParentId,
                        int? level,
                        int? ProjectId) : this()
        {
            _code = Code;
            _barCode = BarCode;
            _title = Title;
            _description = Description;
            _parentId = ParentId;
            _level = level;
            _projectId = ProjectId; 

        }
        #endregion Constructors
        #region Properties
        [MaxLength(64, ErrorMessage = nameof(ErrorCodeInsert.IErr64))] public string Code { get => _code; }
        [MaxLength(128, ErrorMessage = nameof(ErrorCodeInsert.IErr128))] public string BarCode { get => _barCode; }
        [MaxLength(256, ErrorMessage = nameof(ErrorCodeInsert.IErr256))] public string Title { get => _title; }
        public string Description { get => _description; }
        public int? ParentId { get => _parentId; }
        public int? level { get => _level; }
        public int? ProjectId { get => _projectId; }
        #endregion Properties

        #region Behaviours
        public void SetCode(string Code) { _code = Code == null ? _code : Code; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetBarCode(string BarCode) { _barCode = BarCode == null ? _barCode : BarCode; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetTitle(string Title) { _title = Title == null ? _title : Title; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetDescription(string Description) { _description = Description == null ? _description : Description; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetParentId(int? ParentId) { _parentId = !ParentId.HasValue ? _parentId : ParentId; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void Setlevel(int? level) { _level = !level.HasValue ? _level : level; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetProjectId(int? ProjectId) { _projectId = !ProjectId.HasValue ? _projectId : ProjectId; if (!IsValid()) throw new DomainException(_errorMessages); }
        public sealed override bool IsValid()
        {
            return base.IsValid();
        }
        #endregion Behaviours
    }
}
