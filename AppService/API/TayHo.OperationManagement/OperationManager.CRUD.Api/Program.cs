using Services.Common.APIs;


namespace OperationManager.CRUD.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            APIProgramBase<Startup>.Main(args, host => { });
        }
    }
}
