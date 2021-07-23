using OperationManager.CRUD.BLL.IRepositories;
using OperationManager.CRUD.DAL.DBContext;
using OperationManager.CRUD.DAL.DTO.BaseClasses;
using System;
using System.Collections.Generic;
using System.Text;

namespace OperationManager.CRUD.BLL.Repositories
{
    public class ComplaintRepository<T> : IComplaintRepository<T> where T : DOBase
    {
        protected readonly QuanLyVanHanhContext _dbContext;
        public ComplaintRepository(QuanLyVanHanhContext dbContext)
        {
            _dbContext = dbContext;
        }

    }
}
