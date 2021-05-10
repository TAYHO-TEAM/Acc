using Services.Common.Paging;


namespace ProjectManager.Read.Sql.Parameters
{
    public class RequestSysJobFilterParam 
    {
        public int AccountId { get; set; }
        public string DBName { get; set; }
        public string StoreName { get; set; }
        public int Type { get; set; }

    }
}
