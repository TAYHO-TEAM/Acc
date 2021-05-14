using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Acc.Cmd.Api.ViewModels
{
    public class LoginRequestViewModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Device { get; set; }
        public string DeviceToken { get; set; }
        public string Browser { get; set; }
    }
}
