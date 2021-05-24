using Microsoft.AspNetCore.Http;
using OperationManager.CRUD.DAL.DTO.BaseClasses;
using System;
using System.Collections.Generic;
using System.Text;

namespace OperationManager.CRUD.DAL.DTO
{
    public class DefectFeedback : DOBase
    {
        public int? RealEstateId { get; set; }
        public int? CustomerId { get; set; }
        public int? DefectiveId { get; set; }
        public string FullName { get; set; }
        public string Phone { get; set; }
        public string Note { get; set; }
        public int? NoAttachment { get; set; }
        private IFormFileCollection _formFiles { get; set; }
        public void setFile(IFormFileCollection FormFiles)
        {
            _formFiles = FormFiles;
        }
        public IFormFileCollection getFile()
        {
            return _formFiles;
        }
    }
}
