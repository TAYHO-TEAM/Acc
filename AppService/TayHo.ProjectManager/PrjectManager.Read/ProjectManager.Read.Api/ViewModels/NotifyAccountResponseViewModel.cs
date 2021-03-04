using ProjectManager.Read.Api.ViewModels.BaseClasses;
using System;

namespace ProjectManager.Read.Api.ViewModels
{
    public class NotifyAccountResponseViewModel : BaseResponseViewModel
    {
        public int? AccountId { get; set; }
        public int? GroupId { get; set; }
        public int? NotifyId { get; set; }
        public DateTime? PushTime { get; set; }
    }
}
