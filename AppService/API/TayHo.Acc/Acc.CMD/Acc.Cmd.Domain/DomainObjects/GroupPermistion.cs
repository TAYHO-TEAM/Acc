using Acc.Cmd.Domain.DomainObjects.BaseClasses;
using Services.Common.DomainObjects.Exceptions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Acc.Cmd.Domain.DomainObjects
{
    public class GroupPermistion : DOBase
    {
        #region Fields
        private int? _permistionId;
        private int? _groupId;
        #endregion Fields
        #region Constructors

        private GroupPermistion()
        {
        }

        public GroupPermistion(int? PermistionId,
                            int? GroupId) : this()
        {
            _permistionId = PermistionId;
            _groupId = GroupId;

        }
        #endregion Constructors
        #region Properties
        public int? PermistionId { get => _permistionId; }
        public int? GroupId { get => _groupId; }
        #endregion Properties

        #region Behaviours
        public void SetPermistionId(int? PermistionId) { _permistionId = PermistionId.HasValue ? _permistionId : PermistionId; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetGroupId(int? GroupId) { _groupId = GroupId.HasValue ? _groupId : GroupId; if (!IsValid()) throw new DomainException(_errorMessages); }
        public sealed override bool IsValid()
        {
            return base.IsValid();
        }
        #endregion Behaviours
    }
}
