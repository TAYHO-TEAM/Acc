using ProjectManager.CMD.Domain.DomainObjects.BaseClasses;
using Services.Common.DomainObjects.Exceptions;
using System;
using System.ComponentModel.DataAnnotations;


namespace ProjectManager.CMD.Domain.DomainObjects
{
    public class Notify : DOBase
    {
        #region Fields
        private int? _type;
        private string _category;
        private string _message;
        private string _link;
        private int? _templateId;
        private string _title;
        private string _sub;
        private string _bodyContent;

        #endregion Fields
        #region Constructors

        private Notify()
        {
        }

        public Notify(int? Type,
                        string Category,
                        string Message,
                        string Link,
                        int? TemplateId,
                        string Title,
                        string Sub,
                        string BodyContent) : this()
        {
            _type = Type;
            _category = Category;
            _message = Message;
            _link = Link;
            _templateId = TemplateId;
            _title = Title;
            _sub = Sub;
            _bodyContent = BodyContent;
        }
        #endregion Constructors
        #region Properties


        public int? Type { get => _type; }
        [MaxLength(256, ErrorMessage = nameof(ErrorCodeInsert.IErr256))] public string Category { get => _category; }
        public string Message { get => _message; }
        [MaxLength(256, ErrorMessage = nameof(ErrorCodeInsert.IErr256))] public string Link { get => _link; }
        public int? TemplateId { get => _templateId; }
        [MaxLength(256, ErrorMessage = nameof(ErrorCodeInsert.IErr256))] public string Title { get => _title; }
        [MaxLength(256, ErrorMessage = nameof(ErrorCodeInsert.IErr256))] public string Sub { get => _sub; }
        public string BodyContent { get => _bodyContent; }

        #endregion Properties
        #region Behaviours
        public void SetType(int? Type) { _type = !Type.HasValue ? _type : Type; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetCategory(string Category) { _category = Category == null ? _category : Category; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetMessage(string Message) { _message = Message == null ? _message : Message; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetLink(string Link) { _link = Link == null ? _link : Link; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetTemplateId(int? TemplateId) { _templateId = !TemplateId.HasValue ? _templateId : TemplateId; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetTitle(string Title) { _title = Title == null ? _title : Title; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetSub(string Sub) { _sub = Sub == null ? _sub : Sub; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetBodyContent(string BodyContent) { _bodyContent = BodyContent == null ? _bodyContent : BodyContent; if (!IsValid()) throw new DomainException(_errorMessages); }
        public sealed override bool IsValid()
        {
            return base.IsValid();
        }
        #endregion Behaviours
    }
}
