using ProjectManager.Read.Sql.DTOs.BaseClasses;

namespace ProjectManager.Read.Sql.DTOs.DTO
{
    public class AccountInfoDTO 
    {
        public int? AccountId { get; set; }
        public string AccountName { get; set; }
        public string UserName { get; set; }
        public byte[]? AvatarImg { get; set; }
        public string Title { get; set; }
        public string Department { get; set; }
        public int Type { get; set; }
    }
}
