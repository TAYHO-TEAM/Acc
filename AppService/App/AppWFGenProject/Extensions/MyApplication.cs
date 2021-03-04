using Microsoft.Extensions.Configuration;
using System;

namespace AppWFGenProject.Extensions
{
    public class MyApplication
    {
        public readonly string _baseURL;
        public MyApplication(IConfiguration configuration)
        {
            _baseURL = configuration["ServerURL"];
        }

    }
}
