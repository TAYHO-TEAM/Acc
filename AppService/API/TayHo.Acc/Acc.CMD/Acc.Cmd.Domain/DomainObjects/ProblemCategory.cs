using Acc.Cmd.Domain.DomainObjects.BaseClasses;
using Services.Common.DomainObjects.Exceptions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Acc.Cmd.Domain.DomainObjects
{
    public class ProblemCategory : DOBase
    {
        #region Fields
        private string _title;
        private string _descriptions;
        private byte? _priotity;
        #endregion Fields
        #region Constructors

        private ProblemCategory()
        {
        }

        public ProblemCategory(string Title,
                                string Descriptions,
                                byte? Priotity) : this()
        {
            _title = Title;
            _descriptions = Descriptions;
            _priotity = Priotity;
        }
        #endregion Constructors
        #region Properties
        [MaxLength(256, ErrorMessage = nameof(ErrorCodeInsert.IErr256))] public string Title { get => _title; }
        [MaxLength(2048, ErrorMessage = nameof(ErrorCodeInsert.IErr2048))] public string Descriptions { get => _descriptions; }
        public byte? Priotity { get => _priotity; }
        #endregion Properties

        #region Behaviours
        public void SetTitle(string Title) { _title = string.IsNullOrEmpty(Title) ? _title : Title; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetDescriptions(string Descriptions) { _descriptions = string.IsNullOrEmpty(Descriptions) ? _descriptions : Descriptions; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetPriotity(byte? Priotity) { _priotity = Priotity.HasValue ? _priotity : Priotity; if (!IsValid()) throw new DomainException(_errorMessages); }
        public sealed override bool IsValid()
        {
            return base.IsValid();
        }
        #endregion Behaviours
    }
}
