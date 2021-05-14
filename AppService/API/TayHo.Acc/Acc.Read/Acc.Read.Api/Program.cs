using Services.Common.APIs;

namespace Acc.Read.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            APIProgramBase<Startup>.Main(args, host => { });
        }
    }
}
