using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using ProjectManager.CMD.Infrastructure;
using System.Collections;
using System.Collections.ObjectModel;
using System.ComponentModel;

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
        public class ObservableListSource<T> : ObservableCollection<T>, IListSource
           where T : class
        {
            private IBindingList _bindingList;

            bool IListSource.ContainsListCollection { get { return false; } }

            IList IListSource.GetList()
            {
                return _bindingList ?? (_bindingList = this.ToBindingList());
            }
        }
    }
}
