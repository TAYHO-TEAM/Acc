using OperationManager.CRUD.DAL.DTO.BaseClasses;
using System;
using System.Collections.Generic;
using System.Text;

namespace OperationManager.CRUD.DAL.DTO
{
    public class CustomerRealEstate : DOBase
    {
        public int? RealEstateId { get; set; }
        public int? CustomerInfoId { get; set; }
        public int? OwnerType { get; set; }

    }
}
