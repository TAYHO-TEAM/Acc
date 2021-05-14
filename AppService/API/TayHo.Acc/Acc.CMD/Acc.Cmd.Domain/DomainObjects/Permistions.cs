using Acc.Cmd.Domain.DomainObjects.BaseClasses;
using Services.Common.DomainObjects.Exceptions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Acc.Cmd.Domain.DomainObjects
{
    public class Permistions : DOBase
    {
        #region Fields
        private byte? _type;
        private string _title;
        private string _descriptions;
        #endregion Fields
        #region Constructors

        private Permistions()
        {
        }

        public Permistions(byte? Type,
                            string Title,
                            string Descriptions) : this()
        {
            _type = Type;
            _title = Title;
            _descriptions = Descriptions;
        }
        #endregion Constructors
        #region Properties
        public byte? Type { get => _type; }
        [MaxLength(128, ErrorMessage = nameof(ErrorCodeInsert.IErr128))] public string Title { get => _title; }
        [MaxLength(1024, ErrorMessage = nameof(ErrorCodeInsert.IErr1024))] public string Descriptions { get => _descriptions; }
        #endregion Properties

        #region Behaviours
        public void SetType(byte? Type) { _type = Type.HasValue ? _type : Type; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetTitle(string Title) { _title = string.IsNullOrEmpty(Title) ? _title : Title; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetDescriptions(string Descriptions) { _descriptions = string.IsNullOrEmpty(Descriptions) ? _descriptions : Descriptions; if (!IsValid()) throw new DomainException(_errorMessages); }
        public sealed override bool IsValid()
        {
            return base.IsValid();
        }
        #endregion Behaviours
    }
}
