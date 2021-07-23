using OperationManager.CRUD.BLL.IRepositories;
using OperationManager.CRUD.DAL.DBContext;
using System;
using System.Collections.Generic;
using System.Text;

namespace OperationManager.CRUD.BLL.Repositories
{
    public class DocumentReleasedRepository: IDocumentReleasedRepository
    {
        protected readonly QuanLyVanHanhContext _dbContext;
        public DocumentReleasedRepository(QuanLyVanHanhContext dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
