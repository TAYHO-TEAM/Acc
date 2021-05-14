using ProjectManager.CMD.Domain.DomainObjects.BaseClasses;
using Services.Common.DomainObjects.Exceptions;
using System.ComponentModel.DataAnnotations;
using System;

namespace ProjectManager.CMD.Domain.DomainObjects
{
    public class NS_Reason : DOBase
    {
        #region Fields
        private string _ten;
        private string _dienGiai;
        #endregion Fields

        #region Constructors
        private NS_Reason()
        {
        }

        public NS_Reason(string Ten, string DienGiai) : this()
        {
            _ten = Ten;
            _dienGiai = DienGiai;
        }
        #endregion Constructors

        #region Properties
        [MaxLength(500, ErrorMessage = nameof(ErrorCodeInsert.IErr500))] public string Ten { get => _ten; }
        public string DienGiai { get => _dienGiai; }
        #endregion Properties

        #region Behaviours
        public void SetTen(string Ten) { _ten = Ten == null ? _ten : Ten; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetDienGiai(string DienGiai) { _dienGiai = DienGiai == null ? _dienGiai : DienGiai; if (!IsValid()) throw new DomainException(_errorMessages); }
        public sealed override bool IsValid()
        {
            return base.IsValid();
        }
        #endregion Behaviours
    }
}
