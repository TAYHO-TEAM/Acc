using ProjectManager.CMD.Domain.DomainObjects.BaseClasses;
using Services.Common.DomainObjects.Exceptions;
using System.ComponentModel.DataAnnotations;


namespace ProjectManager.CMD.Domain.DomainObjects
{
    public class PlanReport : DOBase
    {
        #region Fields

        private int? _planMasterId;
	private int? _planJobId;
			private string _content;
			private string _unit;
			private int? _amount;
			

        #endregion Fields
        #region Constructors

        private PlanReport()
        {
        }

        public PlanReport(int? PlanMasterId,int? PlanJobId,string Content,string Unit,int? Amount) : this()
        {
            _planMasterId = PlanMasterId;
	 _planJobId = PlanJobId;
			 _content = Content;
			 _unit = Unit;
			 _amount = Amount;
			
        }

        #endregion Constructors
        #region Properties

         public int? PlanMasterId { get=> _planMasterId;}
	 public int? PlanJobId { get=> _planJobId;}
			 public string Content { get=> _content;}
			[MaxLength(64, ErrorMessage = nameof(ErrorCodeInsert.IErr64))]  public string Unit { get=> _unit;}
			 public int? Amount { get=> _amount;}
			

        #endregion Properties
        #region Behaviours

         public void SetPlanMasterId(int? PlanMasterId)
        { _planMasterId= !PlanMasterId.HasValue? _planMasterId:PlanMasterId;if (!IsValid()) throw new DomainException(_errorMessages);}
	 public void SetPlanJobId(int? PlanJobId)
        { _planJobId= !PlanJobId.HasValue? _planJobId:PlanJobId;if (!IsValid()) throw new DomainException(_errorMessages);}
			 public void SetContent(string Content)
        { _content= Content == null? _content:Content;if (!IsValid()) throw new DomainException(_errorMessages);}
			 public void SetUnit(string Unit)
        { _unit= Unit == null? _unit:Unit;if (!IsValid()) throw new DomainException(_errorMessages);}
			 public void SetAmount(int? Amount)
        { _amount= !Amount.HasValue? _amount:Amount;if (!IsValid()) throw new DomainException(_errorMessages);}
			
       
        public sealed override bool IsValid()
        {
            return base.IsValid();
        }
        #endregion Behaviours
    }
}
