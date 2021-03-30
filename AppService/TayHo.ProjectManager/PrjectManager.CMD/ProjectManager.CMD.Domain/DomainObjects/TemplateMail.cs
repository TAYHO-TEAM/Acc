using ProjectManager.CMD.Domain.DomainObjects.BaseClasses;
using Services.Common.DomainObjects.Exceptions;
using System.ComponentModel.DataAnnotations;


namespace ProjectManager.CMD.Domain.DomainObjects
{
    public class TemplateMail : DOBase
    {
        #region Fields

        private string _title;
	private string _bodyContent;
			private bool? _isBodyHtml;
			

        #endregion Fields
        #region Constructors

        private TemplateMail()
        {
        }

        public TemplateMail(string Title,string BodyContent,bool? IsBodyHtml) : this()
        {
            _title = Title;
	 _bodyContent = BodyContent;
			 _isBodyHtml = IsBodyHtml;
			
        }

        #endregion Constructors
        #region Properties

        [MaxLength(256, ErrorMessage = nameof(ErrorCodeInsert.IErr256))]  public string Title { get=> _title;}
	 public string BodyContent { get=> _bodyContent;}
			 public bool? IsBodyHtml { get=> _isBodyHtml;}
			

        #endregion Properties
        #region Behaviours

         public void SetTitle(string Title)
        { _title= Title == null? _title:Title;if (!IsValid()) throw new DomainException(_errorMessages);}
	 public void SetBodyContent(string BodyContent)
        { _bodyContent= BodyContent == null? _bodyContent:BodyContent;if (!IsValid()) throw new DomainException(_errorMessages);}
			 public void SetIsBodyHtml(bool? IsBodyHtml)
        { _isBodyHtml= !IsBodyHtml.HasValue? _isBodyHtml:IsBodyHtml;if (!IsValid()) throw new DomainException(_errorMessages);}
			
       
        public sealed override bool IsValid()
        {
            return base.IsValid();
        }
        #endregion Behaviours
    }
}
