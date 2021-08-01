using OperationManager.CRUD.DAL.DTO.BaseClasses;
using Services.Common.Security;
using System;
using System.Collections.Generic;
using System.Text;

namespace OperationManager.CRUD.DAL.DTO.OperationManagerDTO
{
    public class CustomerInfo : DOBase
    {
        public string Code { get; set; }
        public string Barcode { get; set; }
        public string SignCode { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? Birthday { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public byte? Sex { get; set; }
        public string IDCard { get; set; }
        public int? NoAttachment { get; set; }
        public CustomerInfo()
        {
            
        }
        public void SetSignCode()
        {
            SignCode = GenerateHelper.GenCode(8);
        }
    }
}
