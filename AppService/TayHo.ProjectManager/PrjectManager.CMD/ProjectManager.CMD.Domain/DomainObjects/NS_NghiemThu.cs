using ProjectManager.CMD.Domain.DomainObjects.BaseClasses;
using Services.Common.DomainObjects.Exceptions;
using System.ComponentModel.DataAnnotations;


namespace ProjectManager.CMD.Domain.DomainObjects
{
    public class NS_NghiemThu : DOBase
    {
        #region Fields
        private int? _congViecDetailId;
        private int? _goiThauId;
        private int? _giaiDoanId;
        private int? _dot;
        private double? _khoiLuong;
        #endregion Fields

        #region Constructors
        private NS_NghiemThu()
        {
        }

        public NS_NghiemThu(int? CongViecDetailId,
int? GoiThauId,
int? GiaiDoanId,
int? Dot,
double? KhoiLuong) : this()
        {
            _congViecDetailId = CongViecDetailId;
            _goiThauId = GoiThauId;
            _giaiDoanId = GiaiDoanId;
            _dot = Dot;
            _khoiLuong = KhoiLuong;
        }
        #endregion Constructors

        #region Properties
        public int? CongViecDetailId { get => _congViecDetailId; }
        public int? GoiThauId { get => _goiThauId; }
        public int? GiaiDoanId { get => _giaiDoanId; }
        public int? Dot { get => _dot; }
        public double? KhoiLuong { get => _khoiLuong; }
        #endregion

        #region Behaviours
        public void SetCongViecDetailId(int? CongViecDetailId) { _congViecDetailId = !CongViecDetailId.HasValue ? _congViecDetailId : CongViecDetailId; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetGoiThauId(int? GoiThauId) { _goiThauId = !GoiThauId.HasValue ? _goiThauId : GoiThauId; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetGiaiDoanId(int? GiaiDoanId) { _giaiDoanId = !GiaiDoanId.HasValue ? _giaiDoanId : GiaiDoanId; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetDot(int? Dot) { _dot = !Dot.HasValue ? _dot : Dot; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetKhoiLuong(double? KhoiLuong) { _khoiLuong = !KhoiLuong.HasValue ? _khoiLuong : KhoiLuong; if (!IsValid()) throw new DomainException(_errorMessages); }
        public sealed override bool IsValid()
        {
            return base.IsValid();
        }
        #endregion Behaviours
    }
}
