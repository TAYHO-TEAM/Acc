
namespace Acc.Cmd.Domain.DTOs
{
    public class LoginDTO
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Device { get; set; }
        public string DeviceToken { get; set; }
        public string Browser { get; set; }
    }
}
