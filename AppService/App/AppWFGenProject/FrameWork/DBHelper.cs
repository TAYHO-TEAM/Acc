using Microsoft.Extensions.Options;
using ProjectManager.CMD.Infrastructure;

namespace AppWFGenProject.FrameWork
{
    public class DBHelper
    {
        protected readonly ProjectManagerBaseContext _dbContext;
        public DBHelper(IOptionsSnapshot<ProjectManagerBaseContext> ProjectManagerBaseContext)
        {
            _dbContext = ProjectManagerBaseContext.Value;
        }
        public ProjectManagerBaseContext DBGet<T>()
        {
            return _dbContext;
        }

    }
}
