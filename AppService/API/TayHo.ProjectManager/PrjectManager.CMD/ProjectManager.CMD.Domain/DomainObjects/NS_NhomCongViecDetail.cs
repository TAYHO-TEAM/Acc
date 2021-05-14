using ProjectManager.CMD.Domain.DomainObjects.BaseClasses;
using Services.Common.DomainObjects.Exceptions;
using System.ComponentModel.DataAnnotations;


namespace ProjectManager.CMD.Domain.DomainObjects
{
    public class NS_NhomCongViecDetail : DOBase
    {
        #region Fields

        private int? _nhomCongViecId;
	private int? _giaiDoanId;
			private decimal? _giaTri;
			private int? _sortIndex;
			

        #endregion Fields
        #region Constructors

        private NS_NhomCongViecDetail()
        {
        }

        public NS_NhomCongViecDetail(int? NhomCongViecId,int? GiaiDoanId,decimal? GiaTri,int? SortIndex) : this()
        {
            _nhomCongViecId = NhomCongViecId;
	 _giaiDoanId = GiaiDoanId;
			 _giaTri = GiaTri;
			 _sortIndex = SortIndex;
			
        }

        #endregion Constructors
        #region Properties

         public int? NhomCongViecId { get=> _nhomCongViecId;}
	 public int? GiaiDoanId { get=> _giaiDoanId;}
			 public decimal? GiaTri { get=> _giaTri;}
			 public int? SortIndex { get=> _sortIndex;}
			

        #endregion Properties
        #region Behaviours

         public void SetNhomCongViecId(int? NhomCongViecId)
        { _nhomCongViecId= !NhomCongViecId.HasValue? _nhomCongViecId:NhomCongViecId;if (!IsValid()) throw new DomainException(_errorMessages);}
	 public void SetGiaiDoanId(int? GiaiDoanId)
        { _giaiDoanId= !GiaiDoanId.HasValue? _giaiDoanId:GiaiDoanId;if (!IsValid()) throw new DomainException(_errorMessages);}
			 public void SetGiaTri(decimal? GiaTri)
        { _giaTri= !GiaTri.HasValue? _giaTri:GiaTri;if (!IsValid()) throw new DomainException(_errorMessages);}
			 public void SetSortIndex(int? SortIndex)
        { _sortIndex= !SortIndex.HasValue? _sortIndex:SortIndex;if (!IsValid()) throw new DomainException(_errorMessages);}
			
       
        public sealed override bool IsValid()
        {
            return base.IsValid();
        }
        #endregion Behaviours
    }
}
