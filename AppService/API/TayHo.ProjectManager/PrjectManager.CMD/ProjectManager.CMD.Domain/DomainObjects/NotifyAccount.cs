using ProjectManager.CMD.Domain.DomainObjects.BaseClasses;
using Services.Common.DomainObjects.Exceptions;
using System;
using System.ComponentModel.DataAnnotations;


namespace ProjectManager.CMD.Domain.DomainObjects
{
    public class NotifyAccount : DOBase
    {
        #region Fields
        private int? _accountId;
        private int? _groupId;
        private int? _notifyId;
        private DateTime? _pushTime;

        #endregion Fields
        #region Constructors

        private NotifyAccount()
        {
        }

        public NotifyAccount(int? AccountId, int? GroupId, int? NotifyId, DateTime? PushTime) : this()
        {
            _accountId = AccountId;
            _groupId = GroupId;
            _notifyId = NotifyId;
            _pushTime = PushTime;

        }
        #endregion Constructors
        #region Properties
        public int? AccountId { get => _accountId; }
        public int? GroupId { get => _groupId; }
        public int? NotifyId { get => _notifyId; }
        public DateTime? PushTime { get => _pushTime; }
        #endregion Properties
        #region Behaviours
        public void SetAccountId(int? AccountId) { _accountId = !AccountId.HasValue ? _accountId : AccountId; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetGroupId(int? GroupId) { _groupId = !GroupId.HasValue ? _groupId : GroupId; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetNotifyId(int? NotifyId) { _notifyId = !NotifyId.HasValue ? _notifyId : NotifyId; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetPushTime(DateTime? PushTime) { _pushTime = !PushTime.HasValue ? _pushTime : PushTime; if (!IsValid()) throw new DomainException(_errorMessages); }

        public sealed override bool IsValid()
        {
            return base.IsValid();
        }
        #endregion Behaviours
    }
}
