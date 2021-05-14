using System;

namespace Acc.Cmd.Api.Application.Commands
{
    public class AccountsCommandSet: BaseCommandClasses
    {
        public string Code { get; set; }
        public byte? Type { get; set; }
        public string AccountName { get; set; }
        public string Password { get; set; }
        public int? UserId { get; set; }
    }
}