using Acc.Cmd.Domain.DomainObjects.BaseClasses;
using Services.Common.DomainObjects.Exceptions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Acc.Cmd.Domain.DomainObjects
{
    public class DeviceAccount : DOBase
    {
        #region Fields
        private string _device;
        private int? _accountId;
        private string _deviceToken;
        private string _browser;
        #endregion Fields
        #region Constructors
        private DeviceAccount()
        {

        }

        public DeviceAccount(string Device,
                                int? AccountId,
                                string DeviceToken,
                                string Browser) : this()
        {
            _device = Device;
            _accountId = AccountId;
            _deviceToken = DeviceToken;
            _browser = Browser;
            if (!IsValid()) throw new DomainException(_errorMessages);
        }
        #endregion Constructors
        #region Properties
        [MaxLength(128, ErrorMessage = nameof(ErrorCodeInsert.IErr128))] public string Device { get => _device; }
        public int? AccountId { get => _accountId; }
        [MaxLength(1024, ErrorMessage = nameof(ErrorCodeInsert.IErr1024))] public string DeviceToken { get => _deviceToken; }
        [MaxLength(128, ErrorMessage = nameof(ErrorCodeInsert.IErr128))] public string Browser { get => _browser; }
        #endregion Properties

        #region Behaviours
        public void SetDevice(string Device) { _device = string.IsNullOrEmpty(Device) ? _device : Device; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetAccountId(int? AccountId) { _accountId = !AccountId.HasValue ? _accountId : AccountId; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetDeviceToken(string DeviceToken) { _deviceToken = string.IsNullOrEmpty(DeviceToken) ? _deviceToken : DeviceToken; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetBrowser(string Browser) { _browser = string.IsNullOrEmpty(Browser) ? _browser : Browser; if (!IsValid()) throw new DomainException(_errorMessages); }
        public sealed override bool IsValid()
        {
            return base.IsValid();
        }
        #endregion Behaviours
    }
}
