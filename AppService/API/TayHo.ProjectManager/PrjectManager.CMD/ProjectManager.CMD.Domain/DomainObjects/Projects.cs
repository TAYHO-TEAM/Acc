using ProjectManager.CMD.Domain.DomainObjects.BaseClasses;
using Services.Common.DomainObjects.Exceptions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ProjectManager.CMD.Domain.DomainObjects
{
    public class Projects : DOBase
    {
        #region Fields
        private string _code;
        private string _barCode;
        private string _title;
        private string _descriptions;
        private int? _parentId;
        private int? _nodeLevel;
        private int? _oldId;
        #endregion Fields
        #region Constructors

        private Projects()
        {
        }

        public Projects(string Code,
                        string BarCode,
                        string Title,
                        string Descriptions,
                        int? ParentId,
                        int? NodeLevel,
                        int? OldId) : this()
        {
            _code = Code;
            _barCode = BarCode;
            _title = Title;
            _descriptions = Descriptions;
            _parentId = ParentId;
            _nodeLevel = NodeLevel;
            _oldId = OldId;
        }
        #endregion Constructors
        #region Properties
        [MaxLength(64, ErrorMessage = nameof(ErrorCodeInsert.IErr64))] public string Code { get => _code; }
        [MaxLength(128, ErrorMessage = nameof(ErrorCodeInsert.IErr128))] public string BarCode { get => _barCode; }
        [MaxLength(1024, ErrorMessage = nameof(ErrorCodeInsert.IErr1024))] public string Title { get => _title; }
        public string Descriptions { get => _descriptions; }
        public int? ParentId { get => _parentId; }
        public int? NodeLevel { get => _nodeLevel; }
        public int? OldId { get => _oldId; }
        #endregion Properties

        #region Behaviours
        public void SetCode(string Code) { _code = string.IsNullOrEmpty(Code) ? _code : Code; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetBarCode(string BarCode) { _barCode = string.IsNullOrEmpty(BarCode) ? _barCode : BarCode; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetTitle(string Title) { _title = string.IsNullOrEmpty(Title) ? _title : Title; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetDescriptions(string Descriptions) { _descriptions = string.IsNullOrEmpty(Descriptions) ? _descriptions : Descriptions; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetParentId(int? ParentId) { _parentId = ParentId.HasValue ? _parentId : ParentId; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetNodeLevel(int? NodeLevel) { _nodeLevel = NodeLevel.HasValue ? _nodeLevel : NodeLevel; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetOldId(int? OldId) { _oldId = OldId.HasValue ? _oldId : OldId; if (!IsValid()) throw new DomainException(_errorMessages); }
        public sealed override bool IsValid()
        {
            return base.IsValid();
        }
        #endregion Behaviours
    }
}
