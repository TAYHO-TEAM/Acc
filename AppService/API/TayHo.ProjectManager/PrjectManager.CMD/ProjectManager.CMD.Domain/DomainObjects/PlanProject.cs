using ProjectManager.CMD.Domain.DomainObjects.BaseClasses;
using Services.Common.DomainObjects.Exceptions;
using System.ComponentModel.DataAnnotations;


namespace ProjectManager.CMD.Domain.DomainObjects
{
    public class PlanProject : DOBase
    {
        #region Fields

        private string _title;
	private string _description;
			private int? _priority;
			private int? _projectId;
			

        #endregion Fields
        #region Constructors

        private PlanProject()
        {
        }

        public PlanProject(string Title,string Description,int? Priority,int? ProjectId) : this()
        {
            _title = Title;
	 _description = Description;
			 _priority = Priority;
			 _projectId = ProjectId;
			
        }

        #endregion Constructors
        #region Properties

        [MaxLength(256, ErrorMessage = nameof(ErrorCodeInsert.IErr256))]  public string Title { get=> _title;}
	 public string Description { get=> _description;}
			 public int? Priority { get=> _priority;}
			 public int? ProjectId { get=> _projectId;}
			

        #endregion Properties
        #region Behaviours

         public void SetTitle(string Title)
        { _title= Title == null? _title:Title;if (!IsValid()) throw new DomainException(_errorMessages);}
	 public void SetDescription(string Description)
        { _description= Description == null? _description:Description;if (!IsValid()) throw new DomainException(_errorMessages);}
			 public void SetPriority(int? Priority)
        { _priority= !Priority.HasValue? _priority:Priority;if (!IsValid()) throw new DomainException(_errorMessages);}
			 public void SetProjectId(int? ProjectId)
        { _projectId= !ProjectId.HasValue? _projectId:ProjectId;if (!IsValid()) throw new DomainException(_errorMessages);}
			
       
        public sealed override bool IsValid()
        {
            return base.IsValid();
        }
        #endregion Behaviours
    }
}
