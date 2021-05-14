using ProjectManager.CMD.Domain.DomainObjects.BaseClasses;
using Services.Common.DomainObjects.Exceptions;
using System.ComponentModel.DataAnnotations;

namespace ProjectManager.CMD.Domain.DomainObjects
{
    public class Assignments : DOBase
    {
        #region Fields
        private int? _accountId;
        private int? _requestId;
        private int? _requestDetailId;
        #endregion Fields
        #region Constructors
        private Assignments()
        {
           
        }

        public Assignments(int? AccountId,
                            int? RequestId,
                            int? RequestDetailId) : this()
        {
            _accountId = AccountId;
            _requestId = RequestId;
            _requestDetailId = RequestDetailId;
            if (!IsValid()) throw new DomainException(_errorMessages);
        }
        #endregion Constructors
        #region Properties
        public int? AccountId { get => _accountId; }
        public int? RequestId { get => _requestId; }
        public int? RequestDetailId { get => _requestDetailId; }
        #endregion Properties

        #region Behaviours
        public void SetAccountId(int? AccountId) { _accountId = AccountId.HasValue ? _accountId : AccountId; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetRequestId(int? RequestId) { _requestId = RequestId.HasValue ? _requestId : RequestId; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetRequestDetailId(int? RequestDetailId) { _requestDetailId = RequestDetailId.HasValue ? _requestDetailId : RequestDetailId; if (!IsValid()) throw new DomainException(_errorMessages); }
        public sealed override bool IsValid()
        {
            return base.IsValid();
        }
        #endregion Behaviours
    }
}
