using ProjectManager.CMD.Domain.DomainObjects.BaseClasses;
using Services.Common.DomainObjects.Exceptions;
using System.ComponentModel.DataAnnotations;


namespace ProjectManager.CMD.Domain.DomainObjects
{
    public class Stages : DOBase
    {
        #region Fields
        private string _code;
        private string _title;
        private string _descriptions;
        #endregion Fields
        #region Constructors
        private Stages()
        {
           
        }

        public Stages(string Code, string Title,  string Descriptions) : this()
        {
            _code = Code;
            _title = Title;
            _descriptions = Descriptions;
            if (!IsValid()) throw new DomainException(_errorMessages);
        }
        #endregion Constructors
        #region Properties
        [MaxLength(32, ErrorMessage = nameof(ErrorCodeInsert.IErr32))]
        public string Code { get => _code; }
        [MaxLength(512, ErrorMessage = nameof(ErrorCodeInsert.IErr512))]
        public string Title { get => _title; }
        public string Descriptions { get => _descriptions; }
        #endregion Properties

        #region Behaviours
        public void SetTitle(string Title)
        {
            _title = string.IsNullOrEmpty(Title)? _title:Title ;
            if (!IsValid()) throw new DomainException(_errorMessages);
        }
        public void SetCode(string Code)
        {
            _code = string.IsNullOrEmpty(Code) ? _code : Code;
            if (!IsValid()) throw new DomainException(_errorMessages);
        }
        public void SetDescription(string Descriptions)
        {
            _descriptions = string.IsNullOrEmpty(Descriptions) ? _descriptions : Descriptions;
            if (!IsValid()) throw new DomainException(_errorMessages);
        }
        public sealed override bool IsValid()
        {
            return base.IsValid();
        }
        #endregion Behaviours
    }
}
