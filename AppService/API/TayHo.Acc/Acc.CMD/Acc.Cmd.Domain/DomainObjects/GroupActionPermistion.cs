using Acc.Cmd.Domain.DomainObjects.BaseClasses;
using Services.Common.DomainObjects.Exceptions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Acc.Cmd.Domain.DomainObjects
{
    public class GroupActionPermistion : DOBase
    {
        #region Fields
        private int? _actionId;
        private int? _permistionId;
        private int? _groupId;
        #endregion Fields
        #region Constructors

        private GroupActionPermistion()
        {
        }

        public GroupActionPermistion(int? GroupId,
                                        int? ActionId,
                                        int? PermistionId) : this()
        {
            _groupId = GroupId;
            _actionId = ActionId;
            _permistionId = PermistionId;
        }
        #endregion Constructors
        #region Properties
        public int? GroupId { get => _groupId; }
        public int? ActionId { get => _actionId; }
        public int? PermistionId { get => _permistionId; }
        #endregion Properties

        #region Behaviours
        public void SetGroupId(int? GroupId) { _groupId = GroupId.HasValue ? _groupId : GroupId; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetActionId(int? ActionId) { _actionId = ActionId.HasValue ? _actionId : ActionId; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetPermistionId(int? PermistionId) { _permistionId = PermistionId.HasValue ? _permistionId : PermistionId; if (!IsValid()) throw new DomainException(_errorMessages); }
        public sealed override bool IsValid()
        {
            return base.IsValid();
        }
        #endregion Behaviours
    }
}
