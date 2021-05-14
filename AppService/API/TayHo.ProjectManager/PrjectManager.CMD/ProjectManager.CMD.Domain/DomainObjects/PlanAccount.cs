using ProjectManager.CMD.Domain.DomainObjects.BaseClasses;
using Services.Common.DomainObjects.Exceptions;
using System.ComponentModel.DataAnnotations;


namespace ProjectManager.CMD.Domain.DomainObjects
{
    public class PlanAccount : DOBase
    {
        #region Fields

        private int? _accountId;
	private int? _groupId;
			private int? _permistionId;
			private int? _ownerById;
			private string _ownerTable;
			

        #endregion Fields
        #region Constructors

        private PlanAccount()
        {
        }

        public PlanAccount(int? AccountId,int? GroupId,int? PermistionId,int? OwnerById,string OwnerTable) : this()
        {
            _accountId = AccountId;
	 _groupId = GroupId;
			 _permistionId = PermistionId;
			 _ownerById = OwnerById;
			 _ownerTable = OwnerTable;
			
        }

        #endregion Constructors
        #region Properties

         public int? AccountId { get=> _accountId;}
	 public int? GroupId { get=> _groupId;}
			 public int? PermistionId { get=> _permistionId;}
			 public int? OwnerById { get=> _ownerById;}
			[MaxLength(128, ErrorMessage = nameof(ErrorCodeInsert.IErr128))]  public string OwnerTable { get=> _ownerTable;}
			

        #endregion Properties
        #region Behaviours

         public void SetAccountId(int? AccountId)
        { _accountId= !AccountId.HasValue? _accountId:AccountId;if (!IsValid()) throw new DomainException(_errorMessages);}
	 public void SetGroupId(int? GroupId)
        { _groupId= !GroupId.HasValue? _groupId:GroupId;if (!IsValid()) throw new DomainException(_errorMessages);}
			 public void SetPermistionId(int? PermistionId)
        { _permistionId= !PermistionId.HasValue? _permistionId:PermistionId;if (!IsValid()) throw new DomainException(_errorMessages);}
			 public void SetOwnerById(int? OwnerById)
        { _ownerById= !OwnerById.HasValue? _ownerById:OwnerById;if (!IsValid()) throw new DomainException(_errorMessages);}
			 public void SetOwnerTable(string OwnerTable)
        { _ownerTable= OwnerTable == null? _ownerTable:OwnerTable;if (!IsValid()) throw new DomainException(_errorMessages);}
			
       
        public sealed override bool IsValid()
        {
            return base.IsValid();
        }
        #endregion Behaviours
    }
}
