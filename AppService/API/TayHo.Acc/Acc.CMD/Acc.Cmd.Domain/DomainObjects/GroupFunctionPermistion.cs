using Acc.Cmd.Domain.DomainObjects.BaseClasses;
using Services.Common.DomainObjects.Exceptions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Acc.Cmd.Domain.DomainObjects
{
    public class GroupFunctionPermistion : DOBase
    {
        #region Fields
        private int? _groupId;
        private int? _functionId;
        private int? _permistionId;
        #endregion Fields
        #region Constructors

        private GroupFunctionPermistion()
        {
        }

        public GroupFunctionPermistion(int? GroupId,
                                int? FunctionId,
                                int? PermistionId) : this()
        {
            _groupId = GroupId;
            _functionId = FunctionId;
            _permistionId = PermistionId;
        }
        #endregion Constructors
        #region Properties
        [Required(ErrorMessage = nameof(ErrorCodeInsert.IErr000))] public int? GroupId { get => _groupId; }
        [Required(ErrorMessage = nameof(ErrorCodeInsert.IErr000))] public int? FunctionId { get => _functionId; }
        [Required(ErrorMessage = nameof(ErrorCodeInsert.IErr000))] public int? PermistionId { get => _permistionId; }
        #endregion Properties

        #region Behaviours
        public void SetGroupId(int? GroupId) { _groupId = !GroupId.HasValue ? _groupId : GroupId; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetFunctionId(int? FunctionId) { _functionId = !FunctionId.HasValue ? _functionId : FunctionId; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetPermistionId(int? PermistionId) { _permistionId = !PermistionId.HasValue ? _permistionId : PermistionId; if (!IsValid()) throw new DomainException(_errorMessages); }
        public sealed override bool IsValid()
        {
            return base.IsValid();
        }
        #endregion Behaviours
    }
}
