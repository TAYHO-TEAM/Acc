using Acc.Cmd.Domain.DomainObjects.BaseClasses;
using Services.Common.DomainObjects.Exceptions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Acc.Cmd.Domain.DomainObjects
{
    public class GroupAction : DOBase
    {
        #region Fields
        private int? _actionId;
        private int? _groupId;
        #endregion Fields
        #region Constructors

        private GroupAction()
        {
        }

        public GroupAction(int? ActionId,
                            int? GroupId) : this()
        {
            _actionId = ActionId;
            _groupId = GroupId;

        }
        #endregion Constructors
        #region Properties
        public int? ActionId { get => _actionId; }
        public int? GroupId { get => _groupId; }
        #endregion Properties

        #region Behaviours
        public void SetActionId(int? ActionId) { _actionId = ActionId.HasValue ? _actionId : ActionId; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetGroupId(int? GroupId) { _groupId = GroupId.HasValue ? _groupId : GroupId; if (!IsValid()) throw new DomainException(_errorMessages); }
        public sealed override bool IsValid()
        {
            return base.IsValid();
        }
        #endregion Behaviours
    }
}
