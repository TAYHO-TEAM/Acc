using ProjectManager.CMD.Domain.DomainObjects.BaseClasses;
using Services.Common.DomainObjects.Exceptions;
using System.ComponentModel.DataAnnotations;

namespace ProjectManager.CMD.Domain.DomainObjects
{
    public class CustomForm : DOBase
    {
        #region Fields
        private string _code;
        private string _title;
        private string _header;
        private string _style;
        #endregion Fields
        #region Constructors

        private CustomForm()
        {
        }

        public CustomForm(string Code,
                            string Title,
                            string Header,
                            string Style) : this()
        {
            _code = Code;
            _title = Title;
            _header = Header;
            _style = Style;
        }
        #endregion Constructors
        #region Properties
        [MaxLength(256, ErrorMessage = nameof(ErrorCodeInsert.IErr256))] public string Code { get => _code; }
        [MaxLength(256, ErrorMessage = nameof(ErrorCodeInsert.IErr256))] public string Title { get => _title; }
        [MaxLength(256, ErrorMessage = nameof(ErrorCodeInsert.IErr256))] public string Header { get => _header; }
        [MaxLength(1028, ErrorMessage = nameof(ErrorCodeInsert.IErr1028))] public string Style { get => _style; }
        #endregion Properties

        #region Behaviours
        public void SetCode(string Code) { _code = Code == null ? _code : Code; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetTitle(string Title) { _title = Title == null ? _title : Title; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetHeader(string Header) { _header = Header == null ? _header : Header; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetStyle(string Style) { _style = Style == null ? _style : Style; if (!IsValid()) throw new DomainException(_errorMessages); }
        public sealed override bool IsValid()
        {
            return base.IsValid();
        }
        #endregion Behaviours
    }
}
