using ProjectManager.CMD.Domain.DomainObjects.BaseClasses;
using Services.Common.DomainObjects.Exceptions;
using System.ComponentModel.DataAnnotations;


namespace ProjectManager.CMD.Domain.DomainObjects
{
    public class CustomFormAccount : DOBase
    {
        #region Fields

        private int? _customFormId;
	private int? _accountId;
			private int? _groupId;
			

        #endregion Fields
        #region Constructors

        private CustomFormAccount()
        {
        }

        public CustomFormAccount(int? CustomFormId,int? AccountId,int? GroupId) : this()
        {
            _customFormId = CustomFormId;
	 _accountId = AccountId;
			 _groupId = GroupId;
			
        }

        #endregion Constructors
        #region Properties

         public int? CustomFormId { get=> _customFormId;}
	 public int? AccountId { get=> _accountId;}
			 public int? GroupId { get=> _groupId;}
			

        #endregion Properties
        #region Behaviours

         public void SetCustomFormId(int? CustomFormId)
        { _customFormId= !CustomFormId.HasValue? _customFormId:CustomFormId;if (!IsValid()) throw new DomainException(_errorMessages);}
	 public void SetAccountId(int? AccountId)
        { _accountId= !AccountId.HasValue? _accountId:AccountId;if (!IsValid()) throw new DomainException(_errorMessages);}
			 public void SetGroupId(int? GroupId)
        { _groupId= !GroupId.HasValue? _groupId:GroupId;if (!IsValid()) throw new DomainException(_errorMessages);}
			
       
        public sealed override bool IsValid()
        {
            return base.IsValid();
        }
        #endregion Behaviours
    }
}
