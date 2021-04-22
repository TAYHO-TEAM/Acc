using Microsoft.Extensions.Options;
using ProjectManager.CMD.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppWFGenProject.Extensions
{
    public class DBHelper
    {
        protected readonly ProjectManagerBaseContext _dbContext;
        public DBHelper(IOptionsSnapshot<ProjectManagerBaseContext> ProjectManagerBaseContext)
        {
            _dbContext = ProjectManagerBaseContext.Value;
        }
        public void DBGet<T>()
        {
            var a = _dbContext;
        }

    }
}
