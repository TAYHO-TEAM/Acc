using ProjectManager.CMD.Domain.DomainObjects.BaseClasses;
using Services.Common.DomainObjects.Exceptions;
using System.ComponentModel.DataAnnotations;


namespace ProjectManager.CMD.Domain.DomainObjects
{
    public class NotifyConfigLog : DOBase
    {
        #region Fields

        private int? _notifyConfigId;
        private int? _ownerById;


        #endregion Fields
        #region Constructors

        private NotifyConfigLog()
        {
        }

        public NotifyConfigLog(int? NotifyConfigId, int? OwnerById) : this()
        {
            _notifyConfigId = NotifyConfigId;
            _ownerById = OwnerById;

        }

        #endregion Constructors
        #region Properties

        public int? NotifyConfigId { get => _notifyConfigId; }
        public int? OwnerById { get => _ownerById; }


        #endregion Properties
        #region Behaviours

        public void SetNotifyConfigId(int? NotifyConfigId)
        { _notifyConfigId = !NotifyConfigId.HasValue ? _notifyConfigId : NotifyConfigId; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetOwnerById(int? OwnerById)
        { _ownerById = !OwnerById.HasValue ? _ownerById : OwnerById; if (!IsValid()) throw new DomainException(_errorMessages); }


        public sealed override bool IsValid()
        {
            return base.IsValid();
        }
        #endregion Behaviours
    }
}
