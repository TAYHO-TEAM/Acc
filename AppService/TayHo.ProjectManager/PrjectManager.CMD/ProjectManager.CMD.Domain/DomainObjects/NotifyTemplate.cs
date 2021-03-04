using ProjectManager.CMD.Domain.DomainObjects.BaseClasses;
using Services.Common.DomainObjects.Exceptions;
using System.ComponentModel.DataAnnotations;


namespace ProjectManager.CMD.Domain.DomainObjects
{
    public class NotifyTemplate : DOBase
    {
        #region Fields
        private string _code;
        private string _title;
        private string _content;

        #endregion Fields
        #region Constructors

        private NotifyTemplate()
        {
        }

        public NotifyTemplate(string Code, string Title, string Content) : this()
        {
            _code = Code;
            _title = Title;
            _content = Content;

        }
        #endregion Constructors
        #region Properties
        [MaxLength(128, ErrorMessage = nameof(ErrorCodeInsert.IErr128))] public string Code { get => _code; }
        [MaxLength(256, ErrorMessage = nameof(ErrorCodeInsert.IErr256))] public string Title { get => _title; }
        public string Content { get => _content; }
        #endregion Properties
        #region Behaviours


        public void SetCode(string Code) { _code = Code == null ? _code : Code; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetTitle(string Title) { _title = Title == null ? _title : Title; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetContent(string Content) { _content = Content == null ? _content : Content; if (!IsValid()) throw new DomainException(_errorMessages); }
        public sealed override bool IsValid()
        {
            return base.IsValid();
        }
        #endregion Behaviours
    }
}
