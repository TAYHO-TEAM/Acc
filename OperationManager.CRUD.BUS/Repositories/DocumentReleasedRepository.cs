using OperationManager.CRUD.BLL.IRepositories;
using OperationManager.CRUD.DAL.DBContext;
using System;
using System.Collections.Generic;
using System.Text;

namespace OperationManager.CRUD.BLL.Repositories
{
    public class DocumentReleasedRepository: IDocumentReleasedRepositories
    {
        protected readonly QuanLyVanHanhContext _dbContext;
        public DocumentReleasedRepository(QuanLyVanHanhContext dbContext)
        {
            _dbContext = dbContext;
            //_dbContext.ChangeTracker.AutoDetectChangesEnabled = false;
        }
    }
}
