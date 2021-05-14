using ProjectManager.CMD.Domain.DomainObjects.BaseClasses;
using Services.Common.DomainObjects.Exceptions;
using System.ComponentModel.DataAnnotations;


namespace ProjectManager.CMD.Domain.DomainObjects
{
    public class NS_LoaiCongViec : DOBase
    {
        #region Fields

        private string _tenLoaiCongViec;
	private string _dienGiai;
			private string _kyHieu;
			private int? _projectId;
			private int? _sortIndex;
			

        #endregion Fields
        #region Constructors

        private NS_LoaiCongViec()
        {
        }

        public NS_LoaiCongViec(string TenLoaiCongViec,string DienGiai,string KyHieu,int? ProjectId,int? SortIndex) : this()
        {
            _tenLoaiCongViec = TenLoaiCongViec;
	 _dienGiai = DienGiai;
			 _kyHieu = KyHieu;
			 _projectId = ProjectId;
			 _sortIndex = SortIndex;
			
        }

        #endregion Constructors
        #region Properties

        [MaxLength(500, ErrorMessage = nameof(ErrorCodeInsert.IErr500))]  public string TenLoaiCongViec { get=> _tenLoaiCongViec;}
	[MaxLength(500, ErrorMessage = nameof(ErrorCodeInsert.IErr500))]  public string DienGiai { get=> _dienGiai;}
			[MaxLength(50, ErrorMessage = nameof(ErrorCodeInsert.IErr50))]  public string KyHieu { get=> _kyHieu;}
			 public int? ProjectId { get=> _projectId;}
			 public int? SortIndex { get=> _sortIndex;}
			

        #endregion Properties
        #region Behaviours

         public void SetTenLoaiCongViec(string TenLoaiCongViec)
        { _tenLoaiCongViec= TenLoaiCongViec == null? _tenLoaiCongViec:TenLoaiCongViec;if (!IsValid()) throw new DomainException(_errorMessages);}
	 public void SetDienGiai(string DienGiai)
        { _dienGiai= DienGiai == null? _dienGiai:DienGiai;if (!IsValid()) throw new DomainException(_errorMessages);}
			 public void SetKyHieu(string KyHieu)
        { _kyHieu= KyHieu == null? _kyHieu:KyHieu;if (!IsValid()) throw new DomainException(_errorMessages);}
			 public void SetProjectId(int? ProjectId)
        { _projectId= !ProjectId.HasValue? _projectId:ProjectId;if (!IsValid()) throw new DomainException(_errorMessages);}
			 public void SetSortIndex(int? SortIndex)
        { _sortIndex= !SortIndex.HasValue? _sortIndex:SortIndex;if (!IsValid()) throw new DomainException(_errorMessages);}
			
       
        public sealed override bool IsValid()
        {
            return base.IsValid();
        }
        #endregion Behaviours
    }
}
