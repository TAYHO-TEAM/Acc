using OperationManager.CRUD.DAL.DTO.BaseClasses;

namespace OperationManager.CRUD.DAL.DTO
{
    public class ConstructionCategory : DOBase
    {
        public string Code { get; set; }
        public string Barcode { get; set; }
        public int? ProjectId { get; set; }
        public int? ParentId { get; set; }
        public string Title { get; set; }
        public int? Type { get; set; }
        public string Descriptions { get; set; }
        public int? Priority { get; set; }
    }
}
