using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppWFGenProject.Entities
{
    public class Paging <T> where T : class
    {
        public int TotalRecord { get; }
        public int CurrentPage { get; }
        public int PageSize { get; }
        public IEnumerable<T> Items { get; set; }
        public Paging(int? currentPage, int? pageSize, int? totalRecord)
        {
            TotalRecord = totalRecord.HasValue ? (int)totalRecord : 0;
            PageSize = pageSize.HasValue ? (int)pageSize : 20;
            CurrentPage = currentPage.HasValue ? (int)currentPage : 1;
        }
        public bool Fist()
        {
            if (CurrentPage > 1)
                return true;
            else
                return false;
        }
        public bool Previous()
        {
            if (CurrentPage > 1)
                return true;
            else
                return false;
        }
        
        public bool Next()
        {
            if (((TotalRecord / PageSize) + ((TotalRecord % PageSize) > 0 ? 1 : 0)) > CurrentPage)
                return true;
            else
                return false;
        }
        public bool Last()
        {
            if (((TotalRecord / PageSize) + ((TotalRecord % PageSize) > 0 ? 1 : 0)) > CurrentPage)
                return true;
            else
                return false;
        }

        public int Skip()
        {
            return (CurrentPage - 1) * PageSize;
        }
        public int Take()
        {
            return (CurrentPage * PageSize) - 1;
        }
    }
}
