using ProjectManager.CMD.Domain.DomainObjects.BaseClasses;
using Services.Common.DomainObjects.Exceptions;
using System.ComponentModel.DataAnnotations;

namespace ProjectManager.CMD.Domain.DomainObjects
{
    public class CustomTable : DOBase
    {
        #region Fields
        private string _code;
        private string _title;
        private int? _noColum;
        private int? _noRown;
        private string _style;
        private int? _priority;
        #endregion Fields
        #region Constructors

        private CustomTable()
        {
        }

        public CustomTable(string Code,
                            string Title,
                            int? NoColum,
                            int? NoRown,
                            string Style,
                            int? Priority) : this()
        {
            _code = Code;
            _title = Title;
            _noColum = NoColum;
            _noRown = NoRown;
            _style = Style;
            _priority = Priority;
        }
        #endregion Constructors
        #region Properties
        [MaxLength(256, ErrorMessage = nameof(ErrorCodeInsert.IErr256))] public string Code { get => _code; }
        [MaxLength(512, ErrorMessage = nameof(ErrorCodeInsert.IErr512))] public string Title { get => _title; }
        public int? NoColum { get => _noColum; }
        public int? NoRown { get => _noRown; }
        [MaxLength(1024, ErrorMessage = nameof(ErrorCodeInsert.IErr1024))] public string Style { get => _style; }
        public int? Priority { get => _priority; }
        #endregion Properties

        #region Behaviours
        public void SetCode(string Code) { _code = Code == null ? _code : Code; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetTitle(string Title) { _title = Title == null ? _title : Title; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetNoColum(int? NoColum) { _noColum = !NoColum.HasValue ? _noColum : NoColum; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetNoRown(int? NoRown) { _noRown = !NoRown.HasValue ? _noRown : NoRown; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetStyle(string Style) { _style = Style == null ? _style : Style; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetPriority(int? Priority) { _priority = !Priority.HasValue ? _priority : Priority; if (!IsValid()) throw new DomainException(_errorMessages); }
        public sealed override bool IsValid()
        {
            return base.IsValid();
        }
        #endregion Behaviours
    }
}
