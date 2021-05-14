using ProjectManager.CMD.Domain.DomainObjects.BaseClasses;
using Services.Common.DomainObjects.Exceptions;
using System.ComponentModel.DataAnnotations;

namespace ProjectManager.CMD.Domain.DomainObjects
{
    public class CustomFormContent : DOBase
    {
        #region Fields
        private string _code;
        private int? _customFormId;
        #endregion Fields
        #region Constructors

        private CustomFormContent()
        {
        }

        public CustomFormContent(string Code,
                                int? CustomFormId) : this()
        {
            _code = Code;
            _customFormId = CustomFormId;
        }
        #endregion Constructors
        #region Properties
        [MaxLength(128, ErrorMessage = nameof(ErrorCodeInsert.IErr128))] public string Code { get => _code; }
        public int? CustomFormId { get => _customFormId; }
        #endregion Properties

        #region Behaviours
        public void SetCode(string Code) { _code = Code == null ? _code : Code; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetCustomFormId(int? CustomFormId) { _customFormId = !CustomFormId.HasValue ? _customFormId : CustomFormId; if (!IsValid()) throw new DomainException(_errorMessages); }
        public sealed override bool IsValid()
        {
            return base.IsValid();
        }
        #endregion Behaviours
    }
}
