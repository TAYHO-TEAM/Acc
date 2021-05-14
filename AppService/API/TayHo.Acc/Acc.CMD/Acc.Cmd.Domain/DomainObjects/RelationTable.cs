using Acc.Cmd.Domain.DomainObjects.BaseClasses;
using Services.Common.DomainObjects.Exceptions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Acc.Cmd.Domain.DomainObjects
{
    public class RelationTable : DOBase
    {
        #region Fields
        private string _primaryTable;
        private string _primaryKey;
        private string _foreignTable;
        private string _foreignKey;
        #endregion Fields
        #region Constructors

        private RelationTable()
        {
        }

        public RelationTable(string PrimaryTable,
                            string PrimaryKey,
                            string ForeignTable,
                            string ForeignKey) : this()
        {
            _primaryTable = PrimaryTable;
            _primaryKey = PrimaryKey;
            _foreignTable = ForeignTable;
            _foreignKey = ForeignKey;
        }
        #endregion Constructors
        #region Properties
        [MaxLength(128, ErrorMessage = nameof(ErrorCodeInsert.IErr128))] public string PrimaryTable { get => _primaryTable; }
        [MaxLength(128, ErrorMessage = nameof(ErrorCodeInsert.IErr128))] public string PrimaryKey { get => _primaryKey; }
        [MaxLength(128, ErrorMessage = nameof(ErrorCodeInsert.IErr128))] public string ForeignTable { get => _foreignTable; }
        [MaxLength(128, ErrorMessage = nameof(ErrorCodeInsert.IErr128))] public string ForeignKey { get => _foreignKey; }
        #endregion Properties

        #region Behaviours
        public void SetPrimaryTable(string PrimaryTable) { _primaryTable = string.IsNullOrEmpty(PrimaryTable) ? _primaryTable : PrimaryTable; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetPrimaryKey(string PrimaryKey) { _primaryKey = string.IsNullOrEmpty(PrimaryKey) ? _primaryKey : PrimaryKey; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetForeignTable(string ForeignTable) { _foreignTable = string.IsNullOrEmpty(ForeignTable) ? _foreignTable : ForeignTable; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetForeignKey(string ForeignKey) { _foreignKey = string.IsNullOrEmpty(ForeignKey) ? _foreignKey : ForeignKey; if (!IsValid()) throw new DomainException(_errorMessages); }
        public sealed override bool IsValid()
        {
            return base.IsValid();
        }
        #endregion Behaviours
    }
}
