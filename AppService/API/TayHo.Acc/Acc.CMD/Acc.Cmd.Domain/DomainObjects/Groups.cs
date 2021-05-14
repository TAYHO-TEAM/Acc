using Acc.Cmd.Domain.DomainObjects.BaseClasses;
using Services.Common.DomainObjects.Exceptions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Acc.Cmd.Domain.DomainObjects
{
    public class Groups : DOBase
    {
        #region Fields
        private string _title;
        private string _descriptions;
        private byte? _type;
        #endregion Fields
        #region Constructors

        private Groups()
        {
        }

        public Groups(string Title,
                        string Descriptions,
                        byte? Type) : this()
        {
            _title = Title;
            _descriptions = Descriptions;
            _type = Type;
        }
        #endregion Constructors
        #region Properties
        [MaxLength(512, ErrorMessage = nameof(ErrorCodeInsert.IErr512))] public string Title { get => _title; }
        [MaxLength(1024, ErrorMessage = nameof(ErrorCodeInsert.IErr1024))] public string Descriptions { get => _descriptions; }
        public byte? Type { get => _type; }
        #endregion Properties

        #region Behaviours
        public void SetTitle(string Title) { _title = string.IsNullOrEmpty(Title) ? _title : Title; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetDescriptions(string Descriptions) { _descriptions = string.IsNullOrEmpty(Descriptions) ? _descriptions : Descriptions; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetType(byte? Type) { _type = Type.HasValue ? _type : Type; if (!IsValid()) throw new DomainException(_errorMessages); }
        public sealed override bool IsValid()
        {
            return base.IsValid();
        }
        #endregion Behaviours
    }
}
