using Acc.Cmd.Domain.DomainObjects.BaseClasses;
using Services.Common.DomainObjects.Exceptions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Acc.Cmd.Domain.DomainObjects
{
    public class GroupAccount : DOBase
    {
        #region Fields
        private int? _accountId;
        private int? _groupId;
        #endregion Fields
        #region Constructors

        private GroupAccount()
        {
        }

        public GroupAccount(int? AccountId,
                            int? GroupId) : this()
        {
            _accountId = AccountId;
            _groupId = GroupId;

        }
        #endregion Constructors
        #region Properties
        public int? AccountId { get => _accountId; }
        public int? GroupId { get => _groupId; }
        #endregion Properties

        #region Behaviours
        public void SetAccountId(int? AccountId) { _accountId = AccountId.HasValue ? _accountId : AccountId; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetGroupId(int? GroupId) { _groupId = GroupId.HasValue ? _groupId : GroupId; if (!IsValid()) throw new DomainException(_errorMessages); }
        public sealed override bool IsValid()
        {
            return base.IsValid();
        }
        #endregion Behaviours
    }
}
