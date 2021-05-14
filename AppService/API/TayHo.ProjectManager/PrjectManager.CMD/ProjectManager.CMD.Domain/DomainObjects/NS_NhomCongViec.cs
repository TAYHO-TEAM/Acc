using ProjectManager.CMD.Domain.DomainObjects.BaseClasses;
using Services.Common.DomainObjects.Exceptions;
using System.ComponentModel.DataAnnotations;


namespace ProjectManager.CMD.Domain.DomainObjects
{
    public class NS_NhomCongViec : DOBase
    {
        #region Fields

        private int? _hangMucId;
	private int? _loaiCongViecId;
			private int? _goiThauId;
			private int? _nhomChiPhiId;
			private int? _projectId;
			private string _tenNhomCongViec;
			private string _dienGiai;
			private int? _sortIndex;
			

        #endregion Fields
        #region Constructors

        private NS_NhomCongViec()
        {
        }

        public NS_NhomCongViec(int? HangMucId,int? LoaiCongViecId,int? GoiThauId,int? NhomChiPhiId,int? ProjectId,string TenNhomCongViec,string DienGiai,int? SortIndex) : this()
        {
            _hangMucId = HangMucId;
	 _loaiCongViecId = LoaiCongViecId;
			 _goiThauId = GoiThauId;
			 _nhomChiPhiId = NhomChiPhiId;
			 _projectId = ProjectId;
			 _tenNhomCongViec = TenNhomCongViec;
			 _dienGiai = DienGiai;
			 _sortIndex = SortIndex;
			
        }

        #endregion Constructors
        #region Properties

         public int? HangMucId { get=> _hangMucId;}
	 public int? LoaiCongViecId { get=> _loaiCongViecId;}
			 public int? GoiThauId { get=> _goiThauId;}
			 public int? NhomChiPhiId { get=> _nhomChiPhiId;}
			 public int? ProjectId { get=> _projectId;}
			[MaxLength(500, ErrorMessage = nameof(ErrorCodeInsert.IErr500))]  public string TenNhomCongViec { get=> _tenNhomCongViec;}
			 public string DienGiai { get=> _dienGiai;}
			 public int? SortIndex { get=> _sortIndex;}
			

        #endregion Properties
        #region Behaviours

         public void SetHangMucId(int? HangMucId)
        { _hangMucId= !HangMucId.HasValue? _hangMucId:HangMucId;if (!IsValid()) throw new DomainException(_errorMessages);}
	 public void SetLoaiCongViecId(int? LoaiCongViecId)
        { _loaiCongViecId= !LoaiCongViecId.HasValue? _loaiCongViecId:LoaiCongViecId;if (!IsValid()) throw new DomainException(_errorMessages);}
			 public void SetGoiThauId(int? GoiThauId)
        { _goiThauId= !GoiThauId.HasValue? _goiThauId:GoiThauId;if (!IsValid()) throw new DomainException(_errorMessages);}
			 public void SetNhomChiPhiId(int? NhomChiPhiId)
        { _nhomChiPhiId= !NhomChiPhiId.HasValue? _nhomChiPhiId:NhomChiPhiId;if (!IsValid()) throw new DomainException(_errorMessages);}
			 public void SetProjectId(int? ProjectId)
        { _projectId= !ProjectId.HasValue? _projectId:ProjectId;if (!IsValid()) throw new DomainException(_errorMessages);}
			 public void SetTenNhomCongViec(string TenNhomCongViec)
        { _tenNhomCongViec= TenNhomCongViec == null? _tenNhomCongViec:TenNhomCongViec;if (!IsValid()) throw new DomainException(_errorMessages);}
			 public void SetDienGiai(string DienGiai)
        { _dienGiai= DienGiai == null? _dienGiai:DienGiai;if (!IsValid()) throw new DomainException(_errorMessages);}
			 public void SetSortIndex(int? SortIndex)
        { _sortIndex= !SortIndex.HasValue? _sortIndex:SortIndex;if (!IsValid()) throw new DomainException(_errorMessages);}
			
       
        public sealed override bool IsValid()
        {
            return base.IsValid();
        }
        #endregion Behaviours
    }
}
