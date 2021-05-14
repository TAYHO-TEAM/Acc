using Acc.Cmd.Domain.DomainObjects.BaseClasses;
using Services.Common.DomainObjects.Exceptions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Acc.Cmd.Domain.DomainObjects
{
    public class Actions : DOBase
    {
        #region Fields
        private int? _parentId;
        private string _title;
        private string _descriptions;
        private string _icon;
        private string _url;
        private int? _categoryId;
        private int? _level;
        private byte? _priority;
        #endregion Fields
        #region Constructors

        private Actions()
        {
        }

        public Actions(int? ParentId,
                        string Title,
                        string Descriptions,
                        string Icon,
                        string Url,
                        int? CategoryId,
                        int? Level,
                        byte? Priority) : this()
        {
            _parentId = ParentId;
            _title = Title;
            _descriptions = Descriptions;
            _icon = Icon;
            _url = Url;
            _categoryId = CategoryId;
            _level = Level;
            _priority = Priority;
        }
        #endregion Constructors
        #region Properties
        public int? ParentId { get => _parentId; }
        [MaxLength(128, ErrorMessage = nameof(ErrorCodeInsert.IErr128))] public string Title { get => _title; }
        [MaxLength(1024, ErrorMessage = nameof(ErrorCodeInsert.IErr1024))] public string Descriptions { get => _descriptions; }
        [MaxLength(128, ErrorMessage = nameof(ErrorCodeInsert.IErr128))] public string Icon { get => _icon; }
        [MaxLength(1024, ErrorMessage = nameof(ErrorCodeInsert.IErr1024))] public string Url { get => _url; }
        public int? CategoryId { get => _categoryId; }
        public int? Level { get => _level; }
        public byte? Priority { get => _priority; }
        #endregion Properties

        #region Behaviours
        public void SetParentId(int? ParentId) { _parentId = ParentId.HasValue ? _parentId : ParentId; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetTitle(string Title) { _title = string.IsNullOrEmpty(Title) ? _title : Title; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetDescriptions(string Descriptions) { _descriptions = string.IsNullOrEmpty(Descriptions) ? _descriptions : Descriptions; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetIcon(string Icon) { _icon = string.IsNullOrEmpty(Icon) ? _icon : Icon; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetUrl(string Url) { _url = string.IsNullOrEmpty(Url) ? _url : Url; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetCategoryId(int? CategoryId) { _categoryId = CategoryId.HasValue ? _categoryId : CategoryId; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetLevel(int? Level) { _level = Level.HasValue ? _level : Level; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetPriority(byte? Priority) { _priority = Priority.HasValue ? _priority : Priority; if (!IsValid()) throw new DomainException(_errorMessages); }
        public sealed override bool IsValid()
        {
            return base.IsValid();
        }
        #endregion Behaviours
    }
}
