using OperationManager.CRUD.DAL.DTO.BaseClasses;
using System;
using System.Collections.Generic;
using System.Text;

namespace OperationManager.CRUD.DAL.DTO
{
    public class CustomerInfo : DOBase
    {
        public string Code { get; set; }
        public string BarCode { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? Birthday { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public byte? Sex { get; set; }
        public string IDCard { get; set; }

    }
}
