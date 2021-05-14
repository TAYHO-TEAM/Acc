using ProjectManager.CMD.Domain.DomainObjects.BaseClasses;
using Services.Common.DomainObjects.Exceptions;
using System.ComponentModel.DataAnnotations;
using System;

namespace ProjectManager.CMD.Domain.DomainObjects
{
    public class NS_GoiThau : DOBase
    {
        #region Fields
        private int? _parentId;
        private int? _projectId;
        private string _soHopDong;
        private int? _contractorInfoId;
        private DateTime? _ngayKy;
        private string _dienGiai;
        private short? _thoiGianBaoHanh;
        private short? _thoiGianGiuBaoHanh;
        private double? _tyLeTamUng;
        private double? _tyLeGiuLai;
        private double? _tyLeThanhToanToiDa;
        private decimal? _giaTri;
        #endregion Fields

        #region Constructors
        private NS_GoiThau()
        {
        }

        public NS_GoiThau(
            int? ParentId,
            int? ProjectId,
            string SoHopDong,
            int? ContractorInfoId,
            DateTime? NgayKy,
            string DienGiai,
            short? ThoiGianBaoHanh,
            short? ThoiGianGiuBaoHanh,
            double? TyLeTamUng,
            double? TyLeGiuLai,
            double? TyLeThanhToanToiDa,
            decimal? GiaTri) : this()
        {
            _parentId = ParentId;
            _projectId = ProjectId;
            _soHopDong = SoHopDong;
            _contractorInfoId = ContractorInfoId;
            _ngayKy = NgayKy;
            _dienGiai = DienGiai;
            _thoiGianBaoHanh = ThoiGianBaoHanh;
            _thoiGianGiuBaoHanh = ThoiGianGiuBaoHanh;
            _tyLeTamUng = TyLeTamUng;
            _tyLeGiuLai = TyLeGiuLai;
            _tyLeThanhToanToiDa = TyLeThanhToanToiDa;
            _giaTri = GiaTri;
        }
        #endregion Constructors

        #region Properties
        public int? ParentId { get => _parentId; }
        public int? ProjectId { get => _projectId; }
        [MaxLength(50, ErrorMessage = nameof(ErrorCodeInsert.IErr50))] public string SoHopDong { get => _soHopDong; }
        public int? ContractorInfoId { get => _contractorInfoId; }
        public DateTime? NgayKy { get => _ngayKy; }
        public string DienGiai { get => _dienGiai; }
        public short? ThoiGianBaoHanh { get => _thoiGianBaoHanh; }
        public short? ThoiGianGiuBaoHanh { get => _thoiGianGiuBaoHanh; }
        public double? TyLeTamUng { get => _tyLeTamUng; }
        public double? TyLeGiuLai { get => _tyLeGiuLai; }
        public double? TyLeThanhToanToiDa { get => _tyLeThanhToanToiDa; }
        public decimal? GiaTri { get => _giaTri; }
        #endregion Properties

        #region Behaviours
        public void SetParentId(int? ParentId) { _parentId = !ParentId.HasValue ? _parentId : ParentId; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetProjectId(int? ProjectId) { _projectId = !ProjectId.HasValue ? _projectId : ProjectId; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetSoHopDong(string SoHopDong) { _soHopDong = SoHopDong == null ? _soHopDong : SoHopDong; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetContractorInfoId(int? ContractorInfoId) { _contractorInfoId = !ContractorInfoId.HasValue ? _contractorInfoId : ContractorInfoId; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetNgayKy(DateTime? NgayKy) { _ngayKy = !NgayKy.HasValue ? _ngayKy : NgayKy; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetDienGiai(string DienGiai) { _dienGiai = DienGiai == null ? _dienGiai : DienGiai; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetThoiGianBaoHanh(short? ThoiGianBaoHanh) { _thoiGianBaoHanh = !ThoiGianBaoHanh.HasValue ? _thoiGianBaoHanh : ThoiGianBaoHanh; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetThoiGianGiuBaoHanh(short? ThoiGianGiuBaoHanh) { _thoiGianGiuBaoHanh = !ThoiGianGiuBaoHanh.HasValue ? _thoiGianGiuBaoHanh : ThoiGianGiuBaoHanh; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetTyLeTamUng(double? TyLeTamUng) { _tyLeTamUng = !TyLeTamUng.HasValue ? _tyLeTamUng : TyLeTamUng; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetTyLeGiuLai(double? TyLeGiuLai) { _tyLeGiuLai = !TyLeGiuLai.HasValue ? _tyLeGiuLai : TyLeGiuLai; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetTyLeThanhToanToiDa(double? TyLeThanhToanToiDa) { _tyLeThanhToanToiDa = !TyLeThanhToanToiDa.HasValue ? _tyLeThanhToanToiDa : TyLeThanhToanToiDa; if (!IsValid()) throw new DomainException(_errorMessages); }
        public void SetGiaTri(decimal? GiaTri) { _giaTri = !GiaTri.HasValue ? _giaTri : GiaTri; if (!IsValid()) throw new DomainException(_errorMessages); }
        public sealed override bool IsValid()
        {
            return base.IsValid();
        }
        #endregion Behaviours
    }
}
